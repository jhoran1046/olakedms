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
    public partial class MyApplyUsrCrl : UserControl
    {
        CUserEntity _currentUser;
        AuditeAppUsrCrl auditApply = new AuditeAppUsrCrl();

        public CUserEntity CurrentUser
        {
            get { return _currentUser; }
            set { _currentUser = value; }
        }

        public MyApplyUsrCrl()
        {
            InitializeComponent();
        }

        public void MyApplyUsrCrl_Load(object sender, EventArgs e)
        {
            MyApplyLoad();
        }

        private void ckbAllSelected_Click(object sender, EventArgs e)
        {
            if(ckbAllSelected.Checked == true)
            {
                foreach(ListViewItem item in lsvMyApply.Items)
                {
                    lsvMyApply.MultiSelect = true;
                    item.Selected = true;
                    lsvMyApply.Invalidate();
                }
            }
            else
            {
                foreach(ListViewItem item in lsvMyApply.Items)
                {
                    lsvMyApply.MultiSelect = true;
                    item.Selected = true;
                    lsvMyApply.Invalidate();
                }
            }
        }

        private void btnDisfrock_Click(object sender, EventArgs e)
        {
            try
            {
                if (lsvMyApply.SelectedItems.Count > 0)//判断选中项目与否
                {
                    MessageBox.Show("您确定要撤销文件的归档申请吗？！", "文档管理系统", MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question, new EventHandler(OnMsgBoxClose));
                }
                else
                    MessageBox.Show("没有选中的目录！", "文档管理系统", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            catch (Exception ex)
            {
                MessageBox.Show("撤销失败：" + ex.Message, "文档管理系统");
            }
        }
        protected void OnMsgBoxClose(object sender, EventArgs e)
        {
            if (((Form)sender).DialogResult != DialogResult.Yes)
            {
                return;
            }

            int SelectedCount = lsvMyApply.SelectedItems.Count;
            bool DeleteApp = false;
            try
            {
                foreach (ListViewItem item in lsvMyApply.SelectedItems)
                {
                    DeleteApp = _currentUser.DeleteApply((int)item.Tag);
                    if (DeleteApp == false)
                    {
                        MessageBox.Show("系统错误！", "文档管理系统", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                    }
                }
                if (SelectedCount > 0)//若进行了撤销处理，则判断操作成功与否
                {
                    MyApplyLoad();
                    if (DeleteApp == false)
                    {
                        MessageBox.Show("您要撤销的申请已审核！", "文档管理系统", MessageBoxButtons.OK);
                    }

                    auditApply.CurrentUser = _currentUser;
                    auditApply.LoadOrgApp();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("系统错误:" + ex.Message, "文档管理系统", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void MyApplyLoad()
        {
            try
            {
                List<CApplyInfoEntity> myAppList = new List<CApplyInfoEntity>();
                myAppList = _currentUser.ListMyApplies();
                lsvMyApply.Items.Clear();
                foreach (CApplyInfoEntity apply in myAppList)
                {
                    ListViewItem lviName = new ListViewItem();
                    ListViewItem.ListViewSubItem lvsiApplyer;
                    ListViewItem.ListViewSubItem lvsiComment;
                    ListViewItem.ListViewSubItem lvsiAudite;
                    ListViewItem.ListViewSubItem lvsiCreTime;
                    //ListViewItem.ListViewSubItem lvsiAudTime;

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

                    lsvMyApply.Items.Add(lviName);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("系统错误:" + ex.Message, "文档管理系统", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}