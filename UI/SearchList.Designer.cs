namespace UI
{
    partial class SearchList
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

        #region Visual WebGui UserControl Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.searchListView = new Gizmox.WebGUI.Forms.ListView();
            this.columnHeader1 = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.columnHeader2 = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.searchContextMenu = new Gizmox.WebGUI.Forms.ContextMenu();
            this.SuspendLayout();
            // 
            // searchListView
            // 
            this.searchListView.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None;
            this.searchListView.Columns.AddRange(new Gizmox.WebGUI.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.searchListView.ContextMenu = this.searchContextMenu;
            this.searchListView.DataMember = null;
            this.searchListView.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.searchListView.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.searchListView.ItemsPerPage = 20;
            this.searchListView.Location = new System.Drawing.Point(0, 0);
            this.searchListView.MultiSelect = false;
            this.searchListView.Name = "searchListView";
            this.searchListView.Size = new System.Drawing.Size(391, 326);
            this.searchListView.TabIndex = 0;
            // 
            // columnHeader1
            // 
            this.columnHeader1.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.columnHeader1.Image = null;
            this.columnHeader1.Text = "文件名";
            this.columnHeader1.Width = 150;
            // 
            // columnHeader2
            // 
            this.columnHeader2.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.columnHeader2.Image = null;
            this.columnHeader2.Text = "文件路径";
            this.columnHeader2.Width = 300;
            // 
            // searchContextMenu
            // 
            this.searchContextMenu.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            // 
            // SearchList
            // 
            this.Controls.Add(this.searchListView);
            this.Location = new System.Drawing.Point(15, 15);
            this.Size = new System.Drawing.Size(391, 326);
            this.Text = "SearchList";
            this.ResumeLayout(false);

        }

        #endregion

        private Gizmox.WebGUI.Forms.ListView searchListView;
        private Gizmox.WebGUI.Forms.ColumnHeader columnHeader1;
        private Gizmox.WebGUI.Forms.ColumnHeader columnHeader2;
        private Gizmox.WebGUI.Forms.ContextMenu searchContextMenu;


    }
}