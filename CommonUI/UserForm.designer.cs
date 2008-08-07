namespace CommonUI
{
    partial class UserForm
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
            this.label1 = new Gizmox.WebGUI.Forms.Label();
            this.label2 = new Gizmox.WebGUI.Forms.Label();
            this.memberBox = new Gizmox.WebGUI.Forms.TextBox();
            this.label3 = new Gizmox.WebGUI.Forms.Label();
            this.passwordBox = new Gizmox.WebGUI.Forms.TextBox();
            this.nameBox = new Gizmox.WebGUI.Forms.TextBox();
            this.label5 = new Gizmox.WebGUI.Forms.Label();
            this.btnOK = new Gizmox.WebGUI.Forms.Button();
            this.btnCancel = new Gizmox.WebGUI.Forms.Button();
            this.label6 = new Gizmox.WebGUI.Forms.Label();
            this.txtEmail = new Gizmox.WebGUI.Forms.TextBox();
            this.label4 = new Gizmox.WebGUI.Forms.Label();
            this.txtSurePwd = new Gizmox.WebGUI.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Controls.Add(this.label2);
            this.label1.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.label1.Location = new System.Drawing.Point(30, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "用户帐号";
            // 
            // label2
            // 
            this.label2.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 18);
            this.label2.TabIndex = 0;
            this.label2.Text = "用户帐号";
            // 
            // memberBox
            // 
            this.memberBox.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.memberBox.Location = new System.Drawing.Point(104, 34);
            this.memberBox.Name = "memberBox";
            this.memberBox.Size = new System.Drawing.Size(151, 20);
            this.memberBox.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.label3.Location = new System.Drawing.Point(30, 72);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 18);
            this.label3.TabIndex = 0;
            this.label3.Text = "密　　码";
            // 
            // passwordBox
            // 
            this.passwordBox.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.passwordBox.Location = new System.Drawing.Point(104, 67);
            this.passwordBox.Name = "passwordBox";
            this.passwordBox.PasswordChar = '*';
            this.passwordBox.Size = new System.Drawing.Size(150, 20);
            this.passwordBox.TabIndex = 2;
            // 
            // nameBox
            // 
            this.nameBox.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.nameBox.Location = new System.Drawing.Point(104, 144);
            this.nameBox.Name = "nameBox";
            this.nameBox.Size = new System.Drawing.Size(151, 20);
            this.nameBox.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.label5.Location = new System.Drawing.Point(30, 147);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 18);
            this.label5.TabIndex = 0;
            this.label5.Text = "真实姓名";
            // 
            // btnOK
            // 
            this.btnOK.DialogResult = Gizmox.WebGUI.Forms.DialogResult.OK;
            this.btnOK.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.btnOK.Location = new System.Drawing.Point(58, 222);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 3;
            this.btnOK.Text = "确认";
            this.btnOK.TextImageRelation = Gizmox.WebGUI.Forms.TextImageRelation.Overlay;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = Gizmox.WebGUI.Forms.DialogResult.Cancel;
            this.btnCancel.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.btnCancel.Location = new System.Drawing.Point(169, 222);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "取消";
            this.btnCancel.TextImageRelation = Gizmox.WebGUI.Forms.TextImageRelation.Overlay;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // label6
            // 
            this.label6.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.label6.Location = new System.Drawing.Point(44, 184);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(42, 17);
            this.label6.TabIndex = 5;
            this.label6.Text = "E_mail";
            // 
            // txtEmail
            // 
            this.txtEmail.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.txtEmail.Location = new System.Drawing.Point(104, 181);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(151, 20);
            this.txtEmail.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.label4.Location = new System.Drawing.Point(30, 108);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 23);
            this.label4.TabIndex = 7;
            this.label4.Text = "确认密码";
            // 
            // txtSurePwd
            // 
            this.txtSurePwd.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.txtSurePwd.Location = new System.Drawing.Point(103, 105);
            this.txtSurePwd.Name = "txtSurePwd";
            this.txtSurePwd.PasswordChar = '*';
            this.txtSurePwd.Size = new System.Drawing.Size(150, 20);
            this.txtSurePwd.TabIndex = 8;
            // 
            // UserForm
            // 
            this.Controls.Add(this.txtSurePwd);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.nameBox);
            this.Controls.Add(this.passwordBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.memberBox);
            this.Controls.Add(this.label1);
            this.Location = new System.Drawing.Point(15, 15);
            this.Size = new System.Drawing.Size(302, 284);
            this.StartPosition = Gizmox.WebGUI.Forms.FormStartPosition.CenterScreen;
            this.Text = "用户管理";
            this.Load += new System.EventHandler(this.UserForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Gizmox.WebGUI.Forms.Label label1;
        private Gizmox.WebGUI.Forms.TextBox memberBox;
        private Gizmox.WebGUI.Forms.Label label2;
        private Gizmox.WebGUI.Forms.Label label3;
        private Gizmox.WebGUI.Forms.TextBox passwordBox;
        private Gizmox.WebGUI.Forms.TextBox nameBox;
        private Gizmox.WebGUI.Forms.Label label5;
        private Gizmox.WebGUI.Forms.Button btnOK;
        private Gizmox.WebGUI.Forms.Button btnCancel;
        private Gizmox.WebGUI.Forms.Label label6;
        private Gizmox.WebGUI.Forms.TextBox txtEmail;
        private Gizmox.WebGUI.Forms.Label label4;
        private Gizmox.WebGUI.Forms.TextBox txtSurePwd;


    }
}