using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using MediaPortal.GUI.Library;
using MediaPortal.Dialogs;
using MediaPortal.Utils;
using MediaPortal.Configuration;
using MediaPortal.Common.Utils;
using MediaPortal.InputDevices;
using MediaPortal.Profile;
[assembly: CompatibleVersion("1.1.6.27644")]

namespace CecRemote
{
    public class CecRemote : ISetupForm, IPlugin
    {
        #region members
        private CecClient client;
        private Thread communicationThread;
        private InputHandler remoteHandler;
        private string[] buttons; 
        #endregion

        private enum RemoteButton
        {
            // Same as MCE buttons
            NumPad0 = 0,
            NumPad1 = 1,
            NumPad2 = 2,
            NumPad3 = 3,
            NumPad4 = 4,
            NumPad5 = 5,
            NumPad6 = 6,
            NumPad7 = 7,
            NumPad8 = 8,
            NumPad9 = 9,
            Clear = 10,
            Enter = 11,
            Power2 = 12,
            Start = 13,
            Mute = 14,
            Info = 15,
            VolumeUp = 16,
            VolumeDown = 17,
            ChannelUp = 18,
            ChannelDown = 19,
            Forward = 20,
            Rewind = 21,
            Play = 22,
            Record = 23,
            Pause = 24,
            Stop = 25,
            Skip = 26,
            Replay = 27,
            OemGate = 28,
            Oem8 = 29,
            Up = 30,
            Down = 31,
            Left = 32,
            Right = 33,
            Ok = 34,
            Back = 35,
            DVDMenu = 36,
            LiveTV = 37,
            Guide = 38,
            AspectRatio = 39, // FIC Spectra

            // Wifi Remote stuff
            Menu = 40,
            First = 41,
            Last = 42,
            Fullscreen = 43,
            Subtitles = 44,
            AudioTrack = 45,
            Screenshot = 46,
            // End of Wifi Remote stuff

            RecordedTV = 72,
            Print = 78, // Hewlett Packard MCE Edition
            Teletext = 90,
            Red = 91,
            Green = 92,
            Yellow = 93,
            Blue = 94,
            PowerTV = 101,
            Power1 = 165,

            Home = 800,
            BasicHome = 801,
            NowPlaying = 808,
            PlayDVD = 809,
            MyPlaylists = 810
        }

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
            return "springfield";
        }

        // show the setup dialog
        public void ShowPlugin()
        {
            SettingsForm settings = new SettingsForm();
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
            buttons = new string[12];
            string hdmiPort;
            using (MediaPortal.Profile.Settings reader = new MediaPortal.Profile.Settings(Config.GetFile(Config.Dir.Config, "MediaPortal.xml")))
            {
                hdmiPort = reader.GetValue("CecRemote", "HDMIPort");
                if (hdmiPort == "")
                {
                    return;
                }
                else
                {
                    buttons[0] = reader.GetValue("CecRemote", "enter");
                    buttons[1] = reader.GetValue("CecRemote", "up");
                    buttons[2] = reader.GetValue("CecRemote", "down");
                    buttons[3] = reader.GetValue("CecRemote", "left");
                    buttons[4] = reader.GetValue("CecRemote", "right");
                    buttons[5] = reader.GetValue("CecRemote", "home");
                    buttons[6] = reader.GetValue("CecRemote", "play");
                    buttons[7] = reader.GetValue("CecRemote", "stop");
                    buttons[8] = reader.GetValue("CecRemote", "pause");
                    buttons[9] = reader.GetValue("CecRemote", "rw");
                    buttons[10] = reader.GetValue("CecRemote", "fw");
                    buttons[11] = reader.GetValue("CecRemote", "back");
                }
                client = new CecClient();
                if (client.Connect(10000))
                {
                    remoteHandler = new InputHandler("CecRemote");
                    client.setHdmiPort(0, int.Parse(hdmiPort));
                    communicationThread = new Thread(new ThreadStart(doWork));
                    communicationThread.IsBackground = true;
                    communicationThread.Start();
                }
            }
        }

        public void Stop()
        {
            communicationThread.Abort();
            client.Close();
        }

        private void doWork()
        {
            while (true)
            {
                string command = client.getCommand();
                if (command != null)
                {
                    string[] temp = command.Split(';');
                    if (temp[1] != "0")
                    {
                        RemoteButton button;

                        if (temp[0] == buttons[0])
                            button = RemoteButton.Enter;
                        else if (temp[0] == buttons[1])
                            button = RemoteButton.Up;
                        else if (temp[0] == buttons[2])
                            button = RemoteButton.Down;
                        else if (temp[0] == buttons[3])
                            button = RemoteButton.Left;
                        else if (temp[0] == buttons[4])
                            button = RemoteButton.Right;
                        else if (temp[0] == buttons[5])
                            button = RemoteButton.Home;
                        else if (temp[0] == buttons[6])
                            button = RemoteButton.Play;
                        else if (temp[0] == buttons[7])
                            button = RemoteButton.Stop;
                        else if (temp[0] == buttons[8])
                            button = RemoteButton.Pause;
                        else if (temp[0] == buttons[9])
                            button = RemoteButton.Rewind;
                        else if (temp[0] == buttons[10])
                            button = RemoteButton.Forward;
                        else if (temp[0] == buttons[11])
                            button = RemoteButton.Back;
                        else
                            continue;

                        
                        if (GUIGraphicsContext.form.InvokeRequired)
                        {
                            InvokeButtonDelegate d = new InvokeButtonDelegate(InvokeButton);
                            GUIGraphicsContext.form.Invoke(d, new object[] { button });
                            continue;
                        }
                    }
                }
                Thread.Sleep(1);
            }
        }

        protected delegate void InvokeButtonDelegate(int button);

        protected void InvokeButton(int button)
        {
            remoteHandler.MapAction((int)button);
        }
    }
}
