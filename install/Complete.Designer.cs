namespace install
{
    partial class Complete
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnLast = new System.Windows.Forms.Button();
            this.btnInstall = new System.Windows.Forms.Button();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.txtMemberName = new System.Windows.Forms.TextBox();
            this.txtSurePwd = new System.Windows.Forms.TextBox();
            this.txtMemberPwd = new System.Windows.Forms.TextBox();
            this.txtMember = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnCancel);
            this.groupBox1.Controls.Add(this.btnLast);
            this.groupBox1.Controls.Add(this.btnInstall);
            this.groupBox1.Controls.Add(this.txtEmail);
            this.groupBox1.Controls.Add(this.txtMemberName);
            this.groupBox1.Controls.Add(this.txtSurePwd);
            this.groupBox1.Controls.Add(this.txtMemberPwd);
            this.groupBox1.Controls.Add(this.txtMember);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(333, 273);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "DMS管理员设置";
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(229, 215);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 12;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnLast
            // 
            this.btnLast.Location = new System.Drawing.Point(43, 215);
            this.btnLast.Name = "btnLast";
            this.btnLast.Size = new System.Drawing.Size(75, 23);
            this.btnLast.TabIndex = 11;
            this.btnLast.Text = "上一步";
            this.btnLast.UseVisualStyleBackColor = true;
            this.btnLast.Click += new System.EventHandler(this.btnLast_Click);
            // 
            // btnInstall
            // 
            this.btnInstall.Location = new System.Drawing.Point(135, 215);
            this.btnInstall.Name = "btnInstall";
            this.btnInstall.Size = new System.Drawing.Size(75, 23);
            this.btnInstall.TabIndex = 10;
            this.btnInstall.Text = "安装";
            this.btnInstall.UseVisualStyleBackColor = true;
            this.btnInstall.Click += new System.EventHandler(this.btnInstall_Click);
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(122, 165);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(144, 21);
            this.txtEmail.TabIndex = 9;
            // 
            // txtMemberName
            // 
            this.txtMemberName.Location = new System.Drawing.Point(122, 129);
            this.txtMemberName.Name = "txtMemberName";
            this.txtMemberName.Size = new System.Drawing.Size(144, 21);
            this.txtMemberName.TabIndex = 8;
            // 
            // txtSurePwd
            // 
            this.txtSurePwd.Location = new System.Drawing.Point(122, 93);
            this.txtSurePwd.Name = "txtSurePwd";
            this.txtSurePwd.PasswordChar = '*';
            this.txtSurePwd.Size = new System.Drawing.Size(144, 21);
            this.txtSurePwd.TabIndex = 7;
            // 
            // txtMemberPwd
            // 
            this.txtMemberPwd.Location = new System.Drawing.Point(122, 60);
            this.txtMemberPwd.Name = "txtMemberPwd";
            this.txtMemberPwd.PasswordChar = '*';
            this.txtMemberPwd.Size = new System.Drawing.Size(144, 21);
            this.txtMemberPwd.TabIndex = 6;
            // 
            // txtMember
            // 
            this.txtMember.Location = new System.Drawing.Point(122, 26);
            this.txtMember.Name = "txtMember";
            this.txtMember.Size = new System.Drawing.Size(144, 21);
            this.txtMember.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(53, 174);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 12);
            this.label5.TabIndex = 4;
            this.label5.Text = "E_mail";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(41, 138);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 3;
            this.label4.Text = "真实姓名";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(41, 102);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "确认密码";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(41, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "密　　码";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(41, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "用户账号";
            // 
            // Complete
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(333, 273);
            this.Controls.Add(this.groupBox1);
            this.Name = "Complete";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Complete";
            this.Load += new System.EventHandler(this.Complete_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnLast;
        private System.Windows.Forms.Button btnInstall;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.TextBox txtMemberName;
        private System.Windows.Forms.TextBox txtSurePwd;
        private System.Windows.Forms.TextBox txtMemberPwd;
        private System.Windows.Forms.TextBox txtMember;
        private System.Windows.Forms.Button btnCancel;
    }
}