using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Windows.Forms;
using System.Collections;
using Framework.DB;
namespace Framework.UI
{
    /// <summary>
    ///�ṩ��IResNd��Ĭ��ʵ�� 
    /// </summary>
    /// <typeparam name="DataT">The type of the Data.</typeparam>
    public abstract class CResNd<DataT>: Framework.Patterns.CParentClass<IResNd> , IResNd where DataT: IPersistableData,new()
    {
        #region ���г�Ա����
        List<string> cmds_;
        DataT data_;
        public DataT Data
        {
            get { return data_; }
            set { data_ = value; }
        }
        object[] keyFields_;
   
        #endregion

        public CResNd ( )
        {
            cmds_ = new List<string> ( );
            data_ = new DataT();
            Name = data_.Name;
            //keyFields_ = new ArrayList ( );
            //keyFields_ = new object[];
        }

#region ���з���

#endregion
#region IResNd ��Ա

        public abstract List<string> KeyString
        {
            set;
        }
        public string BuildingString
        {
            get
            {
                //assemble Name
                string assembleStr = this.GetType ( ).Assembly.FullName;
                int assemNameEnd = assembleStr.IndexOf(",");
                assembleStr = assembleStr.Substring ( 0 , assemNameEnd );

                //typename
                string typeName = this.GetType ( ).ToString ( );

                //keys
                string keyStr = "";
                foreach(object key in KeyFields)
                {
                   
                    keyStr += "__";
                    if ( key != null )
                        keyStr += key.ToString ( );
                    else
                        keyStr += "";
                }

                return assembleStr + "::" + typeName + keyStr;
                
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public object[] KeyFields
        {
            get { return keyFields_; }
            set { keyFields_ = value; }
        }
        /// <summary>
        /// Gets or sets the children.
        /// </summary>
        /// <value>The children.</value>
        List<IResNd> IResNd.Children
        {
            get
            {
                return Children;
            }
            set
            {
                Children = value;
            }
        }
        object IResNd.Data
        {
            get { return Data; }
            set { Data = (DataT)value; }
        }

        public virtual void SetKeyObj ( object keyObj )
        {
            return ;
        }
        /// <summary>
        /// ���һ�����ӽڵ�
        /// </summary>
        public virtual object AddChildNode()
        {
            return null;
        }
        /// <summary>
        /// Enums the CMDS.
        /// </summary>
        /// <returns></returns>
        public List<string> EnumCmds()
        {
            return cmds_;
        }

        /// <summary>
        /// Execs the CMD.
        /// </summary>
        /// <param name="cmd">The CMD.</param>
        /// <returns></returns>
        public virtual bool ExecCmd ( string cmd )
        {
            foreach(string aCmd in cmds_)
            {
                //if()
            }
            return true;
        }
        /// <summary>
        /// Execs the CMD.
        /// </summary>
        /// <param name="cmdIndex">Index of the CMD.</param>
        /// <returns></returns>
        public abstract bool ExecCmd(UInt32 cmdIndex);

        /// <summary>
        /// Saves this instance.
        /// </summary>
        /// <returns></returns>
        public virtual bool Save()
        {
            data_.Update( );
            return true;
           
        }
        public virtual void InsertToDB()
        {
            data_.Insert();

        }
        public virtual bool Load()
        {
           data_ = new DataT ( );
           if(keyFields_==null)
           {
               LoadFail ( );
               return false;

           }
           foreach(object ob in keyFields_)
           {
               if ( ob == null )
               {
                   LoadFail ( );
                   return false;
               }
           }
           data_ = (DataT)data_.Load(KeyFields);
           if(data_==null)
           {
               LoadFail ( );
               return false;
           }

           return true;
        }

        protected virtual void AddChildren ( )
        {
            return;
        }
        private void LoadFail()
        {
          
            data_ = new DataT ( );
            data_.Name = "�޴�����";
        }
        /// <summary>
        /// �ӿ���װ���Լ��ĺ���
        /// </summary>
        public virtual bool LoadChildren()
        {
            foreach (IResNd resNd in Children)
            {
                if (!resNd.Load())
                    return false;
            }
            return true;
        }
        /// <summary>
        /// ��node�����ĺ��Ӷ���������
        /// </summary>
        /// <param name="node"></param>
        public virtual void InsertNode(TreeNode parentNode)
        {
            if(parentNode==null)
                return;
            //���Լ�����parentNode����
            TreeNode hostNode = new TreeNode(Name);
            hostNode.Tag = this;
            parentNode.Nodes.Add(hostNode);
            //�����к��Ӽ����Լ�����
            foreach(IResNd child in Children)
            {
               TreeNode childNode = new TreeNode(child.Name);
               childNode.Tag = child;
               hostNode.Nodes.Add(childNode);
            }
        }
#endregion
#region Override NamedClass
        [Browsable(false)]
        [ReadOnly(true)]
        public override string Name
        {
            get
            {
                return base.Name;
            }
            set
            {
                base.Name = value;
            }
        }
#endregion

        public List<IResNd> StructureNodes
        {
            get
            {
                return Children;
            }
            set
            {
                Children = value;
            }
        }

        public List<IResNd> DetailNodes
        {
            get
            {
                return Children;
            }
            set
            {
                Children = value;
            }
        }
   
    }
}
