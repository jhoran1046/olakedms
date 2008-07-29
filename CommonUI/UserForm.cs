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
    public partial class UserForm : Form
    {
        private String _member="";
        private String _password="";
        private String _surepwd = "";
        private String _name="";
        private String _email = "";

        public UserForm()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            _member = memberBox.Text;
            _password = passwordBox.Text;
            _surepwd = txtSurePwd.Text;
            _name = nameBox.Text;
            _email = txtEmail.Text;

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
            passwordBox.Text = _password;
            txtSurePwd.Text = _surepwd;
            nameBox.Text = _name;
            txtEmail.Text = _email;
        }
    }
}