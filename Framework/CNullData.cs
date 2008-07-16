using System;
using System.Collections.Generic;
using System.Text;

namespace Framework.DB
{
    /// <summary>
    /// ĳЩ��CResNode�������ಢ��data,����Ҫ�������stubһ��
    /// </summary>
    public class CNullData : IPersistableData
    {
        #region IPersistableData ��Ա

        public string ConnString
        {
            set { return; }
        }

        public string Name
        {
            get
            {
                return "";
            }
            set
            {
                return ;
            }
        }

        public object Load(params object[] keyValues)
        {
            return null;
        }

        public void Delete()
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public void Delete(string filter)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public int DeleteChildren(params object[] foreignKeyValues)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public System.Data.IDataReader GetDataReader(string filter)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public System.Data.IDataReader GetDataReader(string filter, string subsetFilter)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public System.Data.IDataReader GetDataReader(Grove.ORM.ObjectQuery query)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public Grove.EntityData GetObjectSource(string filter, string subsetFilter)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public Grove.EntityData GetObjectSource(string filter)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public Grove.EntityData GetObjectSource(Grove.ORM.ObjectQuery query)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public System.Collections.ArrayList GetObjectSet(string filter)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public System.Collections.ArrayList GetObjectSet(Grove.ORM.ObjectQuery query)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public System.Collections.ArrayList GetObjectSet(string filter, string subsetFilter)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public int Insert()
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public void Update(string filter, params string[] properties)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public void Update(string filter)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public void Update()
        {
            throw new Exception("The method or operation is not implemented.");
        }

        #endregion
    }
}
