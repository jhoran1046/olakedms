using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Windows.Forms;
using Framework.DB;

namespace Framework.UI
{

    /// <summary>
    /// 用于作为一类Node的container,最有用的就是把资源点分为category
    /// 具体用法：
    /// 1.把某类从本类派生，并且childt置为要包含的资源点类型，把dataT置为CNullData,如：CResCollectionNode<EmployeeNode,CNullData>
    /// 2.Override Load函数，本节点的keyfield应包含足够筛选出本collection内包含的节点的数据。
    /// 3.利用childt所应该包含的data_类的某个实例，来装载出来数据。
    /// 4.利用这些数据，来生成类型为ChildT的Node,
    /// 5.把这些Node插入到chidren.
    /// </summary>
    /// <typeparam name="ChildT">The type of the hild T.</typeparam>
    /// <typeparam name="DataT">The type of the Data T.</typeparam>
    public abstract class CResCollectionNode<ChildT,DataT> : CResNd<DataT> where ChildT : IResNd, new() where DataT: IPersistableData,new()
    {
        /// <summary>
        /// 用于添加属于本collection的新node时候，输入node的keyField用，因为keyfiels在第一次添加后，是不允许修改的，所以要有一个初始化界面。
        /// </summary>
        /// 
        protected object keyObj_;

        public override object AddChildNode()
        {
            //1.生成孩子节点
            ChildT aNewChild = new ChildT();

            //2.显示对话框，让用户输入关键参数
            SetKeyObjForm fm = new SetKeyObjForm();
            fm.keyObj = keyObj_;
            fm.ShowDialog();
            if ( fm.DialogResult == DialogResult.Cancel )
                return null;
            //3.把用户输入的值传递给孩子节点,并且把孩子节点加入孩子列表
            aNewChild.SetKeyObj ( fm.keyObj );
            aNewChild.InsertToDB ( );
            Children.Add ( aNewChild );
            return aNewChild;
        }
        public override bool ExecCmd(string cmd)
        {
            
            throw new Exception("The method or operation is not implemented.");
        }

        public override bool ExecCmd(uint cmdIndex)
        {
            throw new Exception("The method or operation is not implemented.");
        }
        public override bool Load()
        {
            throw new Exception("The method or operation is not implemented.");
        }
        public override bool Save()
        {
            return true;
        }
    }
}
