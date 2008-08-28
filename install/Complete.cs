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
                string text = "成功安装文档管理系统!";
                text += "请将你的安装目录\\DMS\\install\\bin\\Debug\\Web1.config文件改名为Web.config,并替换\\DMS\\UI\\Web.config文件。";
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