#region Using

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;

using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Forms;

using Olake.WDS;
using MidLayer;

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

        private void button1_Click(object sender, EventArgs e)
        {
            CSearchDAL searchEngine = new CSearchDAL();
            string rootPath = MidLayerSettings.AppPath;
            if (rootPath[rootPath.Length - 1] != '\\')
                rootPath += "\\";
            searchEngine.ReIndexFolder(rootPath);
            MessageBox.Show("成功重建索引!", "文档管理系统", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}