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
    public partial class GroupList : UserControl
    {
        CUserEntity _currentUser;

        public CUserEntity CurrentUser
        {
            get { return _currentUser; }
            set { _currentUser = value; }
        }

        public GroupList()
        {
            InitializeComponent();
            CreateContextMenu();
        }

        public void LoadGroups()
        {
            groupListView.Items.Clear();
            List<CGroupEntity> groups = _currentUser.ListGroups();
            foreach (CGroupEntity group in groups)
            {
                ListViewItem lvi = new ListViewItem();

                lvi.Text = group.Grp_Name;
                lvi.Tag = group.Grp_Id;
                groupListView.Items.Add(lvi);
            }
        }

        private void CreateContextMenu()
        {
            MenuItem MenuItem1 = new Gizmox.WebGUI.Forms.MenuItem();
            MenuItem MenuItem2 = new Gizmox.WebGUI.Forms.MenuItem();
            MenuItem MenuItem3 = new Gizmox.WebGUI.Forms.MenuItem();
            MenuItem MenuItem4 = new Gizmox.WebGUI.Forms.MenuItem();


            MenuItem1.Text = "创建用户组";
            MenuItem1.Click += new System.EventHandler(this.menuCreateGroup_Click);
            groupContextMenu.MenuItems.Add(MenuItem1);

            MenuItem2.Text = "删除用户组";
            MenuItem2.Click += new System.EventHandler(this.menuDeleteGroup_Click);
            groupContextMenu.MenuItems.Add(MenuItem2);

            MenuItem3.Text = "修改用户组";
            MenuItem3.Click += new System.EventHandler(this.menuModifyGroup_Click);
            groupContextMenu.MenuItems.Add(MenuItem3);

            MenuItem4.Text = "组用户设置";
            MenuItem4.Click += new System.EventHandler(this.menuGroupUsers_Click);
            groupContextMenu.MenuItems.Add(MenuItem4);
        }


        private void GroupList_Load(object sender, EventArgs e)
        {
            LoadGroups();
        }

        private void menuGroupUsers_Click(object sender, EventArgs e)
        {
            if (groupListView.SelectedItems.Count != 1)
            {
                MessageBox.Show("必须选择一个用户组！", "文档管理系统", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                GroupUsersForm form = new GroupUsersForm();
                form.CurrentUser = _currentUser;
                form.GroupId = (int)groupListView.SelectedItems[0].Tag;
                form.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show("修改用户组失败：" + ex.Message, "文档管理系统", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void menuCreateGroup_Click(object sender, EventArgs e)
        {
            NameForm nameForm = new NameForm();
            nameForm.Closed += new EventHandler(AddGroup_Closed);
            nameForm.ShowDialog();
        }

        private void AddGroup_Closed(object sender, EventArgs e)
        {
            NameForm nameForm = (NameForm)sender;
            if (nameForm.DialogResult != DialogResult.OK)
                return;

            try
            {
                CGroupEntity newGroup = new CGroupEntity(_currentUser.ConnString);
                newGroup.Grp_Name = nameForm.NewName;
                newGroup.Grp_Organize = _currentUser.Usr_Organize;
                _currentUser.CreateGroup(newGroup);
                LoadGroups();
            }
            catch (Exception ex)
            {
                MessageBox.Show("创建用户失败：" + ex.Message, "文档管理系统", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void menuDeleteGroup_Click(object sender, EventArgs e)
        {
            MessageBox.Show("确定要删除用户组吗？", "文档管理系统", MessageBoxButtons.YesNo,
                MessageBoxIcon.Question, new EventHandler(DeleteGroup_Closed));
        }

        private void DeleteGroup_Closed(object sender, EventArgs e)
        {
            if (((Form)sender).DialogResult != DialogResult.Yes)
            {
                return;
            }

            try
            {
                foreach (ListViewItem item in groupListView.SelectedItems)
                {
                    _currentUser.DeleteGroup((int)item.Tag);
                }
                LoadGroups();
            }
            catch (Exception ex)
            {
                MessageBox.Show("删除用户组失败：" + ex.Message, "文档管理系统", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void menuModifyGroup_Click(object sender, EventArgs e)
        {
            if (groupListView.SelectedItems.Count != 1)
            {
                MessageBox.Show("必须选择一个用户组！", "文档管理系统", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                CGroupEntity group = new CGroupEntity(_currentUser.ConnString).Load((int)groupListView.SelectedItems[0].Tag);
                NameForm nameForm = new NameForm();
                nameForm.OldName = group.Grp_Name;
                nameForm.Closed += new EventHandler(ModifyGroup_Closed);
                nameForm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show("修改用户组失败：" + ex.Message, "文档管理系统", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ModifyGroup_Closed(object sender, EventArgs e)
        {
            NameForm nameForm = (NameForm)sender;
            if (nameForm.DialogResult != DialogResult.OK)
                return;

            try
            {
                CGroupEntity group = new CGroupEntity(_currentUser.ConnString).Load((int)groupListView.SelectedItems[0].Tag);
                group.Grp_Name = nameForm.NewName;
                _currentUser.ModifyGroup(group);
                LoadGroups();
            }
            catch (Exception ex)
            {
                MessageBox.Show("修改用户组失败：" + ex.Message, "文档管理系统", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}