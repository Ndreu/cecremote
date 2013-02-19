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
using System.IO;
using System.Xml;
using System.Reflection;
using System.Windows.Forms;
using MediaPortal.GUI.Library;
using MediaPortal.Configuration;


namespace CecRemote
{

    [PluginIcons("CecRemote.Resources.cecremotelogo.png", "CecRemote.Resources.cecremotelogo_disabled.png")]
    public class CecRemote : ISetupForm, IPlugin, IPluginReceiver
    {

        #region wm_powerconstants

        private const int WM_POWERBROADCAST = 0x0218;
        const int PBT_APMSUSPEND = 0x0004;
        const int PBT_APMRESUMEAUTOMATIC = 0x0012;
        const int PBT_APMRESUMESUSPEND = 0x0007;
        #endregion

        #region members

        private CecRemoteClient _client;
        private CecConfig _config;
        private bool _sleep;
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
          _sleep = false;

          PrepareClient();

          _client.OnStart();
           

          // Try to subscribe to Extensions plugin update event.
          // This is potentially flaky if Extensions plugin is not loaded yet,
          // but windowplugins are loaded first, so it should work OK.

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
                        _sleep = true;
                        
                        Log.Info("CecRemote: PowerControl: System going to sleep, stoppping CEC-client...");
                        
                        if (_client != null)
                        {
                          _client.OnSleep();
                        }

                        break;

                    case PBT_APMRESUMESUSPEND:
                        Log.Info("CecRemote: PowerControl: User input detected after sleep (APMRESUMESUSPEND)");
                        if (_sleep)
                        {
                          _sleep = false;

                          // DeInitialize when resuming to make sure client is prepared properly.
                          _client.DeInit();
                          _client = null;
                          _config = null;

                          PrepareClient();
                        }

                        _client.OnResumeByUser();

                        break;

                    case PBT_APMRESUMEAUTOMATIC:
                        Log.Info("CecRemote: PowerControl: System resuming from sleep (APMRESUMEAUTOMATIC)");
                        if (_sleep)
                        {
                          _sleep = false;

                          _client.DeInit();
                          _client = null;
                          _config = null;

                          PrepareClient();
                        }

                        _client.OnResumeByAutomatic();
                    
                        break;

                    default:
                        break;
                }
            }

            return false; // false = allow other plugins to handle the message
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
              Log.Debug("CecRemote: Error while reading config. " + ex.ToString());
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
    }
}
