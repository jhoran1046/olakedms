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
        static int _countForm = 0;

        public static int CountForm
        {
            get { return Complete._countForm; }
            set { Complete._countForm = value; }
        }

        public Complete()
        {
            InitializeComponent();
        }

        private void Complete_Load(object sender, EventArgs e)
        {
            Install sec = new Install();
            if(Complete.CountForm == 1)
            {
                sec.ShowDialog();
            }
            if(sec.DialogResult == DialogResult.OK)
            {
                string text = "�ɹ���װ�ĵ�����ϵͳ!";
                text += "�뽫��İ�װĿ¼\\DMS\\install\\bin\\Debug\\Web1.config�ļ�����ΪWeb.config,���滻\\DMS\\UI\\Web.config�ļ���";
                lblSuccess.Text = text;
                sec.Close();
            }
        }

        private void btnComplete_Click(object sender, EventArgs e)
        {
            _countForm = 0;
            Application.Exit();
        }
    }
}