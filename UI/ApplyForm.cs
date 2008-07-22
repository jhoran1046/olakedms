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

        //�ύ������ɺ���ת��MyApplyFormҳ
        private void btnSubmission_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtComment.Text == "")
                {
                    MessageBox.Show("����дע�⣡", "�ĵ�����ϵͳ", MessageBoxButtons.OK);
                }
                else
                {
                    CUserEntity user = new CUserEntity();
                    user.CreateApply(ResId, txtComment.Text.Trim());
                    MessageBox.Show("�����ύ�ļ��鵵���룡", "�ĵ�����ϵͳ", MessageBoxButtons.OK);
                }
                //7��22���޸�
                MyApplyForm myApplyForm = new MyApplyForm();
                myApplyForm.Show();
                this.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show("ϵͳ����" + ex.Message, "�ĵ�����ϵͳ", MessageBoxButtons.OK, MessageBoxIcon.Error);
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