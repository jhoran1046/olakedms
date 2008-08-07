using System;
using System.Collections.Generic;
using System.Text;
using Gizmox.WebGUI.Common.Resources;

namespace CommonUI
{
    public class CFunction
    {
        private string _name;

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        private Gizmox.WebGUI.Forms.UserControl _ui;

        public Gizmox.WebGUI.Forms.UserControl Ui
        {
            get { return _ui; }
            set { _ui = value; }
        }
        ResourceHandle _image;

        public ResourceHandle Image
        {
            get { return _image; }
            set { _image = value; }
        }
    }
}
