using System;
using Grove.ORM;

namespace MidLayer
{
    public enum ARCHIVESTATUS : int
    {
        NORMAL = 0,
        COMPLETED,
        CANCELLED,
    }

    [DataTable("TBL_Archive")]
    public class CArchiveEntity
    {
        Int32 _Arc_Id;
        Int32 _Arc_Resource;
        Int32 _Arc_User;
        String _Arc_Description;
        DateTime _Arc_CreateTime;
        Int32 _Arc_Status;

        [KeyField("Arc_Id")]
        public Int32 Arc_Id
        {
            get { return this._Arc_Id; }
            set { this._Arc_Id = value; }
        }
        [ForeignKeyField("Arc_Resource")]
        public Int32 Arc_Resource
        {
            get { return this._Arc_Resource; }
            set { this._Arc_Resource = value; }
        }
        [ForeignKeyField("Arc_User")]
        public Int32 Arc_User
        {
            get { return this._Arc_User; }
            set { this._Arc_User = value; }
        }
        [DataField("Arc_Description")]
        public String Arc_Description
        {
            get { return this._Arc_Description; }
            set { this._Arc_Description = value; }
        }
        [DataField("Arc_CreateTime")]
        public DateTime Arc_CreateTime
        {
            get { return this._Arc_CreateTime; }
            set { this._Arc_CreateTime = value; }
        }
        [DataField("Arc_Status")]
        public Int32 Arc_Status
        {
            get { return this._Arc_Status; }
            set { this._Arc_Status = value; }
        }
    }
}
