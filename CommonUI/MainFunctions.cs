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

namespace CommonUI
{
    public partial class MainFunctions: UserControl
    {
       

        public MainFunctions ( )
        {
            InitializeComponent ( );
            List<CFunction> shareSpaceFunctionList = new List<CFunction> ( );
            CFunction function = new CFunction ( );
            function.Name = "我共享给他人的文档";
            shareSpaceFunctionList.Add ( function );
            function = new CFunction ( );
            function.Name = "他人共享给我的文档";
            shareSpaceFunctionList.Add ( function );
            shareSpacefunctionTree.FunctionList = shareSpaceFunctionList;
        }

        private void navigationTabs1_SelectedIndexChanged ( object sender , EventArgs e )
        {
            int a = navigationTabs1.SelectedIndex;
            a++;
            
        }
    }
}