using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace install
{
    public partial class Complete : Form
    {
        public Complete()
        {
            InitializeComponent();
        }

        private void Complete_Load(object sender, EventArgs e)
        {
            Install frm = new Install();
            frm.ShowDialog();

            if(frm.DialogResult == DialogResult.OK)
            {
                string text = "�ɹ���װ�ĵ�����ϵͳ!";
                text += "�뽫��İ�װĿ¼\\DMS\\install\\bin\\Debug\\Web1.config�ļ�����ΪWeb.config,���滻\\DMS\\UI\\Web.config�ļ���";
                lblSuccess.Text = text;
                frm.Close();
            }
        }

        private void btnComplete_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}