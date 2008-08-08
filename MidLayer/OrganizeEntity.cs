using System;
using System.IO;
using Grove.ORM;
using Framework.DB;

namespace MidLayer
{
    public enum SSL : int
    {
        CHECKED = 1,
        UNCHECK
    }


    [DataTable("TBL_Organize")]
    public class COrganizeEntity : CDBEntity<COrganizeEntity>
    {
        Int32 _Org_Id;
        String _Org_Name;
        Int32 _Org_Resource;
        Int32 _Org_ArchiveRes;
        String _Org_Mail;
        String _Org_MailPassword;
        String _Org_MailSmtp;
        Int32 _Org_MailSSL;
        Int32 _Org_SmtpNumber;
        String _Org_SMTPUsrName;
        String _Org_SMTPPassword;

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
        [DataField("Org_Mail")]
        public String Org_Mail
        {
            get { return _Org_Mail; }
            set { _Org_Mail = value; }
        }
        [DataField("Org_MailPassword")]
        public String Org_MailPassword
        {
            get { return _Org_MailPassword; }
            set { _Org_MailPassword = value; }
        }
        [DataField ("Org_MailSmtp")]
        public String Org_MailSmtp
        {
            get { return _Org_MailSmtp; }
            set { _Org_MailSmtp = value; }
        }
        [DataField("Org_MailSSL")]
        public Int32 Org_MailSSL
        {
            get { return _Org_MailSSL; }
            set { _Org_MailSSL = value; }
        }
        [DataField("Org_SmtpNumber")]
        public Int32 Org_SmtpNumber
        {
            get { return _Org_SmtpNumber; }
            set { _Org_SmtpNumber = value; }
        }
        [DataField("Org_SMTPUsrName")]
        public String Org_SMTPUsrName
        {
            get { return _Org_SMTPUsrName; }
            set { _Org_SMTPUsrName = value; }
        }
        [DataField("Org_SMTPPassword")]
        public String Org_SMTPPassword
        {
            get { return _Org_SMTPPassword; }
            set { _Org_SMTPPassword = value; }
        }

        public COrganizeEntity(String connectionString)
        {
            ConnString = connectionString;
        }

        public COrganizeEntity()
            : this("")
        {
            ConnString = MidLayerSettings.ConnectionString;
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