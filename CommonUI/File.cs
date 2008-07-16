using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.ComponentModel;

namespace CommonUI
{
    public class File
    {
        private string _name;
        public string FileName
        {
            get { return _name; }
            set { _name = value; }
        }
        private string _ext;

        public string Ext
        {
            get { return _ext; }
            set { _ext = value; }
        }

        private int _resourceId;
        public int ResourceId
        {
            get { return _resourceId; }
            set { _resourceId = value; }
        }
    
        public File()
        {

        }
        public File(FileInfo info)
        {
            _name = info.Name;
            _ext = info.Extension;
        }

        public File(int resourceId, String resourceName)
        {
            _resourceId = resourceId;

            int pos = resourceName.LastIndexOf('.');
            if (pos == -1)
            {
                _name = resourceName;
                _ext = "";
            }
            else
            {
                _name = resourceName.Substring(0, pos);
                _ext = resourceName.Substring(pos + 1);
            }
        }
    }
}
