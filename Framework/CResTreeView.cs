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
                //����Ҫ���ԭ�нڵ�
                Nodes.Clear();
                //������
                rootNd_ = value;
                if (rootNd_ == null)
                    return;
                //����treeview�ĸ���
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
        /// ����ĳ�ڵ�,����һ��Ĭ��ʵ�֣������������Ը����Լ�����Ҫ����������β���
        /// ��������ʵ�ֲ�ͬ�ӽǵ��������ã����Կ�����Щ��ʾ����Щ����ʾ��
        /// </summary>
        public void InsertNode (TreeNode parentNode, IResNd node )
        {
            if ( parentNode == null )
                return;
            //���Լ�����parentNode����
            TreeNode hostNode = new TreeNode ( node.Name );
            hostNode.Tag = node;
            parentNode.Nodes.Add ( hostNode );
            //�����к��Ӽ����Լ�����
            foreach ( IResNd child in node.Children )
            {
                TreeNode childNode = new TreeNode ( child.Name );
                childNode.Tag = child;
                hostNode.Nodes.Add ( childNode );
            }
        }

    }
}
