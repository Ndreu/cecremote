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
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace CecRemote
{
  public partial class SelectDevices : Form
  {
    public bool TV
    {
      get { return checkBoxTV.Checked; }
      set { checkBoxTV.Checked = value; }
    }

    public bool AudioSystem
    {
      get { return checkBoxAudioSystem.Checked; }
      set { checkBoxAudioSystem.Checked = value; }
    }

    public bool PlaybackDevice1
    {
      get { return checkBoxplaybackDevice1.Checked; }
      set { checkBoxplaybackDevice1.Checked = value; }
    }

    public bool PlaybackDevice2
    {
      get { return checkBoxPlaybackDevice2.Checked; }
      set { checkBoxPlaybackDevice2.Checked = value; }
    }

    public bool RecordingDevice1
    {
      get { return checkBoxRecordingDevice1.Checked; }
      set { checkBoxRecordingDevice1.Checked = value; }
    }

    public bool RecordingDevice2
    {
      get { return checkBoxRecordingDevice2.Checked; }
      set { checkBoxRecordingDevice2.Checked = value; }
    }

    public bool Tuner1
    {
      get { return checkBoxTuner1.Checked; }
      set { checkBoxTuner1.Checked = value; }
    }

    public bool Tuner2
    {
      get { return checkBoxTuner2.Checked; }
      set { checkBoxTuner2.Checked = value; }
    }

    public bool Broadcast
    {
      get { return checkBoxBroadcast.Checked; }
      set { checkBoxBroadcast.Checked = value; }
    }


    public SelectDevices()
    {
      InitializeComponent();
    }

    private void SelectDevices_Load(object sender, EventArgs e)
    {

    }

    private void buttonOK_Click(object sender, EventArgs e)
    {
      DialogResult = DialogResult.OK;
      Close();
    }

    private void buttonCancel_Click(object sender, EventArgs e)
    {
      DialogResult = DialogResult.Cancel;
      Close();
    }
  }
}
