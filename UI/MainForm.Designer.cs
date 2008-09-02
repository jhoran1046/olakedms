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
            this.menuItem8 = new Gizmox.WebGUI.Forms.MenuItem();
            this.menuItem9 = new Gizmox.WebGUI.Forms.MenuItem();
            this.menuCutFolder = new Gizmox.WebGUI.Forms.MenuItem();
            this.menuCutFile = new Gizmox.WebGUI.Forms.MenuItem();
            this.menuPaste = new Gizmox.WebGUI.Forms.MenuItem();
            this.tableLayoutPanel1 = new Gizmox.WebGUI.Forms.TableLayoutPanel();
            this.mainSplit = new Gizmox.WebGUI.Forms.SplitContainer();
            this.leftNavigationTabs = new Gizmox.WebGUI.Forms.NavigationTabs();
            this.systemPage = new Gizmox.WebGUI.Forms.TabPage();
            this.myInfoPage = new Gizmox.WebGUI.Forms.TabPage();
            this.myDocPage = new Gizmox.WebGUI.Forms.TabPage();
            this.shareSpaceTab = new Gizmox.WebGUI.Forms.TabPage();
            this.archiveTab = new Gizmox.WebGUI.Forms.TabPage();
            this.orgManageTab = new Gizmox.WebGUI.Forms.TabPage();
            this.flowLayoutPanel1 = new Gizmox.WebGUI.Forms.FlowLayoutPanel();
            this.panel1 = new Gizmox.WebGUI.Forms.Panel();
            this.btnLogout = new Gizmox.WebGUI.Forms.Button();
            this.txtTarget = new Gizmox.WebGUI.Forms.TextBox();
            this.btnSearch = new Gizmox.WebGUI.Forms.Button();
            this.searchFullText = new Gizmox.WebGUI.Forms.RadioButton();
            this.searchKeyword = new Gizmox.WebGUI.Forms.RadioButton();
            this.menuItem6 = new Gizmox.WebGUI.Forms.MenuItem();
            this.menuItem7 = new Gizmox.WebGUI.Forms.MenuItem();
            this.listView1 = new Gizmox.WebGUI.Forms.ListView();
            this.chbAllDocument = new Gizmox.WebGUI.Forms.CheckBox();
            this.sysFunctionTree = new CommonUI.FunctionTree();
            this.myinfofunctionTree = new CommonUI.FunctionTree();
            this.myDirTree = new CommonUI.DirTree();
            this.shareDirTree = new CommonUI.DirTree();
            this.archiveDirTree = new CommonUI.DirTree();
            this.orgMgerDirTree = new CommonUI.DirTree();
            this.SuspendLayout();
            // 
            // menuItem8
            // 
            this.menuItem8.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            // 
            // menuItem9
            // 
            this.menuItem9.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            // 
            // menuCutFolder
            // 
            this.menuCutFolder.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            // 
            // menuCutFile
            // 
            this.menuCutFile.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            // 
            // menuPaste
            // 
            this.menuPaste.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None;
            this.tableLayoutPanel1.CellBorderStyle = Gizmox.WebGUI.Forms.TableLayoutPanelCellBorderStyle.None;
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Controls.Add(this.mainSplit, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel1, 0, 0);
            this.tableLayoutPanel1.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.tableLayoutPanel1.GrowStyle = Gizmox.WebGUI.Forms.TableLayoutPanelGrowStyle.AddRows;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 7.07457F));
            this.tableLayoutPanel1.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 92.92543F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1024, 523);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // mainSplit
            // 
            this.mainSplit.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None;
            this.mainSplit.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.Clear;
            this.mainSplit.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mainSplit.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.mainSplit.FixedPanel = Gizmox.WebGUI.Forms.FixedPanel.None;
            this.mainSplit.Location = new System.Drawing.Point(3, 40);
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
            this.mainSplit.Size = new System.Drawing.Size(1018, 480);
            this.mainSplit.SplitterDistance = 339;
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
            this.leftNavigationTabs.Controls.Add(this.orgManageTab);
            this.leftNavigationTabs.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.leftNavigationTabs.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.leftNavigationTabs.Location = new System.Drawing.Point(0, 0);
            this.leftNavigationTabs.Multiline = false;
            this.leftNavigationTabs.Name = "leftNavigationTabs";
            this.leftNavigationTabs.SelectedIndex = 0;
            this.leftNavigationTabs.Size = new System.Drawing.Size(339, 480);
            this.leftNavigationTabs.TabIndex = 0;
            this.leftNavigationTabs.SelectedIndexChanged += new System.EventHandler(this.leftNavigationTabs_SelectedIndexChanged);
            // 
            // systemPage
            // 
            this.systemPage.Controls.Add(this.sysFunctionTree);
            this.systemPage.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.systemPage.Location = new System.Drawing.Point(4, 22);
            this.systemPage.Name = "systemPage";
            this.systemPage.Size = new System.Drawing.Size(331, 454);
            this.systemPage.TabIndex = 0;
            this.systemPage.Text = "系统管理";
            // 
            // myInfoPage
            // 
            this.myInfoPage.Controls.Add(this.myinfofunctionTree);
            this.myInfoPage.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.myInfoPage.Location = new System.Drawing.Point(4, 22);
            this.myInfoPage.Name = "myInfoPage";
            this.myInfoPage.Size = new System.Drawing.Size(331, 454);
            this.myInfoPage.TabIndex = 0;
            this.myInfoPage.Text = "我的信息";
            // 
            // myDocPage
            // 
            this.myDocPage.Controls.Add(this.myDirTree);
            this.myDocPage.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.myDocPage.Location = new System.Drawing.Point(4, 22);
            this.myDocPage.Name = "myDocPage";
            this.myDocPage.Size = new System.Drawing.Size(331, 454);
            this.myDocPage.TabIndex = 1;
            this.myDocPage.Text = "我的文档";
            // 
            // shareSpaceTab
            // 
            this.shareSpaceTab.Controls.Add(this.shareDirTree);
            this.shareSpaceTab.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.shareSpaceTab.Location = new System.Drawing.Point(4, 22);
            this.shareSpaceTab.Name = "shareSpaceTab";
            this.shareSpaceTab.Size = new System.Drawing.Size(331, 454);
            this.shareSpaceTab.TabIndex = 0;
            this.shareSpaceTab.Text = "共享空间";
            // 
            // archiveTab
            // 
            this.archiveTab.Controls.Add(this.archiveDirTree);
            this.archiveTab.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.archiveTab.Location = new System.Drawing.Point(4, 22);
            this.archiveTab.Name = "archiveTab";
            this.archiveTab.Size = new System.Drawing.Size(331, 454);
            this.archiveTab.TabIndex = 0;
            this.archiveTab.Text = "归档区";
            // 
            // orgManageTab
            // 
            this.orgManageTab.Controls.Add(this.orgMgerDirTree);
            this.orgManageTab.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.orgManageTab.Location = new System.Drawing.Point(4, 22);
            this.orgManageTab.Name = "orgManageTab";
            this.orgManageTab.Size = new System.Drawing.Size(331, 454);
            this.orgManageTab.TabIndex = 0;
            this.orgManageTab.Text = "全部目录";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None;
            this.flowLayoutPanel1.Controls.Add(this.panel1);
            this.flowLayoutPanel1.Dock = Gizmox.WebGUI.Forms.DockStyle.Top;
            this.flowLayoutPanel1.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.flowLayoutPanel1.FlowDirection = Gizmox.WebGUI.Forms.FlowDirection.LeftToRight;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(1018, 30);
            this.flowLayoutPanel1.TabIndex = 0;
            this.flowLayoutPanel1.WrapContents = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnLogout);
            this.panel1.Controls.Add(this.txtTarget);
            this.panel1.Controls.Add(this.btnSearch);
            this.panel1.Controls.Add(this.searchFullText);
            this.panel1.Controls.Add(this.searchKeyword);
            this.panel1.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1015, 34);
            this.panel1.TabIndex = 0;
            // 
            // btnLogout
            // 
            this.btnLogout.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.Right;
            this.btnLogout.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.btnLogout.Location = new System.Drawing.Point(928, 4);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(84, 23);
            this.btnLogout.TabIndex = 1;
            this.btnLogout.Text = "注销";
            this.btnLogout.TextImageRelation = Gizmox.WebGUI.Forms.TextImageRelation.Overlay;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // txtTarget
            // 
            this.txtTarget.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.Left;
            this.txtTarget.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.txtTarget.Location = new System.Drawing.Point(6, 6);
            this.txtTarget.Name = "txtTarget";
            this.txtTarget.Size = new System.Drawing.Size(330, 20);
            this.txtTarget.TabIndex = 1;
            // 
            // btnSearch
            // 
            this.btnSearch.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.Top;
            this.btnSearch.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.btnSearch.Location = new System.Drawing.Point(343, 4);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(131, 23);
            this.btnSearch.TabIndex = 0;
            this.btnSearch.Text = "搜索";
            this.btnSearch.TextImageRelation = Gizmox.WebGUI.Forms.TextImageRelation.Overlay;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // searchFullText
            // 
            this.searchFullText.Checked = true;
            this.searchFullText.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.searchFullText.Location = new System.Drawing.Point(591, 8);
            this.searchFullText.Name = "searchFullText";
            this.searchFullText.Size = new System.Drawing.Size(85, 20);
            this.searchFullText.TabIndex = 0;
            this.searchFullText.Text = "全文检索";
            // 
            // searchKeyword
            // 
            this.searchKeyword.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.searchKeyword.Location = new System.Drawing.Point(480, 8);
            this.searchKeyword.Name = "searchKeyword";
            this.searchKeyword.Size = new System.Drawing.Size(89, 20);
            this.searchKeyword.TabIndex = 0;
            this.searchKeyword.Text = "关键字检索";
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
            // chbAllDocument
            // 
            this.chbAllDocument.Anchor = ((Gizmox.WebGUI.Forms.AnchorStyles)((Gizmox.WebGUI.Forms.AnchorStyles.Bottom | Gizmox.WebGUI.Forms.AnchorStyles.Right)));
            this.chbAllDocument.Checked = false;
            this.chbAllDocument.CheckState = Gizmox.WebGUI.Forms.CheckState.Unchecked;
            this.chbAllDocument.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.chbAllDocument.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Standard;
            this.chbAllDocument.Location = new System.Drawing.Point(116, 26);
            this.chbAllDocument.Name = "chbAllDocument";
            this.chbAllDocument.Size = new System.Drawing.Size(78, 21);
            this.chbAllDocument.TabIndex = 3;
            this.chbAllDocument.Text = "全文检索";
            this.chbAllDocument.ThreeState = false;
            // 
            // sysFunctionTree
            // 
            this.sysFunctionTree.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None;
            this.sysFunctionTree.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.sysFunctionTree.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.sysFunctionTree.FunctionList = null;
            this.sysFunctionTree.Location = new System.Drawing.Point(0, 0);
            this.sysFunctionTree.Name = "sysFunctionTree";
            this.sysFunctionTree.Size = new System.Drawing.Size(331, 454);
            this.sysFunctionTree.TabIndex = 0;
            this.sysFunctionTree.Text = "FunctionTree";
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
            this.myDirTree.Size = new System.Drawing.Size(331, 454);
            this.myDirTree.TabIndex = 0;
            this.myDirTree.Text = "DirTree";
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
            this.shareDirTree.Size = new System.Drawing.Size(331, 454);
            this.shareDirTree.TabIndex = 0;
            this.shareDirTree.Text = "DirTree";
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
            this.archiveDirTree.Size = new System.Drawing.Size(331, 454);
            this.archiveDirTree.TabIndex = 0;
            this.archiveDirTree.Text = "DirTree";
            // 
            // orgMgerDirTree
            // 
            this.orgMgerDirTree.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None;
            this.orgMgerDirTree.CurrentUser = null;
            this.orgMgerDirTree.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.orgMgerDirTree.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.orgMgerDirTree.FileListUI = null;
            this.orgMgerDirTree.Location = new System.Drawing.Point(0, 0);
            this.orgMgerDirTree.Name = "orgMgerDirTree";
            this.orgMgerDirTree.RootDir = null;
            this.orgMgerDirTree.RootResourceId = 0;
            this.orgMgerDirTree.Size = new System.Drawing.Size(331, 454);
            this.orgMgerDirTree.TabIndex = 0;
            this.orgMgerDirTree.Text = "DirTree";
            // 
            // MainForm
            // 
            this.Controls.Add(this.tableLayoutPanel1);
            this.Location = new System.Drawing.Point(15, -190);
            this.Size = new System.Drawing.Size(1024, 523);
            this.Text = "文档管理系统";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Gizmox.WebGUI.Forms.TableLayoutPanel tableLayoutPanel1;
        private Gizmox.WebGUI.Forms.MenuItem menuItem6;
        private Gizmox.WebGUI.Forms.MenuItem menuItem7;
        private Gizmox.WebGUI.Forms.MenuItem menuItem8;
        private Gizmox.WebGUI.Forms.MenuItem menuItem9;
        private Gizmox.WebGUI.Forms.MenuItem menuCutFolder;
        private Gizmox.WebGUI.Forms.MenuItem menuCutFile;
        private Gizmox.WebGUI.Forms.MenuItem menuPaste;
        private Gizmox.WebGUI.Forms.SplitContainer mainSplit;
        private Gizmox.WebGUI.Forms.NavigationTabs leftNavigationTabs;

        private Gizmox.WebGUI.Forms.TabPage systemPage;
        private Gizmox.WebGUI.Forms.TabPage myInfoPage;
        private Gizmox.WebGUI.Forms.TabPage myDocPage;
        private Gizmox.WebGUI.Forms.TabPage shareSpaceTab;
        private Gizmox.WebGUI.Forms.TabPage archiveTab;
        private Gizmox.WebGUI.Forms.TabPage orgManageTab;
        private FunctionTree sysFunctionTree;
        private FunctionTree myinfofunctionTree;
        private DirTree myDirTree;
        private DirTree archiveDirTree;
        private DirTree orgMgerDirTree;
        private Gizmox.WebGUI.Forms.ListView listView1;
        private DirTree shareDirTree;
        private Gizmox.WebGUI.Forms.CheckBox chbAllDocument;
        private Gizmox.WebGUI.Forms.FlowLayoutPanel flowLayoutPanel1;
        private Gizmox.WebGUI.Forms.TextBox txtTarget;
        private Gizmox.WebGUI.Forms.Button btnSearch;
        private Gizmox.WebGUI.Forms.RadioButton searchKeyword;
        private Gizmox.WebGUI.Forms.RadioButton searchFullText;
        private Gizmox.WebGUI.Forms.Button btnLogout;
        private Gizmox.WebGUI.Forms.Panel panel1;
    }
}