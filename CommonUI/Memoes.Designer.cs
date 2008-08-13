namespace CommonUI
{
    partial class Memoes
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
            this.btnStart = new Gizmox.WebGUI.Forms.Button();
            this.prgbMemo = new Gizmox.WebGUI.Forms.ProgressBar();
            this.groupBox1 = new Gizmox.WebGUI.Forms.GroupBox();
            this.fbdialogSave = new Gizmox.WebGUI.Forms.FolderBrowserDialog();
            this.SuspendLayout();
            // 
            // btnStart
            // 
            this.btnStart.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.btnStart.Location = new System.Drawing.Point(6, 19);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 23);
            this.btnStart.TabIndex = 0;
            this.btnStart.Text = "开始备份";
            this.btnStart.TextImageRelation = Gizmox.WebGUI.Forms.TextImageRelation.Overlay;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // prgbMemo
            // 
            this.prgbMemo.Anchor = ((Gizmox.WebGUI.Forms.AnchorStyles)(((Gizmox.WebGUI.Forms.AnchorStyles.Bottom | Gizmox.WebGUI.Forms.AnchorStyles.Left)
                        | Gizmox.WebGUI.Forms.AnchorStyles.Right)));
            this.prgbMemo.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.prgbMemo.Location = new System.Drawing.Point(133, 238);
            this.prgbMemo.Name = "prgbMemo";
            this.prgbMemo.Size = new System.Drawing.Size(364, 37);
            this.prgbMemo.TabIndex = 2;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None;
            this.groupBox1.Controls.Add(this.btnStart);
            this.groupBox1.Controls.Add(this.prgbMemo);
            this.groupBox1.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.groupBox1.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.groupBox1.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(660, 281);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.Text = "备份本组织文件";
            // 
            // fbdialogSave
            // 
            this.fbdialogSave.RootFolder = System.Environment.SpecialFolder.Desktop;
            // 
            // Memoes
            // 
            this.Controls.Add(this.groupBox1);
            this.Location = new System.Drawing.Point(15, 15);
            this.Size = new System.Drawing.Size(660, 281);
            this.Text = "Memoes";
            this.ResumeLayout(false);

        }

        #endregion

        private Gizmox.WebGUI.Forms.Button btnStart;
        private Gizmox.WebGUI.Forms.ProgressBar prgbMemo;
        private Gizmox.WebGUI.Forms.GroupBox groupBox1;
        private Gizmox.WebGUI.Forms.FolderBrowserDialog fbdialogSave;


    }
}