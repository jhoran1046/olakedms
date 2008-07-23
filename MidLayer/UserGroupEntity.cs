using System;
using Grove.ORM;
using Framework.DB;

namespace MidLayer
{
    [DataTable("TBL_UserGroup")]
    public class CUserGroupEntity : CDBEntity<CUserGroupEntity>
    {
        Int32 _Urg_Id;
        Int32 _Urg_User;
        Int32 _Urg_Group;

        [KeyField("Urg_Id")]
        public Int32 Urg_Id
        {
            get { return this._Urg_Id; }
            set { this._Urg_Id = value; }
        }
        [ForeignKeyField("Urg_User")]
        public Int32 Urg_User
        {
            get { return this._Urg_User; }
            set { this._Urg_User = value; }
        }
        [ForeignKeyField("Urg_Group")]
        public Int32 Urg_Group
        {
            get { return this._Urg_Group; }
            set { this._Urg_Group = value; }
        }

        public CUserGroupEntity(String connectionString)
        {
            ConnString = connectionString;
        }

        public CUserGroupEntity()
            : this("")
        {
            ConnString = MidLayerSettings.ConnectionString;
        }
    }
}
