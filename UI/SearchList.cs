#region Using

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;

using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common.Resources;
using Gizmox.WebGUI.Common.Interfaces;
using Gizmox.WebGUI.Common.Gateways;

using Olake.WDS;
using MidLayer;
#endregion

namespace UI
{
    public partial class SearchList : UserControl, IGatewayControl
    {
        public SearchList()
        {
            InitializeComponent();
            CreateContextMenu();
        }

        public void Init(List<CSearchResultItem> searchResult)
        {
            searchListView.Items.Clear();
            foreach (CSearchResultItem result in searchResult)
            {
                ListViewItem lvi = new ListViewItem();
                ListViewItem.ListViewSubItem lvsi;

                lvi.Text = result.DispName;
                lvi.Tag = result.FullPath;

                lvsi = new ListViewItem.ListViewSubItem();
                String p = result.FullPath;
                lvsi.Text = result.FullPath.Substring(MidLayerSettings.AppPath.Length);
                lvi.SubItems.Add(lvsi);

                searchListView.Items.Add(lvi);
            }

            if (searchListView.Items.Count > 0)
                searchListView.Items[0].Selected = true;
        }

        public void CreateContextMenu()
        {
            MenuItem MenuItem1 = new Gizmox.WebGUI.Forms.MenuItem();

            MenuItem1.Text = "打开文件";
            MenuItem1.Click += new System.EventHandler(this.menuOpenFile_Click);
            searchContextMenu.MenuItems.Add(MenuItem1);
        }

        private void menuOpenFile_Click(object sender, EventArgs e)
        {
            LinkParameters objLinkParameters = new LinkParameters();
            objLinkParameters.Target = "_self";

            Link.Open(new GatewayReference(this, "Download"), objLinkParameters);
        }

        #region IGatewayControl Members

        IGatewayHandler IGatewayControl.GetGatewayHandler(IContext objContext, string strAction)
        {
            if (strAction == "Download")
            {
                String fileName = "attachment; filename=" + searchListView.SelectedItem.Text;
                String fullPath = (String)searchListView.SelectedItem.Tag;
                objContext.HttpContext.Response.AddHeader("content-disposition", fileName);
                objContext.HttpContext.Response.WriteFile(fullPath);
            }
            return null;
        }

        #endregion
    }
}