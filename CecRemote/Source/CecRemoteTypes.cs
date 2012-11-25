// This file is part of CECRemote.
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
using System.Text;

namespace CecRemote
{
    

    public static class Defaults
    {
        public const ushort HDMI_PORT = 1;
        public const bool FAST_SCROLLING = false;
        public const bool FILTER_SHORT_PULSES = false;
        public const bool INACTIVE_SOURCE = true;
        public const bool POWER_OFF = false;

        // Static default delay times in milliseconds
        public const ushort KEY_DOWN_DELAY = 700;
        public const ushort KEY_START_DELAY = 260;
        public const ushort KEY_STOP_DELAY = 250;
        public const ushort REPEAT_DELAY = 55;
        public const ushort KEY_FILTER_DELAY = 300;
        public const ushort CONNECT_DELAY = 10000;
       
        
        public const int LOG_LEVEL = 0;

        public const string DEVICE_TYPE = "PlaybackDevice";
        public const int CONNECTED_TO = 0; // TV
        public const string CONFIG = "MediaPortal.xml";

    }
}
