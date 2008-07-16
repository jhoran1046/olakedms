namespace UI
{
    partial class ShareForm
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
            this.btnOK = new Gizmox.WebGUI.Forms.Button();
            this.label1 = new Gizmox.WebGUI.Forms.Label();
            this.label2 = new Gizmox.WebGUI.Forms.Label();
            this.btnAdd = new Gizmox.WebGUI.Forms.Button();
            this.btnRemove = new Gizmox.WebGUI.Forms.Button();
            this.groupBox1 = new Gizmox.WebGUI.Forms.GroupBox();
            this.writeBox = new Gizmox.WebGUI.Forms.CheckBox();
            this.readBox = new Gizmox.WebGUI.Forms.CheckBox();
            this.groupBox2 = new Gizmox.WebGUI.Forms.GroupBox();
            this.addReadBox = new Gizmox.WebGUI.Forms.CheckBox();
            this.addWriteBox = new Gizmox.WebGUI.Forms.CheckBox();
            this.shareList = new Gizmox.WebGUI.Forms.ListView();
            this.columnHeader1 = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.unshareList = new Gizmox.WebGUI.Forms.ListView();
            this.columnHeader2 = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.DialogResult = Gizmox.WebGUI.Forms.DialogResult.OK;
            this.btnOK.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.btnOK.Location = new System.Drawing.Point(319, 308);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 0;
            this.btnOK.Text = "完成";
            this.btnOK.TextImageRelation = Gizmox.WebGUI.Forms.TextImageRelation.Overlay;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // label1
            // 
            this.label1.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.label1.Location = new System.Drawing.Point(18, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 18);
            this.label1.TabIndex = 2;
            this.label1.Text = "已共享用户";
            // 
            // label2
            // 
            this.label2.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.label2.Location = new System.Drawing.Point(270, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 18);
            this.label2.TabIndex = 2;
            this.label2.Text = "未共享用户";
            // 
            // btnAdd
            // 
            this.btnAdd.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.btnAdd.Location = new System.Drawing.Point(170, 60);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 3;
            this.btnAdd.Text = "<<";
            this.btnAdd.TextImageRelation = Gizmox.WebGUI.Forms.TextImageRelation.Overlay;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnRemove
            // 
            this.btnRemove.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.btnRemove.Location = new System.Drawing.Point(170, 98);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(75, 23);
            this.btnRemove.TabIndex = 3;
            this.btnRemove.Text = ">>";
            this.btnRemove.TextImageRelation = Gizmox.WebGUI.Forms.TextImageRelation.Overlay;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.writeBox);
            this.groupBox1.Controls.Add(this.readBox);
            this.groupBox1.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.groupBox1.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.groupBox1.Location = new System.Drawing.Point(21, 194);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(177, 100);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.Text = "权限";
            // 
            // writeBox
            // 
            this.writeBox.Checked = false;
            this.writeBox.CheckState = Gizmox.WebGUI.Forms.CheckState.Unchecked;
            this.writeBox.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.writeBox.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Standard;
            this.writeBox.Location = new System.Drawing.Point(20, 60);
            this.writeBox.Name = "writeBox";
            this.writeBox.Size = new System.Drawing.Size(104, 24);
            this.writeBox.TabIndex = 0;
            this.writeBox.Text = "写";
            this.writeBox.ThreeState = false;
            this.writeBox.Click += new System.EventHandler(this.writeBox_Click);
            // 
            // readBox
            // 
            this.readBox.Checked = false;
            this.readBox.CheckState = Gizmox.WebGUI.Forms.CheckState.Unchecked;
            this.readBox.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.readBox.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Standard;
            this.readBox.Location = new System.Drawing.Point(20, 30);
            this.readBox.Name = "readBox";
            this.readBox.Size = new System.Drawing.Size(104, 24);
            this.readBox.TabIndex = 0;
            this.readBox.Text = "读";
            this.readBox.ThreeState = false;
            this.readBox.Click += new System.EventHandler(this.readBox_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.addReadBox);
            this.groupBox2.Controls.Add(this.addWriteBox);
            this.groupBox2.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.groupBox2.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.groupBox2.Location = new System.Drawing.Point(217, 194);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(177, 100);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.Text = "权限";
            // 
            // addReadBox
            // 
            this.addReadBox.Checked = false;
            this.addReadBox.CheckState = Gizmox.WebGUI.Forms.CheckState.Unchecked;
            this.addReadBox.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.addReadBox.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Standard;
            this.addReadBox.Location = new System.Drawing.Point(23, 30);
            this.addReadBox.Name = "addReadBox";
            this.addReadBox.Size = new System.Drawing.Size(104, 24);
            this.addReadBox.TabIndex = 0;
            this.addReadBox.Text = "读";
            this.addReadBox.ThreeState = false;
            // 
            // addWriteBox
            // 
            this.addWriteBox.Checked = false;
            this.addWriteBox.CheckState = Gizmox.WebGUI.Forms.CheckState.Unchecked;
            this.addWriteBox.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.addWriteBox.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Standard;
            this.addWriteBox.Location = new System.Drawing.Point(23, 60);
            this.addWriteBox.Name = "addWriteBox";
            this.addWriteBox.Size = new System.Drawing.Size(104, 24);
            this.addWriteBox.TabIndex = 0;
            this.addWriteBox.Text = "写";
            this.addWriteBox.ThreeState = false;
            // 
            // shareList
            // 
            this.shareList.Columns.AddRange(new Gizmox.WebGUI.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.shareList.DataMember = null;
            this.shareList.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.shareList.GridLines = true;
            this.shareList.ItemsPerPage = 20;
            this.shareList.Location = new System.Drawing.Point(21, 60);
            this.shareList.Name = "shareList";
            this.shareList.Size = new System.Drawing.Size(121, 97);
            this.shareList.TabIndex = 5;
            this.shareList.View = Gizmox.WebGUI.Forms.View.List;
            this.shareList.SelectedIndexChanged += new System.EventHandler(this.shareList_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.columnHeader1.Image = null;
            this.columnHeader1.Text = "User";
            this.columnHeader1.Width = 150;
            // 
            // unshareList
            // 
            this.unshareList.Columns.AddRange(new Gizmox.WebGUI.Forms.ColumnHeader[] {
            this.columnHeader2});
            this.unshareList.DataMember = null;
            this.unshareList.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.unshareList.GridLines = true;
            this.unshareList.ItemsPerPage = 20;
            this.unshareList.Location = new System.Drawing.Point(273, 60);
            this.unshareList.Name = "unshareList";
            this.unshareList.Size = new System.Drawing.Size(121, 97);
            this.unshareList.TabIndex = 5;
            this.unshareList.View = Gizmox.WebGUI.Forms.View.List;
            // 
            // columnHeader2
            // 
            this.columnHeader2.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.columnHeader2.Image = null;
            this.columnHeader2.Text = "User";
            this.columnHeader2.Width = 150;
            // 
            // ShareForm
            // 
            this.Controls.Add(this.unshareList);
            this.Controls.Add(this.shareList);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnRemove);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnOK);
            this.Location = new System.Drawing.Point(15, 15);
            this.Size = new System.Drawing.Size(422, 343);
            this.Text = "共享设置";
            this.Load += new System.EventHandler(this.ShareForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Gizmox.WebGUI.Forms.Button btnOK;
        private Gizmox.WebGUI.Forms.Label label1;
        private Gizmox.WebGUI.Forms.Label label2;
        private Gizmox.WebGUI.Forms.Button btnAdd;
        private Gizmox.WebGUI.Forms.Button btnRemove;
        private Gizmox.WebGUI.Forms.GroupBox groupBox1;
        private Gizmox.WebGUI.Forms.CheckBox readBox;
        private Gizmox.WebGUI.Forms.GroupBox groupBox2;
        private Gizmox.WebGUI.Forms.CheckBox writeBox;
        private Gizmox.WebGUI.Forms.CheckBox addReadBox;
        private Gizmox.WebGUI.Forms.CheckBox addWriteBox;
        private Gizmox.WebGUI.Forms.ListView shareList;
        private Gizmox.WebGUI.Forms.ColumnHeader columnHeader1;
        private Gizmox.WebGUI.Forms.ListView unshareList;
        private Gizmox.WebGUI.Forms.ColumnHeader columnHeader2;


    }
}