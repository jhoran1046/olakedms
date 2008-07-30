namespace CommonUI
{
    partial class ApplyForm
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
            this.txtResId = new Gizmox.WebGUI.Forms.TextBox();
            this.txtComment = new Gizmox.WebGUI.Forms.TextBox();
            this.btnSubmission = new Gizmox.WebGUI.Forms.Button();
            this.label1 = new Gizmox.WebGUI.Forms.Label();
            this.label2 = new Gizmox.WebGUI.Forms.Label();
            this.btnCancel = new Gizmox.WebGUI.Forms.Button();
            this.SuspendLayout();
            // 
            // txtResId
            // 
            this.txtResId.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.txtResId.Location = new System.Drawing.Point(108, 34);
            this.txtResId.Name = "txtResId";
            this.txtResId.ReadOnly = true;
            this.txtResId.Size = new System.Drawing.Size(218, 20);
            this.txtResId.TabIndex = 0;
            // 
            // txtComment
            // 
            this.txtComment.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.txtComment.Location = new System.Drawing.Point(108, 86);
            this.txtComment.Multiline = true;
            this.txtComment.Name = "txtComment";
            this.txtComment.ScrollBars = Gizmox.WebGUI.Forms.ScrollBars.Vertical;
            this.txtComment.Size = new System.Drawing.Size(218, 96);
            this.txtComment.TabIndex = 1;
            this.txtComment.Text = "请在这里填写归档申请理由！";
            // 
            // btnSubmission
            // 
            this.btnSubmission.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.btnSubmission.Font = new System.Drawing.Font("Tahoma", 10F);
            this.btnSubmission.Location = new System.Drawing.Point(127, 211);
            this.btnSubmission.Name = "btnSubmission";
            this.btnSubmission.Size = new System.Drawing.Size(75, 23);
            this.btnSubmission.TabIndex = 2;
            this.btnSubmission.Text = "提交";
            this.btnSubmission.TextImageRelation = Gizmox.WebGUI.Forms.TextImageRelation.Overlay;
            this.btnSubmission.Click += new System.EventHandler(this.btnSubmission_Click);
            // 
            // label1
            // 
            this.label1.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.label1.Location = new System.Drawing.Point(12, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 20);
            this.label1.TabIndex = 3;
            this.label1.Text = "归档文件目录";
            // 
            // label2
            // 
            this.label2.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.label2.Location = new System.Drawing.Point(55, 89);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 17);
            this.label2.TabIndex = 4;
            this.label2.Text = "注解";
            // 
            // btnCancel
            // 
            this.btnCancel.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.btnCancel.Font = new System.Drawing.Font("Tahoma", 10F);
            this.btnCancel.Location = new System.Drawing.Point(229, 211);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "取消";
            this.btnCancel.TextImageRelation = Gizmox.WebGUI.Forms.TextImageRelation.Overlay;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // ApplyForm
            // 
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnSubmission);
            this.Controls.Add(this.txtComment);
            this.Controls.Add(this.txtResId);
            this.Location = new System.Drawing.Point(210, 80);
            this.Size = new System.Drawing.Size(362, 262);
            this.Text = "归档申请";
            this.Load += new System.EventHandler(this.ApplyForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Gizmox.WebGUI.Forms.TextBox txtResId;
        private Gizmox.WebGUI.Forms.TextBox txtComment;
        private Gizmox.WebGUI.Forms.Button btnSubmission;
        private Gizmox.WebGUI.Forms.Label label1;
        private Gizmox.WebGUI.Forms.Label label2;
        private Gizmox.WebGUI.Forms.Button btnCancel;


    }
}