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
    public partial class ShowArchiveContent : Form
    {
        CUserEntity _currentUser;
        TreeNode _selectedNode;

        public TreeNode SelectedNode
        {
            get { return _selectedNode; }
            set { _selectedNode = value; }
        }

        public CUserEntity CurrentUser
        {
            get { return _currentUser; }
            set { _currentUser = value; }
        }

        public ShowArchiveContent()
        {
            InitializeComponent();
        }

        private void ShowArchiveContent_Load(object sender, EventArgs e)
        {
            FileList archiFilst = new FileList();
            archiFilst.CurrentUser = _currentUser;
            ContentDirTree.CurrentUser = _currentUser;
            ContentDirTree.RootResourceId = _currentUser.GetUserOrganize().Org_ArchiveRes;

            try
            {
                ContentDirTree.RootDir = Context.Server.MapPath("~/app_data");
                ContentDirTree.Init();
                ContentDirTree.FileListUI = archiFilst;
            }
            catch(Exception ex)
            {
                MessageBox.Show("系统错误："+ex.Message, "文档管理系统", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if(ContentDirTree.MainTreeView.SelectedNode == null)
            {
                MessageBox.Show("没有选中的目录节点！", "文档管理系统", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            try
            {
                _selectedNode = ContentDirTree.MainTreeView.SelectedNode;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show("系统错误："+ex.Message, "文档管理系统", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}