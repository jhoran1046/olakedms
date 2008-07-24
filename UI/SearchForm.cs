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

            String scope = "f:/Game";
            CSearchDAL searchEngine = new CSearchDAL();
            _result = searchEngine.SearchFolder(targetText, scope);
            this.DialogResult = DialogResult.OK;
            Close();
        }

        private void CancelBtn_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}