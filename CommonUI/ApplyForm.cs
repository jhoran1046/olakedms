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

        //提交申请完成后，跳转到MyApplyForm页
        private void btnSubmission_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtComment.Text == "")
                {
                    MessageBox.Show("请填写注解！", "文档管理系统", MessageBoxButtons.OK);
                }
                else
                {
                    this._CurrentUser = new CUserEntity();
                    _CurrentUser = (CUserEntity)Context.Session["CurrentUser"];

                    bool CrAp = _CurrentUser.CreateApply(ResId, txtComment.Text.Trim());
                    if(CrAp == true)
                    {
                        MessageBox.Show("您已成功提交文件归档申请！", "文档管理系统", MessageBoxButtons.OK,MessageBoxIcon.Information,
                            new EventHandler(onMsgBoxClose));
                    }
                    else
                    {
                        MessageBox.Show("您提交的归档申请已经存在！", "文档管理系统", MessageBoxButtons.OK,MessageBoxIcon.Stop);
                    }
                }
                //7月22日修改
              //  MyApplyForm myApplyForm = new MyApplyForm();
              //  myApplyForm.Show();
            }
            catch(Exception ex)
            {
                MessageBox.Show("提交失败：" + ex.Message, "文档管理系统", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        protected void onMsgBoxClose(object sender,EventArgs e)
        {
            if(((Form)sender).DialogResult == DialogResult.OK)
            {
                MyApplyForm MyForm = new MyApplyForm();
                MyForm.Show();
                this.Close();
            }
        }

        //若取消则返回主页
        private void btnCancel_Click(object sender, EventArgs e)
        {
           // MainForm mainForm = new MainForm();
           // mainForm.Show();
            this.Close();
        }
    }
}