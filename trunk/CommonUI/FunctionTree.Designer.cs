namespace CommonUI
{
    partial class FunctionTree
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
            this.MainTree = new Gizmox.WebGUI.Forms.TreeView ( );
            this.SuspendLayout ( );
            // 
            // MainTree
            // 
            this.MainTree.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None;
            this.MainTree.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.MainTree.DragTargets = new Gizmox.WebGUI.Forms.Component [ 0 ];
            this.MainTree.Font = new System.Drawing.Font ( "ÐÂËÎÌå" , 14.25F , System.Drawing.FontStyle.Bold , System.Drawing.GraphicsUnit.Point , ( ( byte ) ( 134 ) ) );
            this.MainTree.Location = new System.Drawing.Point ( 0 , 0 );
            this.MainTree.Name = "MainTree";
            this.MainTree.Size = new System.Drawing.Size ( 391 , 306 );
            this.MainTree.TabIndex = 0;
            // 
            // FunctionTree
            // 
            this.Controls.Add ( this.MainTree );
            this.Size = new System.Drawing.Size ( 391 , 306 );
            this.Text = "FunctionTree";
            this.ResumeLayout ( false );

        }

        #endregion

        private Gizmox.WebGUI.Forms.TreeView MainTree;


    }
}