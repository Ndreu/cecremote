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
using System.Threading;
using MediaPortal.GUI.Library;
using MediaPortal.Dialogs;
using MediaPortal.InputDevices;
using CecRemote.Base;

namespace CecRemote
{
  public class CecRemoteClient : CecClientBase
  {
    private delegate bool ShowCustomYesNoDialogDelegate(string heading, string lines, string yesLabel, string noLabel, bool defaultYes);
       

    private InputHandler _remoteHandler;

    public CecRemoteClient()
    {
      _remoteHandler = new InputHandler("CecRemote");

      if (!_remoteHandler.IsLoaded)
      {
        Log.Error("CecRemote: Error loading mapping file - check configuration.");
      }

    }

    public override void DeInit()
    {
      base.DeInit();
      _remoteHandler = null;
    }

    protected override void KeyPress(int keycode)
    {
      if (!_remoteHandler.MapAction(keycode))
      {
        Log.Info("CecRemote: Received unmapped button with code: " + keycode.ToString());
      }
    }
  }

}