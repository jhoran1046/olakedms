using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using System.Drawing;

namespace install
{
    public partial class InstallDMS : Form
    {
        String _sysName;

        public String SysName
        {
            get { return _sysName; }
            set { _sysName = value; }
        }
        String _sysPwd;

        public String SysPwd
        {
            get { return _sysPwd; }
            set { _sysPwd = value; }
        }

        Complete complete = new Complete();

        public InstallDMS()
        {
            InitializeComponent();
        }

        private void InstallDMS_Load(object sender, EventArgs e)
        {
            this.lblErrorMsg.BackColor = Color.Silver;

            Login login = new Login();
            login.FormClosed += new FormClosedEventHandler(login_FormClosed);
            login.DialogResult = DialogResult.OK;
            int i = 0;
            if(i == 0)
            {
                login.ShowDialog();
                i++;
            }

            this.txtServer.Text = complete.ServerName;
            this.txtUserId.Text = complete.UserId;
            this.txtPassword.Text = complete.Password;
            this.txtPath.Text = complete.Path;
            this.txtOrgName.Text = complete.OrgName;
        }

        void login_FormClosed(object sender, FormClosedEventArgs e)
        {
            
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (txtServer.Text == "" || txtUserId.Text == "" || txtPassword.Text == "" || txtInitialCatalog.Text == "" || txtPath.Text == "" || txtOrgName.Text == "")
            {
                lblErrorMsg.BackColor = Color.Red;
                lblErrorMsg.Text = "您有未填写的项目！";
                return;
            }

            complete.SystemAdmin = _sysName;
            complete.SystemPwd = _sysPwd;

            complete.ServerName = txtServer.Text;
            complete.UserId = txtUserId.Text;
            complete.Password = txtPassword.Text;
            complete.InitialCatalog = txtInitialCatalog.Text;
            complete.OrgName = txtOrgName.Text;
            string pt = txtPath.Text;
            if (pt[2].ToString() == "/")
            {
                lblErrorMsg.BackColor = Color.Red;
                lblErrorMsg.Text = "文件路径格式不正确！";
                return;
            }
            else if (pt[pt.Length - 1].ToString() != "\\")
            {
                pt += "\\";
            }
            complete.Path = pt;

            complete.ShowDialog();
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult result;
            result = MessageBox.Show("您确定要取消DMS的安装吗？", "文档管理系统", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (result == DialogResult.Yes)
            {
                this.Close();
                Application.Exit();
            }
        }
    }
}