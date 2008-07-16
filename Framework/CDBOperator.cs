using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Threading;
using Grove.ORM;
using Framework.Patterns;

namespace Framework.DB
{
    /// <summary>
    /// �����ṩgrove��objectoperator�Ĺ�����singletonģʽ��֤��һ�������ַ������ظ��򿪶������
    /// ���಻���̰߳�ȫ��
    /// </summary>
    public class CDBOperator
    {
#region ��Ա����
        //���洢�����е������ַ�����cdboperatorʵ����ӳ�䣬
        static SortedList<string,CDBOperator> m_connStrList =  new SortedList<string,CDBOperator>();
        static Mutex _lock = new Mutex();
        string m_connString;
        public string ConnString
        {
            get { return m_connString; }
        }
        ObjectOperator m_dbOP;
        public Grove.ORM.ObjectOperator OP
        {
            get { return m_dbOP; }
            set { m_dbOP = value; }
        }
       
#endregion

        //////////////////////////////////////////////////////////////////////////
        // Method:    GetInstance
        // FullName:  Framework.DB.CDBOperator.GetInstance
        // Access:    public static 
        // Returns:   Framework.DB.CDBOperator
        // Parameter: string connString
        //����ӿڱ�֤��һ�������ַ���ֻ������һ��cdboperatorʵ��
        //////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// ����ӿڱ�֤��һ�������ַ���ֻ������һ��cdboperatorʵ��
        /// </summary>
        /// <param name="connString"></param>
        /// <returns></returns>
        static public CDBOperator GetInstance(string connString)
        {
            //sychronization while multi threading
            _lock.WaitOne ( );
            if ( m_connStrList.ContainsKey ( connString ) )
            {
                _lock.ReleaseMutex ( );
                return m_connStrList [ connString ];
            }
            else
            {
                CDBOperator op = new CDBOperator();
                op.m_connString = connString;
                m_connStrList.Add ( connString , op );
                op.Init ( );
                _lock.ReleaseMutex ( );
                return op;
            }
            //_lock.ReleaseMutex ( );
        }
        protected CDBOperator ( )
        {
            m_connString = "";
            m_dbOP = null;// new CDBOperator(m)
        }
        /// <summary>
        /// ���ڹ��캯�������ʼ��������Ϊ��ʱ��Ҫ���ʼ����ʱ��ɿء�
        /// </summary>
        public void Init()
        {
            //�Ѿ���ʼ��������û��Ҫ���ظ�
            if ( m_dbOP != null || m_connString==null || m_connString=="" )
                return;
            m_dbOP = new ObjectOperator ( m_connString );
            
        }
        
    }
}
