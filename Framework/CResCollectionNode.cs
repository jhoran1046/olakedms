using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Windows.Forms;
using Framework.DB;

namespace Framework.UI
{

    /// <summary>
    /// ������Ϊһ��Node��container,�����õľ��ǰ���Դ���Ϊcategory
    /// �����÷���
    /// 1.��ĳ��ӱ�������������childt��ΪҪ��������Դ�����ͣ���dataT��ΪCNullData,�磺CResCollectionNode<EmployeeNode,CNullData>
    /// 2.Override Load���������ڵ��keyfieldӦ�����㹻ɸѡ����collection�ڰ����Ľڵ�����ݡ�
    /// 3.����childt��Ӧ�ð�����data_���ĳ��ʵ������װ�س������ݡ�
    /// 4.������Щ���ݣ�����������ΪChildT��Node,
    /// 5.����ЩNode���뵽chidren.
    /// </summary>
    /// <typeparam name="ChildT">The type of the hild T.</typeparam>
    /// <typeparam name="DataT">The type of the Data T.</typeparam>
    public abstract class CResCollectionNode<ChildT,DataT> : CResNd<DataT> where ChildT : IResNd, new() where DataT: IPersistableData,new()
    {
        /// <summary>
        /// ����������ڱ�collection����nodeʱ������node��keyField�ã���Ϊkeyfiels�ڵ�һ����Ӻ��ǲ������޸ĵģ�����Ҫ��һ����ʼ�����档
        /// </summary>
        /// 
        protected object keyObj_;

        public override object AddChildNode()
        {
            //1.���ɺ��ӽڵ�
            ChildT aNewChild = new ChildT();

            //2.��ʾ�Ի������û�����ؼ�����
            SetKeyObjForm fm = new SetKeyObjForm();
            fm.keyObj = keyObj_;
            fm.ShowDialog();
            if ( fm.DialogResult == DialogResult.Cancel )
                return null;
            //3.���û������ֵ���ݸ����ӽڵ�,���ҰѺ��ӽڵ���뺢���б�
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
