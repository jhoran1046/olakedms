using System;
using System.Collections.Generic;
using System.Text;

namespace MidLayer
{
    public class MidLayerSettings
    {
        private static String m_strAppPath;
        private static String m_strConnString;
        public static String AppPath
        {
            get { return m_strAppPath; }
            set { m_strAppPath = value; }
        }
        public static String ConnectionString
        {
            get { return m_strConnString; }
            set { m_strConnString = value; }
        }
    }
}
