namespace UI
{
    partial class SortApplyForm
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
            this.txtDocId = new Gizmox.WebGUI.Forms.TextBox();
            this.txtComment = new Gizmox.WebGUI.Forms.TextBox();
            this.btnSubmission = new Gizmox.WebGUI.Forms.Button();
            this.label1 = new Gizmox.WebGUI.Forms.Label();
            this.label2 = new Gizmox.WebGUI.Forms.Label();
            this.SuspendLayout();
            // 
            // txtDocId
            // 
            this.txtDocId.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.txtDocId.Location = new System.Drawing.Point(108, 34);
            this.txtDocId.Name = "txtDocId";
            this.txtDocId.Size = new System.Drawing.Size(218, 20);
            this.txtDocId.TabIndex = 0;
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
            this.txtComment.Text = "����������д�鵵�������ɣ�";
            // 
            // btnSubmission
            // 
            this.btnSubmission.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.btnSubmission.Font = new System.Drawing.Font("Tahoma", 10F);
            this.btnSubmission.Location = new System.Drawing.Point(181, 211);
            this.btnSubmission.Name = "btnSubmission";
            this.btnSubmission.Size = new System.Drawing.Size(75, 23);
            this.btnSubmission.TabIndex = 2;
            this.btnSubmission.Text = "�ύ";
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
            this.label1.Text = "�鵵�ļ�Ŀ¼";
            // 
            // label2
            // 
            this.label2.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.label2.Location = new System.Drawing.Point(55, 89);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 17);
            this.label2.TabIndex = 4;
            this.label2.Text = "ע��";
            // 
            // SortApplyForm
            // 
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnSubmission);
            this.Controls.Add(this.txtComment);
            this.Controls.Add(this.txtDocId);
            this.Location = new System.Drawing.Point(15, 15);
            this.Size = new System.Drawing.Size(429, 276);
            this.Text = "�鵵����";
            this.Load += new System.EventHandler(this.SortApplyForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Gizmox.WebGUI.Forms.TextBox txtDocId;
        private Gizmox.WebGUI.Forms.TextBox txtComment;
        private Gizmox.WebGUI.Forms.Button btnSubmission;
        private Gizmox.WebGUI.Forms.Label label1;
        private Gizmox.WebGUI.Forms.Label label2;


    }
}