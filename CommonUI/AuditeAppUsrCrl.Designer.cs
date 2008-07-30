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
            this.chbAllSelect = new Gizmox.WebGUI.Forms.CheckBox();
            this.btnAccept = new Gizmox.WebGUI.Forms.Button();
            this.btnReject = new Gizmox.WebGUI.Forms.Button();
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
            this.lsvOrgApply.DataMember = null;
            this.lsvOrgApply.Dock = Gizmox.WebGUI.Forms.DockStyle.Top;
            this.lsvOrgApply.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.lsvOrgApply.ItemsPerPage = 20;
            this.lsvOrgApply.Location = new System.Drawing.Point(0, 0);
            this.lsvOrgApply.Name = "lsvOrgApply";
            this.lsvOrgApply.Size = new System.Drawing.Size(632, 326);
            this.lsvOrgApply.TabIndex = 0;
            // 
            // columnName
            // 
            this.columnName.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.columnName.Image = null;
            this.columnName.Text = "Ãû³Æ";
            this.columnName.Width = 110;
            // 
            // columnApplyer
            // 
            this.columnApplyer.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.columnApplyer.Image = null;
            this.columnApplyer.Text = "ÉêÇëÈË";
            this.columnApplyer.Width = 110;
            // 
            // columnComment
            // 
            this.columnComment.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.columnComment.Image = null;
            this.columnComment.Text = "×¢½â";
            this.columnComment.Width = 150;
            // 
            // columnState
            // 
            this.columnState.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.columnState.Image = null;
            this.columnState.Text = "×´Ì¬";
            this.columnState.Width = 110;
            // 
            // columnCreTime
            // 
            this.columnCreTime.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.columnCreTime.Image = null;
            this.columnCreTime.Text = "ÉêÇëÊ±¼ä";
            this.columnCreTime.Width = 150;
            // 
            // chbAllSelect
            // 
            this.chbAllSelect.Checked = false;
            this.chbAllSelect.CheckState = Gizmox.WebGUI.Forms.CheckState.Unchecked;
            this.chbAllSelect.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.chbAllSelect.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Standard;
            this.chbAllSelect.Location = new System.Drawing.Point(151, 348);
            this.chbAllSelect.Name = "chbAllSelect";
            this.chbAllSelect.Size = new System.Drawing.Size(57, 24);
            this.chbAllSelect.TabIndex = 1;
            this.chbAllSelect.Text = "È«Ñ¡";
            this.chbAllSelect.ThreeState = false;
            this.chbAllSelect.Click += new System.EventHandler(this.chbAllSelect_Click);
            // 
            // btnAccept
            // 
            this.btnAccept.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.btnAccept.Location = new System.Drawing.Point(241, 349);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(75, 23);
            this.btnAccept.TabIndex = 2;
            this.btnAccept.Text = "ÉóºË";
            this.btnAccept.TextImageRelation = Gizmox.WebGUI.Forms.TextImageRelation.Overlay;
            this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
            // 
            // btnReject
            // 
            this.btnReject.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.btnReject.Location = new System.Drawing.Point(343, 349);
            this.btnReject.Name = "btnReject";
            this.btnReject.Size = new System.Drawing.Size(75, 23);
            this.btnReject.TabIndex = 3;
            this.btnReject.Text = "¾Ü¾ø";
            this.btnReject.TextImageRelation = Gizmox.WebGUI.Forms.TextImageRelation.Overlay;
            this.btnReject.Click += new System.EventHandler(this.btnReject_Click);
            // 
            // AuditeAppUsrCrl
            // 
            this.Controls.Add(this.btnReject);
            this.Controls.Add(this.btnAccept);
            this.Controls.Add(this.chbAllSelect);
            this.Controls.Add(this.lsvOrgApply);
            this.Location = new System.Drawing.Point(15, -69);
            this.Size = new System.Drawing.Size(632, 430);
            this.Text = "AuditeAppUsrCrl";
            this.Load += new System.EventHandler(this.AuditeAppUsrCrl_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Gizmox.WebGUI.Forms.ListView lsvOrgApply;
        private Gizmox.WebGUI.Forms.ColumnHeader columnName;
        private Gizmox.WebGUI.Forms.CheckBox chbAllSelect;
        private Gizmox.WebGUI.Forms.Button btnAccept;
        private Gizmox.WebGUI.Forms.Button btnReject;
        private Gizmox.WebGUI.Forms.ColumnHeader columnApplyer;
        private Gizmox.WebGUI.Forms.ColumnHeader columnComment;
        private Gizmox.WebGUI.Forms.ColumnHeader columnState;
        private Gizmox.WebGUI.Forms.ColumnHeader columnCreTime;


    }
}