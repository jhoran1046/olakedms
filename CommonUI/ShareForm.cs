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
    public partial class ShareForm : Form
    {
        CUserEntity _currentUser;
        int _resourceId;

        public CUserEntity CurrentUser
        {
            set { _currentUser = value; }
        }

        public int ResourceId
        {
            set { _resourceId = value; }
        }

        public ShareForm()
        {
            InitializeComponent();
        }

        private void ShareForm_Load(object sender, EventArgs e)
        {
            try
            {
                FillUserLists();
            }
            catch (Exception ex)
            {
                MessageBox.Show("无法共享: " + ex.Message, "文档管理系统", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FillUserLists()
        {
            // get all shared users and init list
            List<CACLEntity> acls = _currentUser.ListMyAcls(_resourceId);
            List<CUserEntity> sharedUsers = new List<CUserEntity>();
            List<CGroupEntity> sharedGroups = new List<CGroupEntity>();
            foreach (CACLEntity acl in acls)
            {
                if (acl.Acl_RType == (int)ACLROLETYPE.USERROLE && acl.Acl_Role == _currentUser.Usr_Id)
                    continue;

                bool added = false;
                if (acl.Acl_RType == (int)ACLROLETYPE.USERROLE)
                {
                    foreach (CUserEntity u in sharedUsers)
                    {
                        if (acl.Acl_Role == u.Usr_Id)
                        {
                            added = true;
                            break;
                        }
                    }
                    if (added)
                        continue;

                    CUserEntity user = new CUserEntity(_currentUser.ConnString).Load(acl.Acl_Role);
                    sharedUsers.Add(user);
                }
                else if (acl.Acl_RType == (int)ACLROLETYPE.GROUPROLE)
                {
                    foreach (CGroupEntity g in sharedGroups)
                    {
                        if (acl.Acl_Role == g.Grp_Id)
                        {
                            added = true;
                            break;
                        }
                    }
                    if (added)
                        continue;

                    CGroupEntity group = new CGroupEntity(_currentUser.ConnString).Load(acl.Acl_Role);
                    sharedGroups.Add(group);
                }
            }

            shareList.Items.Clear();
            foreach (CGroupEntity ug in sharedGroups)
            {
                ListViewItem lvi = new ListViewItem();

                lvi.Text = ug.Grp_Name;
                lvi.SmallImage = new IconResourceHandle("people.gif");
                lvi.Tag = ug;

                shareList.Items.Add(lvi);
            }
            foreach (CUserEntity ur in sharedUsers)
            {
                ListViewItem lvi = new ListViewItem();

                lvi.Text = ur.Usr_Member + "[" + ur.Usr_Name + "]";
                lvi.SmallImage = new IconResourceHandle("personal.gif");
                lvi.Tag = ur;

                shareList.Items.Add(lvi);
            }

            // get other users and fill unshared user list
            List<CUserEntity> allUsers = _currentUser.ListAllUsers();
            List<CGroupEntity> allGroups = _currentUser.ListGroups();
            unshareList.Items.Clear();
            foreach (CGroupEntity ug in allGroups)
            {
                bool shared = false;
                foreach (CGroupEntity group in sharedGroups)
                {
                    if (ug.Grp_Id == group.Grp_Id)
                    {
                        shared = true;
                        break;
                    }
                }
                if (shared)
                    continue;

                ListViewItem lvi = new ListViewItem();

                lvi.Text = ug.Grp_Name;
                lvi.SmallImage = new IconResourceHandle("people.gif");
                lvi.Tag = ug;

                unshareList.Items.Add(lvi);
            }
            foreach (CUserEntity ur in allUsers)
            {
                if (ur.Usr_Id == _currentUser.Usr_Id)
                    continue;

                bool shared = false;
                foreach (CUserEntity usr in sharedUsers)
                {
                    if (ur.Usr_Id == usr.Usr_Id)
                    {
                        shared = true;
                        break;
                    }
                }
                if (shared)
                    continue;

                ListViewItem lvi = new ListViewItem();

                lvi.Text = ur.Usr_Member;
                lvi.SmallImage = new IconResourceHandle("personal.gif");
                lvi.Tag = ur;

                unshareList.Items.Add(lvi);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (unshareList.SelectedItems.Count <= 0)
            {
                MessageBox.Show("请选择要共享的用户！", "文档管理系统", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!addReadBox.Checked && !addWriteBox.Checked)
            {
                MessageBox.Show("请选择共享权限！", "文档管理系统", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            foreach (ListViewItem item in unshareList.SelectedItems)
            {
                try
                {
                    if (item.Tag is CUserEntity)
                    {
                        CUserEntity user = (CUserEntity)(item.Tag);
                        if (addReadBox.Checked)
                        {
                            _currentUser.Permit(user.Usr_Id, ACLROLETYPE.USERROLE, _resourceId, ACLOPERATION.READ);
                        }
                        if (addWriteBox.Checked)
                        {
                            _currentUser.Permit(user.Usr_Id, ACLROLETYPE.USERROLE, _resourceId, ACLOPERATION.WRITE);
                        }
                    }
                    else if (item.Tag is CGroupEntity)
                    {
                        CGroupEntity group = (CGroupEntity)(item.Tag);
                        if (addReadBox.Checked)
                        {
                            _currentUser.Permit(group.Grp_Id, ACLROLETYPE.GROUPROLE, _resourceId, ACLOPERATION.READ);
                        }
                        if (addWriteBox.Checked)
                        {
                            _currentUser.Permit(group.Grp_Id, ACLROLETYPE.GROUPROLE, _resourceId, ACLOPERATION.WRITE);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("无法共享:" + ex.Message, "文档管理系统", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            // refill user lists
            FillUserLists();
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (shareList.SelectedItems.Count <= 0)
            {
                MessageBox.Show("请选择要停止共享的用户！", "文档管理系统", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            foreach (ListViewItem item in shareList.SelectedItems)
            {
                try
                {
                    if (item.Tag is CUserEntity)
                    {
                        CUserEntity user = (CUserEntity)(item.Tag);
                        _currentUser.Deny(user.Usr_Id, ACLROLETYPE.USERROLE, _resourceId);
                    }
                    else if (item.Tag is CGroupEntity)
                    {
                        CGroupEntity group = (CGroupEntity)(item.Tag);
                        _currentUser.Deny(group.Grp_Id, ACLROLETYPE.GROUPROLE, _resourceId);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("无法共享:" + ex.Message, "文档管理系统", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            // refill user lists
            FillUserLists();
        }

        private void shareList_SelectedIndexChanged(object sender, EventArgs e)
        {
            readBox.Checked = false;
            writeBox.Checked = false;
            if (shareList.SelectedItems.Count == 1)
            {
                ListViewItem item = shareList.SelectedItems[0];
                try
                {
                    List<CACLEntity> acls = new List<CACLEntity>();
                    if (item.Tag is CUserEntity)
                    {
                        CUserEntity user = (CUserEntity)(item.Tag);
                        acls = user.GetUserACLs();
                    }
                    else if (item.Tag is CGroupEntity)
                    {
                        CGroupEntity group = (CGroupEntity)(item.Tag);
                        acls = group.GetGroupACLs();
                    }

                    foreach (CACLEntity acl in acls)
                    {
                        if (acl.Acl_Resource != _resourceId)
                            continue;

                        if (acl.Acl_Operation == (int)ACLOPERATION.READ)
                            readBox.Checked = true;
                        else if (acl.Acl_Operation == (int)ACLOPERATION.WRITE)
                            writeBox.Checked = true;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("共享数据已发生变化:" + ex.Message, "文档管理系统", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void readBox_Click(object sender, EventArgs e)
        {
            if (shareList.SelectedItems.Count == 1)
            {
                ListViewItem item = shareList.SelectedItems[0];
                int id = 0;
                ACLROLETYPE roleType = ACLROLETYPE.USERROLE;

                if (item.Tag is CUserEntity)
                {
                    CUserEntity user = (CUserEntity)(item.Tag);
                    id = user.Usr_Id;
                    roleType = ACLROLETYPE.USERROLE;
                }
                else if (item.Tag is CGroupEntity)
                {
                    CGroupEntity group = (CGroupEntity)(item.Tag);
                    id = group.Grp_Id;
                    roleType = ACLROLETYPE.GROUPROLE;
                }
                else
                    throw new Exception("错误的数据类型: ");
                try
                {
                    if (readBox.Checked)
                        _currentUser.Permit(id, roleType, _resourceId, ACLOPERATION.READ);
                    else
                        _currentUser.Deny(id, roleType, _resourceId, ACLOPERATION.READ);

                    if (!readBox.Checked && !writeBox.Checked)
                        FillUserLists();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("共享数据已发生变化:" + ex.Message, "文档管理系统", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void writeBox_Click(object sender, EventArgs e)
        {
            if (shareList.SelectedItems.Count == 1)
            {
                ListViewItem item = shareList.SelectedItems[0];
                int id = 0;
                ACLROLETYPE roleType = ACLROLETYPE.USERROLE;

                if (item.Tag is CUserEntity)
                {
                    CUserEntity user = (CUserEntity)(item.Tag);
                    id = user.Usr_Id;
                    roleType = ACLROLETYPE.USERROLE;
                }
                else if (item.Tag is CGroupEntity)
                {
                    CGroupEntity group = (CGroupEntity)(item.Tag);
                    id = group.Grp_Id;
                    roleType = ACLROLETYPE.GROUPROLE;
                }
                else
                    throw new Exception("错误的数据类型: ");
                try
                {
                    if (writeBox.Checked)
                        _currentUser.Permit(id, roleType, _resourceId, ACLOPERATION.WRITE);
                    else
                        _currentUser.Deny(id, roleType, _resourceId, ACLOPERATION.WRITE);

                    if (!readBox.Checked && !writeBox.Checked)
                        FillUserLists();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("共享数据已发生变化:" + ex.Message, "文档管理系统", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}