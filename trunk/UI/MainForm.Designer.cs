using CommonUI;
namespace UI
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose ( bool disposing )
        {
            if ( disposing && ( components != null ) )
            {
                components.Dispose ( );
            }
            base.Dispose ( disposing );
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent ( )
        {
            this.mainMenu1 = new Gizmox.WebGUI.Forms.MainMenu();
            this.menuItem1 = new Gizmox.WebGUI.Forms.MenuItem();
            this.menuUpload = new Gizmox.WebGUI.Forms.MenuItem();
            this.menuDeleteFile = new Gizmox.WebGUI.Forms.MenuItem();
            this.menuCreateFolder = new Gizmox.WebGUI.Forms.MenuItem();
            this.menuDeleteFolder = new Gizmox.WebGUI.Forms.MenuItem();
            this.menuItem2 = new Gizmox.WebGUI.Forms.MenuItem();
            this.menuItem8 = new Gizmox.WebGUI.Forms.MenuItem();
            this.menuItem9 = new Gizmox.WebGUI.Forms.MenuItem();
            this.menuPaste = new Gizmox.WebGUI.Forms.MenuItem();
            this.menuItem3 = new Gizmox.WebGUI.Forms.MenuItem();
            this.menuItem4 = new Gizmox.WebGUI.Forms.MenuItem();
            this.menuShareFile = new Gizmox.WebGUI.Forms.MenuItem();
            this.menuShareFolder = new Gizmox.WebGUI.Forms.MenuItem();
            this.menuItem5 = new Gizmox.WebGUI.Forms.MenuItem();
            this.menuAddUser = new Gizmox.WebGUI.Forms.MenuItem();
            this.menuDeleteUser = new Gizmox.WebGUI.Forms.MenuItem();
            this.menuAddGroup = new Gizmox.WebGUI.Forms.MenuItem();
            this.menuDeleteGroup = new Gizmox.WebGUI.Forms.MenuItem();
            this.tableLayoutPanel1 = new Gizmox.WebGUI.Forms.TableLayoutPanel();
            this.mainSplit = new Gizmox.WebGUI.Forms.SplitContainer();
            this.leftNavigationTabs = new Gizmox.WebGUI.Forms.NavigationTabs();
            this.systemPage = new Gizmox.WebGUI.Forms.TabPage();
            this.sysFunctionTree = new CommonUI.FunctionTree();
            this.myInfoPage = new Gizmox.WebGUI.Forms.TabPage();
            this.myinfofunctionTree = new CommonUI.FunctionTree();
            this.myDocPage = new Gizmox.WebGUI.Forms.TabPage();
            this.myDirTree = new CommonUI.DirTree();
            this.shareSpaceTab = new Gizmox.WebGUI.Forms.TabPage();
            this.archiveTab = new Gizmox.WebGUI.Forms.TabPage();
            this.archiveDirTree = new CommonUI.DirTree();
            this.menuItem6 = new Gizmox.WebGUI.Forms.MenuItem();
            this.menuItem7 = new Gizmox.WebGUI.Forms.MenuItem();
            this.listView1 = new Gizmox.WebGUI.Forms.ListView();
            this.shareDirTree = new CommonUI.DirTree();
            this.SuspendLayout();
            // 
            // mainMenu1
            // 
            this.mainMenu1.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.mainMenu1.Location = new System.Drawing.Point(0, 0);
            this.mainMenu1.MenuItems.AddRange(new Gizmox.WebGUI.Forms.MenuItem[] {
            this.menuItem1,
            this.menuItem2,
            this.menuItem3,
            this.menuItem4,
            this.menuItem5});
            this.mainMenu1.Name = "mainMenu1";
            this.mainMenu1.Size = new System.Drawing.Size(100, 22);
            this.mainMenu1.Text = "主菜单";
            // 
            // menuItem1
            // 
            this.menuItem1.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.menuItem1.Index = 0;
            this.menuItem1.MenuItems.AddRange(new Gizmox.WebGUI.Forms.MenuItem[] {
            this.menuUpload,
            this.menuDeleteFile,
            this.menuCreateFolder,
            this.menuDeleteFolder});
            this.menuItem1.RadioCheck = true;
            this.menuItem1.Text = "File";
            // 
            // menuUpload
            // 
            this.menuUpload.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.menuUpload.Text = "Upload File";
            this.menuUpload.Click += new System.EventHandler(this.menuUpload_Click);
            // 
            // menuDeleteFile
            // 
            this.menuDeleteFile.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.menuDeleteFile.Text = "Delete File";
            this.menuDeleteFile.Click += new System.EventHandler(this.menuDeleteFile_Click);
            // 
            // menuCreateFolder
            // 
            this.menuCreateFolder.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.menuCreateFolder.Text = "Create Folder";
            this.menuCreateFolder.Click += new System.EventHandler(this.menuCreateFolder_Click);
            // 
            // menuDeleteFolder
            // 
            this.menuDeleteFolder.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.menuDeleteFolder.Text = "Delete Folder";
            this.menuDeleteFolder.Click += new System.EventHandler(this.menuDeleteFolder_Click);
            // 
            // menuItem2
            // 
            this.menuItem2.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.menuItem2.Index = 1;
            this.menuItem2.MenuItems.AddRange(new Gizmox.WebGUI.Forms.MenuItem[] {
            this.menuItem8,
            this.menuItem9,
            this.menuPaste});
            this.menuItem2.Text = "Edit";
            // 
            // menuItem8
            // 
            this.menuItem8.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.menuItem8.Text = "Copy File";
            this.menuItem8.Click += new System.EventHandler(menuCopyFile_Click);
            // 
            // menuItem9
            // 
            this.menuItem9.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.menuItem9.Text = "Copy Folder";
            this.menuItem9.Click += new System.EventHandler(menuCopyFolder_Click);
            // 
            // menuPaste
            // 
            this.menuPaste.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.menuPaste.Text = "Paste";
            this.menuPaste.Click += new System.EventHandler(menuPaste_Click);
            // 
            // menuItem3
            // 
            this.menuItem3.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.menuItem3.Index = 2;
            this.menuItem3.Text = "Help";
            // 
            // menuItem4
            // 
            this.menuItem4.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.menuItem4.Index = 3;
            this.menuItem4.MenuItems.AddRange(new Gizmox.WebGUI.Forms.MenuItem[] {
            this.menuShareFile,
            this.menuShareFolder});
            this.menuItem4.Text = "Share";
            // 
            // menuShareFile
            // 
            this.menuShareFile.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.menuShareFile.Text = "Share File...";
            // 
            // menuShareFolder
            // 
            this.menuShareFolder.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.menuShareFolder.Text = "Share Folder";
            this.menuShareFolder.Click += new System.EventHandler(this.menuShareFolder_Click);
            // 
            // menuItem5
            // 
            this.menuItem5.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.menuItem5.Index = 4;
            this.menuItem5.MenuItems.AddRange(new Gizmox.WebGUI.Forms.MenuItem[] {
            this.menuAddUser,
            this.menuDeleteUser,
            this.menuAddGroup,
            this.menuDeleteGroup});
            this.menuItem5.Text = "User";
            // 
            // menuAddUser
            // 
            this.menuAddUser.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.menuAddUser.Text = "Add User";
            this.menuAddUser.Click += new System.EventHandler(this.menuAddUser_Click);
            // 
            // menuDeleteUser
            // 
            this.menuDeleteUser.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.menuDeleteUser.Text = "Delete User";
            this.menuDeleteUser.Click += new System.EventHandler(this.menuDeleteUser_Click);
            // 
            // menuAddGroup
            // 
            this.menuAddGroup.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.menuAddGroup.Text = "Add Group";
            // 
            // menuDeleteGroup
            // 
            this.menuDeleteGroup.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.menuDeleteGroup.Text = "Delete Group";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None;
            this.tableLayoutPanel1.CellBorderStyle = Gizmox.WebGUI.Forms.TableLayoutPanelCellBorderStyle.None;
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Controls.Add(this.mainSplit, 0, 1);
            this.tableLayoutPanel1.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.tableLayoutPanel1.GrowStyle = Gizmox.WebGUI.Forms.TableLayoutPanelGrowStyle.AddRows;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 6.25F));
            this.tableLayoutPanel1.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 93.75F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(641, 496);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // mainSplit
            // 
            this.mainSplit.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None;
            this.mainSplit.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.Clear;
            this.mainSplit.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mainSplit.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.mainSplit.FixedPanel = Gizmox.WebGUI.Forms.FixedPanel.None;
            this.mainSplit.Location = new System.Drawing.Point(3, 34);
            this.mainSplit.Name = "mainSplit";
            this.mainSplit.Orientation = Gizmox.WebGUI.Forms.Orientation.Vertical;
            // 
            // mainSplit.Panel1
            // 
            this.mainSplit.Panel1.Controls.Add(this.leftNavigationTabs);
            this.mainSplit.Panel1.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            // 
            // mainSplit.Panel2
            // 
            this.mainSplit.Panel2.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.mainSplit.Size = new System.Drawing.Size(635, 459);
            this.mainSplit.SplitterDistance = 211;
            this.mainSplit.TabIndex = 0;
            // 
            // leftNavigationTabs
            // 
            this.leftNavigationTabs.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None;
            this.leftNavigationTabs.Controls.Add(this.systemPage);
            this.leftNavigationTabs.Controls.Add(this.myInfoPage);
            this.leftNavigationTabs.Controls.Add(this.myDocPage);
            this.leftNavigationTabs.Controls.Add(this.shareSpaceTab);
            this.leftNavigationTabs.Controls.Add(this.archiveTab);
            this.leftNavigationTabs.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.leftNavigationTabs.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.leftNavigationTabs.Location = new System.Drawing.Point(0, 0);
            this.leftNavigationTabs.Multiline = false;
            this.leftNavigationTabs.Name = "leftNavigationTabs";
            this.leftNavigationTabs.SelectedIndex = 0;
            this.leftNavigationTabs.Size = new System.Drawing.Size(211, 459);
            this.leftNavigationTabs.TabIndex = 0;
            this.leftNavigationTabs.SelectedIndexChanged += new System.EventHandler(this.leftNavigationTabs_SelectedIndexChanged);
            // 
            // systemPage
            // 
            this.systemPage.Controls.Add(this.sysFunctionTree);
            this.systemPage.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.systemPage.Location = new System.Drawing.Point(4, 22);
            this.systemPage.Name = "systemPage";
            this.systemPage.Size = new System.Drawing.Size(203, 433);
            this.systemPage.TabIndex = 0;
            this.systemPage.Text = "系统管理";
            // 
            // sysFunctionTree
            // 
            this.sysFunctionTree.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None;
            this.sysFunctionTree.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.sysFunctionTree.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.sysFunctionTree.FunctionList = null;
            this.sysFunctionTree.Location = new System.Drawing.Point(0, 0);
            this.sysFunctionTree.Name = "sysFunctionTree";
            this.sysFunctionTree.Size = new System.Drawing.Size(203, 433);
            this.sysFunctionTree.TabIndex = 0;
            this.sysFunctionTree.Text = "FunctionTree";
            // 
            // myInfoPage
            // 
            this.myInfoPage.Controls.Add(this.myinfofunctionTree);
            this.myInfoPage.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.myInfoPage.Location = new System.Drawing.Point(4, 22);
            this.myInfoPage.Name = "myInfoPage";
            this.myInfoPage.Size = new System.Drawing.Size(203, 433);
            this.myInfoPage.TabIndex = 0;
            this.myInfoPage.Text = "我的信息";
            // 
            // myinfofunctionTree
            // 
            this.myinfofunctionTree.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.myinfofunctionTree.FunctionList = null;
            this.myinfofunctionTree.Location = new System.Drawing.Point(0, 0);
            this.myinfofunctionTree.Name = "myinfofunctionTree";
            this.myinfofunctionTree.Size = new System.Drawing.Size(391, 306);
            this.myinfofunctionTree.TabIndex = 0;
            this.myinfofunctionTree.Text = "FunctionTree";
            // 
            // myDocPage
            // 
            this.myDocPage.Controls.Add(this.myDirTree);
            this.myDocPage.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.myDocPage.Location = new System.Drawing.Point(4, 22);
            this.myDocPage.Name = "myDocPage";
            this.myDocPage.Size = new System.Drawing.Size(203, 433);
            this.myDocPage.TabIndex = 1;
            this.myDocPage.Text = "我的文档";
            // 
            // myDirTree
            // 
            this.myDirTree.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None;
            this.myDirTree.CurrentUser = null;
            this.myDirTree.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.myDirTree.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.myDirTree.FileListUI = null;
            this.myDirTree.Location = new System.Drawing.Point(0, 0);
            this.myDirTree.Name = "myDirTree";
            this.myDirTree.RootDir = null;
            this.myDirTree.RootResourceId = 0;
            this.myDirTree.Size = new System.Drawing.Size(203, 433);
            this.myDirTree.TabIndex = 0;
            this.myDirTree.Text = "DirTree";
            // 
            // shareSpaceTab
            // 
            this.shareSpaceTab.Controls.Add(this.shareDirTree);
            this.shareSpaceTab.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.shareSpaceTab.Location = new System.Drawing.Point(4, 22);
            this.shareSpaceTab.Name = "shareSpaceTab";
            this.shareSpaceTab.Size = new System.Drawing.Size(203, 433);
            this.shareSpaceTab.TabIndex = 0;
            this.shareSpaceTab.Text = "共享空间";
            // 
            // archiveTab
            // 
            this.archiveTab.Controls.Add(this.archiveDirTree);
            this.archiveTab.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.archiveTab.Location = new System.Drawing.Point(4, 22);
            this.archiveTab.Name = "archiveTab";
            this.archiveTab.Size = new System.Drawing.Size(203, 433);
            this.archiveTab.TabIndex = 0;
            this.archiveTab.Text = "归档区";
            // 
            // archiveDirTree
            // 
            this.archiveDirTree.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None;
            this.archiveDirTree.CurrentUser = null;
            this.archiveDirTree.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.archiveDirTree.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.archiveDirTree.FileListUI = null;
            this.archiveDirTree.Location = new System.Drawing.Point(0, 0);
            this.archiveDirTree.Name = "archiveDirTree";
            this.archiveDirTree.RootDir = null;
            this.archiveDirTree.RootResourceId = 0;
            this.archiveDirTree.Size = new System.Drawing.Size(203, 433);
            this.archiveDirTree.TabIndex = 0;
            this.archiveDirTree.Text = "DirTree";
            // 
            // menuItem6
            // 
            this.menuItem6.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            // 
            // menuItem7
            // 
            this.menuItem7.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            // 
            // listView1
            // 
            this.listView1.DataMember = null;
            this.listView1.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.listView1.ItemsPerPage = 20;
            this.listView1.Location = new System.Drawing.Point(35, 149);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(100, 100);
            // 
            // shareDirTree
            // 
            this.shareDirTree.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None;
            this.shareDirTree.CurrentUser = null;
            this.shareDirTree.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.shareDirTree.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.shareDirTree.FileListUI = null;
            this.shareDirTree.Location = new System.Drawing.Point(0, 0);
            this.shareDirTree.Name = "shareDirTree";
            this.shareDirTree.RootDir = null;
            this.shareDirTree.RootResourceId = 0;
            this.shareDirTree.Size = new System.Drawing.Size(203, 433);
            this.shareDirTree.TabIndex = 0;
            this.shareDirTree.Text = "DirTree";
            // 
            // MainForm
            // 
            this.Controls.Add(this.tableLayoutPanel1);
            this.Location = new System.Drawing.Point(15, -15);
            this.Size = new System.Drawing.Size(641, 496);
            this.Text = "文档管理系统";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Gizmox.WebGUI.Forms.MainMenu mainMenu1;
        private Gizmox.WebGUI.Forms.MenuItem menuItem1;
        private Gizmox.WebGUI.Forms.MenuItem menuItem2;
        private Gizmox.WebGUI.Forms.MenuItem menuItem3;
        private Gizmox.WebGUI.Forms.TableLayoutPanel tableLayoutPanel1;
        private Gizmox.WebGUI.Forms.MenuItem menuUpload;
        private Gizmox.WebGUI.Forms.MenuItem menuDeleteFile;
        private Gizmox.WebGUI.Forms.MenuItem menuItem6;
        private Gizmox.WebGUI.Forms.MenuItem menuItem7;
        private Gizmox.WebGUI.Forms.MenuItem menuItem8;
        private Gizmox.WebGUI.Forms.MenuItem menuItem9;
        private Gizmox.WebGUI.Forms.MenuItem menuPaste;
        private Gizmox.WebGUI.Forms.SplitContainer mainSplit;
        private Gizmox.WebGUI.Forms.NavigationTabs leftNavigationTabs;

        private Gizmox.WebGUI.Forms.TabPage systemPage;
        private Gizmox.WebGUI.Forms.TabPage myInfoPage;
        private Gizmox.WebGUI.Forms.TabPage myDocPage;
        private Gizmox.WebGUI.Forms.TabPage shareSpaceTab;
        private Gizmox.WebGUI.Forms.TabPage archiveTab;
        private FunctionTree sysFunctionTree;
        private FunctionTree myinfofunctionTree;
        private DirTree myDirTree;
        private DirTree archiveDirTree;
        private Gizmox.WebGUI.Forms.ListView listView1;
        private Gizmox.WebGUI.Forms.MenuItem menuItem4;
        private Gizmox.WebGUI.Forms.MenuItem menuShareFile;
        private Gizmox.WebGUI.Forms.MenuItem menuShareFolder;
        private Gizmox.WebGUI.Forms.MenuItem menuCreateFolder;
        private Gizmox.WebGUI.Forms.MenuItem menuDeleteFolder;

        private Gizmox.WebGUI.Forms.MenuItem menuItem5;
        private Gizmox.WebGUI.Forms.MenuItem menuAddUser;
        private Gizmox.WebGUI.Forms.MenuItem menuDeleteUser;
        private Gizmox.WebGUI.Forms.MenuItem menuAddGroup;
        private Gizmox.WebGUI.Forms.MenuItem menuDeleteGroup;
        private DirTree shareDirTree;
    }
}