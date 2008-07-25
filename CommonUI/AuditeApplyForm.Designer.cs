namespace CommonUI
{
    partial class AuditeApplyForm
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
            this.btnAccept = new Gizmox.WebGUI.Forms.Button();
            this.btnRefuse = new Gizmox.WebGUI.Forms.Button();
            this.lsvOrgApply = new Gizmox.WebGUI.Forms.ListView();
            this.columnDocName = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.columnApplyer = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.columnComment = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.columnState = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.columnApyDate = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.chkAllSelect = new Gizmox.WebGUI.Forms.CheckBox();
            this.btnBack = new Gizmox.WebGUI.Forms.Button();
            this.AuditeDirTree = new CommonUI.DirTree();
            this.SuspendLayout();
            // 
            // btnAccept
            // 
            this.btnAccept.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.btnAccept.Font = new System.Drawing.Font("Tahoma", 10F);
            this.btnAccept.Location = new System.Drawing.Point(126, 178);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(75, 23);
            this.btnAccept.TabIndex = 3;
            this.btnAccept.Text = "同意";
            this.btnAccept.TextImageRelation = Gizmox.WebGUI.Forms.TextImageRelation.Overlay;
            this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
            // 
            // btnRefuse
            // 
            this.btnRefuse.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.btnRefuse.Font = new System.Drawing.Font("Tahoma", 10F);
            this.btnRefuse.Location = new System.Drawing.Point(126, 228);
            this.btnRefuse.Name = "btnRefuse";
            this.btnRefuse.Size = new System.Drawing.Size(75, 23);
            this.btnRefuse.TabIndex = 4;
            this.btnRefuse.Text = "拒绝";
            this.btnRefuse.TextImageRelation = Gizmox.WebGUI.Forms.TextImageRelation.Overlay;
            this.btnRefuse.Click += new System.EventHandler(this.btnRefuse_Click);
            // 
            // lsvOrgApply
            // 
            this.lsvOrgApply.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None;
            this.lsvOrgApply.Columns.AddRange(new Gizmox.WebGUI.Forms.ColumnHeader[] {
            this.columnDocName,
            this.columnApplyer,
            this.columnComment,
            this.columnState,
            this.columnApyDate});
            this.lsvOrgApply.DataMember = null;
            this.lsvOrgApply.Dock = Gizmox.WebGUI.Forms.DockStyle.Top;
            this.lsvOrgApply.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.lsvOrgApply.ItemsPerPage = 20;
            this.lsvOrgApply.Location = new System.Drawing.Point(0, 0);
            this.lsvOrgApply.Name = "lsvOrgApply";
            this.lsvOrgApply.Size = new System.Drawing.Size(605, 161);
            this.lsvOrgApply.TabIndex = 6;
            // 
            // columnDocName
            // 
            this.columnDocName.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.columnDocName.Image = null;
            this.columnDocName.Text = "名称";
            this.columnDocName.Width = 100;
            // 
            // columnApplyer
            // 
            this.columnApplyer.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.columnApplyer.Image = null;
            this.columnApplyer.Text = "申请人";
            this.columnApplyer.Width = 100;
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
            this.columnState.Width = 100;
            // 
            // columnApyDate
            // 
            this.columnApyDate.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.columnApyDate.Image = null;
            this.columnApyDate.Text = "申请时间";
            this.columnApyDate.Width = 150;
            // 
            // chkAllSelect
            // 
            this.chkAllSelect.Checked = false;
            this.chkAllSelect.CheckState = Gizmox.WebGUI.Forms.CheckState.Unchecked;
            this.chkAllSelect.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.chkAllSelect.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Standard;
            this.chkAllSelect.Font = new System.Drawing.Font("Tahoma", 10F);
            this.chkAllSelect.Location = new System.Drawing.Point(31, 177);
            this.chkAllSelect.Name = "chkAllSelect";
            this.chkAllSelect.Size = new System.Drawing.Size(68, 24);
            this.chkAllSelect.TabIndex = 7;
            this.chkAllSelect.Text = "全选";
            this.chkAllSelect.ThreeState = false;
            this.chkAllSelect.Click += new System.EventHandler(this.chkAllSelect_Click);
            // 
            // btnBack
            // 
            this.btnBack.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.btnBack.Font = new System.Drawing.Font("Tahoma", 10F);
            this.btnBack.Location = new System.Drawing.Point(126, 281);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(75, 23);
            this.btnBack.TabIndex = 8;
            this.btnBack.Text = "完成";
            this.btnBack.TextImageRelation = Gizmox.WebGUI.Forms.TextImageRelation.Overlay;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // AuditeDirTree
            // 
            this.AuditeDirTree.CurrentUser = null;
            this.AuditeDirTree.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.AuditeDirTree.FileListUI = null;
            this.AuditeDirTree.Location = new System.Drawing.Point(241, 177);
            this.AuditeDirTree.Name = "AuditeDirTree";
            this.AuditeDirTree.RootDir = null;
            this.AuditeDirTree.RootResourceId = 0;
            this.AuditeDirTree.Size = new System.Drawing.Size(185, 221);
            this.AuditeDirTree.TabIndex = 9;
            this.AuditeDirTree.Text = "DirTree";
            // 
            // AuditeApplyForm
            // 
            this.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None;
            this.Controls.Add(this.AuditeDirTree);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.chkAllSelect);
            this.Controls.Add(this.btnAccept);
            this.Controls.Add(this.lsvOrgApply);
            this.Controls.Add(this.btnRefuse);
            this.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.Location = new System.Drawing.Point(15, 15);
            this.Size = new System.Drawing.Size(605, 408);
            this.Text = "审核归档申请";
            this.Load += new System.EventHandler(this.ManageAppForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Gizmox.WebGUI.Forms.Button btnAccept;
        private Gizmox.WebGUI.Forms.Button btnRefuse;
        private Gizmox.WebGUI.Forms.ListView lsvOrgApply;
        private Gizmox.WebGUI.Forms.ColumnHeader columnDocName;
        private Gizmox.WebGUI.Forms.ColumnHeader columnApplyer;
        private Gizmox.WebGUI.Forms.ColumnHeader columnComment;
        private Gizmox.WebGUI.Forms.ColumnHeader columnState;
        private Gizmox.WebGUI.Forms.ColumnHeader columnApyDate;
        private Gizmox.WebGUI.Forms.CheckBox chkAllSelect;
        private Gizmox.WebGUI.Forms.Button btnBack;
        private DirTree AuditeDirTree;

    }
}