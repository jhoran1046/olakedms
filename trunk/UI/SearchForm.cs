#region Using

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;

using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Forms;

#endregion

namespace UI
{
    public partial class SearchForm: Form
    {
        public SearchForm ( )
        {
            InitializeComponent ( );
        }

        private void button1_Click ( object sender , EventArgs e )
        {
            openFileDialog1.ShowDialog ( );
        }
    }
}