#region Using

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;

using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common.Interfaces;

using MidLayer;
#endregion

namespace UI
{
    public partial class LoginForm : Form
    {
        private CUserEntity _user = null;
        public CUserEntity User
        {
            get { return _user; }
        }

        public LoginForm()
        {
            InitializeComponent();
        }

        private void loginBtn_Click(object sender, EventArgs e)
        {
            if (memberBox.Text == "" || passwordBox.Text == "")
                return;

            try
            {
                _user = new CUserEntity(MidLayerSettings.ConnectionString);
                _user = _user.Login(memberBox.Text, passwordBox.Text);
                Context.Session["CurrentUser"] = _user;
                Context.Session.IsLoggedOn = true;

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("登录失败：" + ex.Message, "文档管理系统", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Context.Session.IsLoggedOn = false;
            }
        }
    }
}