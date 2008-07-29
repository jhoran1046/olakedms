namespace CommonUI
{
    partial class FileList
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
            this.fileListView = new Gizmox.WebGUI.Forms.ListView();
            this.columnFilleName = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.columnExt = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.fileContextMenu = new Gizmox.WebGUI.Forms.ContextMenu();
            this.SuspendLayout();
            // 
            // fileListView
            // 
            this.fileListView.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None;
            this.fileListView.CheckBoxes = true;
            this.fileListView.ColumnResizeStyle = Gizmox.WebGUI.Forms.ColumnHeaderAutoResizeStyle.ColumnContent;
            this.fileListView.Columns.AddRange(new Gizmox.WebGUI.Forms.ColumnHeader[] {
            this.columnFilleName,
            this.columnExt});
            this.fileListView.ContextMenu = this.fileContextMenu;
            this.fileListView.DataMember = null;
            this.fileListView.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.fileListView.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.fileListView.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.fileListView.GridLines = true;
            this.fileListView.ItemsPerPage = 22;
            this.fileListView.Location = new System.Drawing.Point(0, 0);
            this.fileListView.MultiSelect = false;
            this.fileListView.Name = "fileListView";
            this.fileListView.Size = new System.Drawing.Size(391, 306);
            this.fileListView.TabIndex = 0;
            this.fileListView.UseInternalPaging = true;
            // 
            // columnFilleName
            // 
            this.columnFilleName.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.columnFilleName.Image = null;
            this.columnFilleName.Text = "文件名";
            this.columnFilleName.Width = 150;
            // 
            // columnExt
            // 
            this.columnExt.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.columnExt.Image = null;
            this.columnExt.Text = "扩展名";
            this.columnExt.Width = 150;
            // 
            // fileContextMenu
            // 
            this.fileContextMenu.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            // 
            // FileList
            // 
            this.Controls.Add(this.fileListView);
            this.Location = new System.Drawing.Point(15, 15);
            this.Size = new System.Drawing.Size(391, 306);
            this.Text = "FileList";
            this.ResumeLayout(false);

        }

        #endregion

        private Gizmox.WebGUI.Forms.ListView fileListView;
        private Gizmox.WebGUI.Forms.ColumnHeader columnFilleName;
        private Gizmox.WebGUI.Forms.ColumnHeader columnExt;
        private Gizmox.WebGUI.Forms.ContextMenu fileContextMenu;

        public Gizmox.WebGUI.Forms.ListView FileListView
        {
            get { return fileListView; }
        }
    }
}