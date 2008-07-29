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
using Gizmox.WebGUI.Common.Resources;

#endregion

namespace CommonUI
{
    public partial class GroupUsersForm : Form
    {
        CUserEntity _currentUser;
        public CUserEntity CurrentUser
        {
            get { return _currentUser; }
            set { _currentUser = value; }
        }

        int _groupId;
        public int GroupId
        {
            set { _groupId = value; }
        }

        public GroupUsersForm()
        {
            InitializeComponent();
        }

        private void FillUserLists()
        {
            try
            {
                CGroupEntity group = new CGroupEntity(_currentUser.ConnString).Load(_groupId);
                this.label1.Text = group.Grp_Name + "组用户";
                List<CUserEntity> groupUsers = group.ListUsers();
                List<CUserEntity> allUsers = _currentUser.ListAllUsers();
                groupUserList.Items.Clear();
                otherUserList.Items.Clear();

                foreach (CUserEntity user in groupUsers)
                {
                    ListViewItem lvi = new ListViewItem();

                    lvi.Text = user.Usr_Member + "[" + user.Usr_Name + "]";
                    lvi.SmallImage = new IconResourceHandle("personal.gif");
                    lvi.Tag = user;
                    groupUserList.Items.Add(lvi);
                }

                foreach (CUserEntity user in allUsers)
                {
                    bool other = true;
                    foreach (CUserEntity u in groupUsers)
                    {
                        if (user.Usr_Id == u.Usr_Id)
                        {
                            other = false;
                            break;
                        }
                    }

                    if (other)
                    {
                        ListViewItem lvi = new ListViewItem();

                        lvi.Text = user.Usr_Member + "[" + user.Usr_Name + "]";
                        lvi.SmallImage = new IconResourceHandle("personal.gif");
                        lvi.Tag = user;
                        otherUserList.Items.Add(lvi);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("修改用户组失败：" + ex.Message, "文档管理系统", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void GroupUsersForm_Load(object sender, EventArgs e)
        {
            FillUserLists();
        }

        private void OKBtn_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            this.Close();
        }

        private void AddBtn_Click(object sender, EventArgs e)
        {
            
            if (otherUserList.SelectedItems.Count == 0)
            {
                MessageBox.Show("至少选择一个用户！", "文档管理系统", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                foreach (ListViewItem lvi in otherUserList.SelectedItems)
                {
                    CUserEntity user = (CUserEntity)lvi.Tag;
                    _currentUser.AddUser2Group(_groupId, user.Usr_Id);
                }

                
            }
            catch (Exception ex)
            {
                MessageBox.Show("修改用户组失败：" + ex.Message, "文档管理系统", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            FillUserLists();
        }

        private void RemoveBtn_Click(object sender, EventArgs e)
        {
            if (groupUserList.SelectedItems.Count == 0)
            {
                MessageBox.Show("至少选择一个用户！", "文档管理系统", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                foreach (ListViewItem lvi in groupUserList.SelectedItems)
                {
                    CUserEntity user = (CUserEntity)lvi.Tag;
                    _currentUser.RemoveUserFromGroup(_groupId, user.Usr_Id);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("修改用户组失败：" + ex.Message, "文档管理系统", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            FillUserLists();
        }
    }
}