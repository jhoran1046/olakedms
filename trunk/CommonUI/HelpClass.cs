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
        static  public void LoadDirectory ( TreeNodeCollection objNodes , string strPath )
        {
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

        static public void LoadDirectory(TreeNodeCollection objNodes, CUserEntity user, int resourceId)
        {
            //insert the root node
            List<CResourceEntity> children = user.ListDescendants(resourceId);//user.ListResources(resourceId);

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

        static public List<FileInfo> GetFileInfo(Gizmox.WebGUI.Forms.TreeNode aNode)
        {

            return GetFileInfo ( aNode.Tag.ToString ( ) );
        }
        static public List<FileInfo> GetFileInfo ( string root )
        {
            DirectoryInfo objDir = new DirectoryInfo ( root );
            List<FileInfo> ret = new List<FileInfo> ( );
            ret.AddRange ( objDir.GetFiles ( ) );
            return ret;
        }
        static public List<File> GetFiles ( string root )
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

        static public List<File> GetFiles(CUserEntity user, int parentId)
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
    }
}