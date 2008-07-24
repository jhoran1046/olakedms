using System;
using System.Collections.Generic;
using System.Text;

namespace Olake.WDS
{
    public class CSearchResultItem
    {
        private string _fullPath;

        public string FullPath
        {
            get { return _fullPath; }
            set { _fullPath = value; }
        }
        private string _dispName;

        public string DispName
        {
            get { return _dispName; }
            set { _dispName = value; }
        }
        private Int32 _rank;

        public Int32 Rank
        {
            get { return _rank; }
            set { _rank = value; }
        }
    }
}
