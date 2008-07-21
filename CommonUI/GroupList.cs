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
            
        }

        private void CreateContextMenu()
        {
            MenuItem MenuItem1 = new Gizmox.WebGUI.Forms.MenuItem();
            MenuItem MenuItem2 = new Gizmox.WebGUI.Forms.MenuItem();
            MenuItem MenuItem3 = new Gizmox.WebGUI.Forms.MenuItem();
/*
            MenuItem1.Text = "创建用户组";
            MenuItem1.Click += new System.EventHandler(this.menuCreateUser_Click);
            userContextMenu.MenuItems.Add(MenuItem1);

            MenuItem2.Text = "删除用户组";
            MenuItem2.Click += new System.EventHandler(this.menuDeleteUser_Click);
            userContextMenu.MenuItems.Add(MenuItem2);

            MenuItem3.Text = "管理用户组";
            MenuItem3.Click += new System.EventHandler(this.menuModifyUser_Click);
            userContextMenu.MenuItems.Add(MenuItem3);*/
        }
    }
}