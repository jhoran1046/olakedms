#region Using

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;

using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Forms;

using MidLayer;
using System.Data.SqlClient;
using System.Configuration;
using System.Xml;
using System.Collections;
using System.IO;
using Framework.Util;

#endregion

namespace UI
{
    public partial class install : Form
    {
#region 成员变量
        String _server;

        public String Server
        {
            get { return _server; }
            set { _server = value; }
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
        String _path;//用户输入的服务器上的路径

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
        String _rootPath;//新创建的组织的根目录

        public String RootPath
        {
            get { return _rootPath; }
            set { _rootPath = value; }
        }
#endregion

        public install()
        {
            InitializeComponent();
        }

        private void install_Load(object sender, EventArgs e)
        {
            try
            {
                CUserEntity user = new CUserEntity();
                List<CUserEntity> userList = new List<CUserEntity>();
                userList = user.GetObjectList("this.Usr_Type = '1'");

                if(userList.Count > 0)
                {
                    LoginForm login = new LoginForm();
                    login.Closed += new EventHandler(login_Closed);
                    login.ShowDialog();
                }

                this.btnCreate.Visible = true;
                this.btnInitialize.Visible = false;
            }
            catch(Exception ex)
            {
                MessageBox.Show("系统错误："+ex.Message, "文档管理系统", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        void login_Closed(object sender, EventArgs e)
        {
            LoginForm login = (LoginForm)sender;
            if (login.DialogResult != DialogResult.OK)
                return;

            this.btnCreate.Visible = false;
            this.btnInitialize.Visible = true;
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            _server = txtServer.Text;
            _userId = txtUserId.Text;
            _password = txtPassword.Text;
            _initialCatalog = txtInitialCatalog.Text;
            string pt = txtPath.Text;
            if(pt[2].ToString() == "/")
            {
                MessageBox.Show("路径格式不正确！", "文档管理系统", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            else if(pt[pt.Length-1].ToString() != "\\")
            {
                pt += "\\";
            }
            _path = pt;

            _member = txtMember.Text;
            if(txtMemberPwd.Text == ""||txtSurePwd.Text == "")
            {
                MessageBox.Show("密码与确认密码不能为空！", "文档管理系统", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            else if(txtMemberPwd.Text != txtSurePwd.Text)
            {
                MessageBox.Show("密码与确认密码不相同！", "文档管理系统", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            _userPwd = CHelperClass.UserMd5(txtMemberPwd.Text.ToString());
            _userName = txtMemberName.Text;

            try
            {
                CreateDataBase();
                CreateTable(_connString);
                CreateRootDir();

                MessageBox.Show("注册成功！请您登录系统！", "文档管理系统", 
                    MessageBoxButtons.OK, MessageBoxIcon.Information,new EventHandler(Create_Closed));
            }
            catch(Exception ex)
            {
                MessageBox.Show("系统错误：" + ex.Message, "文档管理系统", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Create_Closed(object sender,EventArgs e)
        {
            if (((Form)sender).DialogResult == DialogResult.OK)
                Context.Redirect("~MainForm.wgx");
        }
        /// <summary>
        /// 创建数据库
        /// </summary>
        private void CreateDataBase()
        {
            SqlConnection DBconn;
            string createDB;
            DBconn = new SqlConnection();
            DBconn.ConnectionString = "Server=" + _server
                           + ";User Id=" + _userId 
                           + ";Password=" + _password;
            createDB = "CREATE DATABASE " + _initialCatalog;
            SqlCommand comm = new SqlCommand(createDB, DBconn);

            //获取新数据库的完整字符串
            string connString = DBconn.ConnectionString;
            connString += ";Initial Catalog =";
            connString += _initialCatalog;
            _connString = connString;

            try
            {
                DBconn.Open();
                comm.ExecuteNonQuery();
            }
            catch
            {
                throw new Exception("系统错误！");
            }
            finally
            {
                DBconn.Close();
            }
        }
        /// <summary>
        /// 创建管理员帐户
        /// </summary>
        private void CreateAdmin()
        {
            //为管理员创建目录,其名称是管理员的账号(member),写入资源表-TBL_Resource
            string adminPath = _rootPath + "\\" + _member;
            System.IO.Directory.CreateDirectory(adminPath);
            
            SqlConnection adminRootConn = new SqlConnection();
            CResourceEntity res = new CResourceEntity();
            List<CResourceEntity> resLst = new List<CResourceEntity>();
            resLst = res.GetObjectList("this.Res_Name ='" + txtOrgName + "'");
            int adminParent = resLst[0].Res_Id; //管理员目录的父目录,即该组织的资源ID
            string adminCommText = "INSERT INTO TBL_Resource"
                + "(Res_Name,Res_Type,Res_Parent) VALUES ('" +
                _member + "',1,'" + adminParent + "')";
            SqlCommand adminRootComm = new SqlCommand(adminCommText, adminRootConn);
            adminRootConn.Open();
            adminRootComm.ExecuteNonQuery();
            adminRootConn.Close();

            //创建管理员帐户,写入用户表-TBL_User
            SqlConnection adminConn = new SqlConnection(_connString);
            CResourceEntity adminRes = new CResourceEntity();
            List<CResourceEntity> adminLst = new List<CResourceEntity>();
            adminLst = adminRes.GetObjectList("this.Res_Name ='" + _member + "'");
            int adRes = adminLst[0].Res_Id;//管理员的资源ID
            string commText = "INSERT INTO TBL_User (Usr_Member,Usr_Password,Usr_Name,Usr_Resource,Usr_Organize,Usr_Type)"
                +"VALUES ('" + _member + "','" + _userPwd + "','" + _userName + "','" + adRes + "','" + resLst[0].Res_Id + "',1)";
            SqlCommand adminComm = new SqlCommand(commText,adminConn);
            adminConn.Open();
            adminComm.ExecuteNonQuery();
            adminConn.Close();
        }
        /// <summary>
        /// 修改Web.config文件
        /// </summary>
        private void ChangeWebConfig()
        {
            string fileName = Context.Server.MapPath("/Web.config");
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(fileName);

            XmlNodeList nodeList = xmlDoc.DocumentElement.ChildNodes;

            foreach(XmlElement element in nodeList)
            {
                if(element.Name == "connectionStrings")
                {
                    XmlNodeList node = element.ChildNodes;
                    if (node.Count <= 0)
                        throw new Exception("系统错误！请重新访问该页！");

                    foreach(XmlElement aNode in node)
                    {
                        aNode["connectionString"].Value = "Provider=SQLOLEDB;" +
                            "Server=" + _server +
                            ";User Id=" + _userId +
                            ";Password=" + _password +
                            ";Initial Catalog=" + _initialCatalog;
                    }
                } 

                if(element.Name == "appSettings")
                {
                    XmlNodeList nodelst = element.ChildNodes;
                    if (nodelst.Count <= 0)
                        throw new Exception("系统错误！请重新访问该页！");

                    foreach(XmlElement aNode in nodelst)
                    {
                        if(aNode.Attributes["key"].Value == "UserData")
                        {
                            aNode.Attributes["value"].Value = _path;
                        }                      
                    }
                }
            }
        }
        /// <summary>
        /// 为新数据库创建数据表：
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
                throw new Exception("请检查您的服务器！");
            }
            finally
            {
                conn.Close();
            }
        }
        /// <summary>
        /// 创建新组织根目录
        /// </summary>
        private void CreateRootDir()
        {
            string path = ConfigurationManager.AppSettings["UserData"];
            if(path.Length <= 0)
                throw new Exception("路径不存在！");

            //创建根目录，将根目录写入资源表-TBL_Resource
            path += txtOrgName;
            System.IO.Directory.CreateDirectory(path);
            _rootPath = path;

            SqlConnection orgRootConn = new SqlConnection(_connString);
            string newRoot = "INSERT INTO TBL_Resource"
                +"(Res_Name,Res_Type,Res_Parent) VALUES ('" + txtOrgName + "',1,0)";
            SqlCommand rootComm = new SqlCommand(newRoot, orgRootConn);
            orgRootConn.Open();
            rootComm.ExecuteNonQuery();
            orgRootConn.Close();

            //将新组织写入组织表-TBL_Organize
            SqlConnection orgConn = new SqlConnection(_connString);
            string newOrg = "INSERT INTO TBL_Organize (Org_Name) VALUES '" + txtOrgName + "'";
            SqlCommand orgComm = new SqlCommand(newOrg,orgConn);
            orgConn.Open();
            orgComm.ExecuteNonQuery();
            orgConn.Close();

            //创建管理员帐户和管理员目录
            CreateAdmin();
        }

        private void btnInitialize_Click(object sender, EventArgs e)
        {
            _server = txtServer.Text;
            _userId = txtUserId.Text;
            _password = txtPassword.Text;
            _initialCatalog = txtInitialCatalog.Text;
            string pt = txtPath.Text;
            if (pt[2].ToString() == "/")
            {
                MessageBox.Show("路径格式不正确！", "文档管理系统", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            else if (pt[pt.Length - 1].ToString() != "\\")
            {
                pt += "\\";
            }
            _path = pt;

            _member = txtMember.Text;
            if (txtMemberPwd.Text == "" || txtSurePwd.Text == "")
            {
                MessageBox.Show("密码与确认密码不能为空！", "文档管理系统", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            else if (txtMemberPwd.Text != txtSurePwd.Text)
            {
                MessageBox.Show("密码与确认密码不相同！", "文档管理系统", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            _userPwd = CHelperClass.UserMd5(txtMemberPwd.Text.ToString());
            _userName = txtMemberName.Text;

            try
            {
                CreateDataBase();
                CreateTable(_connString);
                CreateRootDir();

                MessageBox.Show("注册成功！请您登录系统！", "文档管理系统",
                    MessageBoxButtons.OK, MessageBoxIcon.Information, new EventHandler(Create_Closed));
            }
            catch (Exception ex)
            {
                MessageBox.Show("系统错误：" + ex.Message, "文档管理系统", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}