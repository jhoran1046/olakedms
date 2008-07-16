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
    public partial class SortApplyForm : Form
    {
        public int _docId;

        public SortApplyForm()
        {
            InitializeComponent();
        }

        private void SortApplyForm_Load(object sender, EventArgs e)
        {
            txtInitialise(_docId);
        }

        private void btnSubmission_Click(object sender, EventArgs e)
        {
            string comment = txtComment.Text.Trim();

            CSortApplyInfoEntity appInfo = new CSortApplyInfoEntity();
            try
            {
                if(txtDocId.Text == "")
                {
                    MessageBox.Show("归档目录不能为空！", "文档管理系统", MessageBoxButtons.OK);
                    return;
                }
               /* else if(txtComment.Text == "")
                {
                    MessageBox.Show("请填写归档申请理由！", "文档管理系统", MessageBoxButtons.OK);
                    return;
                } */
                else
                {
                    string applyer = Context.Session["CurrentUser"].ToString();
                    appInfo.App_DocId = _docId;
                    appInfo.App_Applyer = applyer;
                    appInfo.App_Comment = comment;
                    appInfo.Insert();
                    MessageBox.Show("提交申请成功，请等待管理员审核！", "文档管理系统", MessageBoxButtons.OK);
                    
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("提交失败！" + ex.Message, "文档管理系统", MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        //初始化页面：显示归档目录
        void txtInitialise(int docId)
        {
            List<CResourceEntity> resList = new List<CResourceEntity>();
            CResourceEntity cres = new CResourceEntity();
            resList = cres.GetObjectList("this.Res_Id='" + docId + "'");
            txtDocId.Text = resList[0].Res_Name;
        }
    }
}