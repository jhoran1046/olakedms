#region Using

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;

using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Forms;
using System.Security.Cryptography;
using MidLayer;

#endregion

namespace CommonUI
{
    public partial class UserForm : Form
    {
        private String _member="";
        private String _password="";
        private String _surepwd = "";
        private String _name="";
        private String _email = "";
        private Int32 _userType = -1;

        public Int32 UserType
        {
            get { return _userType; }
            set { _userType = value; }
        }

        public UserForm()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            _member = memberBox.Text;
            if(passwordBox.Text == "" || txtSurePwd.Text == "")
            {
                MessageBox.Show("���벻��Ϊ�գ�", "�ĵ�����ϵͳ", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            _password = passwordBox.Text;
            _surepwd = txtSurePwd.Text;
            _name = nameBox.Text;
            _email = txtEmail.Text;
            if(ckbAdmin.Checked == true)
            {
                _userType = (int)USERTYPE.ORGANIZEADMIN;
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        public String Member
        {
            get { return _member; }
            set { _member = value; }
        }

        public String Password
        {
            get { return _password; }
            set { _password = value; }
        }

        public String UserName
        {
            get { return _name; }
            set { _name = value; }
        }

        public String Email
        {
            get { return _email; }
            set { _email = value; }
        }

        public String Surepwd
        {
            get { return _surepwd; }
            set { _surepwd = value; }
        }

        private void UserForm_Load(object sender, EventArgs e)
        {
            memberBox.Text = _member;
            passwordBox.Text = "";
            txtSurePwd.Text = "";
            nameBox.Text = _name;
            txtEmail.Text = _email;
        }
    }
}