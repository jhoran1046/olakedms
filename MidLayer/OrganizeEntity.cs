using System;
using System.IO;
using Grove.ORM;
using Framework.DB;

namespace MidLayer
{
    [DataTable("TBL_Organize")]
    public class COrganizeEntity : CDBEntity<COrganizeEntity>
    {
        Int32 _Org_Id;
        String _Org_Name;
        Int32 _Org_Resource;
        Int32 _Org_ArchiveRes;

        [KeyField("Org_Id", KeyType = UniqueIDType.OtherDefinition)]
        public Int32 Org_Id
        {
            get { return this._Org_Id; }
            set { this._Org_Id = value; }
        }
        [DataField("Org_Name")]
        public String Org_Name
        {
            get { return this._Org_Name; }
            set { this._Org_Name = value; }
        }
        [DataField("Org_Resource")]
        public Int32 Org_Resource
        {
            get { return this._Org_Resource; }
            set { this._Org_Resource = value; }
        }
        [DataField("Org_ArchiveRes")]
        public Int32 Org_ArchiveRes
        {
            get { return this._Org_ArchiveRes; }
            set { this._Org_ArchiveRes = value; }
        }

        public COrganizeEntity(String connectionString)
        {
            ConnString = connectionString;
        }

        public COrganizeEntity()
            : this("")
        {
        }

        public CResourceEntity GetOrganizeFolder()
        {
            return new CResourceEntity(ConnString).Load(Org_Resource);
        }

        public CResourceEntity GetArchiveFolder()
        {
            return new CResourceEntity(ConnString).Load(Org_ArchiveRes);
        }
    }
}