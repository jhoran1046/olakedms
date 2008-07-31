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
    public partial class KeyWdForm : Form
    {
        string _keyWord;

        public string KeyWord
        {
            get { return _keyWord; }
            set { _keyWord = value; }
        }

        public KeyWdForm()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            string keyWd=txtKeyWdChange.Text;
            if(keyWd.Length > 100)
            {
                MessageBox.Show("�ؼ��ֲ��ö���100���֣�", "�ĵ�����ϵͳ", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            try
            {
                this._keyWord = txtKeyWdChange.Text;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show("ϵͳ����"+ex.Message, "�ĵ�����ϵͳ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}