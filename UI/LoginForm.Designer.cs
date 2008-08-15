namespace UI
{
    partial class LoginForm
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
            this.memberBox = new Gizmox.WebGUI.Forms.TextBox();
            this.passwordBox = new Gizmox.WebGUI.Forms.TextBox();
            this.label2 = new Gizmox.WebGUI.Forms.Label();
            this.loginBtn = new Gizmox.WebGUI.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.label1.Location = new System.Drawing.Point(64, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "用户名";
            // 
            // memberBox
            // 
            this.memberBox.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.memberBox.Location = new System.Drawing.Point(122, 46);
            this.memberBox.Name = "memberBox";
            this.memberBox.Size = new System.Drawing.Size(180, 20);
            this.memberBox.TabIndex = 1;
            // 
            // passwordBox
            // 
            this.passwordBox.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.passwordBox.Location = new System.Drawing.Point(122, 92);
            this.passwordBox.Name = "passwordBox";
            this.passwordBox.PasswordChar = '*';
            this.passwordBox.Size = new System.Drawing.Size(180, 20);
            this.passwordBox.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.label2.Location = new System.Drawing.Point(64, 92);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 20);
            this.label2.TabIndex = 0;
            this.label2.Text = "密码";
            // 
            // loginBtn
            // 
            this.loginBtn.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.loginBtn.Location = new System.Drawing.Point(150, 138);
            this.loginBtn.Name = "loginBtn";
            this.loginBtn.Size = new System.Drawing.Size(78, 26);
            this.loginBtn.TabIndex = 2;
            this.loginBtn.Text = "登录";
            this.loginBtn.TextImageRelation = Gizmox.WebGUI.Forms.TextImageRelation.Overlay;
            this.loginBtn.Click += new System.EventHandler(this.loginBtn_Click);
            // 
            // LoginForm
            // 
            this.Controls.Add(this.loginBtn);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.passwordBox);
            this.Controls.Add(this.memberBox);
            this.Controls.Add(this.label1);
            this.Location = new System.Drawing.Point(15, 15);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Size = new System.Drawing.Size(366, 196);
            this.Text = "登录文档管理系统";
            this.ResumeLayout(false);

        }

        #endregion

        private Gizmox.WebGUI.Forms.Label label1;
        private Gizmox.WebGUI.Forms.TextBox memberBox;
        private Gizmox.WebGUI.Forms.TextBox passwordBox;
        private Gizmox.WebGUI.Forms.Label label2;
        private Gizmox.WebGUI.Forms.Button loginBtn;


    }
}