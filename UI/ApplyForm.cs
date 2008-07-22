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
                    CUserEntity user = new CUserEntity();
                    user.CreateApply(ResId, txtComment.Text.Trim());
                    MessageBox.Show("您已提交文件归档申请！", "文档管理系统", MessageBoxButtons.OK);
                }
                //7月22日修改
                MyApplyForm myApplyForm = new MyApplyForm();
                myApplyForm.Show();
                this.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show("系统错误：" + ex.Message, "文档管理系统", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //若取消则返回主页
        private void btnCancel_Click(object sender, EventArgs e)
        {
            MainForm mainForm = new MainForm();
            mainForm.Show();
            this.Close();
        }
    }
}