namespace CommonUI
{
    partial class ShowArchiveContent
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnOK = new Gizmox.WebGUI.Forms.Button();
            this.btnCancel = new Gizmox.WebGUI.Forms.Button();
            this.label1 = new Gizmox.WebGUI.Forms.Label();
            this.ContentDirTree = new CommonUI.DirTree();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.btnOK.Location = new System.Drawing.Point(78, 275);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 0;
            this.btnOK.Text = "确定";
            this.btnOK.TextImageRelation = Gizmox.WebGUI.Forms.TextImageRelation.Overlay;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.btnCancel.Location = new System.Drawing.Point(168, 275);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "取消";
            this.btnCancel.TextImageRelation = Gizmox.WebGUI.Forms.TextImageRelation.Overlay;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // label1
            // 
            this.label1.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.label1.Font = new System.Drawing.Font("Tahoma", 12F);
            this.label1.Location = new System.Drawing.Point(1, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(131, 23);
            this.label1.TabIndex = 2;
            this.label1.Text = "请选择目标目录";
            // 
            // ContentDirTree
            // 
            this.ContentDirTree.CurrentUser = null;
            this.ContentDirTree.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.ContentDirTree.FileListUI = null;
            this.ContentDirTree.Location = new System.Drawing.Point(39, 35);
            this.ContentDirTree.Name = "ContentDirTree";
            this.ContentDirTree.RootDir = null;
            this.ContentDirTree.RootResourceId = 0;
            this.ContentDirTree.Size = new System.Drawing.Size(245, 234);
            this.ContentDirTree.TabIndex = 3;
            this.ContentDirTree.Text = "DirTree";
            // 
            // ShowArchiveContent
            // 
            this.Controls.Add(this.ContentDirTree);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Location = new System.Drawing.Point(15, 15);
            this.Size = new System.Drawing.Size(337, 310);
            this.Text = "选择目标目录";
            this.Load += new System.EventHandler(this.ShowArchiveContent_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Gizmox.WebGUI.Forms.Button btnOK;
        private Gizmox.WebGUI.Forms.Button btnCancel;
        private Gizmox.WebGUI.Forms.Label label1;
        private DirTree ContentDirTree;


    }
}