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

namespace UI
{
    public partial class MyApplyForm : Form
    {
        public CUserEntity _user;

        public MyApplyForm()
        {
            InitializeComponent();
        }

        private void MyApyInfoForm_Load(object sender, EventArgs e)
        {
            LoadMyApply();
        }

        private void btnDisfrock_Click(object sender, EventArgs e)
        {
            this._user = new CUserEntity();
            _user = (CUserEntity)Context.Session["CurrentUser"];

            DialogResult result = MessageBox.Show("您确定要撤销文件的归档申请吗？！", "文档管理系统", MessageBoxButtons.YesNo);
            if (result == DialogResult.No)
                return;
            else
            {
                foreach (ListViewItem item in lsvMyApply.Items)
                {
                    if(item.Selected == true)
                    {
                        try
                        {
                            bool DeleBool = _user.DeleteApply((int)lsvMyApply.Tag);
                            if (DeleBool == true)
                                MessageBox.Show("撤销成功！", "文档管理系统", MessageBoxButtons.OK);
                            else
                                MessageBox.Show("您要撤销的申请已审核！", "文档管理系统", MessageBoxButtons.OK);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("系统错误！" + ex.Message, "文档管理系统");
                        }
                    }                 
                }
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
            this._user = new CUserEntity();
            _user = (CUserEntity)Context.Session["CurrentUser"];

            try
            {
                List<CApplyInfoEntity> myAppList = new List<CApplyInfoEntity>();
                myAppList = _user.ListMyApplies();
                if (myAppList.Count < 0)
                {
                    lsvMyApply.DataSource = null;
                    return;
                }
                foreach (CApplyInfoEntity apply in myAppList)
                {
                    ListViewItem lviName = new ListViewItem();
                    ListViewItem.ListViewSubItem lvsiApplyer;
                    ListViewItem.ListViewSubItem lvsiComment;
                    ListViewItem.ListViewSubItem lvsiAudite;
                    ListViewItem.ListViewSubItem lvsiCreTime;
                    ListViewItem.ListViewSubItem lvsiAudTime;

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
                        case 1: lvsiAudite.Text = "未审核";
                            break;
                        case 2: lvsiAudite.Text = "已批准";
                            break;
                        case 3: lvsiAudite.Text = "未批准";
                            break;
                    }
                    lviName.SubItems.Add(lvsiAudite);

                    lvsiCreTime = new ListViewItem.ListViewSubItem();
                    lvsiCreTime.Text = apply.App_CreateTime.ToString();
                    lviName.SubItems.Add(lvsiCreTime);

                    lvsiAudTime = new ListViewItem.ListViewSubItem();
                    lvsiAudTime.Text = apply.App_AudTime.ToString();
                    lviName.SubItems.Add(lvsiAudTime);

                    lsvMyApply.Items.Add(lviName);
                }
                lsvMyApply.Invalidate();
            }
            catch(Exception ex)
            {
                MessageBox.Show("系统错误:"+ex.Message, "文档管理系统", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            MainForm myMain = new MainForm();
            myMain.Show();
            this.Close();
        }
    }
}