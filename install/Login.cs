using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace install
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();

            btnOK.DialogResult = DialogResult.OK;
            btnCancel.DialogResult = DialogResult.Cancel;

            Complete.CountForm++;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.txtSysAdmin.Text = "administrator";
            this.txtSysPassword.Text = "";
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            Install.SystemAdmin = this.txtSysAdmin.Text;
            Install.SystemPwd = this.txtSysPassword.Text;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}