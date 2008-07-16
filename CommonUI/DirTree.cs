#region Using

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;

using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common.Resources;
using MidLayer;
using Framework.DB;
#endregion

namespace CommonUI
{
    public partial class DirTree:UserControl
    {
        string _rootDir;
        
        public string RootDir
        {
            get { return _rootDir; }
            set { _rootDir = value; }
        }

        CUserEntity _currentUser;

        public CUserEntity CurrentUser
        {
            get { return _currentUser; }
            set { _currentUser = value; }
        }

        int _rootResourceId;
        public int RootResourceId
        {
            get { return _rootResourceId;}
            set { _rootResourceId = value; }
        }

        FileList _fileListUI;

        public FileList FileListUI
        {
            get { return _fileListUI; }
            set 
            { 
                _fileListUI = value; 
                if (_fileListUI != null)
                    _fileListUI.Helper = helper; 
            }
        }

        HelpClass helper;
        public HelpClass Helper
        {
            set { helper = value; }
        }

        Font _defaultFnt = new Font ( "arial" , 9 );
        public DirTree ( )
        {
            InitializeComponent ( );
            helper = new HelpClass();
        }
        /// <summary>
        /// before this , the RootDir must be set
        /// </summary>
        /// <returns></returns>
        public bool Init()
        {
/*
            if ( RootDir == null || RootDir == "" )
                return false;

            helper.LoadDirectory ( MainTreeView.Nodes , RootDir );
            foreach ( TreeNode aNode in mainTreeView.Nodes )
            {
                aNode.NodeFont = _defaultFnt;
                aNode.Image = new IconResourceHandle ( "folder.gif" );
                if(!aNode.Loaded)
                    aNode.Image = new IconResourceHandle ( "folders.gif" );
            }
  
 */
            CreateContextMenu();

            helper.InitDirectory(MainTreeView.Nodes, _currentUser, _rootResourceId);
            foreach ( TreeNode aNode in mainTreeView.Nodes )
            {
                aNode.NodeFont = _defaultFnt;
                aNode.Image = new IconResourceHandle ( "folder.gif" );
                if(!aNode.Loaded)
                    aNode.Image = new IconResourceHandle ( "folders.gif" );
            }
            return true;
        }

        public void CreateContextMenu()
        {
            MenuItem MenuItem1 = new Gizmox.WebGUI.Forms.MenuItem();
            MenuItem MenuItem2 = new Gizmox.WebGUI.Forms.MenuItem();
            MenuItem MenuItem3 = new Gizmox.WebGUI.Forms.MenuItem();
            MenuItem MenuItem4 = new Gizmox.WebGUI.Forms.MenuItem();
            MenuItem MenuItem5 = new Gizmox.WebGUI.Forms.MenuItem();
            MenuItem MenuItem6 = new Gizmox.WebGUI.Forms.MenuItem();
            MenuItem MenuItem7 = new Gizmox.WebGUI.Forms.MenuItem();
            MenuItem MenuItem8 = new Gizmox.WebGUI.Forms.MenuItem();
            MenuItem MenuItem9 = new Gizmox.WebGUI.Forms.MenuItem();

            MenuItem1.Text = "创建子目录";
            MenuItem1.Click += new System.EventHandler(this.menuCreateFolder_Click);
            treeContextMenu.MenuItems.Add(MenuItem1);

            MenuItem2.Text = "删除目录";
            MenuItem2.Click += new System.EventHandler(this.menuDeleteFolder_Click);
            treeContextMenu.MenuItems.Add(MenuItem2);

            MenuItem3.Text = "上传文件";
            MenuItem3.Click += new System.EventHandler(this.menuUpload_Click);
            treeContextMenu.MenuItems.Add(MenuItem3);

            //MenuItem4.Text = "复制";
            //MenuItem4.Click += new System.EventHandler(this.menuCopyFolder_Click);
            //treeContextMenu.MenuItems.Add(MenuItem4);

            //MenuItem5.Text = "粘贴";
            //MenuItem5.Click += new System.EventHandler(this.menuPaste_Click);
            //treeContextMenu.MenuItems.Add(MenuItem5);

            MenuItem6.Text = "共享设置";
            MenuItem6.Click += new System.EventHandler(this.menuShareFolder_Click);
            treeContextMenu.MenuItems.Add(MenuItem6);

            MenuItem7.Text = "申请归档";
            //MenuItem7.Click += new System.EventHandler(this.menuShareFolder_Click);
            treeContextMenu.MenuItems.Add(MenuItem7);

            MenuItem8.Text = "处理归档申请";
            //MenuItem8.Click += new System.EventHandler(this.menuShareFolder_Click);
            treeContextMenu.MenuItems.Add(MenuItem8);

            //MenuItem9.Text = "剪切";
            //MenuItem9.Click += new System.EventHandler(this.menuCutFolder_Click);
            //treeContextMenu.MenuItems.Add(MenuItem9);
        }

        public void ReloadTreeNode(TreeNode node)
        {
            LoadNode(node);
            node.Loaded = true;
        }

        protected void LoadNode(TreeNode node)
        {
            //helper.LoadDirectory ( e.Node.Nodes , e.Node.Tag.ToString ( ) );
            node.Nodes.Clear();
            helper.LoadDirectory(node.Nodes, _currentUser, (int)node.Tag);
            foreach (TreeNode aNode in node.Nodes)
            {
                aNode.NodeFont = _defaultFnt;
                aNode.Image = new IconResourceHandle("folder.gif");
                if (!aNode.Loaded)
                {
                    aNode.Image = new IconResourceHandle("folders.gif");
                }
            }

        }

        public void ReloadFileList()
        {
            if (MainTreeView.SelectedNode == null)
                return;

            _fileListUI.CurrentUser = _currentUser;
            _fileListUI.ParentResourceId = (int)MainTreeView.SelectedNode.Tag;
            _fileListUI.LoadFiles();
        }

        private int GetSelectedTreeResource()
        {
            TreeNode node = mainTreeView.SelectedNode;
            if (node == null || node.Tag == null)
                throw new Exception("没有选中的目录");
            return (int)node.Tag;
        }

        private void mainTreeView_AfterSelect ( object sender , TreeViewEventArgs e )
        {
            try
            {
                //_fileListUI.RootDir = e.Node.Tag.ToString ( );
                _fileListUI.CurrentUser = _currentUser;
                _fileListUI.ParentResourceId = (int)e.Node.Tag;
                _fileListUI.LoadFiles();
            }
            catch (Exception ex)
            {
                throw ex;
            }
         }

        private void mainTreeView_BeforeExpand ( object sender , TreeViewCancelEventArgs e )
        {
            if ( !e.Node.Loaded )
            {
                LoadNode(e.Node);
                e.Node.Loaded = true;
            }
        }

        private void menuCreateFolder_Click(object sender, EventArgs e)
        {
            try
            {
                int selectedResource = GetSelectedTreeResource();
                if (selectedResource <= 0)
                {
                    MessageBox.Show("请选择一个目录", "文档管理系统", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                NameForm nameForm = new NameForm();
                nameForm.Text = "创建目录";
                nameForm.Closed += new EventHandler(CreateFolder_Closed);
                nameForm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show("创建目录失败：" + ex.Message, "文档管理系统", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CreateFolder_Closed(object sender, EventArgs e)
        {
            NameForm nameForm = (NameForm)sender;
            if (nameForm.DialogResult != DialogResult.OK)
                return;

            try
            {
                int selectedResource = GetSelectedTreeResource();
                if (selectedResource <= 0)
                {
                    MessageBox.Show("选择的父目录不存在", "文档管理系统", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                helper.CreateFolder(_currentUser, selectedResource, nameForm.NewName);
                ReloadTreeNode(mainTreeView.SelectedNode);
            }
            catch (Exception ex)
            {
                MessageBox.Show("创建目录失败：" + ex.Message, "文档管理系统", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void menuDeleteFolder_Click(object sender, EventArgs e)
        {
            try
            {
                int selectedResource = GetSelectedTreeResource();
                if (selectedResource <= 0)
                {
                    MessageBox.Show("请选择一个目录", "文档管理系统", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                CResourceEntity res = new CResourceEntity(MidLayerSettings.ConnectionString).Load(selectedResource);
                MessageBox.Show("确定要删除" + res.Res_Name + "目录吗？", "文档管理系统", MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question, new EventHandler(DeleteFolder_Closed));
            }
            catch (Exception ex)
            {
                MessageBox.Show("删除目录失败：" + ex.Message, "文档管理系统", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DeleteFolder_Closed(object sender, EventArgs e)
        {
            if (((Form)sender).DialogResult != DialogResult.Yes)
            {
                return;
            }

            try
            {
                TreeNode node = mainTreeView.SelectedNode;
                if (node == null || (int)node.Tag <= 0)
                {
                    MessageBox.Show("选择的目录不存在", "文档管理系统", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                helper.DeleteFolder(_currentUser, (int)node.Tag);

                node = node.Parent;
                if (node != null)
                {
                   ReloadTreeNode(node);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("创建目录失败：" + ex.Message, "文档管理系统", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void menuUpload_Click(object sender, EventArgs e)
        {
            int selectedResource = GetSelectedTreeResource();
            if (selectedResource <= 0)
            {
                MessageBox.Show("请选择一个目录", "文档管理系统", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            OpenFileDialog objFile = new OpenFileDialog();
            objFile.FileOk += new CancelEventHandler(objFile_FileOk);
            objFile.MaxFileSize = 1000000;
            //objFile.Filter = "Image files(*.bmp;*.gif;*.jpg)|*.bmp;*.gif;*.jpg";
            objFile.Multiselect = true;
            objFile.ShowDialog();
        }

        private void objFile_FileOk(object sender, CancelEventArgs e)
        {
            int selectedResource = GetSelectedTreeResource();
            if (selectedResource <= 0)
            {
                MessageBox.Show("请选择一个目录", "文档管理系统", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                OpenFileDialog objFileDialog = (OpenFileDialog)sender;
                helper.UploadFile(_currentUser, selectedResource, objFileDialog);
                ReloadFileList();
            }
            catch (Exception ex)
            {
                MessageBox.Show("创建文件失败：" + ex.Message, "文档管理系统", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void menuShareFolder_Click(object sender, EventArgs e)
        {
            try
            {
                int res = GetSelectedTreeResource();
                if (res <= 0)
                {
                    MessageBox.Show("无法共享选择的资源！", "文档管理系统", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                helper.ShareResource(_currentUser, res);
            }
            catch (Exception ex)
            {
                MessageBox.Show("无法共享: " + ex.Message, "文档管理系统", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}