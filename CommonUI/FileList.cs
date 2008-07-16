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
        }

        public 
        Font _defaultFnt = new Font ( "arial" , 9 );
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
    }
}