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
/*            MenuItem MenuItem2 = new Gizmox.WebGUI.Forms.MenuItem();
            MenuItem MenuItem3 = new Gizmox.WebGUI.Forms.MenuItem();
            MenuItem MenuItem4 = new Gizmox.WebGUI.Forms.MenuItem();
            MenuItem MenuItem5 = new Gizmox.WebGUI.Forms.MenuItem();
            MenuItem MenuItem6 = new Gizmox.WebGUI.Forms.MenuItem();
            MenuItem MenuItem7 = new Gizmox.WebGUI.Forms.MenuItem();
            MenuItem MenuItem8 = new Gizmox.WebGUI.Forms.MenuItem();
            MenuItem MenuItem9 = new Gizmox.WebGUI.Forms.MenuItem();
*/
            MenuItem1.Text = "删除文件";
            MenuItem1.Click += new System.EventHandler(this.menuDeleteFile_Click);
            fileContextMenu.MenuItems.Add(MenuItem1);

            //MenuItem9.Text = "复制";
            //MenuItem9.Click += new System.EventHandler(this.menuCopyFile_Click);
            //contextMenuRightFile.MenuItems.Add(MenuItem9);

            //MenuItem10.Text = "共享设置";
            //MenuItem10.Click += new System.EventHandler(this.menuShareFolder_Click);
            //contextMenuRightFile.MenuItems.Add(MenuItem10);
            
            //MenuItem11.Text = "剪切";
            //MenuItem11.Click += new System.EventHandler(this.menuCutFile_Click);
            //contextMenuRightFile.MenuItems.Add(MenuItem11);
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
            fileListView.Columns [ 0 ].Text = "文件名";
            fileListView.Columns [ 0 ].AutoResize ( ColumnHeaderAutoResizeStyle.ColumnContent );
            fileListView.Columns [ 0 ].Type = ListViewColumnType.Text;
            //fileListView.Columns [ 0 ].Image = new ImageResourceHandle ("icons/properties.gif" );
            
            fileListView.Columns [ 1 ].Label = "扩展名";
            fileListView.Columns [ 1 ].Width = 60;
            fileListView.Columns [ 1 ].Type = ListViewColumnType.Text ;
            fileListView.Font = _defaultFnt;
            */
            /*
            ColumnHeader nameHeader = new ColumnHeader();
            nameHeader.Text = "文件名";
            nameHeader.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
            nameHeader.Type = ListViewColumnType.Text;
            nameHeader.Visible = true;
            fileListView.Columns.Add(nameHeader);

            ColumnHeader extHeader = new ColumnHeader();
            extHeader.Text = "扩展名";
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
                lvi.Tag = f.ResourceId;

                lvsi = new ListViewItem.ListViewSubItem();
                lvsi.Text = f.Ext;
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
                int res = (int)fileListView.SelectedItem.Tag;
                CACLEntity acl = new CACLEntity(_currentUser.ConnString);
                acl.Acl_Operation = (int)ACLOPERATION.READ;
                acl.Acl_Resource = res;
                acl.Acl_Role = _currentUser.Usr_Id;
                acl.Acl_RType = (int)ACLROLETYPE.USERROLE;
                if (!_currentUser.CheckPrivilege(acl))
                    return null;
                CResourceEntity resource = new CResourceEntity(_currentUser.ConnString).Load(res);
                String fileName = "attachment; filename=" + resource.Res_Name;
                String fullPath = resource.MakeFullPath();
                objContext.HttpContext.Response.AddHeader("content-disposition", fileName);
                objContext.HttpContext.Response.WriteFile(fullPath);
            }
            return null;
        }

        #endregion

        private void fileListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            LinkParameters objLinkParameters = new LinkParameters();
            objLinkParameters.Target = "_self";

            Link.Open(new GatewayReference(this, "Download"), objLinkParameters);
        }

        private void menuDeleteFile_Click(object sender, EventArgs e)
        {
            MessageBox.Show("确定要删除文件吗？", "文档管理系统", MessageBoxButtons.YesNo,
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
                foreach (ListViewItem item in fileListView.Items)
                {
                    if (item.Checked)
                    {
                        _helper.DeleteFile(_currentUser, (int)item.Tag);
                    }
                }
                LoadFiles();
            }
            catch (Exception ex)
            {
                MessageBox.Show("系统错误: " + ex.Message, "文档管理系统", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}