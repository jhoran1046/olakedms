namespace CommonUI
{
    partial class KeyWdForm
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
            this.txtKeyWdChange = new Gizmox.WebGUI.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.btnOK.Location = new System.Drawing.Point(120, 59);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 0;
            this.btnOK.Text = "确定";
            this.btnOK.TextImageRelation = Gizmox.WebGUI.Forms.TextImageRelation.Overlay;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // txtKeyWdChange
            // 
            this.txtKeyWdChange.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.txtKeyWdChange.Location = new System.Drawing.Point(28, 12);
            this.txtKeyWdChange.Multiline = true;
            this.txtKeyWdChange.Name = "txtKeyWdChange";
            this.txtKeyWdChange.Size = new System.Drawing.Size(264, 41);
            this.txtKeyWdChange.TabIndex = 1;
            // 
            // KeyWdForm
            // 
            this.Controls.Add(this.txtKeyWdChange);
            this.Controls.Add(this.btnOK);
            this.Location = new System.Drawing.Point(15, 15);
            this.Size = new System.Drawing.Size(313, 91);
            this.StartPosition = Gizmox.WebGUI.Forms.FormStartPosition.CenterScreen;
            this.Text = "更改关键字";
            this.ResumeLayout(false);

        }

        #endregion

        private Gizmox.WebGUI.Forms.Button btnOK;
        private Gizmox.WebGUI.Forms.TextBox txtKeyWdChange;


    }
}