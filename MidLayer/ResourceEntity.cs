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
            ConnString = MidLayerSettings.ConnectionString;
        }

        public String MakeCompletePath()
        {
            if (Res_Type != (int)RESOURCETYPE.FOLDERRESOURCE && Res_Type != (int)RESOURCETYPE.FILERESOURCE)
                throw new Exception("资源不是文件或目录。 ID=" + Res_Id);

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
                        throw new Exception("无法找到资源。");
                    }
                    else if (resource.Res_Type == (int)RESOURCETYPE.FOLDERRESOURCE)
                    {
                        fullPath = resource.Res_Name + "\\" + fullPath;
                    }
                    else
                    {
                        throw new Exception("资源不是文件或目录。 ID=" + resource.Res_Id);
                    }
                }

                return fullPath;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public String MakeFullPath()
        {
            String fullPath = MakeCompletePath();
            return Path.Combine(MidLayerSettings.AppPath, fullPath);
        }

        public bool IsChild(int parentId)
        {
            int temp = Res_Id;
            while (temp != 0)
            {
                if (temp == parentId)
                    return true;
                CResourceEntity r = new CResourceEntity(ConnString).Load(temp);
                if (r == null)
                    throw new Exception("无法加载资源.");
                temp = r.Res_Parent;
            }
            return false;
        }

        public List<CResourceEntity> ListChildResources()
        {
            String filter = "this.Res_Parent=" + this.Res_Id;
            List<CResourceEntity> children = this.GetObjectList(filter);
            return children;
        }

        public void Remove()
        {
            DeleteChildResource();
            DeleteACLs();
            Delete();
        }

        public void CreateChildResource(CResourceEntity child)
        {
            child.Res_Parent = Res_Id;
            child.Res_Id = child.Insert();
        }

        public void DeleteChildResource()
        {
            List<CResourceEntity> children = ListChildResources();
            foreach (CResourceEntity child in children)
            {
                child.Remove();
            }
        }

        public void DeleteACLs()
        {
            String filter = "this.Acl_Resource=" + Res_Id;
            CACLEntity en = new CACLEntity(ConnString);
            en.Delete(filter);
        }

        public void CopyTo(CResourceEntity dest)
        {
            CResourceEntity newRes = new CResourceEntity(ConnString);
            newRes.Res_Name = Res_Name;
            newRes.Res_Type = Res_Type;
            newRes.Res_Parent = dest.Res_Id;
            newRes.Insert();

            List<CResourceEntity> children = ListChildResources();
            foreach (CResourceEntity child in children)
            {
                child.CopyTo(newRes);
            }
        }

        public void MoveTo(CResourceEntity dest)
        {
            CleanDescendsACLs();

            this.Res_Parent = dest.Res_Id;
            this.Update();
        }

        public void CleanDescendsACLs()
        {
            DeleteACLs();

            List<CResourceEntity> children = ListChildResources();
            foreach (CResourceEntity child in children)
            {
                child.CleanDescendsACLs();
            }
        }
    }
}
