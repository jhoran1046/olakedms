#region Using

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.IO;

using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common.Resources;
using Gizmox.WebGUI.Common.Interfaces;
using Gizmox.WebGUI.Common.Gateways;
using MidLayer;

#endregion

namespace CommonUI
{
    public partial class FileList : UserControl, IGatewayControl
    {
        string _rootDir;
        HelpClass _helper;
        string _keyword;

        public string Keyword
        {
            get { return _keyword; }
            set { _keyword = value; }
        }

        public string RootDir
        {
            get { return _rootDir; }
            set { _rootDir = value; }
        }

        public HelpClass Helper
        {
            set { _helper = value; }
        }

        CUserEntity _currentUser;

        public CUserEntity CurrentUser
        {
            get { return _currentUser; }
            set { _currentUser = value; }
        }

        int _parentResourceId;
        public int ParentResourceId
        {
            get { return _parentResourceId; }
            set { _parentResourceId = value; }
        }

        public FileList ( )
        {
            InitializeComponent ( );
            fileListView.HeaderStyle = ColumnHeaderStyle.Nonclickable;
            CreateContextMenu();
        }

        public Font _defaultFnt = new Font ( "arial" , 9 );

        public void CreateContextMenu()
        {
            MenuItem MenuItem1 = new Gizmox.WebGUI.Forms.MenuItem();
            MenuItem MenuItem2 = new Gizmox.WebGUI.Forms.MenuItem();
            MenuItem MenuItem3 = new Gizmox.WebGUI.Forms.MenuItem();
            MenuItem MenuItem4 = new Gizmox.WebGUI.Forms.MenuItem();
            MenuItem MenuItem5 = new Gizmox.WebGUI.Forms.MenuItem();
            MenuItem MenuItem6 = new Gizmox.WebGUI.Forms.MenuItem();
            MenuItem MenuItem7 = new Gizmox.WebGUI.Forms.MenuItem();
            MenuItem MenuItem8 = new Gizmox.WebGUI.Forms.MenuItem();
            MenuItem MenuItem9 = new Gizmox.WebGUI.Forms.MenuItem();
            MenuItem MenuItem10 = new Gizmox.WebGUI.Forms.MenuItem();
           // MenuItem MenuItem11 = new Gizmox.WebGUI.Forms.MenuItem();

            MenuItem3.Text = "���ļ�";
            MenuItem3.Click += new System.EventHandler(this.menuOpenFile_Click);
            MenuItem3.Icon = new IconResourceHandle("Open.gif");
            fileContextMenu.MenuItems.Add(MenuItem3);

            MenuItem1.Text = "ɾ���ļ�";
            MenuItem1.Click += new System.EventHandler(this.menuDeleteFile_Click);
            MenuItem1.Icon = new IconResourceHandle("Delete.gif");
            fileContextMenu.MenuItems.Add(MenuItem1);

            MenuItem2.Text = "�����ļ�";
            MenuItem2.Click += new System.EventHandler(this.menuShareFile_Click);
            MenuItem2.Icon = new IconResourceHandle("shareFolder.gif");
            fileContextMenu.MenuItems.Add(MenuItem2);

            MenuItem4.Text = "�����ļ�";
            MenuItem4.Click += new System.EventHandler(this.menuUpdateFile_Click);
            MenuItem4.Icon = new IconResourceHandle("changeFile.gif");
            fileContextMenu.MenuItems.Add(MenuItem4);

            MenuItem10.Text = "����";
            MenuItem10.Click += new System.EventHandler(this.menuCopyFile_Click);
            MenuItem10.Icon = new IconResourceHandle("copy.gif");
            fileContextMenu.MenuItems.Add(MenuItem10);
/*
            MenuItem11.Text = "����";
            MenuItem11.Click += new System.EventHandler(this.menuCutFile_Click);
            fileContextMenu.MenuItems.Add(MenuItem11);
*/
            MenuItem6.Text = "���Ĺؼ���";
            MenuItem6.Click += new EventHandler(menuKeyWord_Click);
            MenuItem6.Icon = new IconResourceHandle("keyword.gif");
            fileContextMenu.MenuItems.Add(MenuItem6);

            MenuItem5.Text = "ˢ��";
            MenuItem5.Click += new EventHandler(menuRefreshFilst_Click);
            MenuItem5.Icon = new IconResourceHandle("refresh.bmp");
            fileContextMenu.MenuItems.Add(MenuItem5);

            MenuItem8.Text = "�ϴ��ļ�";
            MenuItem8.Click += new EventHandler(menuUpLoadFile_Click);
            MenuItem8.Icon = new IconResourceHandle("update.gif");
            fileContextMenu.MenuItems.Add(MenuItem8);

            MenuItem9.Text = "�����ĵ�";
            MenuItem9.Click += new EventHandler(menuBookDoc_Click);
            MenuItem9.Icon = new IconResourceHandle("book.gif");
            fileContextMenu.MenuItems.Add(MenuItem9);
        }

        private void menuCopyFile_Click(object sender, EventArgs e)
        {
            try
            {
                List<int> resources = new List<int>();
                foreach (ListViewItem item in FileListView.SelectedItems)
                {
                    resources.Add((int)item.Tag);
                }
                if (resources.Count == 0)
                {
                    MessageBox.Show("��ѡ���ļ���", "�ĵ�����ϵͳ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                ResourceClip clipBoard = (ResourceClip)Context.Session["ResourceClipBoard"];
                clipBoard.Copy(_currentUser, resources);
            }
            catch (Exception ex)
            {
                MessageBox.Show("ϵͳ����: " + ex.Message, "�ĵ�����ϵͳ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
/*
        private void menuCutFile_Click(object sender, EventArgs e)
        {
            try
            {
                List<int> resources = new List<int>();
                foreach (ListViewItem item in FileListView.SelectedItems)
                {
                    resources.Add((int)item.Tag);
                }
                if (resources.Count == 0)
                {
                    MessageBox.Show("��ѡ���ļ���", "�ĵ�����ϵͳ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                ResourceClip clipBoard = (ResourceClip)Context.Session["ResourceClipBoard"];
                clipBoard.Cut(_currentUser, resources);
            }
            catch (Exception ex)
            {
                MessageBox.Show("ϵͳ����: " + ex.Message, "�ĵ�����ϵͳ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
*/
        void menuBookDoc_Click(object sender, EventArgs e)
        {
            int selectedCount = fileListView.SelectedItems.Count;
            if(selectedCount <= 0)
            {
                MessageBox.Show("û��ѡ�е��ļ���", "�ĵ�����ϵͳ", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            try
            {
                foreach(ListViewItem item in fileListView.SelectedItems)
                {
                    _currentUser.BookRead((int)item.Tag);
                }
                if(selectedCount > 0)
                {
                    MessageBox.Show("���Ѷ���ѡ�е��ļ���", "�ĵ�����ϵͳ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("ϵͳ����"+ex.Message, "�ĵ�����ϵͳ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        void menuUpLoadFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog objfile = new OpenFileDialog();
            objfile.Closed += new EventHandler(objfile_Closed);
            objfile.MaxFileSize = 100000;
            objfile.ShowDialog();
        }

        void objfile_Closed(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog newfile = (OpenFileDialog)sender;
                _helper.UploadFile(_currentUser, _parentResourceId, newfile);
                LoadFiles();
            }
            catch(Exception ex)
            {
                MessageBox.Show("ϵͳ����"+ex.Message, "�ĵ�����ϵͳ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        void menuKeyWord_Click(object sender, EventArgs e)
        {
            if(fileListView.SelectedItems.Count == 0)
            {
                MessageBox.Show("��ѡ���ļ���", "�ĵ�����ϵͳ", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            try
            {
                KeyWdForm keyword = new KeyWdForm();
                keyword.Closed += new EventHandler(keyword_Closed);
                keyword.ShowDialog();
            }
            catch(Exception ex)
            {
                MessageBox.Show("ϵͳ����"+ex.Message, "�ĵ�����ϵͳ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        void keyword_Closed(object sender, EventArgs e)
        {
            KeyWdForm keyWd = (KeyWdForm)sender;
            if (keyWd.DialogResult != DialogResult.OK)
                return;

            try
            {
                foreach(ListViewItem item in fileListView.SelectedItems)
                {
                    _currentUser.KeyWordChange((int)item.Tag, keyWd.KeyWord);
                    LoadFiles();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("ϵͳ����"+ex.Message, "�ĵ�����ϵͳ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        void menuRefreshFilst_Click(object sender, EventArgs e)
        {
            LoadFiles();
        }

        /// <summary>
        /// RootDir must be set before this is called
        /// </summary>
        public void LoadFiles()
        {
            fileListView.Items.Clear();
            //List<File> fileList =  _helper.GetFiles( RootDir );
            List<File> fileList = _helper.GetFiles(_currentUser, _parentResourceId);
            if ( fileList.Count == 0 )
            {
                fileListView.DataSource = null;
                return;
            }
            /*fileListView.DataSource = fileList;
            fileListView.HeaderStyle = ColumnHeaderStyle.Nonclickable;
            fileListView.Columns [ 0 ].Text = "�ļ���";
            fileListView.Columns [ 0 ].AutoResize ( ColumnHeaderAutoResizeStyle.ColumnContent );
            fileListView.Columns [ 0 ].Type = ListViewColumnType.Text;
            //fileListView.Columns [ 0 ].Image = new ImageResourceHandle ("icons/properties.gif" );
            
            fileListView.Columns [ 1 ].Label = "��չ��";
            fileListView.Columns [ 1 ].Width = 60;
            fileListView.Columns [ 1 ].Type = ListViewColumnType.Text ;
            fileListView.Font = _defaultFnt;
            */
            /*
            ColumnHeader nameHeader = new ColumnHeader();
            nameHeader.Text = "�ļ���";
            nameHeader.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
            nameHeader.Type = ListViewColumnType.Text;
            nameHeader.Visible = true;
            fileListView.Columns.Add(nameHeader);

            ColumnHeader extHeader = new ColumnHeader();
            extHeader.Text = "��չ��";
            extHeader.Width = 60;
            extHeader.Type = ListViewColumnType.Text;
            extHeader.Visible = true;
            fileListView.Columns.Add(extHeader);
            */

            foreach (File f in fileList)
            {
                ListViewItem lvi = new ListViewItem();
                ListViewItem.ListViewSubItem lvsi;

                lvi.Text = f.FileName;
                IconResourceHandle icoHandle = new IconResourceHandle(f.Ext+".ico");
                if(!System.IO.File.Exists(Context.HttpContext.Server.MapPath("/resources/icons/" + f.Ext + ".ico")))
                {
                    icoHandle = new IconResourceHandle("anual.ico");          
                }

                lvi.SmallImage = icoHandle;
                lvi.Tag = f.ResourceId;

                lvsi = new ListViewItem.ListViewSubItem();
                lvsi.Text = f.Ext;
                lvi.SubItems.Add(lvsi);

                lvsi = new ListViewItem.ListViewSubItem();
                CResourceEntity resource = new CResourceEntity().Load(f.ResourceId);
                lvsi.Text = resource.Res_KeyWord;
                lvi.SubItems.Add(lvsi);

                lvsi = new ListViewItem.ListViewSubItem();
                lvsi.Text = f.ResourceId.ToString();
                lvi.SubItems.Add(lvsi);

                fileListView.Items.Add(lvi);
            }

            fileListView.Update ( );
            // fileListView.AutoResizeColumn ( 0 , ColumnHeaderAutoResizeStyle.ColumnContent );
        }

        #region IGatewayControl Members

        IGatewayHandler IGatewayControl.GetGatewayHandler(IContext objContext, string strAction)
        {
            if (strAction == "Download")
            {
                //objContext.HttpContext.Response.ContentType = "image/jpeg";
                int res = (int)fileListView.SelectedItems[0].Tag;
                CACLEntity acl = new CACLEntity(_currentUser.ConnString);
                acl.Acl_Operation = (int)ACLOPERATION.READ;
                acl.Acl_Resource = res;
                acl.Acl_Role = _currentUser.Usr_Id;
                acl.Acl_RType = (int)ACLROLETYPE.USERROLE;
                if (!_currentUser.CheckPrivilege(acl))
                    return null;
                CResourceEntity resource = new CResourceEntity(_currentUser.ConnString).Load(res);
                String fileName = "attachment; filename=\"" + resource.Res_Name + "\"";
                String fullPath = resource.MakeFullPath();
                objContext.HttpContext.Response.AddHeader("content-disposition", fileName);
                objContext.HttpContext.Response.WriteFile(fullPath);
            }
            return null;
        }

        #endregion
/*
        private void fileListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            LinkParameters objLinkParameters = new LinkParameters();
            objLinkParameters.Target = "_self";

            Link.Open(new GatewayReference(this, "Download"), objLinkParameters);
        }
*/

        private void menuDeleteFile_Click(object sender, EventArgs e)
        {
            if(fileListView.SelectedItems.Count == 0)
            {
                MessageBox.Show("û��ѡ�е��ļ���", "�ĵ�����ϵͳ", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            MessageBox.Show("ȷ��Ҫɾ���ļ���", "�ĵ�����ϵͳ", MessageBoxButtons.YesNo,
                MessageBoxIcon.Question, new EventHandler(DeleteFileHandler));
        }

        private void DeleteFileHandler(object sender, EventArgs e)
        {
            if (((Form)sender).DialogResult != DialogResult.Yes)
            {
                return;
            }

            try
            {
                foreach (ListViewItem item in fileListView.SelectedItems)
                {
                    string body = _currentUser.Usr_Name;
                    body += "��";
                    body += DateTime.Now.ToString();
                    body += "ɾ����";
                    body += item.Text;
                    body += "�ļ�";

                    _helper.DeleteFile(_currentUser, (int)item.Tag);

                    _currentUser.MailSend((int)item.Tag, body);
                }
                LoadFiles();
            }
            catch(Exception ex)
            {
                MessageBox.Show("ɾ���ļ�ʧ��!"+ex.Message, "�ĵ�����ϵͳ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void menuShareFile_Click(object sender, EventArgs e)
        {
            if(fileListView.SelectedItems.Count == 0)
            {
                MessageBox.Show("û��ѡ�е��ļ���", "�ĵ�����ϵͳ", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            try
            {
                foreach (ListViewItem item in fileListView.SelectedItems)
                {
                    int res = (int)item.Tag;
                    if (res <= 0)
                    {
                        MessageBox.Show("�޷�����ѡ�����Դ��", "�ĵ�����ϵͳ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    _helper.ShareResource(_currentUser, res);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("�޷�����: " + ex.Message, "�ĵ�����ϵͳ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void menuOpenFile_Click(object sender, EventArgs e)
        {
            if (fileListView.SelectedItems.Count != 1)
            {
                MessageBox.Show("��ѡ��һ���ļ���", "�ĵ�����ϵͳ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            LinkParameters objLinkParameters = new LinkParameters();
            objLinkParameters.Target = "_self";

            Link.Open(new GatewayReference(this, "Download"), objLinkParameters);
        }

        private void menuUpdateFile_Click(object sender,EventArgs e)
        {
            int selectCount = fileListView.SelectedItems.Count;
            if (selectCount != 1)
            {
                MessageBox.Show("��ѡ��һ���ļ���", "�ĵ�����ϵͳ", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            MessageBox.Show("��ȷ��Ҫ����ԭ�ļ���", "�ĵ�����ϵͳ", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, 
                new EventHandler(UpdateFileClosed));
        }
        protected void UpdateFileClosed(object sender, EventArgs e)
        {
            if (((Form)sender).DialogResult != DialogResult.Yes)
                return;
            try
            {
                OpenFileDialog newFile = new OpenFileDialog();
                newFile.FileOk += new CancelEventHandler(newFile_FileOk);
                newFile.MaxFileSize = 1000000;
                newFile.Multiselect = true;
                newFile.ShowDialog();
            }
            catch(Exception ex)
            {
                MessageBox.Show("ϵͳ����"+ex.Message, "�ĵ�����ϵͳ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        void newFile_FileOk(object sender, CancelEventArgs e)
        {
            try
            {
                int selectCount = fileListView.SelectedItems.Count;
                if (selectCount != 1)
                {
                    MessageBox.Show("��ѡ��һ���ļ���", "�ĵ�����ϵͳ", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }

                int resId = (int)fileListView.SelectedItems[0].Tag;
                OpenFileDialog newfile = (OpenFileDialog)sender;
                _helper.Update(_currentUser, (int)fileListView.SelectedItems[0].Tag, newfile);

                string body = _currentUser.Usr_Name.ToString();
                body += "��";
                body += DateTime.Now.ToString();
                body += "������";
                body += fileListView.SelectedItems[0].Text + "�ļ�";
                _currentUser.MailSend(resId,body);

                LoadFiles();
            }
            catch(Exception ex)
            {
                MessageBox.Show("ϵͳ����"+ex.Message, "�ĵ�����ϵͳ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}