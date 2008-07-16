namespace CommonUI
{
    partial class DirTree
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
            this.mainTreeView = new Gizmox.WebGUI.Forms.TreeView();
            this.treeContextMenu = new Gizmox.WebGUI.Forms.ContextMenu();
            this.SuspendLayout();
            // 
            // mainTreeView
            // 
            this.mainTreeView.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None;
            this.mainTreeView.ContextMenu = this.treeContextMenu;
            this.mainTreeView.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mainTreeView.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.mainTreeView.Font = new System.Drawing.Font("SimSun", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.mainTreeView.Location = new System.Drawing.Point(0, 0);
            this.mainTreeView.Name = "mainTreeView";
            this.mainTreeView.Size = new System.Drawing.Size(303, 286);
            this.mainTreeView.TabIndex = 0;
            this.mainTreeView.BeforeExpand += new Gizmox.WebGUI.Forms.TreeViewCancelEventHandler(this.mainTreeView_BeforeExpand);
            this.mainTreeView.AfterSelect += new Gizmox.WebGUI.Forms.TreeViewEventHandler(this.mainTreeView_AfterSelect);
            // 
            // treeContextMenu
            // 
            this.treeContextMenu.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            // 
            // DirTree
            // 
            this.Controls.Add(this.mainTreeView);
            this.Location = new System.Drawing.Point(15, 15);
            this.Size = new System.Drawing.Size(303, 306);
            this.Text = "DirTree";
            this.ResumeLayout(false);

        }
        private Gizmox.WebGUI.Forms.TreeView mainTreeView;
        private Gizmox.WebGUI.Forms.ContextMenu treeContextMenu;

        public Gizmox.WebGUI.Forms.TreeView MainTreeView
        {
            get { return mainTreeView; }
            set { mainTreeView = value; }
        }
        #endregion

    

    }
}