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
            this.btnDisfrock = new Gizmox.WebGUI.Forms.Button();
            this.ckbAllSelected = new Gizmox.WebGUI.Forms.CheckBox();
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
            this.lsvMyApply.DataMember = null;
            this.lsvMyApply.Dock = Gizmox.WebGUI.Forms.DockStyle.Top;
            this.lsvMyApply.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.lsvMyApply.ItemsPerPage = 20;
            this.lsvMyApply.Location = new System.Drawing.Point(0, 0);
            this.lsvMyApply.Name = "lsvMyApply";
            this.lsvMyApply.Size = new System.Drawing.Size(637, 438);
            this.lsvMyApply.TabIndex = 0;
            // 
            // columnName
            // 
            this.columnName.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.columnName.Image = null;
            this.columnName.Text = "名称";
            this.columnName.Width = 110;
            // 
            // columnApplyer
            // 
            this.columnApplyer.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.columnApplyer.Image = null;
            this.columnApplyer.Text = "申请人";
            this.columnApplyer.Width = 110;
            // 
            // columnComment
            // 
            this.columnComment.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.columnComment.Image = null;
            this.columnComment.Text = "注解";
            this.columnComment.Width = 150;
            // 
            // columnState
            // 
            this.columnState.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.columnState.Image = null;
            this.columnState.Text = "状态";
            this.columnState.Width = 110;
            // 
            // columnCrTime
            // 
            this.columnCrTime.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.columnCrTime.Image = null;
            this.columnCrTime.Text = "申请时间";
            this.columnCrTime.Width = 150;
            // 
            // btnDisfrock
            // 
            this.btnDisfrock.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.btnDisfrock.Location = new System.Drawing.Point(326, 455);
            this.btnDisfrock.Name = "btnDisfrock";
            this.btnDisfrock.Size = new System.Drawing.Size(75, 23);
            this.btnDisfrock.TabIndex = 1;
            this.btnDisfrock.Text = "撤销申请";
            this.btnDisfrock.TextImageRelation = Gizmox.WebGUI.Forms.TextImageRelation.Overlay;
            this.btnDisfrock.Click += new System.EventHandler(this.btnDisfrock_Click);
            // 
            // ckbAllSelected
            // 
            this.ckbAllSelected.Checked = false;
            this.ckbAllSelected.CheckState = Gizmox.WebGUI.Forms.CheckState.Unchecked;
            this.ckbAllSelected.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.ckbAllSelected.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Standard;
            this.ckbAllSelected.Location = new System.Drawing.Point(244, 454);
            this.ckbAllSelected.Name = "ckbAllSelected";
            this.ckbAllSelected.Size = new System.Drawing.Size(61, 24);
            this.ckbAllSelected.TabIndex = 3;
            this.ckbAllSelected.Text = "全选";
            this.ckbAllSelected.ThreeState = false;
            this.ckbAllSelected.Click += new System.EventHandler(this.ckbAllSelected_Click);
            // 
            // MyApplyUsrCrl
            // 
            this.Controls.Add(this.ckbAllSelected);
            this.Controls.Add(this.btnDisfrock);
            this.Controls.Add(this.lsvMyApply);
            this.Location = new System.Drawing.Point(15, -132);
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
        private Gizmox.WebGUI.Forms.Button btnDisfrock;
        private Gizmox.WebGUI.Forms.CheckBox ckbAllSelected;


    }
}