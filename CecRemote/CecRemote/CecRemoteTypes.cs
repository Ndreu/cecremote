using System;
using System.Collections.Generic;
using System.Text;

namespace CecRemote
{
    // Static default delay times in milliseconds

    public static class Defaults
    {
        public const ushort HDMI_PORT = 1;
        public const bool FAST_SCROLLING = false;

        public const ushort KEY_DOWN_DELAY = 300;
        public const ushort KEY_START_DELAY = 260;
        public const ushort KEY_STOP_DELAY = 250;
        public const ushort REPEAT_DELAY = 60;

        public const ushort CONNECT_DELAY = 10000;

        public const string DEVICE_TYPE = "PlaybackDevice";
        public const string CONFIG = "MediaPortal.xml";

    }
}
