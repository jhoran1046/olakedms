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
                    MessageBox.Show("�鵵Ŀ¼����Ϊ�գ�", "�ĵ�����ϵͳ", MessageBoxButtons.OK);
                    return;
                }
               /* else if(txtComment.Text == "")
                {
                    MessageBox.Show("����д�鵵�������ɣ�", "�ĵ�����ϵͳ", MessageBoxButtons.OK);
                    return;
                } */
                else
                {
                    string applyer = Context.Session["CurrentUser"].ToString();
                    appInfo.App_DocId = _docId;
                    appInfo.App_Applyer = applyer;
                    appInfo.App_Comment = comment;
                    appInfo.Insert();
                    MessageBox.Show("�ύ����ɹ�����ȴ�����Ա��ˣ�", "�ĵ�����ϵͳ", MessageBoxButtons.OK);
                    
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("�ύʧ�ܣ�" + ex.Message, "�ĵ�����ϵͳ", MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        //��ʼ��ҳ�棺��ʾ�鵵Ŀ¼
        void txtInitialise(int docId)
        {
            List<CResourceEntity> resList = new List<CResourceEntity>();
            CResourceEntity cres = new CResourceEntity();
            resList = cres.GetObjectList("this.Res_Id='" + docId + "'");
            txtDocId.Text = resList[0].Res_Name;
        }
    }
}