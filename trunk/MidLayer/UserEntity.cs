using System;
using System.IO;
using System.Collections.Generic;
using Grove.ORM;
using Framework.DB;

namespace MidLayer
{
    public enum USERTYPE : int
    {
        NORMALUSER = 0,
        ORGANIZEADMIN,
        SYSTEMADMIN
    }

    [DataTable("TBL_User")]
    public class CUserEntity : CDBEntity<CUserEntity>
    {
        Int32 _Usr_Id;
        String _Usr_Member;
        String _Usr_Password;
        String _Usr_Name;
        Int32 _Usr_Resource;
        Int32 _Usr_Organize;
        Int32 _Usr_Type;

        private COrganizeEntity m_userOrganize;

        [KeyField("Usr_Id")]
        public Int32 Usr_Id
        {
            get { return this._Usr_Id; }
            set { this._Usr_Id = value; }
        }
        [DataField("Usr_Member")]
        public String Usr_Member
        {
            get { return this._Usr_Member; }
            set { this._Usr_Member = value; }
        }
        [DataField("Usr_Password")]
        public String Usr_Password
        {
            get { return this._Usr_Password; }
            set { this._Usr_Password = value; }
        }
        [DataField("Usr_Name")]
        public String Usr_Name
        {
            get { return this._Usr_Name; }
            set { this._Usr_Name = value; }
        }
        [ForeignKeyField("Usr_Resource")]
        public Int32 Usr_Resource
        {
            get { return this._Usr_Resource; }
            set { this._Usr_Resource = value; }
        }
        [ForeignKeyField("Usr_Organize")]
        public Int32 Usr_Organize
        {
            get { return this._Usr_Organize; }
            set { this._Usr_Organize = value; }
        }
        [DataField("Usr_Type")]
        public Int32 Usr_Type
        {
            get { return this._Usr_Type; }
            set { this._Usr_Type = value; }
        }

        public CUserEntity(String connectionString)
        {
            ConnString = connectionString;
            m_userOrganize = null;
        }

        public CUserEntity()
            : this("")
        {
        }

        public bool CheckPrivilege(CACLEntity acl)
        {
            // system admin has all privileges
            if (Usr_Type == (int)USERTYPE.SYSTEMADMIN)
                return true;
            
            // if resourceid of acl is 0, it's a system management 
            // and no users have the privilege except system admin
            if (acl.Acl_Resource == 0)
                return false;

            // if resourceid is the organize id of current user,
            // the user must be system admin
            if (acl.Acl_Resource == this.Usr_Organize)
            {
                if (this.Usr_Type == (int)USERTYPE.ORGANIZEADMIN)
                    return true;
                else
                    return false;
            }

            // get all groups containing current user
            String filter = "this.Urg_User=" + this.Usr_Id;
            CUserGroupEntity userGroup = new CUserGroupEntity(ConnString);
            List<CUserGroupEntity> userGroups = userGroup.GetObjectList(filter);

            // if resource is file or folder, check if user has right on it or its parent
            acl.ConnString = ConnString;
            int resId = acl.Acl_Resource;
            while (resId != 0)
            {
                // check if current user has right on this resource
                filter = "this.Acl_Operation=" + acl.Acl_Operation.ToString();
                filter += " and this.Acl_Resource=" + resId.ToString();
                filter += " and this.Acl_Role=" + Usr_Id.ToString();
                filter += " and this.Acl_RType=" + ((int)ACLROLETYPE.USERROLE).ToString();
                List<CACLEntity> acls = acl.GetObjectList(filter);
                if (acls.Count > 0)
                    return true;

                // check if user's groups have right on this resource
                foreach (CUserGroupEntity ug in userGroups)
                {
                    filter = "this.Acl_Operation=" + acl.Acl_Operation.ToString();
                    filter += " and this.Acl_Resource=" + resId.ToString();
                    filter += " and this.Acl_Role=" + ug.Urg_Group.ToString();
                    filter += " and this.Acl_RType=" + ((int)ACLROLETYPE.GROUPROLE).ToString();
                    acls = acl.GetObjectList(filter);
                    if (acls.Count > 0)
                        return true;
                }

                // get parent id of this resource
                CResourceEntity resource = new CResourceEntity(ConnString).Load(resId);
                if (resource == null)
                    break;
                else
                    resId = resource.Res_Parent;
            }
            return false;
        }

        public List<CGroupEntity> GetUserGroups()
        {
            String filter = "this.Urg_User=" + this.Usr_Id;
            CUserGroupEntity userGroup = new CUserGroupEntity(ConnString);
            List<CUserGroupEntity> userGroups = userGroup.GetObjectList(filter);

            List<CGroupEntity> groups = new List<CGroupEntity>();
            CGroupEntity group = new CGroupEntity(ConnString);
            foreach (CUserGroupEntity ug in userGroups)
            {
                CGroupEntity g = group.Load(ug.Urg_Group);
                if (g != null)
                    groups.Add(g);
            }
            return groups;
        }

        public COrganizeEntity GetUserOrganize()
        {
            if (m_userOrganize != null)
                return m_userOrganize;

            m_userOrganize = new COrganizeEntity(ConnString);
            m_userOrganize = m_userOrganize.Load(Usr_Organize);
            return m_userOrganize;
        }

        public COrganizeEntity CreateOrganize(String organizeName)
        {
            try
            {
                // Check privilege
                CACLEntity acl = new CACLEntity();
                acl.Acl_Resource = 0;
                acl.Acl_Operation = (int)ACLOPERATION.CREATEORGANIZE;
                if (!CheckPrivilege(acl))
                    throw new Exception("当前用户无创建组织权限");

                // create resource for this organize
                CResourceEntity res = new CResourceEntity(ConnString);
                res.Res_Name = organizeName;
                res.Res_Parent = 0;
                res.Res_Type = (int)RESOURCETYPE.ORGANIZERESOURCE;
                res.Res_Id = res.Insert();

                // create default storage folder named as organize resource id
                String organizePath = Path.Combine(MidLayerSettings.AppPath, res.Res_Id.ToString() + organizeName);
                Directory.CreateDirectory(organizePath);

                // create resource for default folder of organize
                CResourceEntity folderRes = new CResourceEntity(ConnString);
                folderRes.Res_Name = res.Res_Id.ToString() + organizeName;
                folderRes.Res_Parent = 0;
                folderRes.Res_Type = (int)RESOURCETYPE.FOLDERRESOURCE;
                folderRes.Res_Id = folderRes.Insert();

                // Create organize entity
                COrganizeEntity organize = new COrganizeEntity(ConnString);
                organize.Org_Name = organizeName;
                organize.Org_Id = res.Res_Id;
                organize.Org_Resource = folderRes.Res_Id;
                organize.Insert();

                // create archive folder for organzie
                String archivePath = Path.Combine(organizePath, "Archive");
                Directory.CreateDirectory(archivePath);

                // create resource for archive folder
                CResourceEntity archiveRes = new CResourceEntity(ConnString);
                archiveRes.Res_Name = "Archive";
                archiveRes.Res_Parent = folderRes.Res_Id;
                archiveRes.Res_Type = (int)RESOURCETYPE.FOLDERRESOURCE;
                archiveRes.Res_Id = archiveRes.Insert();

                organize.Org_ArchiveRes = archiveRes.Res_Id;
                organize.Update();

                return organize;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public CUserEntity CreateNormalUser(CUserEntity newUser)
        {
            try
            {
                // Check privilege
                CACLEntity acl = new CACLEntity();
                acl.Acl_Operation = (int)ACLOPERATION.CREATENORMALUSER;
                acl.Acl_Resource = Usr_Organize;
                if (!CheckPrivilege(acl))
                    throw new Exception("当前用户无创建新用户权限");

                // create user
                newUser.Usr_Type = (int)USERTYPE.NORMALUSER;
                CUserEntity user = CreateUser(newUser);

                // add acl to user
                CACLEntity acl2 = new CACLEntity(ConnString);
                acl2.Acl_CreateTime = DateTime.Now;
                acl2.Acl_Creator = Usr_Id;
                acl2.Acl_Operation = (int)ACLOPERATION.WRITE;
                acl2.Acl_Resource = user.Usr_Resource;
                acl2.Acl_Role = user.Usr_Id;
                acl2.Acl_RType = (int)ACLROLETYPE.USERROLE;
                acl2.Acl_Id = acl2.Insert();

                CACLEntity acl1 = new CACLEntity(ConnString);
                acl1.Acl_CreateTime = DateTime.Now;
                acl1.Acl_Creator = Usr_Id;
                acl1.Acl_Operation = (int)ACLOPERATION.READ;
                acl1.Acl_Resource = user.Usr_Resource;
                acl1.Acl_Role = user.Usr_Id;
                acl1.Acl_RType = (int)ACLROLETYPE.USERROLE;
                acl1.Acl_Id = acl1.Insert();

                return user;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        // newUser.Usr_Organize neend be set
        public CUserEntity CreateAdminlUser(CUserEntity newUser)
        {
            try
            {
                // Check privilege
                CACLEntity acl = new CACLEntity();
                acl.Acl_Operation = (int)ACLOPERATION.CRETAEORGANIZEADMIN;
                acl.Acl_Resource = Usr_Organize;
                if (!CheckPrivilege(acl))
                    throw new Exception("当前用户无创建管理员用户权限");

                // create admin 
                newUser.Usr_Type = (int)USERTYPE.ORGANIZEADMIN;
                CUserEntity user = CreateUser(newUser);

                // add acls to admin, organize acl, root dir acl
                COrganizeEntity organize = new COrganizeEntity(ConnString);
                organize = organize.Load(user.Usr_Organize);

                CACLEntity acl1 = new CACLEntity(ConnString);
                acl1.Acl_CreateTime = DateTime.Now;
                acl1.Acl_Creator = Usr_Id;
                acl1.Acl_Operation = 0;
                acl1.Acl_Resource = organize.Org_Id;
                acl1.Acl_Role = user.Usr_Id;
                acl1.Acl_RType = (int)ACLROLETYPE.USERROLE;
                acl1.Acl_Id = acl1.Insert();

                CACLEntity acl2 = new CACLEntity(ConnString);
                acl2.Acl_CreateTime = DateTime.Now;
                acl2.Acl_Creator = Usr_Id;
                acl2.Acl_Operation = (int)ACLOPERATION.WRITE;
                acl2.Acl_Resource = organize.Org_Resource;
                acl2.Acl_Role = user.Usr_Id;
                acl2.Acl_RType = (int)ACLROLETYPE.USERROLE;
                acl2.Acl_Id = acl2.Insert();

                CACLEntity acl3 = new CACLEntity(ConnString);
                acl3.Acl_CreateTime = DateTime.Now;
                acl3.Acl_Creator = Usr_Id;
                acl3.Acl_Operation = (int)ACLOPERATION.READ;
                acl3.Acl_Resource = organize.Org_Resource;
                acl3.Acl_Role = user.Usr_Id;
                acl3.Acl_RType = (int)ACLROLETYPE.USERROLE;
                acl3.Acl_Id = acl2.Insert();

                return user;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        protected CUserEntity CreateUser(CUserEntity newUser)
        {
            try
            {
                COrganizeEntity organize = new COrganizeEntity(ConnString).Load(Usr_Organize);

                // create resource for user's folder
                CResourceEntity folderRes = new CResourceEntity(ConnString);
                folderRes.Res_Name = "";
                folderRes.Res_Parent = organize.Org_Resource;
                folderRes.Res_Type = (int)RESOURCETYPE.FOLDERRESOURCE;
                folderRes.Res_Id = folderRes.Insert();

                folderRes.Res_Name = folderRes.Res_Id.ToString() + newUser.Usr_Member;
                folderRes.Update();

                // create user's folder
                String userPath = folderRes.MakeFullPath();
                Directory.CreateDirectory(userPath);

                // create user
                newUser.Usr_Resource = folderRes.Res_Id;
                newUser.ConnString = ConnString;
                newUser.Usr_Id = newUser.Insert();
                return newUser;
            }
            catch (Exception e)
            {
                throw e;
            }

        }

        public CUserEntity Login(String member, String password)
        {
            String filter = "this.Usr_Member='" + member + "' and Usr_Password='" + password + "'";
            List<CUserEntity> users = GetObjectList(filter);
            if (users.Count > 0)
                return users[0];
            else
                throw new Exception("错误的用户名和密码");
        }

        // List all children that current user can read
        public List<CResourceEntity> ListResources(int parentId)
        {
            CACLEntity acl = new CACLEntity(ConnString);
            acl.Acl_Resource = parentId;
            acl.Acl_Operation = (int)ACLOPERATION.READ;

            List<CResourceEntity> files = new List<CResourceEntity>();
            if (!CheckPrivilege(acl))
                return files;

            CResourceEntity parent = new CResourceEntity(ConnString).Load(parentId);
            return parent.ListChildResources();
        }

        // List all Descendants of root that current user can read
        public List<CResourceEntity> ListDescendants(int root)
        {
            CACLEntity acl1 = new CACLEntity(ConnString);
            acl1.Acl_Resource = root;
            acl1.Acl_Operation = (int)ACLOPERATION.READ;

            CResourceEntity parent = new CResourceEntity(ConnString).Load(root);
            if (CheckPrivilege(acl1))
            {
                return parent.ListChildResources();
            }

            List<CResourceEntity> resources = new List<CResourceEntity>();
            List<CACLEntity> acls = GetAllACLs();
            foreach (CACLEntity acl in acls)
            {
                if (acl.Acl_Operation != (int)ACLOPERATION.READ && acl.Acl_Operation != (int)ACLOPERATION.WRITE)
                    continue;

                CResourceEntity res = new CResourceEntity(ConnString).Load(acl.Acl_Resource);
                if (res.Res_Type != (int)RESOURCETYPE.FILERESOURCE && res.Res_Type != (int)RESOURCETYPE.FOLDERRESOURCE)
                    continue;

                bool existed = false;
                foreach (CResourceEntity r in resources)
                {
                    if (r.Res_Id == res.Res_Id)
                    {
                        existed = true;
                        break;
                    }
                }

                if (!existed && res.IsChild(parent.Res_Id))
                    resources.Add(res);
            }

            return resources;
        }
#if false
        public List<CResourceEntity> ListArchiveResources()
        {
            List<CResourceEntity> resources = new List<CResourceEntity>();
            COrganizeEntity organize = new COrganizeEntity().Load(this.Usr_Organize);
            CResourceEntity archiveRes = organize.GetArchiveFolder();
            
            if (Usr_Type == (int)USERTYPE.SYSTEMADMIN || Usr_Type == (int)USERTYPE.ORGANIZEADMIN)
            {
                resources.Add(archiveRes);
                return resources;
            }

            List<CACLEntity> acls = GetAllACLs();
            foreach (CACLEntity acl in acls)
            {
                if (acl.Acl_Operation != (int)ACLOPERATION.READ && acl.Acl_Operation != (int)ACLOPERATION.WRITE)
                    continue;

                CResourceEntity res = new CResourceEntity(ConnString).Load(acl.Acl_Resource);
                if (res.Res_Type != (int)RESOURCETYPE.FILERESOURCE && res.Res_Type != (int)RESOURCETYPE.FOLDERRESOURCE)
                    continue;

                bool existed = false;
                foreach (CResourceEntity r in resources)
                {
                    if (r.Res_Id == res.Res_Id)
                    {
                        existed = true;
                        break;
                    }
                }

                if (!existed && res.IsChild(archiveRes.Res_Id))
                    resources.Add(res);
            }

            return resources;
        }
#endif
        // list all resources shared to me
        public List<CResourceEntity> ListShareResources()
        {
            List<CResourceEntity> resources = new List<CResourceEntity>();
            COrganizeEntity organize = new COrganizeEntity().Load(this.Usr_Organize);
            CResourceEntity archiveRes = organize.GetArchiveFolder();

            if (Usr_Type == (int)USERTYPE.SYSTEMADMIN || Usr_Type == (int)USERTYPE.ORGANIZEADMIN)
            {
                return resources;
            }

            List<CACLEntity> acls = GetAllACLs();
            foreach (CACLEntity acl in acls)
            {
                if (acl.Acl_Operation != (int)ACLOPERATION.READ && acl.Acl_Operation != (int)ACLOPERATION.WRITE)
                    continue;

                CResourceEntity res = new CResourceEntity(ConnString).Load(acl.Acl_Resource);
                if (res.Res_Type != (int)RESOURCETYPE.FILERESOURCE && res.Res_Type != (int)RESOURCETYPE.FOLDERRESOURCE)
                    continue;

                bool existed = false;
                foreach (CResourceEntity r in resources)
                {
                    if (r.Res_Id == res.Res_Id)
                    {
                        existed = true;
                        break;
                    }
                }

                if (!existed && !res.IsChild(archiveRes.Res_Id) && !res.IsChild(Usr_Resource))
                    resources.Add(res);
            }

            return resources;
        }

        // list resources I share to other
        public List<CResourceEntity> ListMyShareResources()
        {
            List<CResourceEntity> resources = new List<CResourceEntity>();

            return resources;
        }

#if false
        // list resources of my workspace
        public List<CResourceEntity> ListMyResources()
        {
            CResourceEntity my = new CResourceEntity(ConnString).Load(Usr_Resource);
            return my.ListChildResources();
        }
#endif
        public List<CACLEntity> GetUserACLs()
        {
            String filter = "this.Acl_Role=" + Usr_Id.ToString();
            filter += " and this.Acl_RType=" + ((int)ACLROLETYPE.USERROLE).ToString();
            List<CACLEntity> userAcls = new CACLEntity(ConnString).GetObjectList(filter);
            return userAcls;
        }

        public List<CACLEntity> GetAllACLs()
        {
            List<CACLEntity> userAcls = GetUserACLs();

            List<CGroupEntity> groups = GetUserGroups();
            foreach (CGroupEntity group in groups)
            {
                List<CACLEntity> groupAcls = group.GetGroupACLs();
                userAcls.AddRange(groupAcls);
            }
            return userAcls;
        }

        // return new resource id
        public CResourceEntity CreateFolder(int parentId, String folderName)
        {
            CACLEntity acl = new CACLEntity();
            acl.Acl_Resource = parentId;
            acl.Acl_Operation = (int)ACLOPERATION.WRITE;
            if (!CheckPrivilege(acl))
                return null;

            // create folder
            CResourceEntity parent = new CResourceEntity(MidLayerSettings.ConnectionString).Load(parentId);
            if (parent == null)
                throw new Exception("无法找到资源. ID=" + parentId);

            String path = parent.MakeFullPath();
            if (!Directory.Exists(path))
                throw new Exception("目录不存在: " + path);
            path = Path.Combine(path, folderName);
            if (Directory.Exists(path) || File.Exists(path))
                throw new Exception("名称冲突: " + path);
            Directory.CreateDirectory(path);

            // create resource
            CResourceEntity res = new CResourceEntity(ConnString);
            res.Res_Name = folderName;
            res.Res_Type = (int)RESOURCETYPE.FOLDERRESOURCE;
            parent.CreateChildResource(res);
            return res;
        }

        // return new resource id
        public CResourceEntity CreateFile(int parentId, String fileName, out String filePath)
        {
            CACLEntity acl = new CACLEntity();
            acl.Acl_Resource = parentId;
            acl.Acl_Operation = (int)ACLOPERATION.WRITE;
            if (!CheckPrivilege(acl))
                throw new Exception("没有写权限"); 

            // create folder
            CResourceEntity parent = new CResourceEntity(MidLayerSettings.ConnectionString).Load(parentId);
            if (parent == null)
                throw new Exception("无法找到资源. ID=" + parentId);

            String path = parent.MakeFullPath();
            if (!Directory.Exists(path))
                throw new Exception("目录不存在: " + path);
            path = Path.Combine(path, fileName);
            if (Directory.Exists(path) || File.Exists(path))
                throw new Exception("名称冲突: " + path);

            filePath = path;

            // create resource
            CResourceEntity res = new CResourceEntity(ConnString);
            res.Res_Name = fileName;
            res.Res_Type = (int)RESOURCETYPE.FILERESOURCE;
            parent.CreateChildResource(res);
            return res;
        }

        public void DeleteResource(int resourceId)
        {
            CACLEntity acl = new CACLEntity(ConnString);
            acl.Acl_Resource = resourceId;
            acl.Acl_Operation = (int)ACLOPERATION.WRITE;
            if (!CheckPrivilege(acl))
                throw new Exception("没有写权限");

            CResourceEntity res = new CResourceEntity(ConnString).Load(resourceId);

            res.Remove();
        }

        

        public void Permit(int userId, USERTYPE userType, int resourceId, ACLOPERATION operation)
        {
            // user have to have write privilege on resource
            CACLEntity acl = new CACLEntity();
            acl.Acl_Resource = resourceId;
            acl.Acl_Operation = (int)ACLOPERATION.WRITE;
            if (!CheckPrivilege(acl))
                throw new Exception("没有写权限") ;

            // check if this acl conflicts with others
            CResourceEntity resource = new CResourceEntity(ConnString).Load(resourceId);
            List<CACLEntity> userAcls = GetUserACLs();
            foreach (CACLEntity userAcl in userAcls)
            {
                if (resource.IsChild(userAcl.Acl_Resource) && userAcl.Acl_Operation == (int)operation)
                    throw new Exception("与其他权限冲突");
            }

            // create acl
            CACLEntity acl1 = new CACLEntity(ConnString);
            acl1.Acl_Resource = resourceId;
            acl1.Acl_Role = userId;
            acl1.Acl_RType = (int)userType;
            acl1.Acl_Operation = (int)operation;
            acl1.Acl_Creator = this.Usr_Id;
            acl1.Acl_CreateTime = DateTime.Now;
            acl1.Insert();

            // remove all child privileges
            foreach (CACLEntity ua in userAcls)
            {
                resource = new CResourceEntity(ConnString).Load(ua.Acl_Resource);
                if (resource.IsChild(resourceId) && ua.Acl_Operation == (int)operation)
                {
                    ua.Delete();
                }
            }
        }

        public void Deny(int userId, USERTYPE userType, int resourceId, ACLOPERATION operation)
        {
            // user have to have write privilege on resource
            CACLEntity acl = new CACLEntity();
            acl.Acl_Resource = resourceId;
            acl.Acl_Operation = (int)ACLOPERATION.WRITE;
            if (!CheckPrivilege(acl))
                throw new Exception("没有写权限");

            String filter = "this.Acl_Resource=" + resourceId + " this.Acl_Operation=" + (int)operation;
            filter += " this.Acl_Role" + userId + " this.Acl_RType=" + (int)userType;
            new CACLEntity(ConnString).Delete(filter);
        }
    }
}