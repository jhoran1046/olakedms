using System.Collections.Generic;
namespace MidLayer
{
	using System;
	using Grove.ORM;
    using Framework.DB;

    public enum AUDITE : int
    {
        UNAUDITING = 1, //未审核
        AUDITED,     //已批准
        UNAUDITED    //未批准
    }

    [DataTable("TBL_Apply")]
	public class CApplyEntity:CDBEntity<CApplyEntity>
	{
        public CApplyEntity()
        {
            ConnString = MidLayerSettings.ConnectionString;
        }
        

        /// <summary>
        ///此方法在批准申请时调用。将审核状态（App_Audited）改为已批准。
        /// </summary>
        public void Permit()
        {
           App_Audited = (int)AUDITE.AUDITED;
           App_AudTime = DateTime.Now;
           Update();
        }
        /// <summary>
        /// 此方法在不批准申请时调用。将审核状态（App_Audited）改为未批准。
        /// </summary>
        public void Cancel()
        {
           App_Audited = (int)AUDITE.UNAUDITED;
           App_AudTime = DateTime.Now;
           Update();
        }
#region grove生成的成员
        Int32 _App_Id;
        Int32 _App_ResId;
        Int32 _App_Applyer;
        String _App_Comment;
        String _App_ReComment;
        Int32 _App_Audited;
        DateTime _App_CreateTime;
        DateTime _App_AudTime;

        [KeyField("App_Id")]
        public Int32 App_Id
        {
            get { return this._App_Id; }
            set { this._App_Id = value; }
        }
        [DataField("App_ResId")]
        public Int32 App_ResId
        {
            get { return this._App_ResId; }
            set { this._App_ResId = value; }
        }
        [DataField("App_Applyer")]
        public Int32 App_Applyer
        {
            get { return this._App_Applyer; }
            set { this._App_Applyer = value; }
        }
        [DataField("App_Comment")]
        public String App_Comment
        {
            get { return this._App_Comment; }
            set { this._App_Comment = value; }
        }
        [DataField("App_ReComment")]
        public String App_ReComment
        {
            get { return this._App_ReComment; }
            set { this._App_ReComment = value; }
        }
        [DataField("App_Audited")]
        public Int32 App_Audited
        {
            get { return this._App_Audited; }
            set { this._App_Audited = value; }
        }
        [DataField("App_CreateTime")]
        public DateTime App_CreateTime
        {
            get { return this._App_CreateTime; }
            set { this._App_CreateTime = value; }
        }
        [DataField("App_AudTime")]
        public DateTime App_AudTime
        {
            get { return this._App_AudTime; }
            set { this._App_AudTime = value; }
        }
#endregion
		
	}
}
