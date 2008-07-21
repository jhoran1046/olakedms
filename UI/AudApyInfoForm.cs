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
    public partial class AudApyInfoForm : Form
    {
        public CUserEntity _user;

        public AudApyInfoForm()
        {
            InitializeComponent();
        }

        private void ManageAppForm_Load(object sender, EventArgs e)
        {
            LoadOrgApp();//加载ListView
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {

        }

        private void btnRefuse_Click(object sender, EventArgs e)
        {
            this._user = new CUserEntity();
            _user = (CUserEntity)Context.Session["CurrentUser"];

            foreach(ListViewItem item in lsvOrgApply.Items)
            {
                if(item.Selected == true)
                {
                    int id = (int)item.Tag;
                    _user.CancelApply(id);
                    MessageBox.Show("您已拒绝了" + _user.Usr_Name + "用户的归档申请！", "文档管理系统", MessageBoxButtons.OK);
                }
            }
        }
      
        private void chkAllSelect_Click(object sender, EventArgs e)
        {
            if(chkAllSelect.Checked == true)
            {
                foreach(ListViewItem item in lsvOrgApply.Items)
                {
                    lsvOrgApply.MultiSelect = true;
                    item.Selected = true;
                    lsvOrgApply.Invalidate();
                }
            }
            else
            {
                foreach(ListViewItem item in lsvOrgApply.Items)
                {
                    item.Selected = false;
                    lsvOrgApply.Invalidate();
                }
            }
        }

        private void LoadOrgApp()
        {
            this._user = new CUserEntity();
            _user = (CUserEntity)Context.Session["CurrentUser"];

            List<CApplyInfoEntity> OrgAppList = new List<CApplyInfoEntity>();
            OrgAppList = _user.ListOrganizeApplies();
            if(OrgAppList.Count < 0)
            {
                lsvOrgApply.DataSource = null;
                return;
            }
            foreach(CApplyInfoEntity apply in OrgAppList)
            {
                ListViewItem lviName = new ListViewItem();
                ListViewItem.ListViewSubItem lvsiApplyer;
                ListViewItem.ListViewSubItem lvsiComment;
                ListViewItem.ListViewSubItem lvsiAudite;
                ListViewItem.ListViewSubItem lvsiCreTime;
                ListViewItem.ListViewSubItem lvsiAudTime;

                lviName.Text = apply.Res_Name;
                lviName.Tag = apply.App_Id;

                lvsiApplyer = new ListViewItem.ListViewSubItem();
                lvsiApplyer.Text = apply.Usr_Name;
                lviName.SubItems.Add(lvsiApplyer);

                lvsiComment = new ListViewItem.ListViewSubItem();
                lvsiComment.Text = apply.App_Comment;
                lviName.SubItems.Add(lvsiComment);

                lvsiAudite = new ListViewItem.ListViewSubItem();
                switch((int)apply.App_Audited)
                {
                    case 1: lvsiAudite.Text = "未审核";
                        break;
                    case 2: lvsiAudite.Text = "已批准";
                        break;
                    case 3: lvsiAudite.Text = "未批准";
                        break;
                }
                lviName.SubItems.Add(lvsiAudite);

                lvsiCreTime = new ListViewItem.ListViewSubItem();
                lvsiCreTime.Text = apply.App_CreateTime.ToString();
                lviName.SubItems.Add(lvsiCreTime);

                lvsiAudTime = new ListViewItem.ListViewSubItem();
                lvsiAudTime.Text = apply.App_AudTime.ToString();
                lviName.SubItems.Add(lvsiAudTime);

                lsvOrgApply.Items.Add(lviName);
            }
            lsvOrgApply.Invalidate();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            MainForm myMain = new MainForm();
            myMain.Show();
            this.Close();
        }
    }
}