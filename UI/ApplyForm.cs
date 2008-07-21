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

namespace UI
{
    public partial class ApplyForm : Form
    {
        private int _resId;

        public int ResId
        {
            get { return _resId; }
            set { _resId = value; }
        }

        public ApplyForm()
        {
            InitializeComponent();
        }

        private void SortApplyForm_Load(object sender, EventArgs e)
        {
            CResourceEntity aRes = new CResourceEntity();
            aRes = aRes.Load(_resId);
            txtResId.Text=aRes.MakeFullPath();          
        }

        private void btnSubmission_Click(object sender, EventArgs e)
        {
            if(txtComment.Text == "")
            {
                MessageBox.Show("����дע�⣡", "�ĵ�����ϵͳ", MessageBoxButtons.OK);
            }
            else
            {
                CUserEntity user = new CUserEntity();
                user.CreateApply(ResId, txtComment.Text.Trim());
                MessageBox.Show("��������鵵", "�ĵ�����ϵͳ", MessageBoxButtons.OK);
            }
        }
        //��ȡ���򷵻���ҳ
        private void btnCancel_Click(object sender, EventArgs e)
        {
            MainForm mainForm = new MainForm();
            mainForm.Show();
            this.Close();
        }
    }
}