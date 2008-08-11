#region Using

using System;
using System.Globalization;


using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common.Interfaces;

using MidLayer;
using System.Security.Cryptography;
using System.Text;
using Framework.Util;
using Gizmox.WebGUI.Common.Resources;

#endregion

namespace UI
{
	#region Logon Class
	
	/// <summary>
	/// Impementation for Logon class.
	/// </summary>
	//[Serializable()]
	public class LogonForm : Form ,ILogonForm
	{
	
		#region Classes

		/// <summary>
		/// Language option class
		/// </summary>
		//[Serializable()]
	    private class LanguageOption
		{
			private string mstrLabel;
			private string mstrCulture;

			/// <summary>
			/// Creates a new <see cref="LanguageOption"/> instance.
			/// </summary>
			/// <param name="strCulture">culture.</param>
			/// <param name="strLabel">label.</param>
			internal LanguageOption(string strCulture,string strLabel)
			{
				mstrCulture = strCulture;
				mstrLabel = strLabel;
			}

			/// <summary>
			/// Gets the culture.
			/// </summary>
			/// <value></value>
			public CultureInfo Culture
			{
				get
				{
					return new CultureInfo(mstrCulture);
				}
			}

			/// <summary>
			/// Returns the language label
			/// </summary>
			/// <returns></returns>
			public override string ToString()
			{
				return mstrLabel;
			}

		}
		#endregion Classes

		#region Class Members

		private TextBox mobjTextUsername;
		private TextBox mobjTextPassword;
		//private ComboBox mobjComboLanguage;
		private Button mobjButtonLogon;
		private Label mobjLabelPassword;
        private Label mobjLabelUsername;
		private CheckBox mobjCheckSavePassword;
		private Button mobjButtonClear;
		private Panel mobjPanelTitle;
		private Panel mobjPanelLine;
		private Label mobjLabelMessage;
        private GroupBox groupBox1;
        private PictureBox pictureBoxName;
        private PictureBox pictureBoxPwd;

		/// <summary>
		/// Required designer variable.
		/// </summary>
        [NonSerialized]
        private System.ComponentModel.Container components = null;

		#endregion


		#region C'Tor/D'Tor

		/// <summary>
		/// Creates a new <see cref="LogonForm"/> instance.
		/// </summary>
		public LogonForm()
		{


			InitializeComponent();

			#region Attach Events

			this.mobjButtonLogon.Click+=new EventHandler(mobjButtonLogon_Click);
			this.mobjButtonClear.Click+=new EventHandler(mobjButtonClear_Click);

			#endregion 


			this.Load+=new EventHandler(Logon_Load);

			this.mobjTextUsername.EnterKeyDown+=new KeyEventHandler(mobjTextUsername_EnterKeyDown);

            this.KeyDown += new KeyEventHandler(LogonForm_KeyDown);
		}

        void LogonForm_KeyDown(object objSender, KeyEventArgs objArgs)
        {
        }

		#endregion 

		#region Windows Form Designer generated code


		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.mobjTextUsername = new Gizmox.WebGUI.Forms.TextBox();
            this.mobjTextPassword = new Gizmox.WebGUI.Forms.TextBox();
            this.mobjButtonLogon = new Gizmox.WebGUI.Forms.Button();
            this.mobjLabelPassword = new Gizmox.WebGUI.Forms.Label();
            this.mobjLabelUsername = new Gizmox.WebGUI.Forms.Label();
            this.mobjCheckSavePassword = new Gizmox.WebGUI.Forms.CheckBox();
            this.mobjButtonClear = new Gizmox.WebGUI.Forms.Button();
            this.mobjPanelTitle = new Gizmox.WebGUI.Forms.Panel();
            this.mobjPanelLine = new Gizmox.WebGUI.Forms.Panel();
            this.mobjLabelMessage = new Gizmox.WebGUI.Forms.Label();
            this.groupBox1 = new Gizmox.WebGUI.Forms.GroupBox();
            this.pictureBoxPwd = new Gizmox.WebGUI.Forms.PictureBox();
            this.pictureBoxName = new Gizmox.WebGUI.Forms.PictureBox();
            this.SuspendLayout();
            // 
            // mobjTextUsername
            // 
            this.mobjTextUsername.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.mobjTextUsername.Location = new System.Drawing.Point(88, 39);
            this.mobjTextUsername.Name = "mobjTextUsername";
            this.mobjTextUsername.Size = new System.Drawing.Size(174, 20);
            this.mobjTextUsername.TabIndex = 0;
            // 
            // mobjTextPassword
            // 
            this.mobjTextPassword.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.mobjTextPassword.Location = new System.Drawing.Point(88, 74);
            this.mobjTextPassword.Name = "mobjTextPassword";
            this.mobjTextPassword.PasswordChar = '*';
            this.mobjTextPassword.Size = new System.Drawing.Size(174, 20);
            this.mobjTextPassword.TabIndex = 1;
            // 
            // mobjButtonLogon
            // 
            this.mobjButtonLogon.Anchor = ((Gizmox.WebGUI.Forms.AnchorStyles)((Gizmox.WebGUI.Forms.AnchorStyles.Bottom | Gizmox.WebGUI.Forms.AnchorStyles.Right)));
            this.mobjButtonLogon.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.mobjButtonLogon.Location = new System.Drawing.Point(64, 147);
            this.mobjButtonLogon.Name = "mobjButtonLogon";
            this.mobjButtonLogon.Size = new System.Drawing.Size(72, 23);
            this.mobjButtonLogon.TabIndex = 5;
            this.mobjButtonLogon.Text = "登录";
            this.mobjButtonLogon.TextImageRelation = Gizmox.WebGUI.Forms.TextImageRelation.Overlay;
            // 
            // mobjLabelPassword
            // 
            this.mobjLabelPassword.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.mobjLabelPassword.Location = new System.Drawing.Point(9, 77);
            this.mobjLabelPassword.Name = "mobjLabelPassword";
            this.mobjLabelPassword.Size = new System.Drawing.Size(64, 17);
            this.mobjLabelPassword.TabIndex = 3;
            this.mobjLabelPassword.Text = "密　　码:";
            // 
            // mobjLabelUsername
            // 
            this.mobjLabelUsername.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.mobjLabelUsername.Location = new System.Drawing.Point(9, 39);
            this.mobjLabelUsername.Name = "mobjLabelUsername";
            this.mobjLabelUsername.Size = new System.Drawing.Size(64, 16);
            this.mobjLabelUsername.TabIndex = 4;
            this.mobjLabelUsername.Text = "用户名称:";
            // 
            // mobjCheckSavePassword
            // 
            this.mobjCheckSavePassword.Checked = false;
            this.mobjCheckSavePassword.CheckState = Gizmox.WebGUI.Forms.CheckState.Unchecked;
            this.mobjCheckSavePassword.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.mobjCheckSavePassword.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Standard;
            this.mobjCheckSavePassword.Location = new System.Drawing.Point(31, 109);
            this.mobjCheckSavePassword.Name = "mobjCheckSavePassword";
            this.mobjCheckSavePassword.Size = new System.Drawing.Size(105, 23);
            this.mobjCheckSavePassword.TabIndex = 3;
            this.mobjCheckSavePassword.Text = "保存密码";
            this.mobjCheckSavePassword.ThreeState = false;
            // 
            // mobjButtonClear
            // 
            this.mobjButtonClear.Anchor = ((Gizmox.WebGUI.Forms.AnchorStyles)((Gizmox.WebGUI.Forms.AnchorStyles.Bottom | Gizmox.WebGUI.Forms.AnchorStyles.Right)));
            this.mobjButtonClear.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.mobjButtonClear.Location = new System.Drawing.Point(157, 147);
            this.mobjButtonClear.Name = "mobjButtonClear";
            this.mobjButtonClear.Size = new System.Drawing.Size(75, 23);
            this.mobjButtonClear.TabIndex = 6;
            this.mobjButtonClear.Text = "清除";
            this.mobjButtonClear.TextImageRelation = Gizmox.WebGUI.Forms.TextImageRelation.Overlay;
            // 
            // mobjPanelTitle
            // 
            this.mobjPanelTitle.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None;
            this.mobjPanelTitle.BackColor = System.Drawing.Color.White;
            this.mobjPanelTitle.Dock = Gizmox.WebGUI.Forms.DockStyle.Top;
            this.mobjPanelTitle.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.mobjPanelTitle.Location = new System.Drawing.Point(0, 0);
            this.mobjPanelTitle.Name = "mobjPanelTitle";
            this.mobjPanelTitle.Size = new System.Drawing.Size(422, 56);
            this.mobjPanelTitle.TabIndex = 7;
            // 
            // mobjPanelLine
            // 
            this.mobjPanelLine.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None;
            this.mobjPanelLine.BackColor = System.Drawing.SystemColors.Desktop;
            this.mobjPanelLine.Dock = Gizmox.WebGUI.Forms.DockStyle.Top;
            this.mobjPanelLine.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.mobjPanelLine.Location = new System.Drawing.Point(0, 56);
            this.mobjPanelLine.Name = "mobjPanelLine";
            this.mobjPanelLine.Size = new System.Drawing.Size(422, 6);
            this.mobjPanelLine.TabIndex = 8;
            // 
            // mobjLabelMessage
            // 
            this.mobjLabelMessage.Anchor = ((Gizmox.WebGUI.Forms.AnchorStyles)(((Gizmox.WebGUI.Forms.AnchorStyles.Top | Gizmox.WebGUI.Forms.AnchorStyles.Left)
                        | Gizmox.WebGUI.Forms.AnchorStyles.Right)));
            this.mobjLabelMessage.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.mobjLabelMessage.ForeColor = System.Drawing.Color.Red;
            this.mobjLabelMessage.Location = new System.Drawing.Point(85, 12);
            this.mobjLabelMessage.Name = "mobjLabelMessage";
            this.mobjLabelMessage.Size = new System.Drawing.Size(213, 24);
            this.mobjLabelMessage.TabIndex = 9;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None;
            this.groupBox1.Controls.Add(this.pictureBoxPwd);
            this.groupBox1.Controls.Add(this.pictureBoxName);
            this.groupBox1.Controls.Add(this.mobjTextUsername);
            this.groupBox1.Controls.Add(this.mobjLabelUsername);
            this.groupBox1.Controls.Add(this.mobjLabelMessage);
            this.groupBox1.Controls.Add(this.mobjTextPassword);
            this.groupBox1.Controls.Add(this.mobjLabelPassword);
            this.groupBox1.Controls.Add(this.mobjCheckSavePassword);
            this.groupBox1.Controls.Add(this.mobjButtonClear);
            this.groupBox1.Controls.Add(this.mobjButtonLogon);
            this.groupBox1.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.groupBox1.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.groupBox1.Location = new System.Drawing.Point(0, 68);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(304, 191);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.Text = "登录系统";
            // 
            // pictureBoxPwd
            // 
            this.pictureBoxPwd.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.pictureBoxPwd.Image = null;
            this.pictureBoxPwd.Location = new System.Drawing.Point(262, 71);
            this.pictureBoxPwd.Name = "pictureBoxPwd";
            this.pictureBoxPwd.Size = new System.Drawing.Size(36, 23);
            this.pictureBoxPwd.SizeMode = Gizmox.WebGUI.Forms.PictureBoxSizeMode.Normal;
            this.pictureBoxPwd.TabIndex = 11;
            // 
            // pictureBoxName
            // 
            this.pictureBoxName.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.pictureBoxName.Image = null;
            this.pictureBoxName.Location = new System.Drawing.Point(263, 36);
            this.pictureBoxName.Name = "pictureBoxName";
            this.pictureBoxName.Size = new System.Drawing.Size(35, 23);
            this.pictureBoxName.SizeMode = Gizmox.WebGUI.Forms.PictureBoxSizeMode.Normal;
            this.pictureBoxName.TabIndex = 10;
            // 
            // LogonForm
            // 
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.mobjPanelLine);
            this.Controls.Add(this.mobjPanelTitle);
            this.Location = new System.Drawing.Point(15, 15);
            this.Size = new System.Drawing.Size(422, 307);
            this.Text = "Login";
            this.ResumeLayout(false);

		}
		#endregion

		private void mobjButtonLogon_Click(object sender, EventArgs e)
		{
           /* MD5 md5 = MD5.Create();
            byte[] bytePwd = md5.ComputeHash(Encoding.Unicode.GetBytes(this.mobjTextPassword.Text.Trim()));
            string resultPwd = System.Text.UTF8Encoding.Unicode.GetString(bytePwd);
            */
            string resultPwd = CHelperClass.UserMd5(this.mobjTextPassword.Text.Trim());
			if(mobjCheckSavePassword.Checked)
			{
				Context.Cookies["Username"] = this.mobjTextUsername.Text;
                Context.Cookies["Password"] = this.mobjTextPassword.Text;

				//Context.Cookies["Password"] = this.mobjTextPassword.Text;
				//Context.Cookies["Lang"] = this.mobjComboLanguage.SelectedIndex.ToString();
			}
			else
			{
				Context.Cookies["Username"] = "";
				Context.Cookies["Password"] = "";
				//Context.Cookies["Lang"] = "0";
			}

            try
            {
                CUserEntity user = new CUserEntity(MidLayerSettings.ConnectionString);
                user = user.Login(mobjTextUsername.Text, resultPwd);
                Context.Session["CurrentUser"] = user;
              //  Context.CurrentUICulture = ((LanguageOption)mobjComboLanguage.SelectedItem).Culture;
                mobjLabelMessage.Text = "";
                Context.Session.IsLoggedOn = true;
            }
            catch (Exception ex)
            {
                mobjLabelMessage.Text = "Invalid username or password.";
                MessageBox.Show("登录失败：" + ex.Message, "文档管理系统", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Context.Session.IsLoggedOn = false;
            }
            /*
			if(this.mobjTextUsername.Text=="webgui" && this.mobjTextPassword.Text=="webgui")
			{
				Context.Session.IsLoggedOn = true;
				Context.CurrentUICulture = ((LanguageOption)mobjComboLanguage.SelectedItem).Culture;
				mobjLabelMessage.Text="";
			}
			else
			{
				mobjLabelMessage.Text = "Invalid username or password.";
				Context.Session.IsLoggedOn = false;
			}
            */
		}

		private void mobjButtonClear_Click(object sender, EventArgs e)
		{
			Context.Session.IsLoggedOn = false;
			mobjLabelMessage.Text="";
			mobjTextUsername.Text="";
            mobjTextPassword.Text = "";
		}

		private void Logon_Load(object sender, EventArgs e)
		{
            pictureBoxName.Image = new IconResourceHandle("usrName.gif");
            pictureBoxPwd.Image = new IconResourceHandle("password.gif");
            if (Context.Cookies["Username"] != "")
            {
                this.mobjTextUsername.Text = Context.Cookies["Username"];
                this.mobjTextPassword.Text = Context.Cookies["Password"];

               /* if (Context.Cookies["Lang"] != "" && Context.Cookies["Lang"] != null)
                {
                    this.mobjComboLanguage.SelectedIndex = int.Parse(Context.Cookies["Lang"]);
                } */
                this.mobjCheckSavePassword.Checked = true;

                this.mobjButtonLogon.Focus();
            }
            else
            {
                this.mobjTextUsername.Focus();
            }
		}

		private void mobjTextUsername_EnterKeyDown(object objSender, KeyEventArgs objArgs)
		{
			mobjButtonLogon_Click(mobjButtonLogon,EventArgs.Empty);
		}
	}
	
	#endregion
}
