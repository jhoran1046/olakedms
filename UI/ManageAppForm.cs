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
    public partial class ManageAppForm : Form
    {
        public ManageAppForm()
        {
            InitializeComponent();
        }

        private void ManageAppForm_Load(object sender, EventArgs e)
        {

        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            
        }

        private void btnRefuse_Click(object sender, EventArgs e)
        {
            string comment = txtComment.Text;
            CSortApplyInfoEntity reApp = new CSortApplyInfoEntity();

            reApp.Update();
        }

        private void lsvAppInfo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// 初始化界面
        /// </summary>
        private void initialese()
        {
            CResSorReQuEntity docName = new CResSorReQuEntity();
            List<CResSorReQuEntity> rsqList = new List<CResSorReQuEntity>();
            rsqList = docName.GetObjectList("this.Res_Id > ''");

            CSortApplyInfoEntity SortInfo = new CSortApplyInfoEntity();
            List<CSortApplyInfoEntity> infoList = new List<CSortApplyInfoEntity>();
            infoList = SortInfo.GetObjectList("this.App_Id > ''");

            lsvAppInfo.DataSource = rsqList[0].Res_Name;
            lsvAppInfo.DataSource = infoList[0].App_Applyer;
            lsvAppInfo.DataSource = infoList[0].App_Comment;
            lsvAppInfo.DataSource = infoList[0].App_Audited;
        }
    }
}