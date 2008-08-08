#region Using

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;

using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Forms;

using MidLayer;
using Framework.Util;

using Olake.WDS;
using MidLayer;

#endregion

namespace CommonUI
{
    public partial class MailUsrCrl : UserControl
    {
        CUserEntity _currentUser;

        public CUserEntity CurrentUser
        {
            get { return _currentUser; }
            set { _currentUser = value; }
        }

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
                txtUsrName.Visible = true;
                txtUsrPwd.Visible = true;
                txtSurePwd.Visible = true;
                btnOK.Visible = true;
                btnOK.Enabled = true;
                label5.Visible = true;
                label6.Visible = true;
                label7.Visible = true;
            }
            else
            {
                btnSave.Enabled = true;
                grpBoxValidate.Visible = false;
            }
        }

        private void MailUsrCrl_Load(object sender, EventArgs e)
        {
            COrganizeEntity org = new COrganizeEntity().Load(_currentUser.Usr_Organize);
            txtEmail.Text = org.Org_Mail;
            txtPassword.Text = "";
            txtSmtp.Text = org.Org_MailSmtp;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            COrganizeEntity org = new COrganizeEntity().Load(_currentUser.Usr_Organize);
            org.Org_Mail = txtEmail.Text.Trim();
            if(txtPassword.Text == "")
            {
                MessageBox.Show("密码不能为空！","文档管理系统", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            org.Org_MailPassword = txtPassword.Text;
            org.Org_MailSmtp = txtSmtp.Text;
            org.Org_SmtpNumber = Convert.ToInt32(txtNumber.Text);//端口号
            if(chkBoxSSL.Checked)
            {
                org.Org_MailSSL = (int)SSL.CHECKED;
            }
            else
            {
                org.Org_MailSSL = (int)SSL.UNCHECK;
            }
            org.Update();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            COrganizeEntity org = new COrganizeEntity().Load(_currentUser.Usr_Organize);
            org.Org_Mail = txtEmail.Text.Trim();
            org.Org_MailPassword = txtPassword.Text;
            org.Org_MailSmtp = txtSmtp.Text;
            org.Org_SmtpNumber = Convert.ToInt32(txtNumber.Text);//端口号
            if(chkBoxSSL.Checked)
            {
                org.Org_MailSSL = (int)SSL.CHECKED;
            }
            else
            {
                org.Org_MailSSL = (int)SSL.UNCHECK;
            }

            org.Org_SMTPUsrName = txtUsrName.Text;
            string pwd = txtUsrPwd.Text;
            if(pwd != txtSurePwd.Text)
            {
                MessageBox.Show("口令与确认口令不一致！","文档管理系统",MessageBoxButtons.OK,MessageBoxIcon.Stop);
                return;
            }
            org.Org_SMTPPassword = pwd;
            org.Update();
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