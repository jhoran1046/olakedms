namespace UI
{
    partial class ManageAppForm
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
            this.txtComment = new Gizmox.WebGUI.Forms.TextBox();
            this.label1 = new Gizmox.WebGUI.Forms.Label();
            this.btnAccept = new Gizmox.WebGUI.Forms.Button();
            this.btnRefuse = new Gizmox.WebGUI.Forms.Button();
            this.flowLayoutPanel1 = new Gizmox.WebGUI.Forms.FlowLayoutPanel();
            this.lsvAppInfo = new Gizmox.WebGUI.Forms.ListView();
            this.CoDocName = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.CoApplyer = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.CoComment = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.CoAuditing = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.SuspendLayout();
            // 
            // txtComment
            // 
            this.txtComment.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.txtComment.Font = new System.Drawing.Font("Tahoma", 10F);
            this.txtComment.Location = new System.Drawing.Point(50, 3);
            this.txtComment.Multiline = true;
            this.txtComment.Name = "txtComment";
            this.txtComment.ScrollBars = Gizmox.WebGUI.Forms.ScrollBars.Vertical;
            this.txtComment.Size = new System.Drawing.Size(228, 70);
            this.txtComment.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.label1.Font = new System.Drawing.Font("Tahoma", 10F);
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "×¢½â";
            // 
            // btnAccept
            // 
            this.btnAccept.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None;
            this.btnAccept.Dock = Gizmox.WebGUI.Forms.DockStyle.Bottom;
            this.btnAccept.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.btnAccept.Font = new System.Drawing.Font("Tahoma", 10F);
            this.btnAccept.Location = new System.Drawing.Point(284, 50);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(75, 23);
            this.btnAccept.TabIndex = 3;
            this.btnAccept.Text = "Í¬Òâ";
            this.btnAccept.TextImageRelation = Gizmox.WebGUI.Forms.TextImageRelation.Overlay;
            this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
            // 
            // btnRefuse
            // 
            this.btnRefuse.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None;
            this.btnRefuse.Dock = Gizmox.WebGUI.Forms.DockStyle.Bottom;
            this.btnRefuse.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.btnRefuse.Font = new System.Drawing.Font("Tahoma", 10F);
            this.btnRefuse.Location = new System.Drawing.Point(365, 50);
            this.btnRefuse.Name = "btnRefuse";
            this.btnRefuse.Size = new System.Drawing.Size(75, 23);
            this.btnRefuse.TabIndex = 4;
            this.btnRefuse.Text = "¾Ü¾ø";
            this.btnRefuse.TextImageRelation = Gizmox.WebGUI.Forms.TextImageRelation.Overlay;
            this.btnRefuse.Click += new System.EventHandler(this.btnRefuse_Click);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None;
            this.flowLayoutPanel1.Controls.Add(this.label1);
            this.flowLayoutPanel1.Controls.Add(this.txtComment);
            this.flowLayoutPanel1.Controls.Add(this.btnAccept);
            this.flowLayoutPanel1.Controls.Add(this.btnRefuse);
            this.flowLayoutPanel1.Dock = Gizmox.WebGUI.Forms.DockStyle.Bottom;
            this.flowLayoutPanel1.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.flowLayoutPanel1.FlowDirection = Gizmox.WebGUI.Forms.FlowDirection.LeftToRight;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 184);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(623, 119);
            this.flowLayoutPanel1.TabIndex = 5;
            this.flowLayoutPanel1.WrapContents = false;
            // 
            // lsvAppInfo
            // 
            this.lsvAppInfo.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None;
            this.lsvAppInfo.CheckBoxes = true;
            this.lsvAppInfo.Columns.AddRange(new Gizmox.WebGUI.Forms.ColumnHeader[] {
            this.CoDocName,
            this.CoApplyer,
            this.CoComment,
            this.CoAuditing});
            this.lsvAppInfo.DataMember = null;
            this.lsvAppInfo.Dock = Gizmox.WebGUI.Forms.DockStyle.Top;
            this.lsvAppInfo.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.lsvAppInfo.ItemsPerPage = 20;
            this.lsvAppInfo.Location = new System.Drawing.Point(0, 0);
            this.lsvAppInfo.Name = "lsvAppInfo";
            this.lsvAppInfo.Size = new System.Drawing.Size(623, 161);
            this.lsvAppInfo.TabIndex = 6;
            this.lsvAppInfo.SelectedIndexChanged += new System.EventHandler(this.lsvAppInfo_SelectedIndexChanged);
            // 
            // CoDocName
            // 
            this.CoDocName.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.CoDocName.Image = null;
            this.CoDocName.Text = "Ãû³Æ";
            this.CoDocName.Width = 150;
            // 
            // CoApplyer
            // 
            this.CoApplyer.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.CoApplyer.Image = null;
            this.CoApplyer.Text = "ÉêÇëÈË";
            this.CoApplyer.Width = 150;
            // 
            // CoComment
            // 
            this.CoComment.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.CoComment.Image = null;
            this.CoComment.Text = "×¢½â";
            this.CoComment.Width = 150;
            // 
            // CoAuditing
            // 
            this.CoAuditing.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.CoAuditing.Image = null;
            this.CoAuditing.Text = "×´Ì¬";
            this.CoAuditing.Width = 150;
            // 
            // ManageAppForm
            // 
            this.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None;
            this.Controls.Add(this.lsvAppInfo);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.Location = new System.Drawing.Point(15, 15);
            this.Size = new System.Drawing.Size(623, 303);
            this.Text = "ÉóºË¹éµµÉêÇë";
            this.Load += new System.EventHandler(this.ManageAppForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Gizmox.WebGUI.Forms.TextBox txtComment;
        private Gizmox.WebGUI.Forms.Label label1;
        private Gizmox.WebGUI.Forms.Button btnAccept;
        private Gizmox.WebGUI.Forms.Button btnRefuse;
        private Gizmox.WebGUI.Forms.FlowLayoutPanel flowLayoutPanel1;
        private Gizmox.WebGUI.Forms.ListView lsvAppInfo;
        private Gizmox.WebGUI.Forms.ColumnHeader CoDocName;
        private Gizmox.WebGUI.Forms.ColumnHeader CoApplyer;
        private Gizmox.WebGUI.Forms.ColumnHeader CoComment;
        private Gizmox.WebGUI.Forms.ColumnHeader CoAuditing;

    }
}