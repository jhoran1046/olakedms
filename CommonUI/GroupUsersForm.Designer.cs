namespace CommonUI
{
    partial class GroupUsersForm
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
            this.groupUserList = new Gizmox.WebGUI.Forms.ListView();
            this.otherUserList = new Gizmox.WebGUI.Forms.ListView();
            this.AddBtn = new Gizmox.WebGUI.Forms.Button();
            this.RemoveBtn = new Gizmox.WebGUI.Forms.Button();
            this.OKBtn = new Gizmox.WebGUI.Forms.Button();
            this.label1 = new Gizmox.WebGUI.Forms.Label();
            this.label2 = new Gizmox.WebGUI.Forms.Label();
            this.SuspendLayout();
            // 
            // groupUserList
            // 
            this.groupUserList.DataMember = null;
            this.groupUserList.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.groupUserList.ItemsPerPage = 20;
            this.groupUserList.Location = new System.Drawing.Point(25, 54);
            this.groupUserList.Name = "groupUserList";
            this.groupUserList.Size = new System.Drawing.Size(143, 216);
            this.groupUserList.TabIndex = 0;
            this.groupUserList.View = Gizmox.WebGUI.Forms.View.List;
            // 
            // otherUserList
            // 
            this.otherUserList.DataMember = null;
            this.otherUserList.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.otherUserList.ItemsPerPage = 20;
            this.otherUserList.Location = new System.Drawing.Point(297, 54);
            this.otherUserList.Name = "otherUserList";
            this.otherUserList.Size = new System.Drawing.Size(143, 216);
            this.otherUserList.TabIndex = 0;
            this.otherUserList.View = Gizmox.WebGUI.Forms.View.List;
            // 
            // AddBtn
            // 
            this.AddBtn.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.AddBtn.Location = new System.Drawing.Point(196, 95);
            this.AddBtn.Name = "AddBtn";
            this.AddBtn.Size = new System.Drawing.Size(75, 23);
            this.AddBtn.TabIndex = 1;
            this.AddBtn.Text = "<<";
            this.AddBtn.TextImageRelation = Gizmox.WebGUI.Forms.TextImageRelation.Overlay;
            this.AddBtn.Click += new System.EventHandler(this.AddBtn_Click);
            // 
            // RemoveBtn
            // 
            this.RemoveBtn.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.RemoveBtn.Location = new System.Drawing.Point(196, 160);
            this.RemoveBtn.Name = "RemoveBtn";
            this.RemoveBtn.Size = new System.Drawing.Size(75, 23);
            this.RemoveBtn.TabIndex = 2;
            this.RemoveBtn.Text = ">>";
            this.RemoveBtn.TextImageRelation = Gizmox.WebGUI.Forms.TextImageRelation.Overlay;
            this.RemoveBtn.Click += new System.EventHandler(this.RemoveBtn_Click);
            // 
            // OKBtn
            // 
            this.OKBtn.DialogResult = Gizmox.WebGUI.Forms.DialogResult.OK;
            this.OKBtn.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.OKBtn.Location = new System.Drawing.Point(365, 304);
            this.OKBtn.Name = "OKBtn";
            this.OKBtn.Size = new System.Drawing.Size(75, 23);
            this.OKBtn.TabIndex = 3;
            this.OKBtn.Text = "完成";
            this.OKBtn.TextImageRelation = Gizmox.WebGUI.Forms.TextImageRelation.Overlay;
            this.OKBtn.Click += new System.EventHandler(this.OKBtn_Click);
            // 
            // label1
            // 
            this.label1.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.label1.Location = new System.Drawing.Point(25, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 23);
            this.label1.TabIndex = 4;
            this.label1.Text = "组用户";
            // 
            // label2
            // 
            this.label2.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.label2.Location = new System.Drawing.Point(297, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 23);
            this.label2.TabIndex = 5;
            this.label2.Text = "其他用户";
            // 
            // GroupUsersForm
            // 
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.OKBtn);
            this.Controls.Add(this.RemoveBtn);
            this.Controls.Add(this.AddBtn);
            this.Controls.Add(this.otherUserList);
            this.Controls.Add(this.groupUserList);
            this.Location = new System.Drawing.Point(15, 15);
            this.Size = new System.Drawing.Size(474, 339);
            this.Text = "组用户设置";
            this.Load += new System.EventHandler(this.GroupUsersForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Gizmox.WebGUI.Forms.ListView groupUserList;
        private Gizmox.WebGUI.Forms.ListView otherUserList;
        private Gizmox.WebGUI.Forms.Button AddBtn;
        private Gizmox.WebGUI.Forms.Button RemoveBtn;
        private Gizmox.WebGUI.Forms.Button OKBtn;
        private Gizmox.WebGUI.Forms.Label label1;
        private Gizmox.WebGUI.Forms.Label label2;


    }
}