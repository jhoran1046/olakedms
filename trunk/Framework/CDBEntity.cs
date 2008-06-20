using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Collections;
using Grove.ORM;
using System.ComponentModel;
namespace Framework.DB
{
    /// <summary>
    /// 使用方法：
    /// 1.用grove自动生成一个数据库访问类xxxClass
    /// 2.将xxxClass从本类派生xxxClass:CDBEntity
    ///
    /// 3.在xxxClass的构造函数里面给ConnString赋值，使用正确的连接字符串;
    /// 4.给Name赋值
    /// </summary>
    /// 
    public class CDBEntity<T> : Framework.Patterns.CNamedClass, IPersistableData where T :  CDBEntity<T>, new()
    {
#region 成员变量
        protected CDBOperator m_db;
        string m_connString;
       // [Browsable(false)]
        public string ConnString
        {
            get { return m_connString; }
            set
            {
                m_connString = value;
                m_db = CDBOperator.GetInstance ( m_connString );
            }
        }
#endregion
#region 最基础操作，CRUD
        /// <summary>
        /// Inserts this instance.
        /// </summary>
        public virtual int Insert ( )
        {
            
            m_db.OP = new ObjectOperator ( m_connString );
             m_db.OP.DbOperator.ClearParameters ( );
             m_db.OP.BeginTranscation();
            int id = -1;
            try
            {
                m_db.OP.Insert(this);
                object temp = (m_db.OP.DbOperator.ExecScalar("select @@identity"));
                id = Int32.Parse(temp.ToString());
                m_db.OP.Commit();
                
            }
            catch(System.Exception e)
            {
                m_db.OP.Rollback();
            }
            
          
            m_db.OP.Dispose();
            return id;

        }
        
        
        
        /// <summary>
        /// c.CustomerID=1000;
        /// c.CustomerName="rainbow-co.";
        /// c.Update(); 
        /// </summary>
        public virtual void Update ( )
        {
            m_db.OP = new ObjectOperator ( m_connString );
            m_db.OP.DbOperator.ClearParameters ( );
            m_db.OP.Update ( this );
            m_db.OP.Dispose();
        }
        /// <summary>
        /// Product p=(Product)oo.Retrieve(tyoeof(Product),guidString);
        ///p.ProductID=newGuidString;
        ///p.Update("this.ProductID=guidString");
        /// </summary>
        /// <param name="filter"></param>
        /// <param name="properties"></param>
        public virtual void Update ( string filter , params string [ ] properties )
        {
            m_db.OP = new ObjectOperator ( m_connString );
            m_db.OP.DbOperator.ClearParameters ( );
            m_db.OP.Update ( GetType ( ) , filter , properties );
            m_db.OP.Dispose();
            //m_db.OP.Update(this,"this."+fieldName+"="+value);
        }
        /// <summary>
        /// customer.Update("this.CustomerID<1000","this.Status=2");
        /// </summary>
        /// <param name="filter"></param>
        public virtual void Update ( string filter )
        {
            m_db.OP = new ObjectOperator ( m_connString );
            m_db.OP.DbOperator.ClearParameters ( );
            m_db.OP.Update ( this , filter );
            m_db.OP.Dispose();
        }
        /// <summary>
        /// Categories aCategory = new Categories ( );
        /// aCategory = aCategory.Load ( 1 );
        /// </summary>
        /// <param name="keyValues"></param>
        /// <returns></returns>
        public virtual T Load ( params object [ ] keyValues )
        {
            m_db.OP = new ObjectOperator ( m_connString );
            m_db.OP.DbOperator.ClearParameters ( );
            T ret = (T)m_db.OP.Retrieve(GetType(), keyValues);
            ret.ConnString = m_connString;
             m_db.OP.Dispose();
             return ret;
           
            
        }
        object IPersistableData.Load ( params object [ ] keyValues )
        {
            return Load(keyValues);
        }
        /// <summary>
        /// Deletes this instance.
        /// </summary>
        public virtual void Delete ( )
        {
            m_db.OP = new ObjectOperator ( m_connString );
            m_db.OP.DbOperator.ClearParameters ( );
            m_db.OP.Remove ( this );
            m_db.OP.Dispose();

        }
        /// <summary>
        /// Deletes the specified filter.
        /// </summary>
        /// <param name="filter">The filter.</param>
        public virtual void Delete ( string filter )
        {
            m_db.OP = new ObjectOperator ( m_connString );
            m_db.OP.DbOperator.ClearParameters ( );
            m_db.OP.Remove ( GetType ( ) , filter );
            m_db.OP.Dispose();
        }
        /// <summary>
        /// int customerID=1000;
        ///Order.RemoveChilds(customerID);
        /// </summary>
        /// <param name="ftiler"></param>
        /// <returns></returns>
        public virtual int DeleteChildren ( params object[] foreignKeyValues )
        {
            m_db.OP = new ObjectOperator ( m_connString );
            m_db.OP.DbOperator.ClearParameters ( );
            
            int ret =m_db.OP.RemoveChilds  ( GetType ( ) , foreignKeyValues );
            m_db.OP.Dispose();
            return ret;
        }
#endregion

#region 返回数据源
       /// <summary>
       ///  IDataReader reader = oo.GetDataReader ( new ObjectQuery ( typeof ( Customer ) , "" ) );
       /// </summary>
        public IDataReader GetDataReader(string filter)
        {
            m_db.OP = new ObjectOperator ( m_connString );
            m_db.OP.DbOperator.ClearParameters ( );
            IDataReader ret = m_db.OP.GetDataReader ( new ObjectQuery ( GetType ( ) , filter ) );
            m_db.OP.Dispose();
            return ret;
        }
        /// <summary>
        ///  IDataReader reader = oo.GetDataReader ( new ObjectQuery ( typeof ( Customer ) , "" ) );
        /// </summary>
        public IDataReader GetDataReader(string filter,string subsetFilter)
        {
            m_db.OP = new ObjectOperator ( m_connString );
            m_db.OP.DbOperator.ClearParameters();
            ObjectQuery query = new ObjectQuery(GetType(), filter);
            query.DeclareSubset(GetType(),subsetFilter);
            
            IDataReader ret=  m_db.OP.GetDataReader(query);
            m_db.OP.Dispose();
            return ret;
        }

        public IDataReader GetDataReader(ObjectQuery query)
        {
            m_db.OP = new ObjectOperator ( m_connString );
            m_db.OP.DbOperator.ClearParameters();
            IDataReader ret= m_db.OP.GetDataReader(query);
            m_db.OP.Dispose();
            return ret;

        }
       /// <summary>
       ///   ArrayList customers = oo.GetObjectSet ( new ObjectQuery ( typeof ( Customer ) , "" ) );
       /// </summary>
        public ArrayList GetObjectSet ( string filter )
        {
            m_db.OP = new ObjectOperator ( m_connString );
         
            m_db.OP.DbOperator.ClearParameters ( );
            ObjectQuery query = new ObjectQuery ( GetType ( ) , filter );
            Grove.EntityData temp = GetObjectSource ( filter );
            ArrayList ret = Grove.Util.EntityUtil.ToObjects(temp,GetType());
            m_db.OP.Dispose();
            return ret;
            //return .GetObjectSet ( query);
        }
        public List<T> GetObjectList(string filter)
        {
            m_db.OP = new ObjectOperator ( m_connString );
            List<T> ret = new List<T>();
            m_db.OP.DbOperator.ClearParameters();
            ObjectQuery query = new ObjectQuery(GetType(), filter);
            Grove.EntityData temp = GetObjectSource(filter);
            ArrayList array = Grove.Util.EntityUtil.ToObjects(temp, GetType());
            if (array != null)
            {
                foreach (T t in array)
                {
                    t.ConnString = m_connString;
                    ret.Add(t);
                }
            }
            m_db.OP.Dispose();
            return ret;


        }
        public List<T> GetObjectList ( string filter,int topN )
        {
            m_db.OP = new ObjectOperator ( m_connString );
            List<T> ret = new List<T> ( );
            m_db.OP.DbOperator.ClearParameters ( );
            ObjectQuery query = new ObjectQuery ( GetType ( ) , filter );
            query.PrefixString = "top " + topN.ToString ( );
            //Grove.EntityData temp = GetObjectSource ( filter );
            ArrayList array = GetObjectSet ( query );
            if ( array != null )
            {
                foreach ( T t in array )
                {
                    t.ConnString = m_connString;
                    ret.Add ( t );
                }
            }
            m_db.OP.Dispose();
            return ret;


        }
        /// <summary>
        ///   ArrayList customers = oo.GetObjectSet ( new ObjectQuery ( typeof ( Customer ) , "" ) );
        /// </summary>
        public ArrayList GetObjectSet(string filter,string subsetFilter)
        {
            m_db.OP = new ObjectOperator ( m_connString );
            m_db.OP.DbOperator.ClearParameters();
           // ObjectQuery query = new ObjectQuery(GetType(), filter);
           // query.DeclareSubset(GetType(),subsetFilter);
            Grove.EntityData temp = GetObjectSource ( filter , subsetFilter );
            ArrayList ret = Grove.Util.EntityUtil.ToObjects(temp,GetType());
            m_db.OP.Dispose();
            return ret;
           // return m_db.OP.GetObjectSet(query);
        }

        public ArrayList GetObjectSet(ObjectQuery query)
        {
            m_db.OP = new ObjectOperator ( m_connString );
            m_db.OP.DbOperator.ClearParameters();
            ArrayList ret = Grove.Util.EntityUtil.ToObjects ( GetObjectSource ( query ),GetType() );
            m_db.OP.Dispose();
            return ret;
            //return m_db.OP.GetObjectSet(query);
        }

             /// <summary>
        /// EntityData result = oo.GetObjectSource ( new ObjectQuery ( typeof ( Customer ) , "" ) );
        /// 
        /// </summary>
        public Grove.EntityData GetObjectSource(string filter)
        {
            m_db.OP = new ObjectOperator ( m_connString );
            m_db.OP.DbOperator.ClearParameters ( );
            ObjectQuery query = new ObjectQuery ( GetType ( ) , filter );
            Grove.EntityData ret = m_db.OP.GetObjectSource ( query );
            m_db.OP.Dispose();
            return ret;
        }
        /// <summary>
        /// EntityData result = oo.GetObjectSource ( new ObjectQuery ( typeof ( Customer ) , "" ) );
        /// 
        /// </summary>
        public Grove.EntityData GetObjectSource(string filter, string subsetFilter)
        {
            m_db.OP = new ObjectOperator ( m_connString );
            m_db.OP.DbOperator.ClearParameters();
            ObjectQuery query = new ObjectQuery(GetType(), filter);
            query.DeclareSubset(GetType(),subsetFilter);
            Grove.EntityData ret = m_db.OP.GetObjectSource(query);
            m_db.OP.Dispose();
            return ret;
        }


        public Grove.EntityData GetObjectSource(ObjectQuery query)
        {
            m_db.OP = new ObjectOperator ( m_connString );
            m_db.OP.DbOperator.ClearParameters();
            Grove.EntityData ret = m_db.OP.GetObjectSource(query);
            m_db.OP.Dispose();
            return ret;
        }
        public virtual void Update(T aEntity)
        {
            aEntity.Update();
        }
        public virtual void Insert(T aEntity)
        {
            aEntity.Insert();
        }
        public virtual void Delete(T aEntity)
        {
            aEntity.Delete();
        }
#endregion
    }
}
