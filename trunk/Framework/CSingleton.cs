using System;
using System.Collections.Generic;
using System.Text;

namespace Framework.Patterns
{
    /// <summary>
    /// 单子模式
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class CSingleton<T> where T: class , new ()
    {
        #region
        protected static T m_uniqueInstance = null;
        #endregion
        protected CSingleton ( )
        {
            ;
        }
        public static T Instance
        {
            get
            {

                if ( m_uniqueInstance == null )
                    m_uniqueInstance = new T ( );
                return m_uniqueInstance;
            }

        }
        public void Release ( )
        {
            m_uniqueInstance = null;
        }
    }
}
