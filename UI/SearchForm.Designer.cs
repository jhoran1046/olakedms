namespace UI
{
    partial class SearchForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose ( bool disposing )
        {
            if ( disposing && ( components != null ) )
            {
                components.Dispose ( );
            }
            base.Dispose ( disposing );
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent ( )
        {
            this.label1 = new Gizmox.WebGUI.Forms.Label();
            this.targetBox = new Gizmox.WebGUI.Forms.TextBox();
            this.OKBtn = new Gizmox.WebGUI.Forms.Button();
            this.CancelBtn = new Gizmox.WebGUI.Forms.Button();
            this.groupBox1 = new Gizmox.WebGUI.Forms.GroupBox();
            this.currentDirBox = new Gizmox.WebGUI.Forms.CheckBox();
            this.myDirBox = new Gizmox.WebGUI.Forms.CheckBox();
            this.archiveDirBox = new Gizmox.WebGUI.Forms.CheckBox();
            this.shareDirBox = new Gizmox.WebGUI.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.label1.Location = new System.Drawing.Point(35, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "检索文本";
            // 
            // targetBox
            // 
            this.targetBox.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.targetBox.Location = new System.Drawing.Point(99, 34);
            this.targetBox.Name = "targetBox";
            this.targetBox.Size = new System.Drawing.Size(340, 20);
            this.targetBox.TabIndex = 1;
            // 
            // OKBtn
            // 
            this.OKBtn.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.OKBtn.Location = new System.Drawing.Point(86, 263);
            this.OKBtn.Name = "OKBtn";
            this.OKBtn.Size = new System.Drawing.Size(75, 23);
            this.OKBtn.TabIndex = 2;
            this.OKBtn.Text = "搜索";
            this.OKBtn.TextImageRelation = Gizmox.WebGUI.Forms.TextImageRelation.Overlay;
            this.OKBtn.Click += new System.EventHandler(this.OKBtn_Click);
            // 
            // CancelBtn
            // 
            this.CancelBtn.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.CancelBtn.Location = new System.Drawing.Point(322, 263);
            this.CancelBtn.Name = "CancelBtn";
            this.CancelBtn.Size = new System.Drawing.Size(75, 23);
            this.CancelBtn.TabIndex = 3;
            this.CancelBtn.Text = "退出";
            this.CancelBtn.TextImageRelation = Gizmox.WebGUI.Forms.TextImageRelation.Overlay;
            this.CancelBtn.Click += new System.EventHandler(this.CancelBtn_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.shareDirBox);
            this.groupBox1.Controls.Add(this.archiveDirBox);
            this.groupBox1.Controls.Add(this.myDirBox);
            this.groupBox1.Controls.Add(this.currentDirBox);
            this.groupBox1.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.groupBox1.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.groupBox1.Location = new System.Drawing.Point(38, 85);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(401, 157);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.Text = "检索范围";
            // 
            // currentDirBox
            // 
            this.currentDirBox.Checked = false;
            this.currentDirBox.CheckState = Gizmox.WebGUI.Forms.CheckState.Unchecked;
            this.currentDirBox.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.currentDirBox.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Standard;
            this.currentDirBox.Location = new System.Drawing.Point(48, 28);
            this.currentDirBox.Name = "currentDirBox";
            this.currentDirBox.Size = new System.Drawing.Size(104, 24);
            this.currentDirBox.TabIndex = 0;
            this.currentDirBox.Text = "当前目录";
            this.currentDirBox.ThreeState = false;
            // 
            // myDirBox
            // 
            this.myDirBox.Checked = false;
            this.myDirBox.CheckState = Gizmox.WebGUI.Forms.CheckState.Unchecked;
            this.myDirBox.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.myDirBox.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Standard;
            this.myDirBox.Location = new System.Drawing.Point(48, 58);
            this.myDirBox.Name = "myDirBox";
            this.myDirBox.Size = new System.Drawing.Size(104, 24);
            this.myDirBox.TabIndex = 1;
            this.myDirBox.Text = "我的文档";
            this.myDirBox.ThreeState = false;
            // 
            // archiveDirBox
            // 
            this.archiveDirBox.Checked = false;
            this.archiveDirBox.CheckState = Gizmox.WebGUI.Forms.CheckState.Unchecked;
            this.archiveDirBox.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.archiveDirBox.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Standard;
            this.archiveDirBox.Location = new System.Drawing.Point(48, 88);
            this.archiveDirBox.Name = "archiveDirBox";
            this.archiveDirBox.Size = new System.Drawing.Size(104, 24);
            this.archiveDirBox.TabIndex = 2;
            this.archiveDirBox.Text = "归档区";
            this.archiveDirBox.ThreeState = false;
            // 
            // shareDirBox
            // 
            this.shareDirBox.Checked = false;
            this.shareDirBox.CheckState = Gizmox.WebGUI.Forms.CheckState.Unchecked;
            this.shareDirBox.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.shareDirBox.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Standard;
            this.shareDirBox.Location = new System.Drawing.Point(48, 118);
            this.shareDirBox.Name = "shareDirBox";
            this.shareDirBox.Size = new System.Drawing.Size(104, 24);
            this.shareDirBox.TabIndex = 3;
            this.shareDirBox.Text = "共享目录";
            this.shareDirBox.ThreeState = false;
            // 
            // SearchForm
            // 
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.CancelBtn);
            this.Controls.Add(this.OKBtn);
            this.Controls.Add(this.targetBox);
            this.Controls.Add(this.label1);
            this.Location = new System.Drawing.Point(15, -73);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Size = new System.Drawing.Size(473, 299);
            this.StartPosition = Gizmox.WebGUI.Forms.FormStartPosition.CenterScreen;
            this.Text = "全文检索";
            this.ResumeLayout(false);

        }

        #endregion

        private Gizmox.WebGUI.Forms.Label label1;
        private Gizmox.WebGUI.Forms.TextBox targetBox;
        private Gizmox.WebGUI.Forms.Button OKBtn;
        private Gizmox.WebGUI.Forms.Button CancelBtn;
        private Gizmox.WebGUI.Forms.GroupBox groupBox1;
        private Gizmox.WebGUI.Forms.CheckBox currentDirBox;
        private Gizmox.WebGUI.Forms.CheckBox shareDirBox;
        private Gizmox.WebGUI.Forms.CheckBox archiveDirBox;
        private Gizmox.WebGUI.Forms.CheckBox myDirBox;



    }
}