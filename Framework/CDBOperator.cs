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
    /// 此类提供grove中objectoperator的管理，以singleton模式保证对一个链接字符串不重复打开多个连接
    /// 此类不是线程安全的
    /// </summary>
    public class CDBOperator
    {
#region 成员变量
        //表，存储着所有的连接字符串和cdboperator实例的映射，
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
        //这个接口保证了一个链接字符串只能生成一个cdboperator实例
        //////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// 这个接口保证了一个链接字符串只能生成一个cdboperator实例
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
        /// 不在构造函数里面初始化，是因为有时候要求初始化的时间可控。
        /// </summary>
        public void Init()
        {
            //已经初始化过了则没必要再重复
            if ( m_dbOP != null || m_connString==null || m_connString=="" )
                return;
            m_dbOP = new ObjectOperator ( m_connString );
            
        }
        
    }
}
