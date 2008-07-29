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
        String _Usr_Email;

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
        [DataField("Usr_Email")]
        public String Usr_Email
        { 
            get { return this._Usr_Email; }
            set { this._Usr_Email = value; }
        }

        public CUserEntity(String connectionString)
        {
            ConnString = connectionString;
            m_userOrganize = null;
        }

        public CUserEntity()
            : this("")
        {
            ConnString = MidLayerSettings.ConnectionString;
        }

        public override void Delete()
        {
            // delete all its acls
            String filter = "this.Acl_Creator=" + Usr_Id;
            new CACLEntity(ConnString).Delete(filter);

            filter = "this.Acl_Role=" + Usr_Id + " and this.Acl_RType=" + (int)ACLROLETYPE.USERROLE;
            new CACLEntity(ConnString).Delete(filter);

            // delete from all groups
            filter = "this.Urg_User=" + Usr_Id;
            new CUserGroupEntity(ConnString).Delete(filter);

            // delete all its resources
            CResourceEntity userDir = new CResourceEntity(ConnString).Load(Usr_Resource);
            String path = userDir.MakeFullPath();
            Directory.Delete(path, true);

            base.Delete();
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
/*
                CACLEntity acl1 = new CACLEntity(ConnString);
                acl1.Acl_CreateTime = DateTime.Now;
                acl1.Acl_Creator = Usr_Id;
                acl1.Acl_Operation = 0;
                acl1.Acl_Resource = organize.Org_Id;
                acl1.Acl_Role = user.Usr_Id;
                acl1.Acl_RType = (int)ACLROLETYPE.USERROLE;
                acl1.Acl_Id = acl1.Insert();
*/
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

        public void ModifyUser(CUserEntity user)
        {
            // Check privilege
            CACLEntity acl = new CACLEntity();
            acl.Acl_Operation = (int)ACLOPERATION.CREATENORMALUSER;
            acl.Acl_Resource = Usr_Organize;
            if (!CheckPrivilege(acl))
                throw new Exception("当前用户无修改用户权限");

            user.ConnString = ConnString;
            user.Update();
        }

        public void DeleteUser(int userId)
        {
            // Check privilege
            CACLEntity acl = new CACLEntity();
            acl.Acl_Operation = (int)ACLOPERATION.CREATENORMALUSER;
            acl.Acl_Resource = Usr_Organize;
            if (!CheckPrivilege(acl))
                throw new Exception("当前用户无删除用户权限");

            CUserEntity user = new CUserEntity(ConnString).Load(userId);
            user.Delete();
        }

        public List<CGroupEntity> ListGroups()
        {
            String filter = "this.Grp_Organize=" + Usr_Organize;
            return new CGroupEntity(ConnString).GetObjectList(filter);
        }

        public void CreateGroup(CGroupEntity group)
        {
            // Check privilege
            CACLEntity acl = new CACLEntity();
            acl.Acl_Operation = (int)ACLOPERATION.CREATENORMALUSER;
            acl.Acl_Resource = Usr_Organize;
            if (!CheckPrivilege(acl))
                throw new Exception("当前用户无创建用户组权限");

            group.ConnString = ConnString;
            group.Insert();
        }

        public void ModifyGroup(CGroupEntity group)
        {
            // Check privilege
            CACLEntity acl = new CACLEntity();
            acl.Acl_Operation = (int)ACLOPERATION.CREATENORMALUSER;
            acl.Acl_Resource = Usr_Organize;
            if (!CheckPrivilege(acl))
                throw new Exception("当前用户无修改用户组权限");

            group.ConnString = ConnString;
            group.Update();
        }

        public void DeleteGroup(int groupId)
        {
            // Check privilege
            CACLEntity acl = new CACLEntity();
            acl.Acl_Operation = (int)ACLOPERATION.CREATENORMALUSER;
            acl.Acl_Resource = Usr_Organize;
            if (!CheckPrivilege(acl))
                throw new Exception("当前用户无修改用户组权限");

            CGroupEntity group = new CGroupEntity(ConnString).Load(groupId);
            group.Delete();
        }

        public void AddUser2Group(int groupId, int userId)
        {
            // Check privilege
            CACLEntity acl = new CACLEntity();
            acl.Acl_Operation = (int)ACLOPERATION.CREATENORMALUSER;
            acl.Acl_Resource = Usr_Organize;
            if (!CheckPrivilege(acl))
                throw new Exception("当前用户无修改用户组权限");

            CUserGroupEntity userGroup = new CUserGroupEntity(ConnString);
            userGroup.Urg_Group = groupId;
            userGroup.Urg_User = userId;
            userGroup.Insert();
        }

        public void RemoveUserFromGroup(int groupId, int userId)
        {
            // Check privilege
            CACLEntity acl = new CACLEntity();
            acl.Acl_Operation = (int)ACLOPERATION.CREATENORMALUSER;
            acl.Acl_Resource = Usr_Organize;
            if (!CheckPrivilege(acl))
                throw new Exception("当前用户无修改用户组权限");

            String filter = "this.Urg_Group=" + groupId + " and this.Urg_User=" + userId;
            new CUserGroupEntity(ConnString).Delete(filter);
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
            COrganizeEntity organize = new COrganizeEntity(ConnString).Load(this.Usr_Organize);
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

                if (acl.Acl_Resource == organize.Org_Resource)
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

        // list acls I share to other
        public List<CACLEntity> ListMyAcls()
        {
            String filter = "this.Acl_Creator=" + Usr_Id.ToString();
            List<CACLEntity> userAcls = new CACLEntity(ConnString).GetObjectList(filter);
            return userAcls;
        }

        public List<CACLEntity> ListMyAcls(int sharedResource)
        {
            String filter = "this.Acl_Creator=" + Usr_Id.ToString();
            filter += " and this.Acl_Resource=" + sharedResource.ToString();
            List<CACLEntity> userAcls = new CACLEntity(ConnString).GetObjectList(filter);
            return userAcls;
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

        public List<CUserEntity> ListAllUsers()
        {
            String filter = "this.Usr_Organize=" + Usr_Organize;
            List<CUserEntity> users = new CUserEntity(ConnString).GetObjectList(filter);
            return users;
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

        public void Permit(int userId, ACLROLETYPE roleType, int resourceId, ACLOPERATION operation)
        {
            // user have to have write privilege on resource
            CACLEntity acl = new CACLEntity();
            acl.Acl_Resource = resourceId;
            acl.Acl_Operation = (int)ACLOPERATION.WRITE;
            if (!CheckPrivilege(acl))
                throw new Exception("没有写权限") ;

            List<CACLEntity> userAcls = new List<CACLEntity>();
            if (roleType == ACLROLETYPE.USERROLE)
            {
                CUserEntity user = new CUserEntity(ConnString).Load(userId);
                userAcls = user.GetUserACLs();
            }
            else if (roleType == ACLROLETYPE.GROUPROLE)
            {
                CGroupEntity group = new CGroupEntity(ConnString).Load(userId);
                userAcls = group.GetGroupACLs();
            }

            // check if this acl conflicts with others
            CResourceEntity resource = new CResourceEntity(ConnString).Load(resourceId);
            foreach (CACLEntity userAcl in userAcls)
            {
                if (resource.IsChild(userAcl.Acl_Resource) && userAcl.Acl_Operation == (int)operation)
                    throw new Exception("与其他权限冲突");
            }

            // create acl
            CACLEntity acl1 = new CACLEntity(ConnString);
            acl1.Acl_Resource = resourceId;
            acl1.Acl_Role = userId;
            acl1.Acl_RType = (int)roleType;
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

        public void Deny(int userId, ACLROLETYPE roleType, int resourceId, ACLOPERATION operation)
        {
            // user have to have write privilege on resource
            CACLEntity acl = new CACLEntity();
            acl.Acl_Resource = resourceId;
            acl.Acl_Operation = (int)ACLOPERATION.WRITE;
            if (!CheckPrivilege(acl))
                throw new Exception("没有写权限");

            String filter = "this.Acl_Resource=" + resourceId + " and this.Acl_Operation=" + (int)operation;
            filter += " and this.Acl_Role=" + userId + " and this.Acl_RType=" + (int)roleType;
            new CACLEntity(ConnString).Delete(filter);
        }

        public void Deny(int userId, ACLROLETYPE roleType, int resourceId)
        {
            // user have to have write privilege on resource
            CACLEntity acl = new CACLEntity();
            acl.Acl_Resource = resourceId;
            acl.Acl_Operation = (int)ACLOPERATION.WRITE;
            if (!CheckPrivilege(acl))
                throw new Exception("没有写权限");

            String filter = "this.Acl_Resource=" + resourceId;
            filter += " and this.Acl_Role=" + userId + " and this.Acl_RType=" + (int)roleType;
            new CACLEntity(ConnString).Delete(filter);
        }

        public void CopyResource(int srcResId, int dstResId)
        {
            // copy resource
            CACLEntity acl = new CACLEntity(ConnString);
            acl.Acl_Resource = srcResId;
            acl.Acl_Operation = (int)ACLOPERATION.READ;
            if (!CheckPrivilege(acl))
                throw new Exception("没有读权限!");
            acl.Acl_Resource = dstResId;
            acl.Acl_Operation = (int)ACLOPERATION.WRITE;
            if (!CheckPrivilege(acl))
                throw new Exception("没有写权限!");

            CResourceEntity srcRes = new CResourceEntity(ConnString).Load(srcResId);
            CResourceEntity dstRes = new CResourceEntity(ConnString).Load(dstResId);
            if (dstRes.Res_Type != (int)RESOURCETYPE.FOLDERRESOURCE)
                throw new Exception("粘贴的目标必须是目录！");
            srcRes.CopyTo(dstRes);

            // copy folder/file
            String srcPath = srcRes.MakeFullPath();
            String dstPath = dstRes.MakeFullPath();
            dstPath = Path.Combine(dstPath, srcRes.Res_Name);
            if (Directory.Exists(dstPath) || File.Exists(dstPath))
                throw new Exception(dstPath + "与现有文件名冲突！");
            if (srcRes.Res_Type == (int)RESOURCETYPE.FILERESOURCE)
                File.Copy(srcPath, dstPath);
            else
                CopyDirectory(srcPath, dstPath);
        }

        // Copy directory structure recursively
        public static void CopyDirectory(string Src, string Dst)
        {
            String[] Files;

            if (Dst[Dst.Length - 1] != Path.DirectorySeparatorChar)
                Dst += Path.DirectorySeparatorChar;
            if (!Directory.Exists(Dst)) Directory.CreateDirectory(Dst);
            Files = Directory.GetFileSystemEntries(Src);
            foreach (string Element in Files)
            {
                // Sub directories
                if (Directory.Exists(Element))
                    CopyDirectory(Element, Dst + Path.GetFileName(Element));
                // Files in directory
                else
                    File.Copy(Element, Dst + Path.GetFileName(Element), true);
            }
        }

        public void CutResource(int srcResId, int dstResId)
        {
            // copy resource
            CACLEntity acl = new CACLEntity(ConnString);
            acl.Acl_Resource = srcResId;
            acl.Acl_Operation = (int)ACLOPERATION.WRITE;
            if (!CheckPrivilege(acl))
                throw new Exception("没有写权限!");
            acl.Acl_Resource = dstResId;
            acl.Acl_Operation = (int)ACLOPERATION.WRITE;
            if (!CheckPrivilege(acl))
                throw new Exception("没有写权限!");

            CResourceEntity srcRes = new CResourceEntity(ConnString).Load(srcResId);
            CResourceEntity dstRes = new CResourceEntity(ConnString).Load(dstResId);
            String srcPath = srcRes.MakeFullPath();
            if (dstRes.Res_Type != (int)RESOURCETYPE.FOLDERRESOURCE)
                throw new Exception("粘贴的目标必须是目录！");
            srcRes.MoveTo(dstRes);

            // cut folder/file
            String dstPath = dstRes.MakeFullPath();
            dstPath = Path.Combine(dstPath, srcRes.Res_Name);
            if (Directory.Exists(dstPath) || File.Exists(dstPath))
                throw new Exception(dstPath + "与现有文件名冲突！");
            if (srcRes.Res_Type == (int)RESOURCETYPE.FILERESOURCE)
                File.Move(srcPath, dstPath);
            else
                Directory.Move(srcPath, dstPath);
        }

        /// <summary>
        /// 创建新的归档申请，resource代表申请归档的资源id，comment是用户填写的申请说明。——赵英武
        /// </summary>
        /// <param name="resource"></param>
        /// <param name="comment"></param>
        public bool CreateApply(int resource,  String comment)
        {
            CApplyEntity aRes = new CApplyEntity();
            if(aRes.GetObjectList("this.App_ResId='" + resource + "'").Count > 0)
                return false;

            aRes.App_ResId = resource;
            aRes.App_Applyer = this.Usr_Id;
            aRes.App_Comment = comment;
            aRes.App_Audited = (int)AUDITE.UNAUDITING;
            aRes.Insert();
                return true;
        }
        /// <summary>
        /// 获取当前用户提交的所有申请——赵英武
        /// </summary>
        /// <returns></returns>
        public List<CApplyInfoEntity> ListMyApplies()
        {
            CApplyInfoEntity MyApplies = new CApplyInfoEntity();
            List<CApplyInfoEntity> MyApplyList = new List<CApplyInfoEntity>();
            MyApplyList = MyApplies.GetObjectList("this.App_Applyer='" + this.Usr_Id + "'");
            return MyApplyList;
        }
        /// <summary>
        /// 管理员获取当前本组织用户提交的所有申请——赵英武
        /// </summary>
        /// <returns></returns>
        public List<CApplyInfoEntity> ListOrganizeApplies()
        {
            CApplyInfoEntity OrgApply = new CApplyInfoEntity();
            List<CApplyInfoEntity> OrgApplyList = new List<CApplyInfoEntity>();
            OrgApplyList = OrgApply.GetObjectList("this.Usr_Organize='" + this.Usr_Organize + "'");
            return OrgApplyList;
        }
        /// <summary>
        /// 批准归档申请——赵英武
        /// </summary>
        /// <param name="apply"></param>
        /// <param name="archiveResource"></param>
        public void PermitApply(int apply, int archiveResource)
        {
            CACLEntity acl = new CACLEntity();
            acl.Acl_Operation = (int)ACLOPERATION.AUDITAPPLY;
            acl.Acl_Resource = this.Usr_Organize;

            if (!CheckPrivilege(acl))
                throw new Exception("没有管理归档申请的权限！");

            CApplyEntity aRes=new CApplyEntity().Load(apply);
            if (aRes.App_Audited == (int)AUDITE.AUDITED || aRes.App_Audited == (int)AUDITE.UNAUDITED)
                throw new Exception("该资源已审核！");

            try
            {
                this.CopyResource(aRes.App_ResId, archiveResource);

                aRes.Permit();
            }
            catch(Exception ex)
            {
                throw (ex);
            }
        }
        /// <summary>
        /// 不批准归档申请——赵英武
        /// </summary>
        /// <param name="apply"></param>
        public void CancelApply(int apply)
        {
            CACLEntity acl = new CACLEntity();
            acl.Acl_Operation = (int)ACLOPERATION.AUDITAPPLY;
            acl.Acl_Resource = this.Usr_Organize;
            
            if (!CheckPrivilege(acl))
                throw new Exception("没有管理归档申请的权限！");

            CApplyEntity aRes = new CApplyEntity().Load(apply);

            if (aRes.App_Audited == (int)AUDITE.UNAUDITED || aRes.App_Audited == (int)AUDITE.AUDITED)
                throw new Exception("该资源已审核！");

            try
            {
                aRes.Cancel();
            }
            catch(Exception ex)
            {
                throw (ex);
            }
        }
        /// <summary>
        /// 删除归档申请,删除成功return true,否则return false——赵英武
        /// </summary>
        /// <param name="apply"></param>
        public bool DeleteApply(int apply)
        {
            CApplyEntity aRes = new CApplyEntity().Load(apply);

            if (aRes.App_Applyer == this.Usr_Id && aRes.App_Audited == (int)AUDITE.UNAUDITING)
            {
                aRes.Delete();
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}