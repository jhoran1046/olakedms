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
            this.mainMenu1 = new Gizmox.WebGUI.Forms.MainMenu ( );
            this.menuItem1 = new Gizmox.WebGUI.Forms.MenuItem ( );
            this.menuItem2 = new Gizmox.WebGUI.Forms.MenuItem ( );
            this.openFileDialog1 = new Gizmox.WebGUI.Forms.OpenFileDialog ( );
            this.mainFunctions1 = new CommonUI.MainFunctions ( );
            this.SuspendLayout ( );
            // 
            // mainMenu1
            // 
            this.mainMenu1.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None;
            this.mainMenu1.Dock = Gizmox.WebGUI.Forms.DockStyle.Top;
            this.mainMenu1.DragTargets = new Gizmox.WebGUI.Forms.Component [ 0 ];
            this.mainMenu1.Location = new System.Drawing.Point ( 0 , 0 );
            this.mainMenu1.MenuItems.AddRange ( new Gizmox.WebGUI.Forms.MenuItem [ ] {
            this.menuItem1,
            this.menuItem2} );
            this.mainMenu1.Name = "mainMenu1";
            this.mainMenu1.Size = new System.Drawing.Size ( 100 , 22 );
            // 
            // menuItem1
            // 
            this.menuItem1.AllowDrop = true;
            this.menuItem1.Checked = true;
            this.menuItem1.DragTargets = new Gizmox.WebGUI.Forms.Component [ 0 ];
            this.menuItem1.Index = 0;
            this.menuItem1.Text = "aaaaa";
            // 
            // menuItem2
            // 
            this.menuItem2.DragTargets = new Gizmox.WebGUI.Forms.Component [ 0 ];
            this.menuItem2.Index = 1;
            this.menuItem2.Text = "ddfffff";
            // 
            // mainFunctions1
            // 
            this.mainFunctions1.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None;
            this.mainFunctions1.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mainFunctions1.DragTargets = new Gizmox.WebGUI.Forms.Component [ 0 ];
            this.mainFunctions1.Location = new System.Drawing.Point ( 0 , 0 );
            this.mainFunctions1.Name = "mainFunctions1";
            this.mainFunctions1.Size = new System.Drawing.Size ( 419 , 466 );
            this.mainFunctions1.TabIndex = 0;
            this.mainFunctions1.Text = "MainFunctions";
            // 
            // SearchForm
            // 
            this.Controls.Add ( this.mainFunctions1 );
            this.Location = new System.Drawing.Point ( 15 , 15 );
            this.Menu = this.mainMenu1;
            this.Size = new System.Drawing.Size ( 419 , 466 );
            this.StartPosition = Gizmox.WebGUI.Forms.FormStartPosition.CenterScreen;
            this.Text = "SearchForm";
            this.ResumeLayout ( false );

        }

        #endregion

        private Gizmox.WebGUI.Forms.MainMenu mainMenu1;
        private Gizmox.WebGUI.Forms.MenuItem menuItem1;
        private Gizmox.WebGUI.Forms.MenuItem menuItem2;
        private Gizmox.WebGUI.Forms.OpenFileDialog openFileDialog1;
        private CommonUI.MainFunctions mainFunctions1;


    }
}