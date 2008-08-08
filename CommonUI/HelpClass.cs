using System;
using System.Collections.Generic;
using System.Text;

using System.ComponentModel;
using System.Data;
using System.Drawing;


using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Forms;
using System.IO;
using Gizmox.WebGUI.Common.Resources;

using MidLayer;

namespace CommonUI
{
    public class HelpClass
    {
        public virtual void InitDirectory(TreeNodeCollection objNodes, CUserEntity user, int resourceId)
        {
            objNodes.Clear();
            CResourceEntity rootRes = new CResourceEntity(user.ConnString).Load(resourceId);
            if (rootRes.Res_Type != (int)RESOURCETYPE.FOLDERRESOURCE)
                return;

            List<CResourceEntity> children = user.ListDescendants(resourceId);

            bool blnHasNodes = false;
            foreach (CResourceEntity r in children)
            {
                if (r.Res_Type == (int)RESOURCETYPE.FOLDERRESOURCE)
                {
                    blnHasNodes = true;
                    break;
                }
            }

            TreeNode objNode = new TreeNode(rootRes.Res_Name);
            objNode.Tag = resourceId;

            objNode.IsExpanded = !blnHasNodes;
            objNode.HasNodes = blnHasNodes;

            objNode.Loaded = !blnHasNodes;
            objNodes.Add(objNode);
        }

        public virtual void LoadDirectory(TreeNodeCollection objNodes, string strPath)
        {
            objNodes.Clear();

            //insert the root node
            DirectoryInfo objDir = new DirectoryInfo ( strPath );

            foreach ( DirectoryInfo objSubDir in objDir.GetDirectories ( ) )
            {
                bool blnHasNodes = objSubDir.GetDirectories ( ).Length > 0;

                
                TreeNode objNode = new TreeNode ( objSubDir.Name );
                objNode.Tag = objSubDir.FullName;
                //objNode.DragTargets = treeView1.DragTargets;

                objNode.IsExpanded = !blnHasNodes;
                objNode.HasNodes = blnHasNodes;

                objNode.Loaded = !blnHasNodes;

                //objNode.Image = new ImageResourceHandle ( "Folder.gif" );
                //objNode.ExpandedImage = new ImageResourceHandle ( "Folder.gif" );

                objNodes.Add ( objNode );
            }
        }

        public virtual void LoadDirectory(TreeNodeCollection objNodes, CUserEntity user, int resourceId)
        {
            objNodes.Clear();

            //insert the root node
            List<CResourceEntity> children = user.ListDescendants(resourceId);

            foreach (CResourceEntity res in children)
            {
                if (res.Res_Type != (int)RESOURCETYPE.FOLDERRESOURCE)
                    continue;

                bool blnHasNodes = false;
                List<CResourceEntity> list = user.ListResources(res.Res_Id);
                foreach (CResourceEntity r in list)
                {
                    if (r.Res_Type == (int)RESOURCETYPE.FOLDERRESOURCE)
                    {
                        blnHasNodes = true;
                        break;
                    }
                }

                TreeNode objNode = new TreeNode(res.Res_Name);
                objNode.Tag = res.Res_Id;

                objNode.IsExpanded = !blnHasNodes;
                objNode.HasNodes = blnHasNodes;

                objNode.Loaded = !blnHasNodes;
                objNodes.Add(objNode);
            }
        }

        public virtual List<FileInfo> GetFileInfo(Gizmox.WebGUI.Forms.TreeNode aNode)
        {

            return GetFileInfo ( aNode.Tag.ToString ( ) );
        }
        public virtual List<FileInfo> GetFileInfo(string root)
        {
            DirectoryInfo objDir = new DirectoryInfo ( root );
            List<FileInfo> ret = new List<FileInfo> ( );
            ret.AddRange ( objDir.GetFiles ( ) );
            return ret;
        }
        public virtual List<File> GetFiles(string root)
        {
            List<File> ret = new List<File> ( );
            List<FileInfo> retInfo = new List<FileInfo> ( );
            retInfo = GetFileInfo ( root );
            foreach(FileInfo aInfo in retInfo)
            {
                ret.Add ( new File ( aInfo ) );
            }
            return ret;
        }

        public virtual List<File> GetFiles(CUserEntity user, int parentId)
        {
            //insert the root node
            List<CResourceEntity> children = user.ListResources(parentId);
            List<File> ret = new List<File>();

            foreach (CResourceEntity res in children)
            {
                if (res.Res_Type != (int)RESOURCETYPE.FILERESOURCE)
                    continue;
                File f = new File(res.Res_Id, res.Res_Name);
                ret.Add(f);
            }

            return ret;
        }

        public virtual void CreateFolder(CUserEntity user, int parentResource, String folderName)
        {
            CACLEntity acl = new CACLEntity(user.ConnString);
            acl.Acl_Resource = parentResource;
            acl.Acl_Operation = (int)ACLOPERATION.WRITE;
            if (!user.CheckPrivilege(acl))
            {
                throw new Exception("没有写权限！");
            }

            user.CreateFolder(parentResource, folderName);
        }

        public virtual void DeleteFolder(CUserEntity user, int resource)
        {
            CACLEntity acl = new CACLEntity(user.ConnString);
            acl.Acl_Resource = resource;
            acl.Acl_Operation = (int)ACLOPERATION.WRITE;
            if (!user.CheckPrivilege(acl))
            {
                throw new Exception("没有写权限！");
            }

            CResourceEntity res = new CResourceEntity(user.ConnString).Load(resource);

            String dirPath = res.MakeFullPath();
            user.DeleteResource(resource);
            System.IO.Directory.Delete(dirPath, true);
        }

        public virtual void UploadFile(CUserEntity user, int parentResource, OpenFileDialog objFileDialog)
        {
            CACLEntity acl = new CACLEntity(user.ConnString);
            acl.Acl_Resource = parentResource;
            acl.Acl_Operation = (int)ACLOPERATION.WRITE;
            if (!user.CheckPrivilege(acl))
            {
                throw new Exception("没有写权限！");
            }

            for (int i = 0; i < objFileDialog.Files.Count; i++)
            {
                String filePath;
                HttpPostedFileHandle hfh = (HttpPostedFileHandle)objFileDialog.Files[i]; ;
                user.CreateFile(parentResource, hfh.PostedFileName, out filePath);
                hfh.SaveAs(filePath);
            }
        }
        /// <summary>
        /// 更新文件——赵英武
        /// </summary>
        /// <param name="user"></param>
        /// <param name="resId"></param>
        /// <param name="objFileDialog"></param>
        public virtual void Update(CUserEntity user,int resId,OpenFileDialog objFileDialog)
        {
            CACLEntity acl = new CACLEntity(user.ConnString);
            acl.Acl_Resource = resId;
            acl.Acl_Operation = (int)ACLOPERATION.WRITE;
            if (!user.CheckPrivilege(acl))
            {
                throw new Exception("没有写权限！");
            }

            String filePath;
            HttpPostedFileHandle hfh = (HttpPostedFileHandle)objFileDialog.Files[0];
            CResourceEntity res = new CResourceEntity().Load(resId);
            user.UpdateFile(resId, hfh.PostedFileName, out filePath);
            hfh.SaveAs(filePath);
        }

        public virtual void ShareResource(CUserEntity user, int resource)
        {
            CResourceEntity res = new CResourceEntity(user.ConnString).Load(resource);
            COrganizeEntity org = new COrganizeEntity(user.ConnString).Load(user.Usr_Organize);
            if (res.IsChild(user.Usr_Resource) || (user.Usr_Type == (int)USERTYPE.ORGANIZEADMIN && res.IsChild(org.Org_ArchiveRes)))
            {
                ShareForm shareForm = new ShareForm();
                shareForm.CurrentUser = user;
                shareForm.ResourceId = resource;
                shareForm.ShowDialog();
            }
            else
            {
                throw new Exception("不能共享此目录！");
            }
        }

        public virtual void DeleteFile(CUserEntity user, int resource)
        {
            CResourceEntity res = new CResourceEntity(user.ConnString).Load(resource);
            String filePath = res.MakeFullPath();
            user.DeleteResource(resource);
            System.IO.File.Delete(filePath);
        }

        public virtual void FilterContextMenu(CUserEntity user, ContextMenu contextMenu)
        {
        }
    }
}
