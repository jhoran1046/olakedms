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
        FileList _myFileList = new FileList ( );
        FileList _archiveFileLst = new FileList ( );

        CUserEntity _currentUser;
        public CUserEntity CurrentUser
        {
            get { return _currentUser; }
            set { _currentUser = value; }
        }
        
        public MainForm ()
        {
            InitializeComponent ( );

            MidLayerSettings.ConnectionString = "Provider=SQLOLEDB.1;Data Source=home;Initial Catalog=DMS;User ID=sa;password=a;connect timeout = 300";
            MidLayerSettings.AppPath = Context.Server.MapPath("~/App_Data");
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
                //_currentUser = new CUserEntity(MidLayerSettings.ConnectionString);
                //_currentUser = _currentUser.Load(1); //olake

                myDirTree.CurrentUser = _currentUser;
                myDirTree.RootResourceId = _currentUser.Usr_Resource;
                archiveDirTree.CurrentUser = _currentUser;
                archiveDirTree.RootResourceId = _currentUser.GetUserOrganize().Org_ArchiveRes;
                _myFileList.CurrentUser = _currentUser;
                _archiveFileLst.CurrentUser = _currentUser;

                //ϵͳ����
                List<CFunction> systemFunctions = new List<CFunction>();
                CFunction function = new CFunction();
                function.Name = "����";
                function.Image = new IconResourceHandle("save.gif");
                systemFunctions.Add(function);

                function = new CFunction();
                function.Name = "�û�����";
                function.Image = new IconResourceHandle("member.png");
                systemFunctions.Add(function);


                function = new CFunction();
                function.Name = "ϵͳ����";
                function.Image = new IconResourceHandle("properties.gif");
                systemFunctions.Add(function);

                this.sysFunctionTree.FunctionList = systemFunctions;

                //�ҵ���Ϣ
                List<CFunction> myinfoFunctions = new List<CFunction>();
                function = new CFunction();
                function.Name = "��ȫ��Ϣ";
                function.Image = new IconResourceHandle("importantmail.gif");
                myinfoFunctions.Add(function);


                function = new CFunction();
                function.Name = "������Ϣ";
                function.Image = new IconResourceHandle("member.gif");
                myinfoFunctions.Add(function);

                this.myinfofunctionTree.FunctionList = myinfoFunctions;

                //�ҵ��ĵ�
                myDirTree.RootDir = Context.Server.MapPath("~/");
                myDirTree.Init();
                myDirTree.FileListUI = _myFileList;

                //����ռ�
                List<CFunction> shareSpaceFunctionList = new List<CFunction>();
                function = new CFunction();
                function.Name = "�ҹ�������˵��ĵ�";
                function.Image = new IconResourceHandle("folders.gif");
                shareSpaceFunctionList.Add(function);
                function = new CFunction();
                function.Name = "���˹�����ҵ��ĵ�";
                function.Image = new IconResourceHandle("folders.gif");
                shareSpaceFunctionList.Add(function);
                shareSpacefunctionTree.FunctionList = shareSpaceFunctionList;

                //�鵵��
                archiveDirTree.RootDir = Context.Server.MapPath("~/app_data");
                archiveDirTree.Init();
                archiveDirTree.FileListUI = _archiveFileLst;
            }
            catch (Exception ex)
            {
                MessageBox.Show("ϵͳ����" + ex.Message, "�ĵ�����ϵͳ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void leftNavigationTabs_SelectedIndexChanged ( object sender , EventArgs e )
        {
            this.mainSplit.Panel2.Controls.Clear ( );
            if(leftNavigationTabs.SelectedItem == this.myDocPage||leftNavigationTabs.SelectedItem == this.archiveTab)
            {
                DirTree dirTree =(DirTree) leftNavigationTabs.SelectedItem.Controls [ 0 ];
                this.mainSplit.Panel2.Controls.Add(dirTree.FileListUI);
                dirTree.FileListUI.Dock = DockStyle.Fill;
            }
        }

        private int GetSelectedTreeResource()
        {
            int selectedResource;
            DirTree selectedTree = null;

            if (leftNavigationTabs.SelectedItem == archiveTab)
            {
                selectedTree = archiveDirTree;
            }
            else if (leftNavigationTabs.SelectedItem == myDocPage)
            {
                selectedTree = myDirTree;
            }

            if (selectedTree == null || selectedTree.MainTreeView.SelectedNode == null)
            {
                return -1;
            }
            selectedResource = (int)selectedTree.MainTreeView.SelectedNode.Tag;
            return selectedResource;
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

            return null;
        }

        private void menuUpload_Click(object sender, EventArgs e)
        {
            int selectedResource = GetSelectedTreeResource();
            if (selectedResource < 0)
            {
                MessageBox.Show("��ѡ��һ��Ŀ¼", "�ĵ�����ϵͳ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            
            CACLEntity acl = new CACLEntity(MidLayerSettings.ConnectionString);
            acl.Acl_Resource = selectedResource;
            acl.Acl_Operation = (int)ACLOPERATION.WRITE;
            if (!_currentUser.CheckPrivilege(acl))
            {
                MessageBox.Show("û��дȨ�ޣ�", "�ĵ�����ϵͳ", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            if (selectedResource < 0)
            {
                MessageBox.Show("��ѡ��һ��Ŀ¼", "�ĵ�����ϵͳ", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("�����ļ�ʧ�ܣ�" + ex.Message, "�ĵ�����ϵͳ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void menuDeleteFile_Click(object sender, EventArgs e)
        {
            FileList currentList = GetActiveFileList();
            if (currentList == null)
            {
                MessageBox.Show("��ѡ���ļ���", "�ĵ�����ϵͳ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            MessageBox.Show("ȷ��Ҫɾ���ļ���", "�ĵ�����ϵͳ", MessageBoxButtons.YesNo,
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
                MessageBox.Show("��ѡ���ļ�", "�ĵ�����ϵͳ", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            }
            catch (Exception ex)
            {
                MessageBox.Show("ϵͳ����: " + ex.Message, "�ĵ�����ϵͳ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}