using System;
using Grove.ORM;
using Framework.DB;

namespace MidLayer
{
    public enum ACLROLETYPE : int
    {
        USERROLE = 0,
        GROUPROLE
    }

    public enum ACLOPERATION : int
    {
        CREATEORGANIZE = 0,
        CRETAEORGANIZEADMIN = 1,
        CREATENORMALUSER = 2,
        AUDITAPPLY = 3,
        READ = 4,
        WRITE = 5
    }

    [DataTable("TBL_ACL")]
    public class CACLEntity : CDBEntity<CACLEntity>
    {
        Int32 _Acl_Id;
        Int32 _Acl_Resource;
        Int32 _Acl_Operation;
        Int32 _Acl_Role;
        Int32 _Acl_RType;
        Int32 _Acl_Creator;
        DateTime _Acl_CreateTime;

        [KeyField("Acl_Id")]
        public Int32 Acl_Id
        {
            get { return this._Acl_Id; }
            set { this._Acl_Id = value; }
        }
        [DataField("Acl_Resource")]
        public Int32 Acl_Resource
        {
            get { return this._Acl_Resource; }
            set { this._Acl_Resource = value; }
        }
        [DataField("Acl_Operation")]
        public Int32 Acl_Operation
        {
            get { return this._Acl_Operation; }
            set { this._Acl_Operation = value; }
        }
        [DataField("Acl_Role")]
        public Int32 Acl_Role
        {
            get { return this._Acl_Role; }
            set { this._Acl_Role = value; }
        }
        [DataField("Acl_RType")]
        public Int32 Acl_RType
        {
            get { return this._Acl_RType; }
            set { this._Acl_RType = value; }
        }
        [DataField("Acl_Creator")]
        public Int32 Acl_Creator
        {
            get { return this._Acl_Creator; }
            set { this._Acl_Creator = value; }
        }
        [DataField("Acl_CreateTime")]
        public DateTime Acl_CreateTime
        {
            get { return this._Acl_CreateTime; }
            set { this._Acl_CreateTime = value; }
        }

        public CACLEntity(String connectionString)
        {
            ConnString = connectionString;
        }

        public CACLEntity()
            : this("")
        {
            ConnString = MidLayerSettings.ConnectionString;
        }
    }
}