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
using System.Windows.Forms;

namespace CecRemote
{
  public partial class AdvancedPower : Form
  {
    public bool RequireUser
    {
      get { return checkBoxRequireUser.Checked; }
      set { checkBoxRequireUser.Checked = value; }
    }

    public bool RequireActiveSource
    {
      get { return checkBoxRequireActiveSource.Checked; }
      set { checkBoxRequireActiveSource.Checked = value; }
    }

    public bool SendTvPower
    {
      get { return checkBoxSendTvPower.Checked; }
      set { checkBoxSendTvPower.Checked = value; }
    }

    public bool SendTvPowerAlways
    {
      get { return radioButtonAlways.Checked; }
      set { radioButtonAlways.Checked = value; }
    }

    public bool SendTvPowerOffOnlyIfActiveSource
    {
      get { return radioButtonOnlyIfMediaPortal.Checked; }
      set { radioButtonOnlyIfMediaPortal.Checked = value; }
    }


    public AdvancedPower()
    {
      InitializeComponent();

      radioButtonAlways.DataBindings.Add("Enabled", this.checkBoxSendTvPower, "Checked");
      radioButtonOnlyIfMediaPortal.DataBindings.Add("Enabled", this.checkBoxSendTvPower, "Checked");

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
