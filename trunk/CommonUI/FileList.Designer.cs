namespace CommonUI
{
    partial class FileList
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
            this.fileListView = new Gizmox.WebGUI.Forms.ListView ( );
            this.SuspendLayout ( );
            // 
            // fileListView
            // 
            this.fileListView.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None;
            this.fileListView.CheckBoxes = true;
            this.fileListView.ColumnResizeStyle = Gizmox.WebGUI.Forms.ColumnHeaderAutoResizeStyle.ColumnContent;
            this.fileListView.DataMember = null;
            this.fileListView.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.fileListView.DragTargets = new Gizmox.WebGUI.Forms.Component [ 0 ];
            this.fileListView.Font = new System.Drawing.Font ( "ËÎÌו" , 9F , System.Drawing.FontStyle.Regular , System.Drawing.GraphicsUnit.Point , ( ( byte ) ( 134 ) ) );
            this.fileListView.GridLines = true;
            this.fileListView.ItemsPerPage = 22;
            this.fileListView.Location = new System.Drawing.Point ( 0 , 0 );
            this.fileListView.Name = "fileListView";
            this.fileListView.Size = new System.Drawing.Size ( 391 , 306 );
            this.fileListView.TabIndex = 0;
            this.fileListView.UseInternalPaging = true;
            // 
            // FileList
            // 
            this.Controls.Add ( this.fileListView );
            this.Size = new System.Drawing.Size ( 391 , 306 );
            this.Text = "FileList";
            this.ResumeLayout ( false );

        }

        #endregion

        private Gizmox.WebGUI.Forms.ListView fileListView;



    }
}