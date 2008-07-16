namespace CommonUI
{
    partial class ResTree
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

        #region Visual WebGui UserControl Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent ( )
        {
            this.mainTreeView = new Gizmox.WebGUI.Forms.TreeView ( );
            this.SuspendLayout ( );
            // 
            // mainTreeView
            // 
            this.mainTreeView.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None;
            this.mainTreeView.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mainTreeView.DragTargets = new Gizmox.WebGUI.Forms.Component [ 0 ];
            this.mainTreeView.Location = new System.Drawing.Point ( 0 , 0 );
            this.mainTreeView.Name = "mainTreeView";
            this.mainTreeView.Size = new System.Drawing.Size ( 305 , 293 );
            this.mainTreeView.TabIndex = 0;
            // 
            // ResTree
            // 
            this.Controls.Add ( this.mainTreeView );
            this.Size = new System.Drawing.Size ( 305 , 293 );
            this.Text = "ResTree";
            this.ResumeLayout ( false );

        }

        #endregion

        private Gizmox.WebGUI.Forms.TreeView mainTreeView;

        public Gizmox.WebGUI.Forms.TreeView MainTreeView
        {
            get { return mainTreeView; }
            set { mainTreeView = value; }
        }


    }
}