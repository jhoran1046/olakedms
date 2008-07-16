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
    public class ShareHelpClass : HelpClass
    {
        public override void InitDirectory(TreeNodeCollection objNodes, CUserEntity user, int resourceId)
        {
            objNodes.Clear();
            // Add tree root
            TreeNode rootNode = new TreeNode("¹²ÏíÄ¿Â¼");
            objNodes.Add(rootNode);

            List<CResourceEntity> children = user.ListShareResources();
            bool blnHasNodes = false;
            foreach (CResourceEntity res in children)
            {
                if (res.Res_Type == (int)RESOURCETYPE.FOLDERRESOURCE)
                {
                    blnHasNodes = true;
                    break;
                }
            }

            rootNode.Tag = 0;

            rootNode.IsExpanded = !blnHasNodes;
            rootNode.HasNodes = blnHasNodes;
            rootNode.Loaded = false;
        }

        public override void LoadDirectory(TreeNodeCollection objNodes, CUserEntity user, int resourceId)
        {
            objNodes.Clear();
            
            List<CResourceEntity> children;
            if (resourceId == 0)
                children = user.ListShareResources();
            else
                children = user.ListDescendants(resourceId);

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

        public override List<File> GetFiles(CUserEntity user, int parentId)
        {
            List<CResourceEntity> children;
            List<File> ret = new List<File>();

            if (parentId == 0)
                children = user.ListShareResources();
            else
                children = user.ListResources(parentId);
           
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
