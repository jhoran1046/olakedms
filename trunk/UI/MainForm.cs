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
        
        public MainForm ( )
        {
            InitializeComponent ( );

            MidLayerSettings.ConnectionString = "Provider=SQLOLEDB.1;Data Source=home;Initial Catalog=DMS;User ID=sa;password=a;connect timeout = 300";
            MidLayerSettings.AppPath = Context.Server.MapPath("~/App_Data");

            try
            {
                _currentUser = new CUserEntity(MidLayerSettings.ConnectionString);
                _currentUser = _currentUser.Load(1); //olake

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
                throw ex;
            }
        }

        private void button1_Click ( object sender , EventArgs e )
        {
            SearchForm aFrm = new SearchForm ( );
            aFrm.ShowDialog ( );
        }

        private void MainForm_Load ( object sender , EventArgs e )
        {
            this.Menu = mainMenu1;
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
    }
}