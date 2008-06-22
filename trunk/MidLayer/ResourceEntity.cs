using System;
using System.IO;
using System.Collections.Generic;
using Grove.ORM;
using Framework.DB;

namespace MidLayer
{
    public enum RESOURCETYPE : int
    {
        FILERESOURCE = 0,
        FOLDERRESOURCE,
        ORGANIZERESOURCE
    }

    [DataTable("TBL_Resource")]
    public class CResourceEntity : CDBEntity<CResourceEntity>
    {
        Int32 _Res_Id;
        String _Res_Name;
        Int32 _Res_Type;
        Int32 _Res_Parent;

        [KeyField("Res_Id")]
        public Int32 Res_Id
        {
            get { return this._Res_Id; }
            set { this._Res_Id = value; }
        }
        [DataField("Res_Name")]
        public String Res_Name
        {
            get { return this._Res_Name; }
            set { this._Res_Name = value; }
        }
        [DataField("Res_Type")]
        public Int32 Res_Type
        {
            get { return this._Res_Type; }
            set { this._Res_Type = value; }
        }
        [ForeignKeyField("Res_Parent")]
        public Int32 Res_Parent
        {
            get { return this._Res_Parent; }
            set { this._Res_Parent = value; }
        }

        public CResourceEntity(String connectionString)
        {
            ConnString = connectionString;
        }

        public CResourceEntity()
            : this("")
        {
        }

        public String MakeFullPath()
        {
            if (Res_Type != (int)RESOURCETYPE.FOLDERRESOURCE && Res_Type != (int)RESOURCETYPE.FILERESOURCE)
                throw new Exception("��Դ�����ļ���Ŀ¼�� ID=" + Res_Id);

            string fullPath = Res_Name;
            if (Res_Type == (int)RESOURCETYPE.FOLDERRESOURCE)
                fullPath += "\\";
        
            try
            {
                CResourceEntity resource = this;
                while (resource.Res_Parent != 0)
                {
                    // get parent of this resource
                    resource = Load(resource.Res_Parent);
                    if (resource == null)
                    {
                        throw new Exception("�޷��ҵ���Դ��");
                    }
                    else if (resource.Res_Type == (int)RESOURCETYPE.FOLDERRESOURCE)
                    {
                        fullPath = resource.Res_Name + "\\" + fullPath;
                    }
                    else
                    {
                        throw new Exception("��Դ�����ļ���Ŀ¼�� ID=" + resource.Res_Id);
                    }
                }

                return Path.Combine(MidLayerSettings.AppPath, fullPath);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public bool IsChild(int parentId)
        {
            int temp = Res_Parent;
            while (temp != 0)
            {
                if (temp == parentId)
                    return true;
                CResourceEntity parent = Load(temp);
                if (parent == null)
                    throw new Exception("�޷�������Դ. ID=" + temp);
                temp = parent.Res_Parent;
            }
            return false;
        }

        public List<CResourceEntity> ListChildResources()
        {
            String filter = "this.Res_Parent=" + this.Res_Id;
            List<CResourceEntity> children = this.GetObjectList(filter);
            return children;
        }

        public  void CreateChildResource(CResourceEntity child)
        {
            child.Res_Parent = Res_Id;
            child.Res_Id = child.Insert();
        }
    }
}