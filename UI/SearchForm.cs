#region Using

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;

using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Forms;

using Olake.WDS;
using MidLayer;
#endregion

namespace UI
{
    public partial class SearchForm: Form
    {
        List<CSearchResultItem> _result;
        public List<CSearchResultItem> SearchResult
        {
            get { return _result; }
        }
        CUserEntity _currentUser;
        public CUserEntity CurrentUser
        {
            get { return _currentUser; }
            set { _currentUser = value; }
        }

        private int _resource;
        public int CurrentResource
        {
            set { _resource = value; }
        }

        public SearchForm ( )
        {
            InitializeComponent ( );
            _result = new List<CSearchResultItem>();
            _resource = 0;
        }

        private void OKBtn_Click(object sender, EventArgs e)
        {
            String targetText = targetBox.Text;
            if (targetText.Length <= 0)
            {
                MessageBox.Show("请填写检索内容！", "文档管理系统", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            List<String> searchScopes = new List<string>();

            if (currentDirBox.Checked)
            {
                CResourceEntity res = new CResourceEntity().Load(_resource);
                String curDir = res.MakeFullPath();
                searchScopes.Add(curDir);
            }

            if (myDirBox.Checked)
            {
                int myDirId = _currentUser.Usr_Resource;
                CResourceEntity res = new CResourceEntity().Load(myDirId);
                String myDir = res.MakeFullPath();
                searchScopes.Add(myDir);
            }

            if (archiveDirBox.Checked)
            {
                int archiveId = _currentUser.GetUserOrganize().Org_ArchiveRes;
                CACLEntity acl1 = new CACLEntity();
                acl1.Acl_Resource = archiveId;
                acl1.Acl_Operation = (int)ACLOPERATION.READ;

                if (_currentUser.CheckPrivilege(acl1))
                {
                    CResourceEntity res = new CResourceEntity().Load(archiveId);
                    String archiveDir = res.MakeFullPath();
                    searchScopes.Add(archiveDir);
                }
                else
                {
                    List<CResourceEntity> ress = _currentUser.ListDescendants(archiveId);
                    foreach (CResourceEntity res in ress)
                    {
                        searchScopes.Add(res.MakeFullPath());
                    }
                }
            }

            if (shareDirBox.Checked)
            {
                List<CResourceEntity> ress = _currentUser.ListShareResources();
                foreach (CResourceEntity res in ress)
                {
                    searchScopes.Add(res.MakeFullPath());
                }
            }

            _result.Clear();
            foreach (String s in searchScopes)
            {
                SearchFullText(targetText, s);
            }

            this.DialogResult = DialogResult.OK;
            Close();
        }

        public void SearchFullText(String text, int resource)
        {
            CResourceEntity res = new CResourceEntity().Load(resource);
            String s = res.MakeFullPath();
            SearchFullText(text, s);
        }

        public void SearchFullText(String text, String path)
        {
            String scope = path;
            if (scope[scope.Length - 1] == '\\')
                scope = scope.Substring(0, scope.Length - 1);
            scope = scope.Replace('\\', '/');

            CSearchDAL searchEngine = new CSearchDAL();
            List<CSearchResultItem> tempResult = searchEngine.SearchFolder(text, scope);
            if (tempResult.Count > 0)
            {
                _result.AddRange(tempResult);
            }
        }

        public void SearchKeyword(String key)
        {
            String filter = "this.Res_KeyWord like'" + key + "'";
            List<CResourceEntity> resList = new CResourceEntity().GetObjectList(filter);
            foreach (CResourceEntity res in resList)
            {
                CACLEntity acl = new CACLEntity();
                acl.Acl_Resource = res.Res_Id;
                acl.Acl_Operation = (int)ACLOPERATION.READ;
                if (_currentUser.CheckPrivilege(acl))
                {
                    CSearchResultItem item = new CSearchResultItem();
                    item.DispName = res.Res_Name;
                    item.FullPath = res.MakeFullPath();
                    _result.Add(item);
                }
            }
        }

        private void CancelBtn_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            Close();
        }

        private void SearchForm_Load(object sender, EventArgs e)
        {
            if (_resource > 0)
            {
                CResourceEntity res = new CResourceEntity().Load(_resource);
                currentDirBox.Text = "当前目录：" + res.MakeCompletePath();
            }
            else
            {
                currentDirBox.Checked = false;
                currentDirBox.Enabled = false;
            }
        }
    }
}