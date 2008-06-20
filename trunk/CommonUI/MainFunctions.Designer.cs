namespace CommonUI
{
    partial class MainFunctions
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

        #region Visual WebGui UserControl Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent ( )
        {
            this.navigationTabs1 = new Gizmox.WebGUI.Forms.NavigationTabs ( );
            this.systemPage = new Gizmox.WebGUI.Forms.TabPage ( );
            this.myInfoPage = new Gizmox.WebGUI.Forms.TabPage ( );
            this.myDocPage = new Gizmox.WebGUI.Forms.TabPage ( );
            this.shareSpaceTab = new Gizmox.WebGUI.Forms.TabPage ( );
            this.archiveTab = new Gizmox.WebGUI.Forms.TabPage ( );
            this.sysFunctionTree = new CommonUI.FunctionTree ( );
            this.myinfofunctionTree = new CommonUI.FunctionTree ( );
            this.myDirTree = new CommonUI.DirTree ( );
            this.shareSpacefunctionTree = new CommonUI.FunctionTree ( );
            this.archiveDirTree = new CommonUI.DirTree ( );
            this.SuspendLayout ( );


            // 
            // sysFunctionTree
            // 
            this.sysFunctionTree.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None;
            this.sysFunctionTree.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.sysFunctionTree.DragTargets = new Gizmox.WebGUI.Forms.Component [ 0 ];
            this.sysFunctionTree.FunctionList = null;
            this.sysFunctionTree.Location = new System.Drawing.Point ( 0 , 0 );
            this.sysFunctionTree.Name = "sysFunctionTree";
            this.sysFunctionTree.Size = new System.Drawing.Size ( 383 , 280 );
            this.sysFunctionTree.TabIndex = 0;
            this.sysFunctionTree.Text = "FunctionTree";
            // 
            // myinfofunctionTree
            // 
            this.myinfofunctionTree.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None;
            this.myinfofunctionTree.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.myinfofunctionTree.DragTargets = new Gizmox.WebGUI.Forms.Component [ 0 ];
            this.myinfofunctionTree.FunctionList = null;
            this.myinfofunctionTree.Location = new System.Drawing.Point ( 0 , 0 );
            this.myinfofunctionTree.Name = "myinfofunctionTree";
            this.myinfofunctionTree.Size = new System.Drawing.Size ( 383 , 280 );
            this.myinfofunctionTree.TabIndex = 0;
            this.myinfofunctionTree.Text = "FunctionTree";
            // 
            // myDirTree
            // 
            this.myDirTree.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None;
            this.myDirTree.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.myDirTree.DragTargets = new Gizmox.WebGUI.Forms.Component [ 0 ];
            this.myDirTree.Location = new System.Drawing.Point ( 0 , 0 );
            this.myDirTree.Name = "myDirTree";
            this.myDirTree.RootDir = null;
            this.myDirTree.Size = new System.Drawing.Size ( 383 , 280 );
            this.myDirTree.TabIndex = 0;
            this.myDirTree.Text = "DirTree";
            // 
            // shareSpacefunctionTree
            // 
            this.shareSpacefunctionTree.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None;
            this.shareSpacefunctionTree.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.shareSpacefunctionTree.DragTargets = new Gizmox.WebGUI.Forms.Component [ 0 ];
            this.shareSpacefunctionTree.FunctionList = null;
            this.shareSpacefunctionTree.Location = new System.Drawing.Point ( 0 , 0 );
            this.shareSpacefunctionTree.Name = "shareSpacefunctionTree";
            this.shareSpacefunctionTree.Size = new System.Drawing.Size ( 383 , 280 );
            this.shareSpacefunctionTree.TabIndex = 0;
            this.shareSpacefunctionTree.Text = "FunctionTree";
            // 
            // archiveDirTree
            // 
            this.archiveDirTree.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None;
            this.archiveDirTree.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.archiveDirTree.DragTargets = new Gizmox.WebGUI.Forms.Component [ 0 ];
            this.archiveDirTree.Location = new System.Drawing.Point ( 0 , 0 );
            this.archiveDirTree.Name = "archiveDirTree";
            this.archiveDirTree.RootDir = null;
            this.archiveDirTree.Size = new System.Drawing.Size ( 383 , 280 );
            this.archiveDirTree.TabIndex = 0;
            this.archiveDirTree.Text = "DirTree";
            // 
            // navigationTabs1
            // 
            this.navigationTabs1.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None;
            this.navigationTabs1.Controls.Add ( this.systemPage );
            this.navigationTabs1.Controls.Add ( this.myInfoPage );
            this.navigationTabs1.Controls.Add ( this.myDocPage );
            this.navigationTabs1.Controls.Add ( this.shareSpaceTab );
            this.navigationTabs1.Controls.Add ( this.archiveTab );
            this.navigationTabs1.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.navigationTabs1.DragTargets = new Gizmox.WebGUI.Forms.Component [ 0 ];
            this.navigationTabs1.Location = new System.Drawing.Point ( 0 , 0 );
            this.navigationTabs1.Multiline = false;
            this.navigationTabs1.Name = "navigationTabs1";
            this.navigationTabs1.SelectedIndex = 0;
            this.navigationTabs1.Size = new System.Drawing.Size ( 391 , 306 );
            this.navigationTabs1.TabIndex = 0;
            this.navigationTabs1.SelectedIndexChanged += new System.EventHandler ( this.navigationTabs1_SelectedIndexChanged );
            // 
            // systemPage
            // 
            this.systemPage.Controls.Add ( this.sysFunctionTree );
            this.systemPage.DragTargets = new Gizmox.WebGUI.Forms.Component [ 0 ];
            this.systemPage.Location = new System.Drawing.Point ( 4 , 22 );
            this.systemPage.Name = "systemPage";
            this.systemPage.Size = new System.Drawing.Size ( 383 , 280 );
            this.systemPage.TabIndex = 0;
            this.systemPage.Text = "系统管理";
            // 
            // myInfoPage
            // 
            this.myInfoPage.Controls.Add ( this.myinfofunctionTree );
            this.myInfoPage.DragTargets = new Gizmox.WebGUI.Forms.Component [ 0 ];
            this.myInfoPage.Location = new System.Drawing.Point ( 4 , 22 );
            this.myInfoPage.Name = "myInfoPage";
            this.myInfoPage.Size = new System.Drawing.Size ( 383 , 280 );
            this.myInfoPage.TabIndex = 0;
            this.myInfoPage.Text = "我的信息";
            // 
            // myDocPage
            // 
            this.myDocPage.Controls.Add ( this.myDirTree );
            this.myDocPage.DragTargets = new Gizmox.WebGUI.Forms.Component [ 0 ];
            this.myDocPage.Location = new System.Drawing.Point ( 4 , 22 );
            this.myDocPage.Name = "myDocPage";
            this.myDocPage.Size = new System.Drawing.Size ( 383 , 280 );
            this.myDocPage.TabIndex = 1;
            this.myDocPage.Text = "我的文档";
            // 
            // shareSpaceTab
            // 
            this.shareSpaceTab.Controls.Add ( this.shareSpacefunctionTree );
            this.shareSpaceTab.DragTargets = new Gizmox.WebGUI.Forms.Component [ 0 ];
            this.shareSpaceTab.Location = new System.Drawing.Point ( 4 , 22 );
            this.shareSpaceTab.Name = "shareSpaceTab";
            this.shareSpaceTab.Size = new System.Drawing.Size ( 383 , 280 );
            this.shareSpaceTab.TabIndex = 0;
            this.shareSpaceTab.Text = "共享空间";
            // 
            // archiveTab
            // 
            this.archiveTab.Controls.Add ( this.archiveDirTree );
            this.archiveTab.DragTargets = new Gizmox.WebGUI.Forms.Component [ 0 ];
            this.archiveTab.Location = new System.Drawing.Point ( 4 , 22 );
            this.archiveTab.Name = "archiveTab";
            this.archiveTab.Size = new System.Drawing.Size ( 383 , 280 );
            this.archiveTab.TabIndex = 0;
            this.archiveTab.Text = "归档区";
        
            // 
            // MainFunctions
            // 
            this.Controls.Add ( this.navigationTabs1 );
            this.Size = new System.Drawing.Size ( 391 , 306 );
            this.Text = "MainFunctions";
            this.ResumeLayout ( false );

        }

        #endregion

        private Gizmox.WebGUI.Forms.NavigationTabs navigationTabs1;
        private Gizmox.WebGUI.Forms.TabPage systemPage;
        private Gizmox.WebGUI.Forms.TabPage myInfoPage;
        private Gizmox.WebGUI.Forms.TabPage myDocPage;
        private Gizmox.WebGUI.Forms.TabPage shareSpaceTab;
        private Gizmox.WebGUI.Forms.TabPage archiveTab;
        private FunctionTree sysFunctionTree;
        private FunctionTree myinfofunctionTree;
        private DirTree myDirTree;
        private FunctionTree shareSpacefunctionTree;
        private DirTree archiveDirTree;


    }
}