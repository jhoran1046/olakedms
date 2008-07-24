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
using CommonUI;
using MidLayer;

#endregion

namespace UI
{
    public partial class MainForm: Form
    {
        FileList _myFileList = new FileList();
        FileList _archiveFileLst = new FileList();
        FileList _shareFileList = new FileList();
        UserList _userList = new UserList();
        GroupList _groupList = new GroupList();

        CUserEntity _currentUser;
        ResourceClip _clipBoard;

        public CUserEntity CurrentUser
        {
            get { return _currentUser; }
            set { _currentUser = value; }
        }
        
        public MainForm ()
        {
            InitializeComponent ( );
            _clipBoard = new ResourceClip();
        }

        private void button1_Click ( object sender , EventArgs e )
        {
            SearchForm aFrm = new SearchForm ( );
            aFrm.ShowDialog ( );
        }

        private void MainForm_Load ( object sender , EventArgs e )
        {
            this.Menu = mainMenu1;
            _currentUser = (CUserEntity)Context.Session["CurrentUser"];

            try
            {
                myDirTree.CurrentUser = _currentUser;
                myDirTree.RootResourceId = _currentUser.Usr_Resource;
                archiveDirTree.CurrentUser = _currentUser;
                archiveDirTree.RootResourceId = _currentUser.GetUserOrganize().Org_ArchiveRes;
                _myFileList.CurrentUser = _currentUser;
                _archiveFileLst.CurrentUser = _currentUser;
                shareDirTree.CurrentUser = _currentUser;
                shareDirTree.Helper = new ShareHelpClass();
                _shareFileList.CurrentUser = _currentUser;
                _userList.CurrentUser = _currentUser;
                _groupList.CurrentUser = _currentUser;


                //系统管理
                List<CFunction> systemFunctions = new List<CFunction>();
                CFunction function = new CFunction();
                function.Name = "备份";
                function.Image = new IconResourceHandle("save.gif");
                systemFunctions.Add(function);

                function = new CFunction();
                function.Name = "用户管理";
                function.Image = new IconResourceHandle("member.png");
                function.Ui = _userList;
                systemFunctions.Add(function);

                function = new CFunction();
                function.Name = "用户组管理";
                function.Image = new IconResourceHandle("member.png");
                function.Ui = _groupList;
                systemFunctions.Add(function);


                function = new CFunction();
                function.Name = "系统配置";
                function.Image = new IconResourceHandle("properties.gif");
                systemFunctions.Add(function);
                this.sysFunctionTree.FunctionList = systemFunctions;
                this.sysFunctionTree.TreeEvent += FunctionTreeEventHandler;

                //我的信息
                List<CFunction> myinfoFunctions = new List<CFunction>();
                function = new CFunction();
                function.Name = "安全信息";
                function.Image = new IconResourceHandle("importantmail.gif");
                myinfoFunctions.Add(function);


                function = new CFunction();
                function.Name = "其它信息";
                function.Image = new IconResourceHandle("member.gif");
                myinfoFunctions.Add(function);

                this.myinfofunctionTree.FunctionList = myinfoFunctions;

                //我的文档
                myDirTree.RootDir = Context.Server.MapPath("~/");
                myDirTree.Init();
                myDirTree.FileListUI = _myFileList;

                //共享空间
                /*
                List<CFunction> shareSpaceFunctionList = new List<CFunction>();
                function = new CFunction();
                function.Name = "我共享给他人的文档";
                function.Image = new IconResourceHandle("folders.gif");
                shareSpaceFunctionList.Add(function);
                function = new CFunction();
                function.Name = "他人共享给我的文档";
                function.Image = new IconResourceHandle("folders.gif");
                shareSpaceFunctionList.Add(function);
                shareSpacefunctionTree.FunctionList = shareSpaceFunctionList;
                */
                shareDirTree.Init();
                shareDirTree.FileListUI = _shareFileList;

                //归档区
                archiveDirTree.RootDir = Context.Server.MapPath("~/app_data");
                archiveDirTree.Init();
                archiveDirTree.FileListUI = _archiveFileLst;

                // only administrator can see system admin page
                if (_currentUser.Usr_Type != (int)USERTYPE.ORGANIZEADMIN &&
                    _currentUser.Usr_Type != (int)USERTYPE.SYSTEMADMIN)
                {
                    leftNavigationTabs.Controls.Remove(systemPage);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("系统错误：" + ex.Message, "文档管理系统", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void leftNavigationTabs_SelectedIndexChanged ( object sender , EventArgs e )
        {
            this.mainSplit.Panel2.Controls.Clear ( );
            if (leftNavigationTabs.SelectedItem == this.myDocPage||
                leftNavigationTabs.SelectedItem == this.archiveTab ||
                leftNavigationTabs.SelectedItem == this.shareSpaceTab)
            {
                DirTree dirTree =(DirTree) leftNavigationTabs.SelectedItem.Controls [ 0 ];
                this.mainSplit.Panel2.Controls.Clear();
                this.mainSplit.Panel2.Controls.Add(dirTree.FileListUI);
                dirTree.FileListUI.Dock = DockStyle.Fill;
            }
            else if (leftNavigationTabs.SelectedItem == this.systemPage)
            {
                CFunction func = sysFunctionTree.SelectedFunction;
                if (func != null && func.Ui != null)
                {
                    this.mainSplit.Panel2.Controls.Clear();
                    this.mainSplit.Panel2.Controls.Add(func.Ui);
                    func.Ui.Dock = DockStyle.Fill;
                }
            }
        }

        public void FunctionTreeEventHandler(object sender, FunctionTreeEventArgs e)
        {
            if (e.UI != null)
            {
                this.mainSplit.Panel2.Controls.Clear();
                this.mainSplit.Panel2.Controls.Add(e.UI);
                e.UI.Dock = DockStyle.Fill;
            }
        }

        private int GetSelectedTreeResource()
        {
            TreeNode node = GetSelectedTreeNode();
            if (node == null || node.Tag == null)
                throw new Exception("没有选中的目录");
            return (int)node.Tag;
        }

        private TreeNode GetSelectedTreeNode()
        {
          
            DirTree selectedTree = GetActiveTree();
            if (selectedTree == null)
            {
                return null;
            }
            return selectedTree.MainTreeView.SelectedNode;
        }

        private DirTree GetActiveTree()
        {
            DirTree selectedTree = null;

            if (leftNavigationTabs.SelectedItem == archiveTab)
            {
                selectedTree = archiveDirTree;
            }
            else if (leftNavigationTabs.SelectedItem == myDocPage)
            {
                selectedTree = myDirTree;
            }
            else if (leftNavigationTabs.SelectedItem == shareSpaceTab)
            {
                selectedTree = shareDirTree;
            }

            return selectedTree;
        }

        private FileList GetActiveFileList()
        {
            if (leftNavigationTabs.SelectedItem == archiveTab)
            {
                return _archiveFileLst;
            }
            else if (leftNavigationTabs.SelectedItem == myDocPage)
            {
                return _myFileList;
            }
            else if (leftNavigationTabs.SelectedItem == shareSpaceTab)
            {
                return _shareFileList;
            }

            return null;
        }

        private void menuUpload_Click(object sender, EventArgs e)
        {
            int selectedResource = GetSelectedTreeResource();
            if (selectedResource <= 0)
            {
                MessageBox.Show("请选择一个目录", "文档管理系统", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            
            CACLEntity acl = new CACLEntity(MidLayerSettings.ConnectionString);
            acl.Acl_Resource = selectedResource;
            acl.Acl_Operation = (int)ACLOPERATION.WRITE;
            if (!_currentUser.CheckPrivilege(acl))
            {
                MessageBox.Show("没有写权限！", "文档管理系统", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                for (int i = 0; i < objFileDialog.Files.Count; i++)
                {
                    String filePath;
                    HttpPostedFileHandle hfh = (HttpPostedFileHandle)objFileDialog.Files[i]; ;
                    _currentUser.CreateFile(selectedResource, hfh.PostedFileName, out filePath);
                    hfh.SaveAs(filePath);

                    DirTree selTree = GetActiveTree();
                    selTree.ReloadFileList();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("创建文件失败：" + ex.Message, "文档管理系统", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void menuDeleteFile_Click(object sender, EventArgs e)
        {
            FileList currentList = GetActiveFileList();
            if (currentList == null)
            {
                MessageBox.Show("请选择文件！", "文档管理系统", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            MessageBox.Show("确定要删除文件吗？", "文档管理系统", MessageBoxButtons.YesNo,
                MessageBoxIcon.Question, new EventHandler(DeleteFileHandler));
        }

        private void DeleteFileHandler(object sender, EventArgs e)
        {
            if (((Form)sender).DialogResult != DialogResult.Yes)
            {
                return;
            }

            FileList currentList = GetActiveFileList();
            if (currentList == null)
            {
                MessageBox.Show("请选择文件", "文档管理系统", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                foreach (ListViewItem item in currentList.FileListView.Items)
                {
                    if (item.Checked)
                    {
                        CResourceEntity res = new CResourceEntity(MidLayerSettings.ConnectionString).Load((int)item.Tag);
                        String filePath = res.MakeFullPath();
                        _currentUser.DeleteResource((int)item.Tag);
                        System.IO.File.Delete(filePath);
                    }
                }
                DirTree selTree = GetActiveTree();
                selTree.ReloadFileList();
            }
            catch (Exception ex)
            {
                MessageBox.Show("系统错误: " + ex.Message, "文档管理系统", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void menuCreateFolder_Click(object sender, EventArgs e)
        {
            int selectedResource = GetSelectedTreeResource();
            if (selectedResource <= 0)
            {
                MessageBox.Show("请选择一个目录", "文档管理系统", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                CACLEntity acl = new CACLEntity(MidLayerSettings.ConnectionString);
                acl.Acl_Resource = selectedResource;
                acl.Acl_Operation = (int)ACLOPERATION.WRITE;
                if (!_currentUser.CheckPrivilege(acl))
                {
                    MessageBox.Show("没有写权限！", "文档管理系统", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

                _currentUser.CreateFolder(selectedResource, nameForm.NewName);
                DirTree selTree = GetActiveTree();
                selTree.ReloadTreeNode(selTree.MainTreeView.SelectedNode);
            }
            catch (Exception ex)
            {
                MessageBox.Show("创建目录失败：" + ex.Message, "文档管理系统", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void menuDeleteFolder_Click(object sender, EventArgs e)
        {
            int selectedResource = GetSelectedTreeResource();
            if (selectedResource <= 0)
            {
                MessageBox.Show("请选择一个目录", "文档管理系统", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                CACLEntity acl = new CACLEntity(MidLayerSettings.ConnectionString);
                acl.Acl_Resource = selectedResource;
                acl.Acl_Operation = (int)ACLOPERATION.WRITE;
                if (!_currentUser.CheckPrivilege(acl))
                {
                    MessageBox.Show("没有写权限！", "文档管理系统", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                TreeNode node = GetSelectedTreeNode();
                if (node == null || (int)node.Tag <= 0)
                {
                    MessageBox.Show("选择的目录不存在", "文档管理系统", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                CResourceEntity res = new CResourceEntity(MidLayerSettings.ConnectionString).Load((int)node.Tag);

                String dirPath = res.MakeFullPath();
                _currentUser.DeleteResource((int)node.Tag);
                System.IO.Directory.Delete(dirPath, true);

                node = node.Parent;
                if (node != null)
                {
                    DirTree selTree = GetActiveTree();
                    selTree.ReloadTreeNode(node);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("删除目录失败：" + ex.Message, "文档管理系统", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void menuAddUser_Click(object sender, EventArgs e)
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
                CUserEntity newUser = new CUserEntity(MidLayerSettings.ConnectionString);
                newUser.Usr_Member = userForm.Member;
                newUser.Usr_Password = userForm.Password;
                newUser.Usr_Name = userForm.UserName;
                newUser.Usr_Organize = _currentUser.Usr_Organize;
                _currentUser.CreateNormalUser(newUser);
            }
            catch (Exception ex)
            {
                MessageBox.Show("创建用户失败：" + ex.Message, "文档管理系统", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void menuDeleteUser_Click(object sender, EventArgs e)
        {
        }

        private void menuShareFolder_Click(object sender, EventArgs e)
        {
            try
            {
                DirTree activeTree = GetActiveTree();
                if (activeTree == myDirTree || (activeTree == archiveDirTree && _currentUser.Usr_Type == (int)USERTYPE.ORGANIZEADMIN))
                {
                    int res = GetSelectedTreeResource();
                    if (res <= 0)
                    {
                        MessageBox.Show("无法共享选择的资源！", "文档管理系统", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    ShareForm shareForm = new ShareForm();
                    shareForm.CurrentUser = _currentUser;
                    shareForm.ResourceId = res;
                    shareForm.ShowDialog();
                }
                else
                {
                    MessageBox.Show("只能共享个人目录！", "文档管理系统", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("无法共享: " + ex.Message, "文档管理系统", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void menuCopyFile_Click(object sender, EventArgs e)
        {
            try
            {
                FileList currentList = GetActiveFileList();
                if (currentList == null)
                {
                    MessageBox.Show("请选择文件！", "文档管理系统", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                List<int> resources = new List<int>();
                foreach (ListViewItem item in currentList.FileListView.Items)
                {
                    if (item.Checked)
                    {
                        resources.Add((int)item.Tag);
                    }
                }
                _clipBoard.Copy(_currentUser, resources);
            }
            catch (Exception ex)
            {
                MessageBox.Show("系统错误: " + ex.Message, "文档管理系统", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void menuCopyFolder_Click(object sender, EventArgs e)
        {
            try
            {
                int selectedResource = GetSelectedTreeResource();
                if (selectedResource <= 0)
                {
                    MessageBox.Show("请选择一个目录", "文档管理系统", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                _clipBoard.Copy(_currentUser, selectedResource);
            }
            catch (Exception ex)
            {
                MessageBox.Show("系统错误: " + ex.Message, "文档管理系统", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void menuCutFile_Click(object sender, EventArgs e)
        {
            try
            {
                FileList currentList = GetActiveFileList();
                if (currentList == null)
                {
                    MessageBox.Show("请选择文件！", "文档管理系统", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                List<int> resources = new List<int>();
                foreach (ListViewItem item in currentList.FileListView.Items)
                {
                    if (item.Checked)
                    {
                        resources.Add((int)item.Tag);
                    }
                }
                _clipBoard.Cut(_currentUser, resources);
            }
            catch (Exception ex)
            {
                MessageBox.Show("系统错误: " + ex.Message, "文档管理系统", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void menuCutFolder_Click(object sender, EventArgs e)
        {
            try
            {
                int selectedResource = GetSelectedTreeResource();
                if (selectedResource <= 0)
                {
                    MessageBox.Show("请选择一个目录", "文档管理系统", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                _clipBoard.Cut(_currentUser, selectedResource);
            }
            catch (Exception ex)
            {
                MessageBox.Show("系统错误: " + ex.Message, "文档管理系统", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void menuPaste_Click(object sender, EventArgs e)
        {
            try
            {
                int selectedResource = GetSelectedTreeResource();
                if (selectedResource <= 0)
                {
                    MessageBox.Show("请选择一个目录", "文档管理系统", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                _clipBoard.Paste(_currentUser, selectedResource);
                DirTree selTree = GetActiveTree();
                selTree.ReloadTreeNode(selTree.MainTreeView.SelectedNode);
                selTree.ReloadFileList();
            }
            catch (Exception ex)
            {
                MessageBox.Show("系统错误: " + ex.Message, "文档管理系统", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //（右侧文件列表）打开文件——赵英武
        private void menuOpen_Click(object sender, EventArgs e)
        {
            try
            {
                FileList selectedfile = GetActiveFileList();
                ListView filelistview = new ListView();
                if(selectedfile == null)
                {
                    MessageBox.Show("请选择文件！", "文档管理系统", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    System.Diagnostics.Process.Start(filelistview.Columns[0].Text);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("系统错误:" + ex.Message,"文档管理系统",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }

           // throw new Exception("The method or operation is not implemented.");
        }
    }
}