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

#endregion

namespace CommonUI
{
    public partial class AuditeAppUsrCrl : UserControl
    {
        CUserEntity _currentUser;

        public CUserEntity CurrentUser
        {
            get { return _currentUser; }
            set { _currentUser = value; }
        }

        public AuditeAppUsrCrl()
        {
            InitializeComponent();
        }

        public void CreateContextMenu()
        {
            MenuItem MenuItem1 = new Gizmox.WebGUI.Forms.MenuItem();
            MenuItem MenuItem2 = new Gizmox.WebGUI.Forms.MenuItem();
            MenuItem MenuItem3 = new Gizmox.WebGUI.Forms.MenuItem();
            
            MenuItem1.Text = "��׼����";
            MenuItem1.Click += new System.EventHandler(this.btnAccept_Click);
            listContextMenu.MenuItems.Add(MenuItem1);

            MenuItem2.Text = "�ܾ�����";
            MenuItem2.Click += new System.EventHandler(this.btnReject_Click);
            listContextMenu.MenuItems.Add(MenuItem2);

            MenuItem3.Text = "ˢ��";
            MenuItem3.Click += new System.EventHandler(this.refreshApp_Click);
            listContextMenu.MenuItems.Add(MenuItem3);
        }

        private void refreshApp_Click(object sender,EventArgs e)
        {
            LoadOrgApp();
        }

        private void AuditeAppUsrCrl_Load(object sender, EventArgs e)
        {
            LoadOrgApp();
            CreateContextMenu();
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            int selectedCount = lsvOrgApply.SelectedItems.Count;
            if (selectedCount <= 0)
            {
                MessageBox.Show("û��ѡ�е����룡", "�ĵ�����ϵͳ", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            try
            {
                ShowArchiveContent showDialog = new ShowArchiveContent();
                showDialog.CurrentUser = _currentUser;
                showDialog.Closed+=new EventHandler(showDialog_Closed);
                showDialog.ShowDialog();              
            }
            catch(Exception ex)
            {
                MessageBox.Show("ϵͳ����" + ex.Message, "�ĵ�����ϵͳ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void showDialog_Closed(object sender,EventArgs e)
        {
            ShowArchiveContent showArchive = (ShowArchiveContent)sender;
            if (showArchive.DialogResult != DialogResult.OK)
                return;
            int selectedCount = lsvOrgApply.SelectedItems.Count;
            if (selectedCount <= 0)
            {
                MessageBox.Show("û��ѡ�е����룡", "�ĵ�����ϵͳ", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            try
            {
                if (showArchive.SelectedNode == null || showArchive.SelectedNode.Tag == null)
                    return;
                foreach (ListViewItem item in lsvOrgApply.SelectedItems)
                {
                    _currentUser.PermitApply((int)item.Tag, (int)showArchive.SelectedNode.Tag);
                }
                if (selectedCount > 0)
                {
                    MessageBox.Show("��ѡ�����Ŀ����׼��", "�ĵ�����ϵͳ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("ϵͳ����" + ex.Message, "�ĵ�����ϵͳ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

   /*     private void errorMsgClose(object sender,EventArgs e)
        {
            if(((Form)sender).DialogResult == DialogResult.OK)
                showDialog.Close();
        }
   */
        private void btnReject_Click(object sender, EventArgs e)
        {
            int SelectedCount = lsvOrgApply.SelectedItems.Count;
            if(SelectedCount <= 0)
            {
                MessageBox.Show("û��ѡ�е�Ŀ¼��", "�ĵ�����ϵͳ", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            try
            {
                foreach(ListViewItem item in lsvOrgApply.SelectedItems)
                {
                    _currentUser.CancelApply((int)item.Tag);
                }
                if(SelectedCount > 0)
                {
                    MessageBox.Show("�Ѿܾ����룡", "�ĵ�����ϵͳ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadOrgApp();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("ϵͳ����"+ex.Message, "�ĵ�����ϵͳ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void LoadOrgApp()
        {
            try
            {
                lsvOrgApply.Items.Clear();
                List<CApplyInfoEntity> OrgAppList = new List<CApplyInfoEntity>();
                OrgAppList = _currentUser.ListOrganizeApplies();

                foreach (CApplyInfoEntity apply in OrgAppList)
                {
                    ListViewItem lviName = new ListViewItem();
                    ListViewItem.ListViewSubItem lvsiApplyer;
                    ListViewItem.ListViewSubItem lvsiComment;
                    ListViewItem.ListViewSubItem lvsiAudite;
                    ListViewItem.ListViewSubItem lvsiCreTime;
                    // ListViewItem.ListViewSubItem lvsiAudTime;

                    lviName.Text = apply.Res_Name;
                    lviName.Tag = apply.App_Id;

                    lvsiApplyer = new ListViewItem.ListViewSubItem();
                    lvsiApplyer.Text = apply.Usr_Name;
                    lviName.SubItems.Add(lvsiApplyer);

                    lvsiComment = new ListViewItem.ListViewSubItem();
                    lvsiComment.Text = apply.App_Comment;
                    lviName.SubItems.Add(lvsiComment);

                    lvsiAudite = new ListViewItem.ListViewSubItem();
                    switch ((int)apply.App_Audited)
                    {
                        case 1: lvsiAudite.Text = "δ���";
                            break;
                        case 2: lvsiAudite.Text = "����׼";
                            break;
                        case 3: lvsiAudite.Text = "δ��׼";
                            break;
                    }
                    lviName.SubItems.Add(lvsiAudite);

                    lvsiCreTime = new ListViewItem.ListViewSubItem();
                    lvsiCreTime.Text = apply.App_CreateTime.ToString();
                    lviName.SubItems.Add(lvsiCreTime);

                    // lvsiAudTime = new ListViewItem.ListViewSubItem();
                    // lvsiAudTime.Text = apply.App_AudTime.ToString();
                    // lviName.SubItems.Add(lvsiAudTime);  

                    lsvOrgApply.Items.Add(lviName);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("���ع鵵�����б�ʧ�ܣ�" + ex.Message, "�ĵ�����ϵͳ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}