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
    public partial class MyApplyForm : Form
    {
        public CUserEntity _CurrentUser;

        public MyApplyForm()
        {
            InitializeComponent();
        }

        private void MyApplyForm_Load(object sender, EventArgs e)
        {
            LoadMyApply();
        }

        private void btnDisfrock_Click(object sender, EventArgs e)
        {
            this._CurrentUser = new CUserEntity();
            _CurrentUser = (CUserEntity)Context.Session["CurrentUser"];

            try
            {
                if (lsvMyApply.SelectedItems.Count > 0)//�ж�ѡ����Ŀ���
                {
                    MessageBox.Show("��ȷ��Ҫ�����ļ��Ĺ鵵�����𣿣�", "�ĵ�����ϵͳ", MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question, new EventHandler(OnMsgBoxClose));
                }
                else
                    MessageBox.Show("û��ѡ�е�Ŀ¼��", "�ĵ�����ϵͳ", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            catch (Exception ex)
            {
                 MessageBox.Show("����ʧ�ܣ�" + ex.Message, "�ĵ�����ϵͳ");
            }
        }
        protected  void OnMsgBoxClose(object sender,EventArgs e)
        {
            if(((Form)sender).DialogResult != DialogResult.Yes)
            {
                return;
            }

            int SelectedCount = lsvMyApply.SelectedItems.Count;
            bool DeleteApp = false;
            try
            {
                foreach (ListViewItem item in lsvMyApply.SelectedItems)
                {
                    DeleteApp = _CurrentUser.DeleteApply((int)item.Tag);
                    if (DeleteApp == false)
                    {
                        MessageBox.Show("ϵͳ����", "�ĵ�����ϵͳ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                    }
                }
                if (SelectedCount > 0)//�������˳������������жϲ����ɹ����
                {
                    LoadMyApply();
                    if (DeleteApp == true)
                    {
                        MessageBox.Show("�����ɹ���", "�ĵ�����ϵͳ", MessageBoxButtons.OK);
                        
                    }
                    else
                        MessageBox.Show("��Ҫ��������������ˣ�", "�ĵ�����ϵͳ", MessageBoxButtons.OK);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("ϵͳ����:"+ex.Message, "�ĵ�����ϵͳ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void chkAllSelect_Click(object sender, EventArgs e)
        {
            if(chkAllSelect.Checked == true)
            {
                foreach(ListViewItem item in lsvMyApply.Items)
                {
                    lsvMyApply.MultiSelect = true;
                    item.Selected = true;
                    lsvMyApply.Invalidate();
                }
            }
            else
            {
                foreach(ListViewItem item in lsvMyApply.Items)
                {
                    //lsvMyApply.MultiSelect = true;
                    item.Selected = false;
                    lsvMyApply.Invalidate();
                }
            }
        }

        private void LoadMyApply()
        {
            this._CurrentUser = new CUserEntity();
            _CurrentUser = (CUserEntity)Context.Session["CurrentUser"];

            try
            {
                List<CApplyInfoEntity> myAppList = new List<CApplyInfoEntity>();
                myAppList = _CurrentUser.ListMyApplies();
                lsvMyApply.Items.Clear();
                foreach (CApplyInfoEntity apply in myAppList)
                {
                    ListViewItem lviName = new ListViewItem();
                    ListViewItem.ListViewSubItem lvsiApplyer;
                    ListViewItem.ListViewSubItem lvsiComment;
                    ListViewItem.ListViewSubItem lvsiAudite;
                    ListViewItem.ListViewSubItem lvsiCreTime;
                    //ListViewItem.ListViewSubItem lvsiAudTime;

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

                    lsvMyApply.Items.Add(lviName);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("ϵͳ����:"+ex.Message, "�ĵ�����ϵͳ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
           // MainForm myMain = new MainForm();
           // myMain.Show();
            this.Close();
        }
    }
}