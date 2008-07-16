using System;
using System.Data;
using System.Collections.Generic;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

using MidLayer;

namespace UI
{
    public enum ClipMode
    {
        NONE, COPYMODE, CUTMODE
    }

    public class ResourceClip
    {
        private List<int> _resources;
        private ClipMode _clipMode;
        private CUserEntity _currentUser;

        public ResourceClip()
        {
            _clipMode = ClipMode.NONE;
            _resources = new List<int>();
            _currentUser = null;
        }

        private void AddResource(int resourceId)
        {
            CACLEntity acl = new CACLEntity();
            acl.Acl_Resource = resourceId;
            acl.Acl_Operation = (int)ACLOPERATION.WRITE;
            if (!_currentUser.CheckPrivilege(acl))
                throw new Exception("没有写权限！"); 

            foreach (int res in _resources)
            {
                if (res == resourceId)
                    return;
            }

            _resources.Add(resourceId);
        }

        public void Copy(CUserEntity user, int resourceId)
        {
            _currentUser = user;
            _clipMode = ClipMode.COPYMODE;
            _resources.Clear();
            AddResource(resourceId);
        }

        public void Copy(CUserEntity user, List<int> resources)
        {
            _currentUser = user;
            _clipMode = ClipMode.COPYMODE;
            _resources.Clear();
            foreach (int res in resources)
            {
                AddResource(res);
            }
        }

        public void Cut(CUserEntity user, int resourceId)
        {
            _currentUser = user;
            _clipMode = ClipMode.CUTMODE;
            _resources.Clear();
            AddResource(resourceId);
        }

        public void Cut(CUserEntity user, List<int> resources)
        {
            _currentUser = user;
            _clipMode = ClipMode.CUTMODE;
            _resources.Clear();
            foreach (int res in resources)
            {
                AddResource(res);
            }
        }

        public void Paste(CUserEntity user, int dstResid)
        {
            if (_currentUser == null || _currentUser.Usr_Id != user.Usr_Id)
                throw new Exception("无法粘贴其他用户选择的资源！");
            if (_clipMode == ClipMode.NONE || _resources.Count == 0)
                throw new Exception("剪贴板中没有资源。");
            foreach (int res in _resources)
            {
                if (_clipMode == ClipMode.COPYMODE)
                    _currentUser.CopyResource(res, dstResid);
                else
                    _currentUser.CutResource(res, dstResid);
            }
        }
    }
}
