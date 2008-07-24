namespace CommonUI
{
    partial class MyApplyForm
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
            this.lsvMyApply = new Gizmox.WebGUI.Forms.ListView();
            this.columnDocName = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.columnApplyer = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.columnComment = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.columnState = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.columnApyDate = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.btnDisfrock = new Gizmox.WebGUI.Forms.Button();
            this.chkAllSelect = new Gizmox.WebGUI.Forms.CheckBox();
            this.btnBack = new Gizmox.WebGUI.Forms.Button();
            this.SuspendLayout();
            // 
            // lsvMyApply
            // 
            this.lsvMyApply.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None;
            this.lsvMyApply.Columns.AddRange(new Gizmox.WebGUI.Forms.ColumnHeader[] {
            this.columnDocName,
            this.columnApplyer,
            this.columnComment,
            this.columnState,
            this.columnApyDate});
            this.lsvMyApply.DataMember = null;
            this.lsvMyApply.Dock = Gizmox.WebGUI.Forms.DockStyle.Top;
            this.lsvMyApply.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.lsvMyApply.ItemsPerPage = 20;
            this.lsvMyApply.Location = new System.Drawing.Point(0, 0);
            this.lsvMyApply.Name = "lsvMyApply";
            this.lsvMyApply.Size = new System.Drawing.Size(678, 216);
            this.lsvMyApply.TabIndex = 0;
            // 
            // columnDocName
            // 
            this.columnDocName.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.columnDocName.Image = null;
            this.columnDocName.Text = "名称";
            this.columnDocName.TextAlign = Gizmox.WebGUI.Forms.HorizontalAlignment.Center;
            this.columnDocName.Width = 150;
            // 
            // columnApplyer
            // 
            this.columnApplyer.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.columnApplyer.Image = null;
            this.columnApplyer.Text = "申请人";
            this.columnApplyer.Width = 150;
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
            this.columnState.Width = 150;
            // 
            // columnApyDate
            // 
            this.columnApyDate.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.columnApyDate.Image = null;
            this.columnApyDate.Text = "申请时间";
            this.columnApyDate.Width = 150;
            // 
            // btnDisfrock
            // 
            this.btnDisfrock.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.btnDisfrock.Font = new System.Drawing.Font("Tahoma", 10F);
            this.btnDisfrock.Location = new System.Drawing.Point(181, 233);
            this.btnDisfrock.Name = "btnDisfrock";
            this.btnDisfrock.Size = new System.Drawing.Size(75, 23);
            this.btnDisfrock.TabIndex = 1;
            this.btnDisfrock.Text = "撤销申请";
            this.btnDisfrock.TextImageRelation = Gizmox.WebGUI.Forms.TextImageRelation.Overlay;
            this.btnDisfrock.Click += new System.EventHandler(this.btnDisfrock_Click);
            // 
            // chkAllSelect
            // 
            this.chkAllSelect.Checked = false;
            this.chkAllSelect.CheckState = Gizmox.WebGUI.Forms.CheckState.Unchecked;
            this.chkAllSelect.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.chkAllSelect.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Standard;
            this.chkAllSelect.Location = new System.Drawing.Point(87, 233);
            this.chkAllSelect.Name = "chkAllSelect";
            this.chkAllSelect.Size = new System.Drawing.Size(67, 23);
            this.chkAllSelect.TabIndex = 2;
            this.chkAllSelect.Text = "全选";
            this.chkAllSelect.ThreeState = false;
            this.chkAllSelect.Click += new System.EventHandler(this.chkAllSelect_Click);
            // 
            // btnBack
            // 
            this.btnBack.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.btnBack.Font = new System.Drawing.Font("Tahoma", 10F);
            this.btnBack.Location = new System.Drawing.Point(181, 279);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(75, 23);
            this.btnBack.TabIndex = 3;
            this.btnBack.Text = "完成";
            this.btnBack.TextImageRelation = Gizmox.WebGUI.Forms.TextImageRelation.Overlay;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // MyApplyForm
            // 
            this.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None;
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.chkAllSelect);
            this.Controls.Add(this.btnDisfrock);
            this.Controls.Add(this.lsvMyApply);
            this.Location = new System.Drawing.Point(15, 15);
            this.Size = new System.Drawing.Size(678, 350);
            this.Text = "我的归档申请列表";
            this.Load += new System.EventHandler(this.MyApplyForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Gizmox.WebGUI.Forms.ListView lsvMyApply;
        private Gizmox.WebGUI.Forms.ColumnHeader columnDocName;
        private Gizmox.WebGUI.Forms.ColumnHeader columnApplyer;
        private Gizmox.WebGUI.Forms.ColumnHeader columnComment;
        private Gizmox.WebGUI.Forms.ColumnHeader columnState;
        private Gizmox.WebGUI.Forms.ColumnHeader columnApyDate;
        private Gizmox.WebGUI.Forms.Button btnDisfrock;
        private Gizmox.WebGUI.Forms.CheckBox chkAllSelect;
        private Gizmox.WebGUI.Forms.Button btnBack;


    }
}