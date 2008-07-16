namespace MidLayer
{
	using System;
	using Grove.ORM;
    using Framework.DB;
	[DataTable("TBL_SortApplyInfo")]
	public class CSortApplyInfoEntity:CDBEntity<CSortApplyInfoEntity>
	{
        public CSortApplyInfoEntity()
        {
            ConnString = "Provider=SQLOLEDB.1;Data Source=WIN2003;Password=a;Persist Security Info=True;User ID=sa;Initial Catalog=DMS";
        }

		Int32 _App_Id;
		Int32 _App_DocId;
		String _App_Applyer;
		String _App_Comment;
		String _App_Audited;

		[KeyField("App_Id")]
		public Int32 App_Id
		{
			get{return this._App_Id;}
			set{this._App_Id=value;}
		}
		[DataField("App_DocId")]
		public Int32 App_DocId
		{
			get{return this._App_DocId;}
			set{this._App_DocId=value;}
		}
		[DataField("App_Applyer")]
		public String App_Applyer
		{
			get{return this._App_Applyer;}
			set{this._App_Applyer=value;}
		}
		[DataField("App_Comment")]
		public String App_Comment
		{
			get{return this._App_Comment;}
			set{this._App_Comment=value;}
		}
		[DataField("App_Audited")]
		public String App_Audited
		{
			get{return this._App_Audited;}
			set{this._App_Audited=value;}
		}
	}
}
