namespace CommonUI
{
    partial class UserList
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
            this.userListView = new Gizmox.WebGUI.Forms.ListView();
            this.columnHeader1 = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.columnHeader2 = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.columnHeader4 = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.columnHeader3 = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.userContextMenu = new Gizmox.WebGUI.Forms.ContextMenu();
            this.SuspendLayout();
            // 
            // userListView
            // 
            this.userListView.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None;
            this.userListView.Columns.AddRange(new Gizmox.WebGUI.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader4,
            this.columnHeader3});
            this.userListView.ContextMenu = this.userContextMenu;
            this.userListView.DataMember = null;
            this.userListView.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.userListView.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.userListView.GridLines = true;
            this.userListView.ItemsPerPage = 20;
            this.userListView.Location = new System.Drawing.Point(0, 0);
            this.userListView.Name = "userListView";
            this.userListView.Size = new System.Drawing.Size(391, 326);
            this.userListView.TabIndex = 0;
            // 
            // columnHeader1
            // 
            this.columnHeader1.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.columnHeader1.Image = null;
            this.columnHeader1.Text = "用户名";
            this.columnHeader1.Width = 150;
            // 
            // columnHeader2
            // 
            this.columnHeader2.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.columnHeader2.Image = null;
            this.columnHeader2.Text = "真实姓名";
            this.columnHeader2.Width = 150;
            // 
            // columnHeader4
            // 
            this.columnHeader4.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.columnHeader4.Image = null;
            this.columnHeader4.Text = "电子邮件";
            this.columnHeader4.Width = 150;
            // 
            // columnHeader3
            // 
            this.columnHeader3.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.columnHeader3.Image = null;
            this.columnHeader3.Text = "用户类型";
            this.columnHeader3.Width = 150;
            // 
            // userContextMenu
            // 
            this.userContextMenu.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            // 
            // UserList
            // 
            this.Controls.Add(this.userListView);
            this.Location = new System.Drawing.Point(15, 15);
            this.Size = new System.Drawing.Size(391, 326);
            this.Text = "UserList";
            this.Load += new System.EventHandler(this.UserList_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Gizmox.WebGUI.Forms.ListView userListView;
        private Gizmox.WebGUI.Forms.ColumnHeader columnHeader1;
        private Gizmox.WebGUI.Forms.ColumnHeader columnHeader2;
        private Gizmox.WebGUI.Forms.ColumnHeader columnHeader4;
        private Gizmox.WebGUI.Forms.ColumnHeader columnHeader3;
        private Gizmox.WebGUI.Forms.ContextMenu userContextMenu;


    }
}