#region Using

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;

using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Forms;

#endregion

namespace CommonUI
{
    public partial class MailUsrCrl : UserControl
    {


        public MailUsrCrl()
        {
            InitializeComponent();
        }

        private void chkBoxUseValidate_Click(object sender, EventArgs e)
        {
            if(chkBoxUseValidate.Checked)
            {
                btnSave.Enabled = false;
                grpBoxValidate.Visible = true;
                btnOK.Enabled = true;
            }
            else
            {
                btnSave.Enabled = true;
                grpBoxValidate.Visible = false;
            }
        }

        private void MailUsrCrl_Load(object sender, EventArgs e)
        {

        }
    }
}