using System;
using System.Collections.Generic;
using System.Text;
using MidLayer;

namespace CommonUI
{
    class ApplyInfoClass
    {
        string _name;
        string _fullPath;
        List<CResSorReQuEntity> _nameList;

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public string FullPath
        {
            get { return _fullPath; }
            set { _fullPath = value; }
        }
        public List<CResSorReQuEntity> NameList
        {
            get { return _nameList; }
            set { _nameList = value; }
        }

        public ApplyInfoClass()
        {
            //构造函数
        }
        /// <summary>
        /// 查询资源数据表
        /// </summary>
        /// <param name="id"></param>
        /// <returns>DocName</returns>
        public bool Load(int id)
        {
            CResourceEntity aRes = new CResourceEntity();
            List<CResourceEntity> resList = new List<CResourceEntity>();
            resList = aRes.GetObjectList("this.Res_Id='" + id + "'");
            if(resList.Count < 0)
                return false;
            _name = resList[0].Res_Name;
            _fullPath = resList[0].MakeFullPath();
            return true;
        }
        /// <summary>
        /// 返回TBL_Resource.Res_Id与tbl_sortapplyinfo.App_DocId相等的Res_Name
        /// </summary>
        /// <returns></returns>
        public bool QueryNameList()
        {
            CResSorReQuEntity ResSoRe = new CResSorReQuEntity();
            List<CResSorReQuEntity> RelaList = new List<CResSorReQuEntity>();
            RelaList = ResSoRe.GetObjectList("this.Res_Id > ''");
            if (RelaList.Count < 0)
                return false;
            _nameList = RelaList;
            return true;
        }
    }
}
