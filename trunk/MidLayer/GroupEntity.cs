using System;
using System.Collections.Generic;
using Grove.ORM;
using Framework.DB;

namespace MidLayer
{
    [DataTable("TBL_Group")]
    public class CGroupEntity : CDBEntity<CGroupEntity>
    {
        Int32 _Grp_Id;
        String _Grp_Name;
        Int32 _Grp_Organize;

        [KeyField("Grp_Id")]
        public Int32 Grp_Id
        {
            get { return this._Grp_Id; }
            set { this._Grp_Id = value; }
        }
        [DataField("Grp_Name")]
        public String Grp_Name
        {
            get { return this._Grp_Name; }
            set { this._Grp_Name = value; }
        }
        [ForeignKeyField("Grp_Organize")]
        public Int32 Grp_Organize
        {
            get { return this._Grp_Organize; }
            set { this._Grp_Organize = value; }
        }

        public CGroupEntity(String connectionString)
        {
            ConnString = connectionString;
        }

        public CGroupEntity()
            : this("")
        {
        }

        public List<CACLEntity> GetGroupACLs()
        {
            String filter = "this.Acl_Role=" + Grp_Id.ToString();
            filter += " and this.Acl_RType=" + ((int)ACLROLETYPE.GROUPROLE).ToString();
            List<CACLEntity> acls = new CACLEntity(ConnString).GetObjectList(filter);
            return acls;
        }
    }
}