using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Framework.Patterns;
using Framework.DB;

namespace Framework.UI
{
    public partial class CResTreeView: TreeView
    {
        /// <summary>
        /// 
        /// </summary>
        private IResNd rootNd_;

        /// <summary>
        /// Initializes a new instance of the <see cref="CResTreeView"/> class.
        /// </summary>
        public CResTreeView ( )
        {
            InitializeComponent ( );
        }
        [Browsable(false)]
        public IResNd RootRes
        {
            get
            {

                return rootNd_;
            }
            set
            {
                //首先要清空原有节点
                Nodes.Clear();
                //错误处理
                rootNd_ = value;
                if (rootNd_ == null)
                    return;
                //设置treeview的根。
                TreeNode rootNde = new TreeNode(rootNd_.Name);
                rootNde.Tag = rootNd_;
                base.Nodes.Add(rootNde);
                foreach(IResNd child in rootNd_.Children)
                {
                    TreeNode childNode = new TreeNode(child.Name);
                    childNode.Tag = child;
                    rootNde.Nodes.Add(childNode);
                }
                 
            }
        }

        /// <summary>
        /// Gets the sel res.
        /// </summary>
        /// <returns></returns>
        public IResNd GetSelRes ( )
        {
            TreeNode selectedNode = SelectedNode;
            return (IResNd)selectedNode.Tag;
        }

        /// <summary>
        /// 插入某节点,这是一个默认实现，其它的树可以根据自己的需要，来决定如何插入
        /// 这样对于实现不同视角的树很有用，可以控制哪些显示，哪些不显示。
        /// </summary>
        public void InsertNode (TreeNode parentNode, IResNd node )
        {
            if ( parentNode == null )
                return;
            //把自己加入parentNode下面
            TreeNode hostNode = new TreeNode ( node.Name );
            hostNode.Tag = node;
            parentNode.Nodes.Add ( hostNode );
            //把所有孩子加入自己下面
            foreach ( IResNd child in node.Children )
            {
                TreeNode childNode = new TreeNode ( child.Name );
                childNode.Tag = child;
                hostNode.Nodes.Add ( childNode );
            }
        }

    }
}
