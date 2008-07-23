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
    public partial class ApplyForm : Form
    {
        private int _resId;
        private CUserEntity _CurrentUser;

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
            DialogResult result;

            try
            {
                if (txtComment.Text == "")
                {
                    MessageBox.Show("����дע�⣡", "�ĵ�����ϵͳ", MessageBoxButtons.OK);
                }
                else
                {
                    this._CurrentUser = new CUserEntity();
                    _CurrentUser = (CUserEntity)Context.Session["CurrentUser"];

                    bool CrAp = _CurrentUser.CreateApply(ResId, txtComment.Text.Trim());
                    if(CrAp == true)
                    {
                        result = MessageBox.Show("���ѳɹ��ύ�ļ��鵵���룡", "�ĵ�����ϵͳ", MessageBoxButtons.OK,MessageBoxIcon.Information);
                    }
                    else
                    {
                        result = MessageBox.Show("���ύ�Ĺ鵵�����Ѿ����ڣ�", "�ĵ�����ϵͳ", MessageBoxButtons.OK,MessageBoxIcon.Stop);
                    }
                    if(result == DialogResult.OK)
                        this.Close();
                }
                //7��22���޸�
              //  MyApplyForm myApplyForm = new MyApplyForm();
              //  myApplyForm.Show();
            }
            catch(Exception ex)
            {
                MessageBox.Show("�ύʧ�ܣ�" + ex.Message, "�ĵ�����ϵͳ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //��ȡ���򷵻���ҳ
        private void btnCancel_Click(object sender, EventArgs e)
        {
           // MainForm mainForm = new MainForm();
           // mainForm.Show();
            this.Close();
        }
    }
}