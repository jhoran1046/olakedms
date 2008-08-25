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
using Olake.WDS;
using System.Security.Cryptography;
using Framework.Util;
using System.Configuration;
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
        UserUpdate _userUpdate = new UserUpdate();
        SearchList _searchList = new SearchList();
        MyApplyUsrCrl _myApply = new MyApplyUsrCrl();
        AuditeAppUsrCrl _auditeApply = new AuditeAppUsrCrl();
        FileList _orgMgerList = new FileList();
        Memoes _orgMemo = new Memoes();
        MailUsrCrl _mailSet = new MailUsrCrl();

        CUserEntity _currentUser;
        private UserControl _activeRigthControl = null;
        
        public CUserEntity CurrentUser
        {
            get { return _currentUser; }
            set { _currentUser = value; }
        }
        
        public MainForm ()
        {
            InitializeComponent ( );
        }

        private void ActiveRigthPanel(UserControl uc)
        {
            if (_activeRigthControl == uc)
                return;
            this.mainSplit.Panel2.Controls.Clear();
            this.mainSplit.Panel2.Controls.Add(uc);
            uc.Dock = DockStyle.Fill;
            _activeRigthControl = uc;
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
                _userUpdate.CurrentUser = _currentUser;
                _myApply.CurrentUser = _currentUser;
                _auditeApply.CurrentUser = _currentUser;

                orgMgerDirTree.CurrentUser = _currentUser;
                orgMgerDirTree.RootResourceId = _currentUser.GetUserOrganize().Org_Resource;
                _orgMgerList.CurrentUser = _currentUser;

                _orgMemo.CurrentUser = _currentUser;
                _mailSet.CurrentUser = _currentUser;

                // Create resource clipboard and save in session
                ResourceClip clipBoard = new ResourceClip();
                Context.Session["ResourceClipBoard"] = clipBoard;

                //系统管理
                List<CFunction> systemFunctions = new List<CFunction>();
                CFunction function = new CFunction();
                function.Name = "备份";
                function.Ui = _orgMemo;
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
                function.Ui = _mailSet;
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

                function = new CFunction();
                function.Name = "修改个人资料";
                function.Image = new IconResourceHandle("member.gif");
                function.Ui = _userUpdate;
                myinfoFunctions.Add(function);

                function = new CFunction();
                function.Name = "审核归档申请";
                function.Image = new IconResourceHandle("member.gif");
                function.Ui = _auditeApply;
                CACLEntity acl = new CACLEntity();
                acl.Acl_Operation = (int)ACLOPERATION.AUDITAPPLY;
                acl.Acl_Resource = _currentUser.Usr_Organize;
                if(_currentUser.CheckPrivilege(acl) == true)
                {
                    myinfoFunctions.Add(function);
                }

                function = new CFunction();
                function.Name = "我的归档申请";
                function.Image = new IconResourceHandle("member.gif");
                function.Ui = _myApply;
                myinfoFunctions.Add(function);
             
                this.myinfofunctionTree.FunctionList = myinfoFunctions;
                this.myinfofunctionTree.TreeEvent += FunctionTreeEventHandler;
                     
                //我的文档
               // myDirTree.RootDir = Context.Server.MapPath("~/App_Data");
                //myDirTree.RootDir = Context.Server.MapPath("~/"+ConfigurationManager.AppSettings["Userdata"]);
                myDirTree.RootDir = ConfigurationManager.AppSettings["UserData"];
                myDirTree.Init();
                myDirTree.FileListUI = _myFileList;
                myDirTree.TreeEvent += DirTreeEventHandler;

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
                shareDirTree.TreeEvent += DirTreeEventHandler;

                //归档区
                //archiveDirTree.RootDir = Context.Server.MapPath("~/App_Data");
                archiveDirTree.RootDir = ConfigurationManager.AppSettings["UserData"];
                archiveDirTree.Init();
                archiveDirTree.FileListUI = _archiveFileLst;
                archiveDirTree.TreeEvent += DirTreeEventHandler;
                
                //组织管理——赵英武
               // orgMgerDirTree.RootDir = Context.Server.MapPath("~/App_Data");
                orgMgerDirTree.RootDir = ConfigurationManager.AppSettings["UserData"];
                orgMgerDirTree.Init();
                orgMgerDirTree.FileListUI = _orgMgerList;
                orgMgerDirTree.TreeEvent += DirTreeEventHandler;

                systemPage.Image = new IconResourceHandle("24X24.applications.gif");
                myInfoPage.Image = new IconResourceHandle("24X24.behaviors.gif");
                myDocPage.Image = new IconResourceHandle("24X24.controls.gif");
                shareSpaceTab.Image = new IconResourceHandle("24X24.sharedspace.gif");
                archiveTab.Image = new IconResourceHandle("24X24.folders.gif");
                orgManageTab.Image = new IconResourceHandle("24X24.orgAdmin.gif");

                // only administrator can see system admin page
                if (_currentUser.Usr_Type != (int)USERTYPE.ORGANIZEADMIN &&
                    _currentUser.Usr_Type != (int)USERTYPE.SYSTEMADMIN)
                {
                    leftNavigationTabs.Controls.Remove(systemPage);
                }
                //only orgnizeAdministrator can see orgnize admin page
                if(_currentUser.Usr_Type != (int)USERTYPE.ORGANIZEADMIN)
                {
                    leftNavigationTabs.Controls.Remove(orgManageTab);
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
                leftNavigationTabs.SelectedItem == this.shareSpaceTab ||
                leftNavigationTabs.SelectedItem == this.orgManageTab)
            {
                DirTree dirTree =(DirTree) leftNavigationTabs.SelectedItem.Controls [ 0 ];
                ActiveRigthPanel(dirTree.FileListUI);
            }
            else if (leftNavigationTabs.SelectedItem == this.systemPage)
            {
                CFunction func = sysFunctionTree.SelectedFunction;
                if (func != null && func.Ui != null)
                {
                    ActiveRigthPanel(func.Ui);
                }
            }
            else if (leftNavigationTabs.SelectedItem == this.myInfoPage)
            {
                CFunction func = myinfofunctionTree.SelectedFunction;
                if (func != null && func.Ui != null)
                {
                    ActiveRigthPanel(func.Ui);
                }
            }

            //删除由于备份产生的临时文件夹——赵英武
            if(leftNavigationTabs.SelectedItem != systemPage)
            {
                string path = (string)Context.Session["temperoryFolder"];
                if(System.IO.Directory.Exists(path))
                {
                    COrganizeEntity org = new COrganizeEntity().Load(_currentUser.Usr_Organize);
                    string filePath = path + @"\" + org.Org_Name + ".zip";
                    System.IO.File.Delete(filePath);
                    System.IO.Directory.Delete(path);
                    Context.Session["temperoryFolder"] = "";
                }
            }
        }

        public void FunctionTreeEventHandler(object sender, FunctionTreeEventArgs e)
        {
            if (e.UI != null)
            {
                ActiveRigthPanel(e.UI);
            }
        }

        public void DirTreeEventHandler(object sender, DirTreeEventArgs e)
        {
            if (e.UI != null)
            {
                ActiveRigthPanel(e.UI);
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
            else if(leftNavigationTabs.SelectedItem == orgManageTab)
            {
                selectedTree = orgMgerDirTree;
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
            else if(leftNavigationTabs.SelectedItem == orgManageTab)
            {
                return _orgMgerList;
            }

            return null;
        }

        private void menuUpload_Click(object sender, EventArgs e)
        {
          /*  int selectedResource = GetSelectedTreeResource();
            if (selectedResource <= 0)
            {
                MessageBox.Show("请选择一个目录", "文档管理系统", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            } */

            try
            {
                int selectedResource = GetSelectedTreeResource();
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
            catch(Exception ex)
            {
                MessageBox.Show("警告:"+ex.Message, "文档管理系统", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
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
           /* int selectedResource = GetSelectedTreeResource();
            if (selectedResource <= 0)
            {
                MessageBox.Show("请选择一个目录", "文档管理系统", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            } */

            try
            {
                int selectedResource = GetSelectedTreeResource();
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
           /* int selectedResource = GetSelectedTreeResource();
            if (selectedResource <= 0)
            {
                MessageBox.Show("请选择一个目录", "文档管理系统", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            } */

            try
            {
                int selectedResource = GetSelectedTreeResource();

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
               // newUser.Usr_Password = userForm.Password;

                /*MD5 md5 = MD5.Create();
                byte[] bytePwd = md5.ComputeHash(Encoding.Unicode.GetBytes(userForm.Password));
                byte[] byteSurePwd = md5.ComputeHash(Encoding.Unicode.GetBytes(userForm.Surepwd));
                string resultPwd = System.Text.UTF8Encoding.Unicode.GetString(bytePwd);
                string resultSurePwd = System.Text.UTF8Encoding.Unicode.GetString(byteSurePwd);
                if (resultPwd == resultSurePwd)
                {
                    newUser.Usr_Password = resultPwd;
                }
                else
                {
                    throw new Exception("密码与确认密码不相等！");
                }*/
                string pwd = CHelperClass.UserMd5(userForm.Password);
                string surePwd = CHelperClass.UserMd5(userForm.Surepwd);
                if(pwd == surePwd)
                {
                    newUser.Usr_Password = pwd;
                }
                else
                {
                    MessageBox.Show("密码与确认密码不相等！", "文档管理系统", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }

                newUser.Usr_Name = userForm.UserName;
                newUser.Usr_Email = userForm.Email;
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
                    shareForm.Closed += new EventHandler(shareForm_Closed);
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

        void shareForm_Closed(object sender, EventArgs e)
        {
            ShareForm share = (ShareForm)sender;
            if (share.DialogResult != DialogResult.OK)
                return;
            myDirTree.ReloadTreeNode(myDirTree.MainTreeView.SelectedNode.Parent);
        }

        private void menuSearch_Click(object sender, EventArgs e)
        {
            try
            {
                int selectedResource = 0;
                TreeNode node = GetSelectedTreeNode();
                if (node != null && node.Tag is int)
                    selectedResource = (int)node.Tag;
                SearchForm searchForm = new SearchForm();
                searchForm.CurrentResource = selectedResource;
                searchForm.CurrentUser = _currentUser;
                searchForm.Closed += new EventHandler(SearchFrom_Closed);
                searchForm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show("系统错误: " + ex.Message, "文档管理系统", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SearchFrom_Closed(object sender, EventArgs e)
        {
            SearchForm searchForm = (SearchForm)sender;
            if (searchForm.DialogResult != DialogResult.OK)
                return;

            try
            {
                List<CSearchResultItem> result = searchForm.SearchResult;
                if (result.Count == 0)
                {
                    MessageBox.Show("搜索结果为空！", "文档管理系统", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    this._searchList.Init(result);
                    ActiveRigthPanel(_searchList);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("搜索失败：" + ex.Message, "文档管理系统", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string targetText = txtTarget.Text;
            if(targetText.Length < 0)
            {
                MessageBox.Show("请填写检索内容！", "问昂管理系统", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            if(!searchKeyword.Checked && !searchFullText.Checked)
            {
                MessageBox.Show("请选择检索方式！", "文档管理系统", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            SearchForm searchForm = new SearchForm();
            searchForm.CurrentUser = _currentUser;
            List<String> searchScope = new List<string>();
            List<CSearchResultItem> result = new List<CSearchResultItem>();
            try
            {
                if (searchKeyword.Checked)
                {
                    searchForm.SearchKeyword(targetText);
                    result = searchForm.SearchResult;
                }
                else if (searchFullText.Checked)
                {
                    List<CACLEntity> myAclst = new List<CACLEntity>();
                    myAclst = _currentUser.GetAllACLs();
                    foreach(CACLEntity acl in myAclst)
                    {
                        /* CResourceEntity res = new CResourceEntity().Load(acl.Acl_Resource);
                        string scope = res.MakeFullPath();
                        _search.SearchFullText(targetText, scope);
                         */
                        if(acl.Acl_Operation == (int)ACLOPERATION.READ)
                        {
                            searchForm.SearchFullText(targetText, acl.Acl_Resource);
                        }
                    }
                    result = searchForm.SearchResult;
                }
                this._searchList.Init(result);
                if (result.Count <= 0)
                {
                    MessageBox.Show("搜索结果为空！", "文档管理系统", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    ActiveRigthPanel(_searchList);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("系统错误："+ex.Message, "文档管理系统", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            Context.Session.IsLoggedOn = false;
            Context.Redirect("mainform.wgx");
//            MainForm form = new MainForm();
//            form.Show();
//            this.Close();
        }
    }
}