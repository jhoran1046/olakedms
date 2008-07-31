namespace CommonUI
{
    partial class AuditeAppUsrCrl
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
            this.lsvOrgApply = new Gizmox.WebGUI.Forms.ListView();
            this.columnName = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.columnApplyer = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.columnComment = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.columnState = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.columnCreTime = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.listContextMenu = new Gizmox.WebGUI.Forms.ContextMenu();
            this.SuspendLayout();
            // 
            // lsvOrgApply
            // 
            this.lsvOrgApply.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None;
            this.lsvOrgApply.Columns.AddRange(new Gizmox.WebGUI.Forms.ColumnHeader[] {
            this.columnName,
            this.columnApplyer,
            this.columnComment,
            this.columnState,
            this.columnCreTime});
            this.lsvOrgApply.ContextMenu = this.listContextMenu;
            this.lsvOrgApply.DataMember = null;
            this.lsvOrgApply.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.lsvOrgApply.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.lsvOrgApply.ItemsPerPage = 20;
            this.lsvOrgApply.Location = new System.Drawing.Point(0, 0);
            this.lsvOrgApply.Name = "lsvOrgApply";
            this.lsvOrgApply.Size = new System.Drawing.Size(632, 430);
            this.lsvOrgApply.TabIndex = 0;
            // 
            // columnName
            // 
            this.columnName.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.columnName.Image = null;
            this.columnName.Text = "√˚≥∆";
            this.columnName.Width = 110;
            // 
            // columnApplyer
            // 
            this.columnApplyer.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.columnApplyer.Image = null;
            this.columnApplyer.Text = "…Í«Î»À";
            this.columnApplyer.Width = 110;
            // 
            // columnComment
            // 
            this.columnComment.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.columnComment.Image = null;
            this.columnComment.Text = "◊¢Ω‚";
            this.columnComment.Width = 150;
            // 
            // columnState
            // 
            this.columnState.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.columnState.Image = null;
            this.columnState.Text = "◊¥Ã¨";
            this.columnState.Width = 110;
            // 
            // columnCreTime
            // 
            this.columnCreTime.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.columnCreTime.Image = null;
            this.columnCreTime.Text = "…Í«Î ±º‰";
            this.columnCreTime.Width = 150;
            // 
            // listContextMenu
            // 
            this.listContextMenu.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            // 
            // AuditeAppUsrCrl
            // 
            this.Controls.Add(this.lsvOrgApply);
            this.Location = new System.Drawing.Point(15, -56);
            this.Size = new System.Drawing.Size(632, 430);
            this.Text = "AuditeAppUsrCrl";
            this.Load += new System.EventHandler(this.AuditeAppUsrCrl_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Gizmox.WebGUI.Forms.ListView lsvOrgApply;
        private Gizmox.WebGUI.Forms.ColumnHeader columnName;
        private Gizmox.WebGUI.Forms.ColumnHeader columnApplyer;
        private Gizmox.WebGUI.Forms.ColumnHeader columnComment;
        private Gizmox.WebGUI.Forms.ColumnHeader columnState;
        private Gizmox.WebGUI.Forms.ColumnHeader columnCreTime;
        private Gizmox.WebGUI.Forms.ContextMenu listContextMenu;


    }
}