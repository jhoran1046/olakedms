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
    public partial class UserList : UserControl
    {
        CUserEntity _currentUser;

        public CUserEntity CurrentUser
        {
            get { return _currentUser; }
            set { _currentUser = value; }
        }

        public UserList()
        {
            InitializeComponent();
            CreateContextMenu();
        }

        public void LoadUsers()
        {
            userListView.Items.Clear();
            List<CUserEntity> users = _currentUser.ListAllUsers();
            foreach (CUserEntity user in users)
            {
                ListViewItem lvi = new ListViewItem();
                ListViewItem.ListViewSubItem lvsi;

                lvi.Text = user.Usr_Member;
                lvi.Tag = user.Usr_Id;

                lvsi = new ListViewItem.ListViewSubItem();
                lvsi.Text = user.Usr_Name;
                lvi.SubItems.Add(lvsi);

                lvsi = new ListViewItem.ListViewSubItem();
                lvsi.Text = "";
                lvi.SubItems.Add(lvsi);

                lvsi = new ListViewItem.ListViewSubItem();
                if (user.Usr_Type == (int)USERTYPE.SYSTEMADMIN)
                    lvsi.Text = "系统管理员";
                else if (user.Usr_Type == (int)USERTYPE.ORGANIZEADMIN)
                    lvsi.Text = "管理员";
                else
                    lvsi.Text = "普通用户";
                lvi.SubItems.Add(lvsi);
                userListView.Items.Add(lvi);
            }
        }

        private void CreateContextMenu()
        {
            MenuItem MenuItem1 = new Gizmox.WebGUI.Forms.MenuItem();
            MenuItem MenuItem2 = new Gizmox.WebGUI.Forms.MenuItem();
            MenuItem MenuItem3 = new Gizmox.WebGUI.Forms.MenuItem();
            MenuItem MenuItem4 = new Gizmox.WebGUI.Forms.MenuItem();

            MenuItem1.Text = "创建用户";
            MenuItem1.Click += new System.EventHandler(this.menuCreateUser_Click);
            userContextMenu.MenuItems.Add(MenuItem1);

            MenuItem2.Text = "删除用户";
            MenuItem2.Click += new System.EventHandler(this.menuDeleteUser_Click);
            userContextMenu.MenuItems.Add(MenuItem2);

            MenuItem3.Text = "修改用户";
            MenuItem3.Click += new System.EventHandler(this.menuModifyUser_Click);
            userContextMenu.MenuItems.Add(MenuItem3);

            MenuItem4.Text = "用户组";
            MenuItem4.Click += new System.EventHandler(this.menuUserGroup_Click);
            userContextMenu.MenuItems.Add(MenuItem4);
        }

        private void UserList_Load(object sender, EventArgs e)
        {
            LoadUsers();
        }

        private void menuUserGroup_Click(object sender, EventArgs e)
        {
            
        }

        private void menuCreateUser_Click(object sender, EventArgs e)
        {
            UserForm userForm = new UserForm();
            userForm.Closed += new EventHandler(AddUser_Closed);
            userForm.ShowDialog();
        }

        private void AddUser_Closed(object sender, EventArgs e)
        {
            UserForm userForm = (UserForm)sender;
            if (userForm.DialogResult != DialogResult.OK)
                return;

            try
            {
                CUserEntity newUser = new CUserEntity(_currentUser.ConnString);
                newUser.Usr_Member = userForm.Member;
                newUser.Usr_Password = userForm.Password;
                newUser.Usr_Name = userForm.UserName;
                newUser.Usr_Organize = _currentUser.Usr_Organize;
                _currentUser.CreateNormalUser(newUser);
                this.LoadUsers();
            }
            catch (Exception ex)
            {
                MessageBox.Show("创建用户失败：" + ex.Message, "文档管理系统", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void menuDeleteUser_Click(object sender, EventArgs e)
        {
            MessageBox.Show("确定要删除用户吗？", "文档管理系统", MessageBoxButtons.YesNo,
                MessageBoxIcon.Question, new EventHandler(DeleteUser_Closed));
        }

        private void DeleteUser_Closed(object sender, EventArgs e)
        {
            if (((Form)sender).DialogResult != DialogResult.Yes)
            {
                return;
            }

            try
            {
                foreach (ListViewItem item in userListView.SelectedItems)
                {
                    _currentUser.DeleteUser((int)item.Tag);
                }
                LoadUsers();
            }
            catch (Exception ex)
            {
                MessageBox.Show("删除用户失败：" + ex.Message, "文档管理系统", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void menuModifyUser_Click(object sender, EventArgs e)
        {
            if (userListView.SelectedItems.Count != 1)
            {
                MessageBox.Show("必须选择一个用户！", "文档管理系统", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                CUserEntity user = new CUserEntity(_currentUser.ConnString).Load((int)userListView.SelectedItems[0].Tag);
                UserForm userForm = new UserForm();
                userForm.Member = user.Usr_Member;
                userForm.Password = user.Usr_Password;
                userForm.UserName = user.Usr_Name;
                userForm.Closed += new EventHandler(ModifyUser_Closed);
                userForm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show("修改用户失败：" + ex.Message, "文档管理系统", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ModifyUser_Closed(object sender, EventArgs e)
        {
            UserForm userForm = (UserForm)sender;
            if (userForm.DialogResult != DialogResult.OK)
                return;

            try
            {
                CUserEntity user = new CUserEntity(_currentUser.ConnString).Load((int)userListView.SelectedItems[0].Tag);
                user.Usr_Member = userForm.Member;
                user.Usr_Password = userForm.Password;
                user.Usr_Name = userForm.UserName;
                _currentUser.ModifyUser(user);
                this.LoadUsers();
            }
            catch (Exception ex)
            {
                MessageBox.Show("修改用户失败：" + ex.Message, "文档管理系统", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}