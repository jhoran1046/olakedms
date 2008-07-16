namespace MidLayer
{
	using System;
	using Grove.ORM;
    using Framework.DB;
	[RelationTable("TBL_ResourceRelationQuery",BeginWithTable="TBL_Resource")]
	public class CResSorReQuEntity:CDBEntity<CResSorReQuEntity>
	{

        public CResSorReQuEntity()
        {
            ConnString = "Provider=SQLOLEDB.1;Password=a;Persist Security Info=True;User ID=sa;Initial Catalog=DMS;Data Source=WIN2003";
        }

		[RelationReflect("TBL_Resource","TBL_SortApplyInfo")]
		[RelationField("Res_Id","App_DocId")]
		public string Relationship_1
		{
			get{return "[TBL_Resource].[Res_Id]=[TBL_SortApplyInfo].[App_DocId]";}
		}

		String _Res_Name;
		[DataField("Res_Name",TableName="TBL_Resource")]
		public String Res_Name
		{
			get{return this._Res_Name;}
			set{this._Res_Name=value;}
		}
	}

}
