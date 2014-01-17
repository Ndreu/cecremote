// CECRemote
//
// Copyright (C) 2012-2013, CECRemote team
//
// CECRemote is free software: you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation, either version 2 of the License, or
// (at your option) any later version.
//
// CECRemote is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
//
// You should have received a copy of the GNU General Public License
// along with CECRemote. If not, see <http://www.gnu.org/licenses/>.

using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.IO;
using System.Xml;
using System.Reflection;
using System.Threading;
using System.Windows.Forms;
using MediaPortal.GUI.Library;
using MediaPortal.Configuration;


namespace CecRemote
{

    [PluginIcons("CecRemote.Resources.cecremotelogo.png", "CecRemote.Resources.cecremotelogo_disabled.png")]
    public class CecRemote : ISetupForm, IPlugin, IPluginReceiver
    {
        // Structure of PBT_POWERBROADCAST_SETTING (away mode detection)
        [StructLayout(LayoutKind.Sequential, Pack = 4)]
        internal struct POWERBROADCAST_SETTING
        {
            public Guid PowerSetting;
            public uint DataLength;
            public byte Data;
        }

        #region wm_powerconstants

        private const int WM_POWERBROADCAST = 0x0218;
        private const int PBT_APMSUSPEND = 0x0004;
        private const int PBT_APMRESUMEAUTOMATIC = 0x0012;
        private const int PBT_APMRESUMESUSPEND = 0x0007;
        private const int PBT_POWERSETTINGCHANGE = 0x8013;
        private static Guid GUID_SYSTEM_AWAYMODE = new Guid("98a7f580-01f7-48aa-9c0f-44352c29e5C0");
        #endregion

        #region members

        private CecRemoteClient _client;
        private CecConfig _config;
        private bool _sleep;
        private bool _away;
        private readonly string DefaultLanguage = "en-US";
        private readonly string Guid = "cb89aada-3b22-44e3-b5dc-f4fb02940f42";

        #endregion


        #region ISetupForm Members

        // Returns the name of the plugin which is shown in the plugin menu
        public string PluginName()
        {
            return "CecRemote";
        }

        // Returns the description of the plugin is shown in the plugin menu
        public string Description()
        {
            return "CecRemote";
        }

        // Returns the author of the plugin which is shown in the plugin menu
        public string Author()
        {
            return "Tuomaa, Springfield, libcec by Pulse-Eight";
        }

        // show the setup dialog
        public void ShowPlugin()
        {
          
            CecSettings settings = new CecSettings();
            settings.StartPosition = FormStartPosition.CenterParent;
            settings.ShowDialog();
           
        }

        // Indicates whether plugin can be enabled/disabled
        public bool CanEnable()
        {
            return true;
        }

        // Get Windows-ID
        public int GetWindowId()
        {
          // WindowID of windowplugin belonging to this setup
          // enter your own unique code
          return 50001;
        }

        // Indicates if plugin is enabled by default;
        public bool DefaultEnabled()
        {
            return true;
        }

        // indicates if a plugin has it's own setup screen
        public bool HasSetup()
        {
            return true;
        }

        /// <summary>
        /// If the plugin should have it's own button on the main menu of MediaPortal then it
        /// should return true to this method, otherwise if it should not be on home
        /// it should return false
        /// </summary>
        /// <param name="strButtonText">text the button should have</param>
        /// <param name="strButtonImage">image for the button, or empty for default</param>
        /// <param name="strButtonImageFocus">image for the button, or empty for default</param>
        /// <param name="strPictureImage">subpicture for the button or empty for none</param>
        /// <returns>true : plugin needs it's own button on home
        /// false : plugin does not need it's own button on home</returns>

        public bool GetHome(out string strButtonText, out string strButtonImage,
          out string strButtonImageFocus, out string strPictureImage)
        {
            strButtonText = String.Empty;
            strButtonImage = String.Empty;
            strButtonImageFocus = String.Empty;
            strPictureImage = String.Empty;
            return false;
        }

        #endregion

        public void Start()
        {
            Log.Info("CeCRemote: Version 0.9.3");

          _sleep = false;
          _away = false;

          PrepareClient();

          Thread starterThread = new Thread(new ThreadStart(_client.OnStart));
          starterThread.Name = "CECMain";
          starterThread.Start();
           

          // Try to subscribe to Extensions plugin update event.

          try
          {
            var extensions = GUIWindowManager.GetWindow(803);  // Extensions ID is 803
            EventInfo evt = extensions.GetType().GetEvent("OnSettingsChanged");
            MethodInfo handler = this.GetType().GetMethod("MPEI_OnConfigurationChanged");
            Delegate del = Delegate.CreateDelegate(evt.EventHandlerType, this, handler);

            evt.AddEventHandler(extensions, del);

            LoadTranslations();
          }
          catch
          {
            Log.Debug("CecRemote: Error while subscribing to extensions update event, extensions plugin probably not installed.");
          }

          if (_config.ControlVolume)
          {
              // Receive MP action messages
              GUIWindowManager.OnNewAction += new OnActionHandler(GUIWindowManager_OnNewAction);
          }

        }


        public void Stop()
        {
            Log.Info("CecRemote: Closing connection to client...");

            if (_client == null)
            {
              Log.Info("CecRemote: Client already closed. Plugin exit.");
              return;
            }

            _client.OnStop();

            _client = null;
            _config = null;

            Log.Info("CecRemote: Plugin exit.");

        }

        public bool WndProc(ref Message msg)
        {
            if (msg.Msg == WM_POWERBROADCAST)
            {

                switch (msg.WParam.ToInt32())
                {
                    case PBT_APMSUSPEND:

                        if (!_sleep)
                        {
                            _sleep = true;

                            Log.Info("CecRemote: PowerControl: System going to sleep, stopping CEC-client...");

                            if (_client != null)
                            {
                                _client.OnSleep();
                            }
                        }
                        else
                        {
                            Log.Warn("CecRemote: PowerControl: Received PBT_APMSUSPEND when remote state already suspended");
                        }

                        break;

                    case PBT_APMRESUMESUSPEND:
                        
                        Log.Info("CecRemote: PowerControl: User input detected after sleep (APMRESUMESUSPEND)");
                        HandleResume(false);

                        break;

                    case PBT_APMRESUMEAUTOMATIC:
                        
                        Log.Info("CecRemote: PowerControl: System resuming from sleep (APMRESUMEAUTOMATIC)");
                        HandleResume(true);
                    
                        break;
                  
                      // Handle awaymode
                     case PBT_POWERSETTINGCHANGE:

                        POWERBROADCAST_SETTING ps = (POWERBROADCAST_SETTING)Marshal.PtrToStructure(msg.LParam, typeof(POWERBROADCAST_SETTING));

                        if (ps.PowerSetting == GUID_SYSTEM_AWAYMODE)
                        {
                            if (ps.Data == 0)
                            {
                                if (_away && !_sleep)
                                {
                                    _away = false;
                                    Log.Info("CecRemote: PowerControl: System exiting away mode");
                                    HandleResume(false);
                                }
                                else
                                {
                                    Log.Warn("CecRemote: PowerControl: Received GUID_SYSTEM_AWAYMODE 0 and sleepmode is {0} and awaymode is {1}", _sleep.ToString(), _away.ToString());
                                }
                            }
                            else
                            {
                                if (!_away)
                                {
                                    _away = true;
                                    Log.Info("CecRemote: PowerControl: System entering away mode");

                                    if (_client != null)
                                    {
                                        _client.OnAwayMode();
                                    }
                                }
                                else
                                {
                                    Log.Warn("CecRemote: PowerControl: Received GUID_SYSTEM_AWAYMODE 1 and awaymode is {0}", _away.ToString());
                                }
                            }
                        }

                        break;


                    default:
                        break;
                }
            }

            return false; // false = allow other plugins to handle the message
        }

        private void HandleResume(bool automatic)
        {
            if (_sleep)
            {
                _sleep = false;
                _away = false;

                // DeInitialize when resuming to make sure client is prepared properly.
                if (_client != null)
                {
                    _client.DeInit();
                    _client = null;
                }
            }

            if (_client == null)
            {
                _config = null;

                PrepareClient();
            }

            if (automatic)
            {
                Thread resumeThread = new Thread(new ThreadStart(_client.OnResumeByAutomatic));
                resumeThread.Name = "CECResA";
                resumeThread.Start();
            }
            else
            {
                Thread resumeThread = new Thread(new ThreadStart(_client.OnResumeByUser));
                resumeThread.Name = "CECResU";
                resumeThread.Start();
            }
        }

        private void PrepareClient()
        {
          if (_client == null)
          {
            _client = new CecRemoteClient();
          }
          if (_config == null)
          {
            _config = new CecConfig();
            
            try
            {
              _config.ReadConfig();
              _client.SetConfig(_config);
            }
            catch (Exception ex)
            {
              Log.Error("CecRemote: Error while reading config. " + ex.ToString());
              // Defaults will be used automatically if config reading fails, so we can still try to connect.
            }
          }
        }

        public void MPEI_OnConfigurationChanged(string guid)
        {
          // Check if message is for us
          if (guid == this.Guid)
          {
            Log.Debug("CecRemote: Settings changed from Extensions plugin, updating configuration.");

            _config = null;
            PrepareClient();

            _client.LoadConfig();
          }
        }

        private void LoadTranslations()
        {
          Log.Debug("CecRemote: Loading translated strings for MPEI settings.");

          string lang = "";

          try
          {
            lang = GUILocalizeStrings.GetCultureName(GUILocalizeStrings.CurrentLanguage());
          }
          catch (Exception)
          {
            Log.Debug("CecRemote: Unable to detect current language. Using English.");
            lang = this.DefaultLanguage;
          }

          Log.Debug("CecRemote: MPEI settings language set to " + lang);

          XmlDocument xmlTranslation = new XmlDocument();

          for (short i = 0; i < 2; ++i)
          {
            try
            {
              string path = Path.Combine(Config.GetSubFolder(Config.Dir.Language, "CecRemote"), lang + ".xml");
              xmlTranslation.Load(path);
            }
            catch
            {
              Log.Debug("CecRemote: Could not open translation file for langueage: {0}. Loading default language: {1}", lang, DefaultLanguage);
              lang = this.DefaultLanguage;
              continue;
            }
            break;
          }

          foreach (XmlNode node in xmlTranslation.DocumentElement.ChildNodes)
          {
            if (node.NodeType == XmlNodeType.Element)
            {
              try
              {
                GUIPropertyManager.SetProperty("#CecRemote.Translation." + node.Attributes.GetNamedItem("name").Value + ".Label", node.InnerText);
              }
              catch (Exception ex)
              {
                Log.Error("CecRemote: Error while loading translations. Translation string missing or invalid. " + ex.Message);
              }
            }
          }

        }

        void GUIWindowManager_OnNewAction(MediaPortal.GUI.Library.Action action)
        {
          switch (action.wID)
          {
            case MediaPortal.GUI.Library.Action.ActionType.ACTION_VOLUME_UP:
              _client.VolumeUp();
              MediaPortal.Player.VolumeHandler.Instance.Volume = MediaPortal.Player.VolumeHandler.Instance.Maximum;
              break;
            case MediaPortal.GUI.Library.Action.ActionType.ACTION_VOLUME_DOWN:
              _client.VolumeDown();
              MediaPortal.Player.VolumeHandler.Instance.Volume = MediaPortal.Player.VolumeHandler.Instance.Maximum;
              break;
            case MediaPortal.GUI.Library.Action.ActionType.ACTION_VOLUME_MUTE:
              _client.VolumeMute();
              MediaPortal.Player.VolumeHandler.Instance.IsMuted = false;
              break;
            default:
              break;
          }
        }

    }
}
