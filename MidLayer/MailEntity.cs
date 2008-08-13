namespace MidLayer
{
	using System;
	using Grove.ORM;
    using Framework.DB;
	[DataTable("TBL_Mail")]
	public class CMailEntity:CDBEntity<CMailEntity>
	{
		Int32 _M_Id;
		Int32 _M_UsrId;
		Int32 _M_Resource;
		Int32 _M_Organize;
		String _M_UsrMail;

		[KeyField("M_Id")]
		public Int32 M_Id
		{
			get{return this._M_Id;}
			set{this._M_Id=value;}
		}
		[DataField("M_UsrId")]
		public Int32 M_UsrId
		{
			get{return this._M_UsrId;}
			set{this._M_UsrId=value;}
		}
		[DataField("M_Resource")]
		public Int32 M_Resource
		{
			get{return this._M_Resource;}
			set{this._M_Resource=value;}
		}
		[DataField("M_Organize")]
		public Int32 M_Organize
		{
			get{return this._M_Organize;}
			set{this._M_Organize=value;}
		}
		[DataField("M_UsrMail")]
		public String M_UsrMail
		{
			get{return this._M_UsrMail;}
			set{this._M_UsrMail=value;}
		}

        public CMailEntity()
        {
            ConnString = MidLayerSettings.ConnectionString;
        }

        public void Remove(string filter)
        {
            this.Delete(filter);
        }
	}
}
