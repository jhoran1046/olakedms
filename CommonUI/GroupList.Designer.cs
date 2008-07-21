namespace CommonUI
{
    partial class GroupList
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
            this.groupListView = new Gizmox.WebGUI.Forms.ListView();
            this.SuspendLayout();
            // 
            // groupListView
            // 
            this.groupListView.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None;
            this.groupListView.DataMember = null;
            this.groupListView.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.groupListView.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.groupListView.ItemsPerPage = 20;
            this.groupListView.Location = new System.Drawing.Point(0, 0);
            this.groupListView.Name = "groupListView";
            this.groupListView.Size = new System.Drawing.Size(391, 306);
            this.groupListView.TabIndex = 0;
            this.groupListView.View = Gizmox.WebGUI.Forms.View.List;
            // 
            // GroupList
            // 
            this.Controls.Add(this.groupListView);
            this.Size = new System.Drawing.Size(391, 306);
            this.Text = "GroupList";
            this.ResumeLayout(false);

        }

        #endregion

        private Gizmox.WebGUI.Forms.ListView groupListView;


    }
}