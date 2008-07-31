namespace CommonUI
{
    partial class MyApplyUsrCrl
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
            this.lsvMyApply = new Gizmox.WebGUI.Forms.ListView();
            this.columnName = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.columnApplyer = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.columnComment = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.columnState = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.columnCrTime = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.listContextMenu = new Gizmox.WebGUI.Forms.ContextMenu();
            this.SuspendLayout();
            // 
            // lsvMyApply
            // 
            this.lsvMyApply.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None;
            this.lsvMyApply.Columns.AddRange(new Gizmox.WebGUI.Forms.ColumnHeader[] {
            this.columnName,
            this.columnApplyer,
            this.columnComment,
            this.columnState,
            this.columnCrTime});
            this.lsvMyApply.ContextMenu = this.listContextMenu;
            this.lsvMyApply.DataMember = null;
            this.lsvMyApply.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.lsvMyApply.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.lsvMyApply.ItemsPerPage = 20;
            this.lsvMyApply.Location = new System.Drawing.Point(0, 0);
            this.lsvMyApply.Name = "lsvMyApply";
            this.lsvMyApply.Size = new System.Drawing.Size(637, 493);
            this.lsvMyApply.TabIndex = 0;
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
            // columnCrTime
            // 
            this.columnCrTime.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.columnCrTime.Image = null;
            this.columnCrTime.Text = "…Í«Î ±º‰";
            this.columnCrTime.Width = 150;
            // 
            // listContextMenu
            // 
            this.listContextMenu.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            // 
            // MyApplyUsrCrl
            // 
            this.Controls.Add(this.lsvMyApply);
            this.Location = new System.Drawing.Point(15, 15);
            this.Size = new System.Drawing.Size(637, 493);
            this.Text = "MyApplyUsrCrl";
            this.Load += new System.EventHandler(this.MyApplyUsrCrl_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Gizmox.WebGUI.Forms.ListView lsvMyApply;
        private Gizmox.WebGUI.Forms.ColumnHeader columnName;
        private Gizmox.WebGUI.Forms.ColumnHeader columnApplyer;
        private Gizmox.WebGUI.Forms.ColumnHeader columnState;
        private Gizmox.WebGUI.Forms.ColumnHeader columnCrTime;
        private Gizmox.WebGUI.Forms.ColumnHeader columnComment;
        private Gizmox.WebGUI.Forms.ContextMenu listContextMenu;


    }
}