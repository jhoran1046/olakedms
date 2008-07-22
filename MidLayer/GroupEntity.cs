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

        public override void Delete()
        {
            // delete all its acls
            String filter = "this.Acl_Role=" + Grp_Id + " and this.Acl_RType=" + (int)ACLROLETYPE.GROUPROLE;
            new CACLEntity(ConnString).Delete(filter);

            // exclude all users in it
            filter = "this.Urg_Group=" + Grp_Id;
            new CUserGroupEntity(ConnString).Delete(filter);

            base.Delete();
        }

        public List<CACLEntity> GetGroupACLs()
        {
            String filter = "this.Acl_Role=" + Grp_Id.ToString();
            filter += " and this.Acl_RType=" + ((int)ACLROLETYPE.GROUPROLE).ToString();
            List<CACLEntity> acls = new CACLEntity(ConnString).GetObjectList(filter);
            return acls;
        }

        public List<CUserEntity> ListUsers()
        {
            List<CUserEntity> users = new List<CUserEntity>();
            String filter = "this.Urg_Group=" + Grp_Id;
            List<CUserGroupEntity> userGroups = new CUserGroupEntity(ConnString).GetObjectList(filter);
            foreach (CUserGroupEntity ug in userGroups)
            {
                CUserEntity user = new CUserEntity(ConnString).Load(ug.Urg_User);
                users.Add(user);
            }
            return users;
        }
    }
}