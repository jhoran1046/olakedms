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

#endregion

namespace CommonUI
{
    public partial class UserUpdate : UserControl
    {
        CUserEntity _currentUser;

        public CUserEntity CurrentUser
        {
            get { return _currentUser; }
            set { _currentUser = value; }
        }

        public UserUpdate()
        {
            InitializeComponent();
        }

        private void UserUpdate_Load(object sender, EventArgs e)
        {
            txtMember.Text = _currentUser.Usr_Member.ToString();
            txtPassword.Text = _currentUser.Usr_Password.ToString();
            txtSurePwd.Text = _currentUser.Usr_Password.ToString();
            txtName.Text = _currentUser.Usr_Name.ToString();
            txtEmail.Text = _currentUser.Usr_Email;
        }
        
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtPassword.Text.Trim() == "")
            {
                MessageBox.Show("密码不能为空！", "文档管理系统", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            if(txtSurePwd.Text.Trim() == "")
            {
                MessageBox.Show("确认密码不能为空！", "文档管理系统", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            try
            {
                _currentUser.Usr_Password = txtPassword.Text.Trim();
                _currentUser.Usr_Name = txtName.Text.Trim();
                _currentUser.Usr_Email = txtEmail.Text.Trim();
                _currentUser.Update();
                MessageBox.Show("修改成功！", "文档管理系统", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("系统错误:" + ex.Message, "文档管理系统", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            txtMember.Text = _currentUser.Usr_Member;
            txtPassword.Text = _currentUser.Usr_Password;
            txtSurePwd.Text = _currentUser.Usr_Password.ToString();
            txtName.Text = _currentUser.Usr_Name;
            txtEmail.Text = _currentUser.Usr_Email;
        }
    }
}