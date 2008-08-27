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
        InstallDMS insll = new InstallDMS();

        public Login()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.txtSysAdmin.Text = "administrator";
            this.txtSysPassword.Text = "";
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            insll.SysName = this.txtSysAdmin.Text;
            insll.SysPwd = this.txtSysPassword.Text;

            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
            Application.Exit();
        }
    }
}