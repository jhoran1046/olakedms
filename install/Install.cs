using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using System.Data.SqlClient;
using System.Xml;
using System.IO;
using System.Collections;
using System.Web;
using MidLayer;
using CommonUI;
using Framework.Util;

namespace install
{
    public partial class Install : Form
    {
 #region 成员变量
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

        public String Password
        {
            get { return _password; }
            set { _password = value; }
        }
        String _initialCatalog;

        public String InitialCatalog
        {
            get { return _initialCatalog; }
            set { _initialCatalog = value; }
        }
        String _path;//用户输入的服务器上的路径

        public String Path
        {
            get { return _path; }
            set { _path = value; }
        }
        String _orgName;

        public String OrgName
        {
            get { return _orgName; }
            set { _orgName = value; }
        }
        String _member;

        public String Member
        {
            get { return _member; }
            set { _member = value; }
        }
        String _memberPwd;

        public String UserPwd
        {
            get { return _memberPwd; }
            set { _memberPwd = value; }
        }
        String _memberName;

        public String UserName
        {
            get { return _memberName; }
            set { _memberName = value; }
        }
        String _memberEmail;

        public String Email
        {
            get { return _memberEmail; }
            set { _memberEmail = value; }
        }
        String _connString;//新创建组织的连接字符串
        String _rootPath;//新创建的组织的根目录
        String _originalConnString;//原来的连接字符串

        String _systemAdmin;

        public String SystemAdmin
        {
            get { return _systemAdmin; }
            set { _systemAdmin = value; }
        }
        String _systemPwd;

        public String SystemPwd
        {
            get { return _systemPwd; }
            set { _systemPwd = value; }
        }
#endregion

        public Install()
        {
            InitializeComponent();
            btnInstall.DialogResult = DialogResult.OK;
            btnCancel.DialogResult = DialogResult.Cancel;
        }

        private void Install_Load(object sender, EventArgs e)
        {
            
        }

        private void btnInstall_Click(object sender, EventArgs e)
        {
            if (txtServer.Text == "" || txtUserId.Text == "" || txtPassword.Text == "" || txtInitialCatalog.Text == "" || txtPath.Text == "" || txtOrgName.Text == "")
            {
                MessageBox.Show("数据库配置有未填写的项目！", "文档管理系统", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            if(txtMember.Text == "")
            {
                MessageBox.Show("用户账号不能为空！", "文档管理系统", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            if(txtMemberPwd.Text == ""||txtSurePwd.Text == "")
            {
                MessageBox.Show("密码或确认密码不能为空！", "文档管理系统", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            _member = txtMember.Text;
            if(txtMemberPwd.Text != txtSurePwd.Text)
            {
                MessageBox.Show("密码错误！", "文档管理系统", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            _memberPwd = CHelperClass.UserMd5(this.txtMemberPwd.Text);
            _memberName = txtMemberName.Text;
            _memberEmail = txtEmail.Text;

            _serverName = txtServer.Text;
            _userId = txtUserId.Text;
            _password = txtPassword.Text;
            _initialCatalog = txtInitialCatalog.Text;
            _orgName = txtOrgName.Text;
            string pt = txtPath.Text;
            if (pt[2].ToString() == "/")
            {
                MessageBox.Show("文件路径格式不正确！", "文档管理系统", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            else if (pt[pt.Length - 1].ToString() != "\\")
            {
                pt += "\\";
            }
            _path = pt;

            if(txtSysPwd.Text == ""||txtSysSurePwd.Text == "")
            {
                MessageBox.Show("本机管理员密码不能为空！", "文档管理系统", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            if(txtSysPwd.Text != txtSysSurePwd.Text)
            {
                MessageBox.Show("本机管理员密码不正确！", "文档管理系统", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            _systemAdmin = txtSysAdmin.Text;
            _systemPwd = txtSysPwd.Text;

            try
            {
                CreateDataBase();
                ChangeWebConfig();
                CreateTable(_connString);
                CreateOrganize(_orgName);
                CreateAdminlUser();
            }
            catch(Exception ex)
            {
                MessageBox.Show("安装失败："+ex.Message, "文档管理系统", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        /// <summary>
        /// 创建数据库
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
        /// 修改Web.config文件
        /// </summary>
        private void ChangeWebConfig()
        {
            //string fileName = Context.Server.MapPath("~/Web.config");
            string fileName = System.IO.Path.GetFullPath("Web.config");
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
                        throw new Exception("系统错误！请重新访问该页！");

                    foreach (XmlElement aNode in node)
                    {
                        if (aNode.Attributes["name"].Value == "ConnectionString")
                        {
                            _originalConnString = aNode.Attributes["connectionString"].Value;
                            aNode.Attributes["connectionString"].Value = "Provider=SQLOLEDB;" + connString;
                        }
                    }
                }

                if (element.Name == "appSettings")
                {
                    XmlNodeList nodelst = element.ChildNodes;
                    if (nodelst.Count <= 0)
                        throw new Exception("系统错误！请重新访问该页！");

                    foreach (XmlElement aNode in nodelst)
                    {
                        if (aNode.Attributes["key"].Value == "UserData")
                        {
                            aNode.Attributes["value"].Value = _path;
                        }
                    }
                }
                if(element.Name == "system.web")
                {
                    XmlNode node = element.LastChild;
                    if (node.Attributes["impersonate"].Value == "true")
                    {
                        node.Attributes["userName"].Value = _systemAdmin;
                        node.Attributes["password"].Value = _systemPwd;
                    }
                }
            }
            //string newConfig = Context.Server.MapPath("~/");
            //newConfig += "Web1.config";
            string newConfig = System.IO.Path.GetFullPath("Web1.config");
            FileStream webStream = new FileStream(newConfig, FileMode.Create);
            XmlTextWriter xmltext = new XmlTextWriter(webStream, Encoding.UTF8);
            xmltext.Flush();
            xmltext.Close();
            xmlDoc.Save(newConfig);
        }
        /// <summary>
        /// 为新数据库创建数据表：
        /// </summary>
        /// <param name="connString"></param>
        private void CreateTable(string connString)
        {
            //string path = Context.Server.MapPath("~/App_Data/dms.sql");
            string path = System.IO.Path.GetFullPath("dms.sql");
            StreamReader read = System.IO.File.OpenText(path);
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
                throw new Exception("请检查您的服务器！");
            }
            finally
            {
                conn.Close();
            }
        }
        /// <summary>
        /// 初始化之前删除原有数据库
        /// </summary>
        private void DeleteData()
        {
            string str = _originalConnString;
            int startStr = str.LastIndexOf("=");
            string dataBase = str.Substring(startStr + 1);

            SqlConnection conn = new SqlConnection(_originalConnString);
            string commText = "DROP DATABASE " + dataBase;
            SqlCommand comm = new SqlCommand(commText, conn);
            conn.Open();
            comm.ExecuteNonQuery();
            conn.Close();
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
                String archivePath = System.IO.Path.Combine(organizePath, "归档目录");
                Directory.CreateDirectory(archivePath);

                // create resource for archive folder
                CResourceEntity archiveRes = new CResourceEntity(_connString);
                archiveRes.Res_Name = "归档目录";
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
            newUser.Usr_Name = _memberName;
            newUser.Usr_Organize = orgId;
            newUser.Usr_Password = _memberPwd;
            newUser.Usr_Email = _memberEmail;

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
                acl3.Acl_Id = acl3.Insert();

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