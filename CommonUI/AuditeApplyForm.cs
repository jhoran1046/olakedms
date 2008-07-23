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
using CommonUI;
#endregion

namespace CommonUI
{
    public partial class AuditeApplyForm : Form
    {
        public CUserEntity _currentUser;
        public FileList _applyFileLst = new FileList();
        private int _achiveResourceId;

        public int AchiveResourceId
        {
            get { return _achiveResourceId; }
            set { _achiveResourceId = value; }
        }

        public CUserEntity CurrentUser
        {
            get { return _currentUser; }
            set { _currentUser = value; }
        }

        public AuditeApplyForm()
        {
            InitializeComponent();
        }

        private void ManageAppForm_Load(object sender, EventArgs e)
        {
            LoadOrgApp();//加载ListView     
            LoadDirTree();//加载归档目标目录DirTree
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            this._currentUser = new CUserEntity();
            _currentUser = (CUserEntity)Context.Session["CurrentUser"];

            try
            {
                foreach (ListViewItem item in lsvOrgApply.Items)
                {
                    if (item.Selected == true)
                    {
                        if (AuditeDirTree.MainTreeView.SelectedNode == null) 
                        {
                            MessageBox.Show("请选择目标路径！", "文档管理系统", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                            return;
                        }
                        else
                        {
                            this._achiveResourceId = (int)AuditeDirTree.MainTreeView.SelectedNode.Tag;
                            _currentUser.PermitApply((int)item.Tag, _achiveResourceId);
                        }
                    }
                }
                MessageBox.Show("您选择的项目已批准", "文档管理系统", MessageBoxButtons.OK,MessageBoxIcon.Information);
                lsvOrgApply.Invalidate();
                AuditeDirTree.Invalidate();
            }
            catch(Exception ex)
            {
                MessageBox.Show("系统错误：" + ex.Message, "文档管理系统", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRefuse_Click(object sender, EventArgs e)
        {
            this._currentUser = new CUserEntity();
            _currentUser = (CUserEntity)Context.Session["CurrentUser"];

            try
            {
                foreach (ListViewItem item in lsvOrgApply.Items)
                {
                    if (item.Selected == true)
                    {
                        int applyId = (int)item.Tag;
                        _currentUser.CancelApply(applyId);
                        MessageBox.Show("您已拒绝了" + item.Text + "用户的归档申请！", "文档管理系统", MessageBoxButtons.OK,MessageBoxIcon.Information);
                    }
                }
                lsvOrgApply.Invalidate();
            }
            catch(Exception ex)
            {
                MessageBox.Show("审核失败：" + ex.Message, "文档管理系统", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            this._currentUser = new CUserEntity();
            _currentUser = (CUserEntity)Context.Session["CurrentUser"];

            try
            {
                List<CApplyInfoEntity> OrgAppList = new List<CApplyInfoEntity>();
                OrgAppList = _currentUser.ListOrganizeApplies();
                if (OrgAppList.Count < 0)
                {
                    lsvOrgApply.DataSource = null;
                    return;
                }
                foreach (CApplyInfoEntity apply in OrgAppList)
                {
                    ListViewItem lviName = new ListViewItem();
                    ListViewItem.ListViewSubItem lvsiApplyer;
                    ListViewItem.ListViewSubItem lvsiComment;
                    ListViewItem.ListViewSubItem lvsiAudite;
                    ListViewItem.ListViewSubItem lvsiCreTime;
                   // ListViewItem.ListViewSubItem lvsiAudTime;

                    lviName.Text = apply.Res_Name;
                    lviName.Tag = apply.App_Id;

                    lvsiApplyer = new ListViewItem.ListViewSubItem();
                    lvsiApplyer.Text = apply.Usr_Name;
                    lviName.SubItems.Add(lvsiApplyer);

                    lvsiComment = new ListViewItem.ListViewSubItem();
                    lvsiComment.Text = apply.App_Comment;
                    lviName.SubItems.Add(lvsiComment);

                    lvsiAudite = new ListViewItem.ListViewSubItem();
                    switch ((int)apply.App_Audited)
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

                      // lvsiAudTime = new ListViewItem.ListViewSubItem();
                      // lvsiAudTime.Text = apply.App_AudTime.ToString();
                      // lviName.SubItems.Add(lvsiAudTime);  

                    lsvOrgApply.Items.Add(lviName);
                }
                lsvOrgApply.Invalidate();
            }
            catch(Exception ex)
            {
                MessageBox.Show("加载归档申请列表失败：" + ex.Message, "文档管理系统", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        private void LoadDirTree()
        {
            _currentUser = (CUserEntity)Context.Session["CurrentUser"];
            _applyFileLst.CurrentUser = _currentUser;
            AuditeDirTree.CurrentUser = _currentUser;
            AuditeDirTree.RootResourceId = _currentUser.GetUserOrganize().Org_ArchiveRes;

            try
            {
                AuditeDirTree.RootDir = Context.Server.MapPath("~/app_data");
                AuditeDirTree.Init();
                AuditeDirTree.FileListUI = _applyFileLst;
            }
            catch (Exception ex)
            {
                MessageBox.Show("加载目录树失败：" + ex.Message, "文档管理系统", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
           // MainForm mainForm = new MainForm();
           // mainForm.Show();
            this.Close();
        }
    }
}