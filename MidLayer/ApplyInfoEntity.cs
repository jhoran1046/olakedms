namespace MidLayer
{
    using System;
    using Grove.ORM;
    using Framework.DB;
    [RelationTable("TBL_ResourceRelationQuery", BeginWithTable = "TBL_Resource")]
    public class CApplyInfoEntity:CDBEntity<CApplyInfoEntity>
    {
        public int Org_Id;

        public CApplyInfoEntity()
        {
            ConnString = MidLayerSettings.ConnectionString;
        }

#region grove生成的成员
        [RelationReflect("TBL_Resource", "TBL_Apply")]
        [RelationField("Res_Id", "App_ResId")]
        public string Relationship_1
        {
            get { return "[TBL_Resource].[Res_Id]=[TBL_Apply].[App_ResId]"; }
        }
        [RelationReflect("TBL_Apply", "TBL_User", JoinType = TableJOINType.LEFTOUTERJOIN)]
        [RelationField("App_Applyer", "Usr_Id")]
        public string Relationship_2
        {
            get { return "[TBL_Apply].[App_Applyer]=[TBL_User].[Usr_Id]"; }
        }
        [RelationReflect("TBL_User", "TBL_Organize")]
        [RelationField("Usr_Organize", "Org_Id")]
        public string Relationship_3
        {
            get { return "[TBL_User].[Usr_Organize]=[TBL_Organize].[Org_Id]"; }
        }

        String _Res_Name;
        [DataField("Res_Name", TableName = "TBL_Resource")]
        public String Res_Name
        {
            get { return this._Res_Name; }
            set { this._Res_Name = value; }
        }
        String _Usr_Name;
        [DataField("Usr_Name", TableName = "TBL_User")]
        public String Usr_Name
        {
            get { return this._Usr_Name; }
            set { this._Usr_Name = value; }
        }
        Int32 _Usr_Type;
        [DataField("Usr_Type", TableName = "TBL_User")]
        public Int32 Usr_Type
        {
            get { return this._Usr_Type; }
            set { this._Usr_Type = value; }
        }
        Int32 _Usr_Organize;
        [DataField("Usr_Organize", TableName = "TBL_User")]
        public Int32 Usr_Organize
        {
            get { return this._Usr_Organize; }
            set { this._Usr_Organize = value; }
        }
        Int32 _App_Id;
        [DataField("App_Id", TableName = "TBL_Apply")]
        public Int32 App_Id
        {
            get { return this._App_Id; }
            set { this._App_Id = value; }
        }
        Int32 _App_ResId;
        [DataField("App_ResId", TableName = "TBL_Apply")]
        public Int32 App_ResId
        {
            get { return this._App_ResId; }
            set { this._App_ResId = value; }
        }
        Int32 _App_Applyer;
        [DataField("App_Applyer", TableName = "TBL_Apply")]
        public Int32 App_Applyer
        {
            get { return this._App_Applyer; }
            set { this._App_Applyer = value; }
        }
        String _App_Comment;
        [DataField("App_Comment", TableName = "TBL_Apply")]
        public String App_Comment
        {
            get { return this._App_Comment; }
            set { this._App_Comment = value; }
        }
        String _App_ReComment;
        [DataField("App_ReComment", TableName = "TBL_Apply")]
        public String App_ReComment
        {
            get { return this._App_ReComment; }
            set { this._App_ReComment = value; }
        }
        Int32 _App_Audited;
        [DataField("App_Audited", TableName = "TBL_Apply")]
        public Int32 App_Audited
        {
            get { return this._App_Audited; }
            set { this._App_Audited = value; }
        }
        DateTime _App_CreateTime;
        [DataField("App_CreateTime", TableName = "TBL_Apply")]
        public DateTime App_CreateTime
        {
            get { return this._App_CreateTime; }
            set { this._App_CreateTime = value; }
        }
        DateTime _App_AudTime;
        [DataField("App_AudTime", TableName = "TBL_Apply")]
        public DateTime App_AudTime
        {
            get { return this._App_AudTime; }
            set { this._App_AudTime = value; }
        }
#endregion
        
    }

}