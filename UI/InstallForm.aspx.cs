using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

using MidLayer;
using System.Collections.Generic;
using System.Drawing;
using Framework.Util;
using System.Data.SqlClient;
using System.IO;
using System.Xml;
using System.Text;

namespace UI
{
    public partial class InstallForm : System.Web.UI.Page
    {
#region ��Ա����
        String _serverName;

        public String ServerName
        {
            get { return _serverName; }
            set { _serverName = value; }
        }
        String _userId;

        public String UserId
        {
            get { return _userId; }
            set { _userId = value; }
        }
        String _password;

        public String Password1
        {
            get { return _password; }
            set { _password = value; }
        }
        String _initialCatalog;

        public String InitialCatalog1
        {
            get { return _initialCatalog; }
            set { _initialCatalog = value; }
        }
        String _path;//�û�����ķ������ϵ�·��

        public String Path
        {
            get { return _path; }
            set { _path = value; }
        }
        String _member;

        public String Member
        {
            get { return _member; }
            set { _member = value; }
        }
        String _userPwd;

        public String UserPwd
        {
            get { return _userPwd; }
            set { _userPwd = value; }
        }
        String _userName;

        public String UserName
        {
            get { return _userName; }
            set { _userName = value; }
        }
        String _email;

        public String Email
        {
            get { return _email; }
            set { _email = value; }
        }
        String _connString;

        public String ConnString
        {
            get { return _connString; }
            set { _connString = value; }
        }
        String _rootPath;//�´�������֯�ĸ�Ŀ¼

        public String RootPath
        {
            get { return _rootPath; }
            set { _rootPath = value; }
        }
        String _orgName;
        String _originalConnString;
#endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            lblMsg.BackColor = Color.White;
            lblErrorMsg.BackColor = Color.White;
            lblErrorMsg.Text = "";
            LogonPanel.Visible = true;

            try
            {
                CUserEntity user = new CUserEntity();
                List<CUserEntity> usrlst = new List<CUserEntity>();
                usrlst = user.GetObjectList("this.Usr_Type = '1'");
                if(usrlst.Count > 0)
                {
                    LogonPanel.Visible = true;
                    LogonPanel.Enabled = true;
                    mainPanel.Enabled = false;
                    this.btnCreate.Enabled = false;
                    this.btnInitial.Enabled = true;
                }
            }
            catch
            {
                LogonPanel.Visible = false;
                mainPanel.Enabled = true;
                this.btnCreate.Enabled = true;
                this.btnInitial.Enabled = false;
            }
        }

        protected void btnOK_Click(object sender, EventArgs e)
        {
            if(txtUsrName.Text =="")
            {
                lblMsg.BackColor = Color.Red;
                lblMsg.Text = "�û��������ǿգ�";
                return;
            }
            else if(txtPassWd.Text == "")
            {
                lblMsg.BackColor = Color.Red;
                lblMsg.Text = "���벻��Ϊ�գ�";
                return;
            }
            string member = txtUsrName.Text;
            string pwd = CHelperClass.UserMd5(txtPassWd.Text);
            CUserEntity user = new CUserEntity();
            List<CUserEntity> usrlst = new List<CUserEntity>();
            usrlst = user.GetObjectList("this.Usr_Member ='" + member + "'");
            if(usrlst.Count <= 0)
            {
                lblMsg.BackColor = Color.Red;
                lblMsg.Text = "�û��������ڣ�";
                txtPassWd.Text = "";
                return;
            }
            else if(usrlst[0].Usr_Password != pwd)
            {
                lblMsg.BackColor = Color.Red;
                lblMsg.Text = "���벻��ȷ��";
                txtPassWd.Text = "";
                return;
            }
            else
            {
                lblMsg.BackColor = Color.GreenYellow;
                lblMsg.Text = "�ɹ���¼��";
                mainPanel.Enabled = true;
                LogonPanel.Enabled = false;
            }
        }

        protected void btnCreate_Click(object sender, EventArgs e)
        {
            if (txtServer.Text == "" || txtUserId.Text == "" || txtPassword.Text == "" || txtInitialCatalog.Text == "" || txtPath.Text == "" || txtOrgName.Text == "")
            {
                lblErrorMsg.BackColor = Color.Red;
                lblErrorMsg.Text = "����δ��д����Ŀ��";
                return;
            }

            _serverName = txtServer.Text;
            _userId = txtUserId.Text;
            _password = txtPassword.Text;
            _initialCatalog = txtInitialCatalog.Text;
            _orgName = txtOrgName.Text;
            string pt = txtPath.Text;
            if (pt[2].ToString() == "/")
            {
                lblErrorMsg.BackColor = Color.Red;
                lblErrorMsg.Text = "�ļ�·����ʽ����ȷ��";
                return;
            }
            else if (pt[pt.Length - 1].ToString() != "\\")
            {
                pt += "\\";
            }
            _path = pt;

            _member = txtMember.Text;
            if (txtMemberPwd.Text != txtSurePwd.Text)
            {
                lblErrorMsg.BackColor = Color.Red;
                lblErrorMsg.Text = "������ȷ�����벻��ͬ��";
                return;
            }

            _userPwd = CHelperClass.UserMd5(txtMemberPwd.Text.ToString());
            _userName = txtMemberName.Text;

            try
            {
                CreateDataBase();
                ChangeWebConfig();
                CreateTable(_connString);
                CreateOrganize(_orgName);
                CreateAdminlUser();

                this.Response.Write("<script language='javascript'>alert(' �����ɹ���������¼ϵͳǰ��Web1.config�ĳ�Web.config�滻ԭ��Web.config�ļ���');window.location.history;</script>");
            }
            catch (Exception ex)
            {
                lblErrorMsg.Text = "ϵͳ����" + ex.Message;
            }
        }
        /// <summary>
        /// �������ݿ�
        /// </summary>
        private void CreateDataBase()
        {
            SqlConnection DBconn;
            string createDB;
            DBconn = new SqlConnection();
            DBconn.ConnectionString = "Server=" + _serverName
                           + ";User Id=" + _userId
                           + ";Password=" + _password;
            createDB = "CREATE DATABASE " + _initialCatalog;
            SqlCommand comm = new SqlCommand(createDB, DBconn);

            try
            {
                DBconn.Open();
                comm.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                DBconn.Close();
            }
        }
        /// <summary>
        /// �޸�Web.config�ļ�
        /// </summary>
        private void ChangeWebConfig()
        {
            string fileName = Context.Server.MapPath("/Web.config");
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(fileName);

            string connString = "Server=" + _serverName +
                                  ";User Id=" + _userId +
                                  ";Password=" + _password +
                                  ";Initial Catalog=" + _initialCatalog;
            _connString = connString;
            MidLayerSettings.ConnectionString = connString;

            XmlNodeList nodeList = xmlDoc.DocumentElement.ChildNodes;

            foreach (XmlElement element in nodeList)
            {
                if (element.Name == "connectionStrings")
                {
                    XmlNodeList node = element.ChildNodes;
                    if (node.Count <= 0)
                        throw new Exception("ϵͳ���������·��ʸ�ҳ��");

                    foreach (XmlElement aNode in node)
                    {
                        if (aNode.Attributes["name"].Value == "ConnectionString")
                        {
                            _originalConnString = aNode.Attributes["connectionString"].Value;
                            aNode.Attributes["connectionString"].Value = connString;
                        }
                    }
                }

                if (element.Name == "appSettings")
                {
                    XmlNodeList nodelst = element.ChildNodes;
                    if (nodelst.Count <= 0)
                        throw new Exception("ϵͳ���������·��ʸ�ҳ��");

                    foreach (XmlElement aNode in nodelst)
                    {
                        if (aNode.Attributes["key"].Value == "UserData")
                        {
                            aNode.Attributes["value"].Value = _path;
                        }
                    }
                }
            }
            string newConfig = Context.Server.MapPath("~/");
            newConfig += "Web1.config";
            FileStream webStream = new FileStream(newConfig, FileMode.Create);
            XmlTextWriter xmltext = new XmlTextWriter(webStream, Encoding.UTF8);
            xmltext.Flush();
            xmltext.Close();
            xmlDoc.Save(newConfig);
        }
        /// <summary>
        /// Ϊ�����ݿⴴ�����ݱ�
        /// </summary>
        /// <param name="connString"></param>
        private void CreateTable(string connString)
        {
            string path = Context.Server.MapPath("/App_Data/dms.sql");
            StreamReader read = File.OpenText(path);
            ArrayList commandList = new ArrayList();
            string commandText = "";
            string sqlLine = "";
            while (read.Peek() > -1)
            {
                sqlLine = read.ReadLine();
                if (sqlLine == "")
                    continue;

                if (sqlLine != "GO")
                {
                    commandText += sqlLine;
                    commandText += "\r\n";
                }
                else
                {
                    commandList.Add(commandText);
                    commandText = "";
                }
            }
            read.Close();
            SqlConnection conn = new SqlConnection(connString);
            conn.Open();
            SqlTransaction myTr = conn.BeginTransaction();
            SqlCommand comm = new SqlCommand();
            comm.Connection = conn;
            comm.Transaction = myTr;
            try
            {
                foreach (string aSql in commandList)
                {
                    comm.CommandText = aSql;
                    comm.ExecuteNonQuery();
                }
                myTr.Commit();
            }
            catch
            {
                throw new Exception("�������ķ�������");
            }
            finally
            {
                conn.Close();
            }
        }
        /// <summary>
        /// ��ʼ��֮ǰɾ��ԭ�����ݿ�
        /// </summary>
        private void DeleteData()
        {
            string str = _originalConnString;
            int startStr = str.LastIndexOf("=");
            string dataBase = str.Substring(startStr + 1);

            SqlConnection conn = new SqlConnection(_originalConnString);
            string commText = "DROP DATABASE " + dataBase;
            SqlCommand comm = new SqlCommand(commText,conn);
            conn.Open();
            comm.ExecuteNonQuery();
            conn.Close();
        }

        protected void btnInitial_Click(object sender, EventArgs e)
        {
            if (txtServer.Text == "" || txtUserId.Text == "" || txtPassword.Text == "" || txtInitialCatalog.Text == "" || txtPath.Text == "" || txtOrgName.Text == "")
            {
                lblErrorMsg.BackColor = Color.Red;
                lblErrorMsg.Text = "����δ��д����Ŀ��";
                return;
            }

            _serverName = txtServer.Text;
            _userId = txtUserId.Text;
            _password = txtPassword.Text;
            _initialCatalog = txtInitialCatalog.Text;
            _orgName = txtOrgName.Text;
            string pt = txtPath.Text;
            if (pt[2].ToString() == "/")
            {
                lblErrorMsg.BackColor = Color.Red;
                lblErrorMsg.Text = "·����ʽ����ȷ��";
                return;
            }
            else if (pt[pt.Length - 1].ToString() != "\\")
            {
                pt += "\\";
            }
            _path = pt;

            _member = txtMember.Text;
            if (txtMemberPwd.Text != txtSurePwd.Text)
            {
                lblErrorMsg.BackColor = Color.Red;
                lblErrorMsg.Text = "������ȷ�����벻��ͬ��";
                return;
            }

            _userPwd = CHelperClass.UserMd5(txtMemberPwd.Text.ToString());
            _userName = txtMemberName.Text;

            try
            {
                ChangeWebConfig();
                DeleteData();
                CreateDataBase();
                CreateTable(_connString);
                CreateOrganize(_orgName);
                CreateAdminlUser();

                this.Response.Write("<script language='javascrip'>alert(' ϵͳ�ѳ�ʼ����������¼ϵͳǰ��Web1.config�ļ��ĳ�Web.config�滻ԭ��Web.config�ļ���');</script>");
            }
            catch (Exception ex)
            {
                lblErrorMsg.BackColor = Color.Red;
                lblErrorMsg.Text = "ϵͳ����" + ex.Message;
            }
        }

        public COrganizeEntity CreateOrganize(String organizeName)
        {
            try
            {
                // create resource for this organize
                CResourceEntity res = new CResourceEntity(_connString);
                res.Res_Name = _orgName;
                res.Res_Parent = 0;
                res.Res_Type = (int)RESOURCETYPE.ORGANIZERESOURCE;
                res.Res_Id = res.Insert();

                // create default storage folder named as organize resource id
                String organizePath = System.IO.Path.Combine(_path, res.Res_Id.ToString() + _orgName);
                Directory.CreateDirectory(organizePath);
                _rootPath = organizePath;

                // create resource for default folder of organize
                CResourceEntity folderRes = new CResourceEntity(_connString);
                folderRes.Res_Name = res.Res_Id.ToString() + _orgName;
                folderRes.Res_Parent = 0;
                folderRes.Res_Type = (int)RESOURCETYPE.FOLDERRESOURCE;
                folderRes.Res_Id = folderRes.Insert();

                // Create organize entity
                COrganizeEntity organize = new COrganizeEntity(_connString);
                organize.Org_Name = _orgName;
                organize.Org_Resource = folderRes.Res_Id;
                organize.Insert();

                // create archive folder for organzie
                String archivePath = System.IO.Path.Combine(organizePath, "�鵵Ŀ¼");
                Directory.CreateDirectory(archivePath);

                // create resource for archive folder
                CResourceEntity archiveRes = new CResourceEntity(_connString);
                archiveRes.Res_Name = "�鵵Ŀ¼";
                archiveRes.Res_Parent = folderRes.Res_Id;
                archiveRes.Res_Type = (int)RESOURCETYPE.FOLDERRESOURCE;
                archiveRes.Res_Id = archiveRes.Insert();

                organize.Org_ArchiveRes = archiveRes.Res_Id;
                organize.Update();

                return organize;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public CUserEntity CreateAdminlUser()
        {
            COrganizeEntity org = new COrganizeEntity(_connString);
            List<COrganizeEntity> organizelst = new List<COrganizeEntity>();
            organizelst = org.GetObjectList("this.Org_Name ='" + _orgName + "'");
            int orgId = organizelst[0].Org_Id;

            CUserEntity newUser = new CUserEntity();
            newUser.Usr_Member = _member;
            newUser.Usr_Name = _userName;
            newUser.Usr_Organize = orgId;
            newUser.Usr_Password = _userPwd;
            newUser.Usr_Email = _email;

            try
            {
                // create admin 
                newUser.Usr_Type = (int)USERTYPE.ORGANIZEADMIN;
                CUserEntity user = CreateUser(newUser);

                // add acls to admin, organize acl, root dir acl
                COrganizeEntity organize = new COrganizeEntity(_connString);
                organize = organize.Load(user.Usr_Organize);
                /*
                                CACLEntity acl1 = new CACLEntity(ConnString);
                                acl1.Acl_CreateTime = DateTime.Now;
                                acl1.Acl_Creator = Usr_Id;
                                acl1.Acl_Operation = 0;
                                acl1.Acl_Resource = organize.Org_Id;
                                acl1.Acl_Role = user.Usr_Id;
                                acl1.Acl_RType = (int)ACLROLETYPE.USERROLE;
                                acl1.Acl_Id = acl1.Insert();
                */
                CACLEntity acl2 = new CACLEntity(_connString);
                acl2.Acl_CreateTime = DateTime.Now;
                acl2.Acl_Creator = user.Usr_Id;
                acl2.Acl_Operation = (int)ACLOPERATION.WRITE;
                acl2.Acl_Resource = organize.Org_Resource;
                acl2.Acl_Role = user.Usr_Id;
                acl2.Acl_RType = (int)ACLROLETYPE.USERROLE;
                acl2.Acl_Id = acl2.Insert();

                CACLEntity acl3 = new CACLEntity(_connString);
                acl3.Acl_CreateTime = DateTime.Now;
                acl3.Acl_Creator = user.Usr_Id;
                acl3.Acl_Operation = (int)ACLOPERATION.READ;
                acl3.Acl_Resource = organize.Org_Resource;
                acl3.Acl_Role = user.Usr_Id;
                acl3.Acl_RType = (int)ACLROLETYPE.USERROLE;
                acl3.Acl_Id = acl2.Insert();

                return user;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        protected CUserEntity CreateUser(CUserEntity newUser)
        {
            try
            {
                COrganizeEntity organize = new COrganizeEntity(_connString);
                List<COrganizeEntity> organizelst = new List<COrganizeEntity>();
                organizelst = organize.GetObjectList("this.Org_Name ='" + _orgName + "'");
                int orgRes = organizelst[0].Org_Resource;

                // create resource for user's folder
                CResourceEntity folderRes = new CResourceEntity(_connString);
                folderRes.Res_Name = "";
                folderRes.Res_Parent = orgRes;
                folderRes.Res_Type = (int)RESOURCETYPE.FOLDERRESOURCE;
                folderRes.Res_Id = folderRes.Insert();

                folderRes.Res_Name = folderRes.Res_Id.ToString() + newUser.Usr_Member;
                folderRes.Update();

                // create user's folder
                //String userPath = folderRes.MakeFullPath();
                String userPath = _rootPath + "\\" + folderRes.Res_Name;
                Directory.CreateDirectory(userPath);

                // create user
                newUser.Usr_Resource = folderRes.Res_Id;
                newUser.ConnString = _connString;
                newUser.Usr_Id = newUser.Insert();
                return newUser;
            }
            catch (Exception e)
            {
                throw e;
            }

        }

    }
}
