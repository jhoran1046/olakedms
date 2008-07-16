using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace Framework.UI
{
    public interface IResNd
    {
        /// <summary>
        /// 自己的名字
        /// </summary>
        string Name
        {
            get;
            set;
        }
        /// <summary>
        /// Sets the key string.
        /// 为了支持web树存储节点信息，必须用string存储每个节点的key.所以要转换一下
        /// </summary>
        /// <value>The key string.</value>
        List<string> KeyString
        {
            set;
        }
        string BuildingString
        {
            get;
        }
        object[] KeyFields
        {
            get;
            set;
        }
        /// <summary>
        /// 所有的孩子
        /// </summary>
        List<IResNd> Children
        {
            get;
            set;
        }
        object Data
        {
            get;
            set;
        }

        /// <summary>
        /// detail.应该是显示在detailView里面
        /// </summary>
        List<IResNd> DetailNodes
        {
            get;
            set;
        }

        /// <summary>
        /// 显示在左边的树中的
        /// </summary>
        List<IResNd> StructureNodes
        {
            get;
            set;
        }

        /// <summary>
        /// 列举本节点能够执行的命令
        /// </summary>
        List<string> EnumCmds();

        /// <summary>
        /// 执行某条cmd string
        /// </summary>
        bool ExecCmd(string cmd);
#region 持久化
        /// <summary>
        /// 从库中装载自己
        /// </summary>
        bool Load ( );

        /// <summary>
        /// 保存自己
        /// </summary>
        bool Save ( );
        /// <summary>
        /// 执行某条cmd index
        /// </summary>
        bool ExecCmd ( UInt32 cmdIndex );

        /// <summary>
        /// 从库中装载自己的孩子
        /// </summary>
        bool LoadChildren ( );
#endregion
        
        /// <summary>
        /// 将node和他的孩子都插入树中
        /// </summary>
        /// <param name="node"></param>
        void InsertNode(TreeNode parentNode);

        /// <summary>
        /// 增加一个孩子节点
        /// </summary>
        object AddChildNode ( );

        /// <summary>
        /// 设置孩子节点的关键属性
        /// </summary>
        void SetKeyObj ( object keyObj );
        void InsertToDB ( );
    }
}
