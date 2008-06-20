using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Framework.UI
{
    public partial class SetKeyObjForm: Form
    {
        private object keyObj_;
    
        public SetKeyObjForm ( )
        {
            InitializeComponent ( );
        }

        public Object keyObj
        {
            get
            {
                return keyObj_;
            }
            set
            {
                keyObj_ = value;
            }
        }

        private void SetKeyObjForm_Load ( object sender , EventArgs e )
        {
            propertyGridKeyObj.SelectedObject = keyObj;
        }
    }
}