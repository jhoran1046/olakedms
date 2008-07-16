using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace Framework.UI
{
    public interface IResNd
    {
        /// <summary>
        /// �Լ�������
        /// </summary>
        string Name
        {
            get;
            set;
        }
        /// <summary>
        /// Sets the key string.
        /// Ϊ��֧��web���洢�ڵ���Ϣ��������string�洢ÿ���ڵ��key.����Ҫת��һ��
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
        /// ���еĺ���
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
        /// detail.Ӧ������ʾ��detailView����
        /// </summary>
        List<IResNd> DetailNodes
        {
            get;
            set;
        }

        /// <summary>
        /// ��ʾ����ߵ����е�
        /// </summary>
        List<IResNd> StructureNodes
        {
            get;
            set;
        }

        /// <summary>
        /// �оٱ��ڵ��ܹ�ִ�е�����
        /// </summary>
        List<string> EnumCmds();

        /// <summary>
        /// ִ��ĳ��cmd string
        /// </summary>
        bool ExecCmd(string cmd);
#region �־û�
        /// <summary>
        /// �ӿ���װ���Լ�
        /// </summary>
        bool Load ( );

        /// <summary>
        /// �����Լ�
        /// </summary>
        bool Save ( );
        /// <summary>
        /// ִ��ĳ��cmd index
        /// </summary>
        bool ExecCmd ( UInt32 cmdIndex );

        /// <summary>
        /// �ӿ���װ���Լ��ĺ���
        /// </summary>
        bool LoadChildren ( );
#endregion
        
        /// <summary>
        /// ��node�����ĺ��Ӷ���������
        /// </summary>
        /// <param name="node"></param>
        void InsertNode(TreeNode parentNode);

        /// <summary>
        /// ����һ�����ӽڵ�
        /// </summary>
        object AddChildNode ( );

        /// <summary>
        /// ���ú��ӽڵ�Ĺؼ�����
        /// </summary>
        void SetKeyObj ( object keyObj );
        void InsertToDB ( );
    }
}
