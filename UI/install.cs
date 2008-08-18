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
#region ��Ա����
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

                if(userList.Count > 0)//������û��Ѿ����ڣ���Ҫ������������
                {
                    LoginForm login = new LoginForm();
                    login.Closed += new EventHandler(login_Closed);
                    login.ShowDialog();
                }
                //������û���һ��ʹ�ñ�ϵͳ����Ϊ�䴴���ʻ�
                this.btnCreate.Enabled = true;
                this.btnInitialize.Enabled = false;
            }
            catch(Exception ex)
            {
                MessageBox.Show("ϵͳ����"+ex.Message, "�ĵ�����ϵͳ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        void login_Closed(object sender, EventArgs e)
        {
            LoginForm login = (LoginForm)sender;
            if (login.DialogResult != DialogResult.OK)
                return;

            this.btnCreate.Enabled = false;
            this.btnInitialize.Enabled = true;
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            if (txtServer.Text == "" || txtUserId.Text == "" || txtPassword.Text == "" || txtInitialCatalog.Text == "" || txtPath.Text == ""||txtOrgName.Text == "")
            {
                MessageBox.Show("����δ��д����Ŀ��", "�ĵ�����ϵͳ", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            _server = txtServer.Text;
            _userId = txtUserId.Text;
            _password = txtPassword.Text;
            _initialCatalog = txtInitialCatalog.Text;
            _orgName = txtOrgName.Text;
            string pt = txtPath.Text;
            if(pt[2].ToString() == "/")
            {
                MessageBox.Show("·����ʽ����ȷ��", "�ĵ�����ϵͳ", MessageBoxButtons.OK, MessageBoxIcon.Stop);
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
                MessageBox.Show("������ȷ�����벻��Ϊ�գ�", "�ĵ�����ϵͳ", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            else if(txtMemberPwd.Text != txtSurePwd.Text)
            {
                MessageBox.Show("������ȷ�����벻��ͬ��", "�ĵ�����ϵͳ", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            _userPwd = CHelperClass.UserMd5(txtMemberPwd.Text.ToString());
            _userName = txtMemberName.Text;

            try
            {
                CreateDataBase();
                ChangeWebConfig();
                CreateTable(_connString);
                CreateRootDir();

                MessageBox.Show("ע��ɹ���������¼ϵͳǰ��'Web1.config'�ĳ�'Web.config'�滻ԭ��Web.config�ļ�", "�ĵ�����ϵͳ", 
                    MessageBoxButtons.OK, MessageBoxIcon.Information,new EventHandler(Create_Closed));
            }
            catch(Exception ex)
            {
                MessageBox.Show("ϵͳ����" + ex.Message, "�ĵ�����ϵͳ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Create_Closed(object sender,EventArgs e)
        {
            if (((Form)sender).DialogResult == DialogResult.OK)
                Context.Redirect("~MainForm.wgx");
        }
        /// <summary>
        /// �������ݿ�
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

            try
            {
                DBconn.Open();
                comm.ExecuteNonQuery();
            }
            catch(Exception ex)
            {
                throw (ex);
            }
            finally
            {
                DBconn.Close();
            }
        }
        /// <summary>
        /// ��������Ա�ʻ�
        /// </summary>
        private void CreateAdmin()
        {
            //Ϊ����Ա����Ŀ¼,�������ǹ���Ա���˺�(member),д����Դ��-TBL_Resource
            string adminPath = _rootPath + "\\" + _member;
            System.IO.Directory.CreateDirectory(adminPath);
            
            SqlConnection adminRootConn = new SqlConnection(_connString);
            CResourceEntity res = new CResourceEntity();
            List<CResourceEntity> resLst = new List<CResourceEntity>();
            resLst = res.GetObjectList("this.Res_Name ='" + _orgName + "'");
            int adminParent = resLst[0].Res_Id; //����ԱĿ¼�ĸ�Ŀ¼,������֯����ԴID
            string adminCommText = "INSERT INTO TBL_Resource"
                + "(Res_Name,Res_Type,Res_Parent) VALUES ('" +
                _member + "',1,'" + adminParent + "')";
            SqlCommand adminRootComm = new SqlCommand(adminCommText, adminRootConn);
            adminRootConn.Open();
            adminRootComm.ExecuteNonQuery();
            adminRootConn.Close();

            //��������Ա�ʻ�,д���û���-TBL_User
            SqlConnection adminConn = new SqlConnection(_connString);
            CResourceEntity adminRes = new CResourceEntity();
            List<CResourceEntity> adminLst = new List<CResourceEntity>();
            adminLst = adminRes.GetObjectList("this.Res_Name ='" + _member + "'");
            int adRes = adminLst[0].Res_Id;//����Ա����ԴID
            string commText = "INSERT INTO TBL_User (Usr_Member,Usr_Password,Usr_Name,Usr_Resource,Usr_Organize,Usr_Type)"
                +"VALUES ('" + _member + "','" + _userPwd + "','" + _userName + "','" + adRes + "','" + resLst[0].Res_Id + "','" + (int)USERTYPE.ORGANIZEADMIN + "')";
            SqlCommand adminComm = new SqlCommand(commText,adminConn);
            adminConn.Open();
            adminComm.ExecuteNonQuery();
            adminConn.Close();

            //����TBL_ACL��
            CUserEntity user = new CUserEntity();
            List<CUserEntity> usrLst=new List<CUserEntity>();
            usrLst = user.GetObjectList("this.Usr_Member ='"+_member+"'");
            CACLEntity acl = new CACLEntity();
            acl.Acl_Resource = usrLst[0].Usr_Resource;
            acl.Acl_Operation = (int)ACLOPERATION.CREATENORMALUSER;
            acl.Acl_Role = usrLst[0].Usr_Id;
            acl.Acl_RType = (int)ACLROLETYPE.USERROLE;
            acl.Acl_Creator = usrLst[0].Usr_Id;
            acl.Insert();
        }
        /// <summary>
        /// �޸�Web.config�ļ�
        /// </summary>
        private void ChangeWebConfig()
        {
            string fileName = Context.Server.MapPath("/Web.config");
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(fileName);

            string connString = "Server=" + _server +
                                  ";User Id=" + _userId +
                                  ";Password=" + _password +
                                  ";Initial Catalog=" + _initialCatalog;
            _connString = connString;
            MidLayerSettings.ConnectionString = connString;
            
            XmlNodeList nodeList = xmlDoc.DocumentElement.ChildNodes;
            
            foreach(XmlElement element in nodeList)
            {
                if(element.Name == "connectionStrings")
                {
                    XmlNodeList node = element.ChildNodes;
                    if (node.Count <= 0)
                        throw new Exception("ϵͳ���������·��ʸ�ҳ��");

                    foreach(XmlElement aNode in node)
                    {
                        if(aNode.Attributes["name"].Value == "ConnectionString")
                        {
                            aNode.Attributes["connectionString"].Value = connString;
                        }
                    }
                } 

                if(element.Name == "appSettings")
                {
                    XmlNodeList nodelst = element.ChildNodes;
                    if (nodelst.Count <= 0)
                        throw new Exception("ϵͳ���������·��ʸ�ҳ��");

                    foreach(XmlElement aNode in nodelst)
                    {
                        if(aNode.Attributes["key"].Value == "UserData")
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
        /// ��������֯��Ŀ¼
        /// </summary>
        private void CreateRootDir()
        {
            string path = txtPath.Text;
            if(path.Length <= 0)
                throw new Exception("·�������ڣ�");

            //������Ŀ¼������Ŀ¼д����Դ��-TBL_Resource
            path += _orgName;
            System.IO.Directory.CreateDirectory(path);
            _rootPath = path;

            SqlConnection orgRootConn = new SqlConnection(_connString);
            string newRoot = "INSERT INTO TBL_Resource"
                +"(Res_Name,Res_Type,Res_Parent) VALUES ('" + _orgName + "','" + (int)RESOURCETYPE.ORGANIZERESOURCE +"',0)";
            SqlCommand rootComm = new SqlCommand(newRoot, orgRootConn);
            orgRootConn.Open();
            rootComm.ExecuteNonQuery();
            orgRootConn.Close();

            //create the archiveDir,and write to the table of TBL_Resource
            System.IO.Directory.CreateDirectory(_rootPath);
            CResourceEntity res = new CResourceEntity();
            List<CResourceEntity> reslst = new List<CResourceEntity>();
            reslst = res.GetObjectList("this.Res_Name ='" + _orgName + "'");
            int parentId = reslst[0].Res_Id;

            res.Res_Name = "�鵵Ŀ¼";
            res.Res_Type = (int)RESOURCETYPE.FOLDERRESOURCE;
            res.Res_Parent = parentId;
            res.Insert();

            CResourceEntity arc=new CResourceEntity();
            List<CResourceEntity> arclst=new List<CResourceEntity>();
            arclst = arc.GetObjectList("this.Res_Name ='" + _orgName + "'");

            //������֯д����֯��-TBL_Organize
            SqlConnection orgConn = new SqlConnection(_connString);
            string newOrg = "INSERT INTO TBL_Organize (Org_Name,Org_Resource,Org_ArchiveRes) VALUES ('" 
                + _orgName + "'," + "'" + reslst[0].Res_Id + "'," + "'" + arclst[0].Res_Id + "')";
            SqlCommand orgComm = new SqlCommand(newOrg,orgConn);
            orgConn.Open();
            orgComm.ExecuteNonQuery();
            orgConn.Close();

            //��������Ա�ʻ��͹���ԱĿ¼
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
                MessageBox.Show("·����ʽ����ȷ��", "�ĵ�����ϵͳ", MessageBoxButtons.OK, MessageBoxIcon.Stop);
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
                MessageBox.Show("������ȷ�����벻��Ϊ�գ�", "�ĵ�����ϵͳ", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            else if (txtMemberPwd.Text != txtSurePwd.Text)
            {
                MessageBox.Show("������ȷ�����벻��ͬ��", "�ĵ�����ϵͳ", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            _userPwd = CHelperClass.UserMd5(txtMemberPwd.Text.ToString());
            _userName = txtMemberName.Text;

            try
            {
                DeleteData();
                CreateTable(_connString);
                CreateRootDir();

                MessageBox.Show("����ϵͳ�ѳ�ʼ����������¼ϵͳ��", "�ĵ�����ϵͳ",
                    MessageBoxButtons.OK, MessageBoxIcon.Information, new EventHandler(Initialize_Closed));
            }
            catch (Exception ex)
            {
                MessageBox.Show("ϵͳ����" + ex.Message, "�ĵ�����ϵͳ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Initialize_Closed(object sender, EventArgs e)
        {
            if (((Form)sender).DialogResult == DialogResult.OK)
                Context.Redirect("~MainForm.wgx");
        }

        private void DeleteData()
        {
            throw new Exception("δɾ����Դ��");
        }
    }
}