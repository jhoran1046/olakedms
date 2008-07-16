#region Using

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;

using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Forms;

#endregion

namespace UI
{
    public partial class NameForm : Form
    {
        public NameForm()
        {
            InitializeComponent();
        }

        private String oldName;
        public String OldName
        {
            get { return oldName; }
            set { oldName = value; }
        }

        private String newName;
        public String NewName
        {
            get { return newName; }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            newName = nameBox.Text;
            DialogResult = DialogResult.OK;
            this.Close();
        }

        private void NameForm_Load(object sender, EventArgs e)
        {
            nameBox.Text = oldName;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}