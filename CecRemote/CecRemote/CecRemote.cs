 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Collections.ObjectModel;
using MediaPortal.GUI.Library;
using MediaPortal.Dialogs;
using MediaPortal.Utils;
using MediaPortal.Util;
using MediaPortal.Configuration;
using MediaPortal.Common.Utils;
using MediaPortal.InputDevices;
using MediaPortal.Profile;
using Microsoft.Win32;

namespace CecRemote
{
    public class CecRemote : ISetupForm, IPlugin
    {
        #region members
        private int keyDownDelay;
        private int startDelay;
        private int stopDelay;
        private int hdmiPort;
        private bool fastScrolling;

        private CecSharp.CecDeviceType type;
        private StopWatch m_keyDownTimer;
        private CecClient client;
        private InputHandler remoteHandler;
        private Thread repeatCommand;
        private volatile bool keyDown;
        private volatile bool scrolling;
        private int currentKey;
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
            return "Springfield, Tuomas";
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
            return -1;
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

        // With GetID it will be an window-plugin / otherwise a process-plugin
        // Enter the id number here again


        #endregion

        public void Start()
        {

            currentKey = -1;
            keyDown = false;
            int logLevel = 0;

            //Subscribe to PowerModeChanged events.
            SystemEvents.PowerModeChanged += new PowerModeChangedEventHandler(SystemEvents_PowerModeChanged);

            using (MediaPortal.Profile.Settings reader = new MediaPortal.Profile.Settings(Config.GetFile(Config.Dir.Config, "MediaPortal.xml")))
            {
                hdmiPort = reader.GetValueAsInt("CecRemote", "HDMIPort", Defaults.HDMI_PORT);
                startDelay = reader.GetValueAsInt("CecRemote", "StartDelay", Defaults.KEY_START_DELAY);
                stopDelay = reader.GetValueAsInt("CecRemote", "StopDelay", Defaults.KEY_STOP_DELAY);
                keyDownDelay = reader.GetValueAsInt("CecRemote", "KeyDownDelay", Defaults.KEY_DOWN_DELAY);
                fastScrolling = reader.GetValueAsBool("CecRemote", "FastScrolling", Defaults.FAST_SCROLLING);
                type = (CecSharp.CecDeviceType)Enum.Parse(typeof(CecSharp.CecDeviceType), (reader.GetValueAsString("CecRemote", "Type", Defaults.DEVICE_TYPE)), true);
                logLevel = reader.GetValueAsInt("general", "loglevel", 0);
            }

            CecSharp.CecLogLevel level;

            switch ((MediaPortal.Services.Level)logLevel)
            {
                /*
                case MediaPortal.Services.Level.Error:
                    level = CecSharp.CecLogLevel.Error;
                    break;
                case MediaPortal.Services.Level.Warning:
                    level = CecSharp.CecLogLevel.Warning;
                    break;
                case MediaPortal.Services.Level.Information:
                    level = CecSharp.CecLogLevel.Notice;
                    break;
                */
                case MediaPortal.Services.Level.Debug:
                    level = CecSharp.CecLogLevel.Debug;
                    break;
                default:
                    level = CecSharp.CecLogLevel.None;
                    break;
            }

            Log.Info("CecRemote: LibCec log level set to: " + level.ToString());


            client = new CecClient("MediaPortal", type, level);

            client.CecRemoteKeyEvent += new CecRemoteKeyEventHandler(oCecRemote_CecRemoteKeyEvent);
            client.CecRemoteLogEvent += new CecRemoteLogEventHandler(oCecRemote_CecRemoteLogEvent);
            client.CecRemoteCommandEvent += new CecRemoteCommandEventHandler(oCecRemote_CecRemoteCommandEvent);

            if (client.Connect(Defaults.CONNECT_DELAY))
            {
                remoteHandler = new InputHandler("CecRemote");
                m_keyDownTimer = new StopWatch();
                client.setHdmiPort(0, hdmiPort);

                Log.Info("CecRemote: Client connected!");

            }
            else
            {
                Log.Error("CecRemote: Could not connect to CEC-Adapter, check configuration!");
            }

        }


        public void Stop()
        {
            Log.Info("CecRemote: Closing connection to client...");
            
            if(client)
            {
            
              client.Close();
              client = null;
            
            }
            else
            {
               Log.Info("CecRemote: Client already disconnected!");
            }
            
            Log.Info("CecRemote: Client closed.");

             if(repeatCommand.IsAlive)
             {
                  repeatCommand.Abort();
             }
             repeatCommand = null;
           
            
          Log.Info("CecRemote: Plugin exit.");
          
        }

        private void oCecRemote_CecRemoteKeyEvent(object sender, CecRemoteEventArgs e)
        {
            if (fastScrolling)
            {

                if (e.Key.Duration == 0 && currentKey != (int)e.Key.Keycode)
                {
                    remoteHandler.MapAction((int)e.Key.Keycode);
                    currentKey = (int)e.Key.Keycode;
                    return;
                }
                else if (e.Key.Duration == 0 && currentKey == (int)e.Key.Keycode)
                {

                    if (keyDown == true && scrolling == false)
                    {
                        scrolling = true;
                        m_keyDownTimer.StartZero();
                        repeatCommand = new Thread(new ThreadStart(repeatKey));
                        repeatCommand.Start();
                    }
                    else if (keyDown == true && scrolling == true)
                    {
                        m_keyDownTimer.StartZero();
                    }
                }
            }
            else
            {
                if (e.Key.Duration == 0)
                {
                    remoteHandler.MapAction((int)e.Key.Keycode);
                    return;
                }
            }
        }

        private void oCecRemote_CecRemoteLogEvent(object sender, CecRemoteEventArgs e)
        {
            Log.Debug("CecRemote: Message from LibCec: " + e.Message.Message + e.Message.Level.ToString());
        }

        private void oCecRemote_CecRemoteCommandEvent(object sender, CecRemoteEventArgs e)
        {
            if (e.Command.Opcode == CecSharp.CecOpcode.UserControlPressed)
            {
                keyDown = true;
            }
            else if (e.Command.Opcode == CecSharp.CecOpcode.UserControlRelease)
            {
                keyDown = false;
                scrolling = false;
                currentKey = -1;
            }

        }


        private void repeatKey()
        {
            while (keyDown && m_keyDownTimer.ElapsedMilliseconds < keyDownDelay)
            {
                remoteHandler.MapAction(currentKey);
                Thread.Sleep(Defaults.REPEAT_DELAY);
            }

            m_keyDownTimer.Stop();
            //keyDown = false;
        }

        //Detect Sleep/Hibernate and resuming events and connect/disconnect CEC-client
        void SystemEvents_PowerModeChanged(object sender, PowerModeChangedEventArgs e)
        {
            //If user puts computer to sleep
            if (e.Mode == PowerModes.Suspend)
            {
                Log.Debug("CecRemote: System going to sleep, stoppping CEC-client...");
                Stop(); //Disconnect
            }
            else if (e.Mode == PowerModes.Resume)
            {

                Start(); //Connect again when resuming from sleep
            }

        }


    }
}
