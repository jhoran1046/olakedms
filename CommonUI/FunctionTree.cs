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
    public partial class FunctionTree: UserControl
    {
        Font _defaultFnt = new Font ( "arial" , 9 );
        private List<CFunction> _functionList;

        public List<CFunction> FunctionList
        {
            get { return _functionList; }
            set 
            {
                _functionList = value;
                if ( value == null )
                    return;
                foreach(CFunction function in _functionList)
                {
                    TreeNode newNode = new TreeNode ( );
                    Font aFnt = _defaultFnt;

                    newNode.NodeFont = aFnt;
                    newNode.Text = function.Name;
                    newNode.Tag = function.Ui;
                    newNode.Image = function.Image;
                    MainTree.Nodes.Add ( newNode );
                }
            }
        }
    
        public CFunction SelectedFunction
        {
            get
            {
                if(MainTree.SelectedNode==null)
                    return null;
                CFunction function = ( CFunction ) MainTree.SelectedNode.Tag;
                return function;
            }
        }

        //public Delegate 
        public FunctionTree ( )
        {
            InitializeComponent ( );

        }
    }
}