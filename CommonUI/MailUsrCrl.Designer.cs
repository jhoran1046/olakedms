namespace CommonUI
{
    partial class MailUsrCrl
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
            this.groupBox1 = new Gizmox.WebGUI.Forms.GroupBox();
            this.label2 = new Gizmox.WebGUI.Forms.Label();
            this.txtSmtp = new Gizmox.WebGUI.Forms.TextBox();
            this.btnSave = new Gizmox.WebGUI.Forms.Button();
            this.txtEmail = new Gizmox.WebGUI.Forms.TextBox();
            this.label1 = new Gizmox.WebGUI.Forms.Label();
            this.button1 = new Gizmox.WebGUI.Forms.Button();
            this.txtPassword = new Gizmox.WebGUI.Forms.TextBox();
            this.label3 = new Gizmox.WebGUI.Forms.Label();
            this.chkBoxSSL = new Gizmox.WebGUI.Forms.CheckBox();
            this.groupBox2 = new Gizmox.WebGUI.Forms.GroupBox();
            this.groupBox3 = new Gizmox.WebGUI.Forms.GroupBox();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None;
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.groupBox1.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.groupBox1.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(652, 328);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.Text = "系统配置";
            // 
            // label2
            // 
            this.label2.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.label2.Location = new System.Drawing.Point(25, 132);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 32);
            this.label2.TabIndex = 5;
            this.label2.Text = "SMTP服务器（发送邮件）";
            // 
            // txtSmtp
            // 
            this.txtSmtp.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.txtSmtp.Location = new System.Drawing.Point(127, 132);
            this.txtSmtp.Name = "txtSmtp";
            this.txtSmtp.Size = new System.Drawing.Size(155, 20);
            this.txtSmtp.TabIndex = 4;
            this.txtSmtp.Text = "smtp.";
            // 
            // btnSave
            // 
            this.btnSave.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.btnSave.Location = new System.Drawing.Point(98, 215);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 3;
            this.btnSave.Text = "保存";
            this.btnSave.TextImageRelation = Gizmox.WebGUI.Forms.TextImageRelation.Overlay;
            // 
            // txtEmail
            // 
            this.txtEmail.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.txtEmail.Location = new System.Drawing.Point(127, 37);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(155, 20);
            this.txtEmail.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.label1.Location = new System.Drawing.Point(47, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "电子邮箱";
            // 
            // button1
            // 
            this.button1.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.button1.Location = new System.Drawing.Point(59, 19);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 6;
            this.button1.Text = "重建索引";
            this.button1.TextImageRelation = Gizmox.WebGUI.Forms.TextImageRelation.Overlay;
            // 
            // txtPassword
            // 
            this.txtPassword.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.txtPassword.Location = new System.Drawing.Point(127, 86);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(155, 20);
            this.txtPassword.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.label3.Location = new System.Drawing.Point(71, 89);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(33, 20);
            this.label3.TabIndex = 8;
            this.label3.Text = "密码";
            // 
            // chkBoxSSL
            // 
            this.chkBoxSSL.Checked = false;
            this.chkBoxSSL.CheckState = Gizmox.WebGUI.Forms.CheckState.Unchecked;
            this.chkBoxSSL.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.chkBoxSSL.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Standard;
            this.chkBoxSSL.Location = new System.Drawing.Point(74, 167);
            this.chkBoxSSL.Name = "chkBoxSSL";
            this.chkBoxSSL.Size = new System.Drawing.Size(208, 24);
            this.chkBoxSSL.TabIndex = 9;
            this.chkBoxSSL.Text = "此服务器要求安全连接（SSL）";
            this.chkBoxSSL.ThreeState = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtEmail);
            this.groupBox2.Controls.Add(this.chkBoxSSL);
            this.groupBox2.Controls.Add(this.btnSave);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.txtPassword);
            this.groupBox2.Controls.Add(this.txtSmtp);
            this.groupBox2.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.groupBox2.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.groupBox2.Location = new System.Drawing.Point(17, 31);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(312, 257);
            this.groupBox2.TabIndex = 10;
            this.groupBox2.Text = "邮件设置";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.button1);
            this.groupBox3.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.groupBox3.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.groupBox3.Location = new System.Drawing.Point(364, 31);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(215, 257);
            this.groupBox3.TabIndex = 11;
            this.groupBox3.Text = "其它";
            // 
            // MailUsrCrl
            // 
            this.Controls.Add(this.groupBox1);
            this.Location = new System.Drawing.Point(15, 15);
            this.Size = new System.Drawing.Size(652, 328);
            this.Text = "MailUsrCrl";
            this.ResumeLayout(false);

        }

        #endregion

        private Gizmox.WebGUI.Forms.GroupBox groupBox1;
        private Gizmox.WebGUI.Forms.Button btnSave;
        private Gizmox.WebGUI.Forms.TextBox txtEmail;
        private Gizmox.WebGUI.Forms.Label label1;
        private Gizmox.WebGUI.Forms.Label label2;
        private Gizmox.WebGUI.Forms.TextBox txtSmtp;
        private Gizmox.WebGUI.Forms.Button button1;
        private Gizmox.WebGUI.Forms.Label label3;
        private Gizmox.WebGUI.Forms.TextBox txtPassword;
        private Gizmox.WebGUI.Forms.CheckBox chkBoxSSL;
        private Gizmox.WebGUI.Forms.GroupBox groupBox2;
        private Gizmox.WebGUI.Forms.GroupBox groupBox3;


    }
}