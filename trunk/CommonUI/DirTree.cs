#region Using

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;

using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common.Resources;
using MidLayer;
using Framework.DB;
#endregion

namespace CommonUI
{
    public partial class DirTree:UserControl
    {
        string _rootDir;

        public string RootDir
        {
            get { return _rootDir; }
            set { _rootDir = value; }
        }

        CUserEntity _currentUser;

        public CUserEntity CurrentUser
        {
            get { return _currentUser; }
            set { _currentUser = value; }
        }

        int _rootResourceId;
        public int RootResourceId
        {
            get { return _rootResourceId;}
            set { _rootResourceId = value; }
        }

        FileList _fileListUI;

        public FileList FileListUI
        {
            get { return _fileListUI; }
            set { _fileListUI = value; }
        }
        Font _defaultFnt = new Font ( "arial" , 9 );
        public DirTree ( )
        {
            InitializeComponent ( );
        }
        /// <summary>
        /// before this , the RootDir must be set
        /// </summary>
        /// <returns></returns>
        public bool Init()
        {
/*
            if ( RootDir == null || RootDir == "" )
                return false;

            HelpClass.LoadDirectory ( MainTreeView.Nodes , RootDir );
            foreach ( TreeNode aNode in mainTreeView.Nodes )
            {
                aNode.NodeFont = _defaultFnt;
                aNode.Image = new IconResourceHandle ( "folder.gif" );
                if(!aNode.Loaded)
                    aNode.Image = new IconResourceHandle ( "folders.gif" );
            }
  
 */
            HelpClass.LoadDirectory ( MainTreeView.Nodes , _currentUser, _rootResourceId );
            foreach ( TreeNode aNode in mainTreeView.Nodes )
            {
                aNode.NodeFont = _defaultFnt;
                aNode.Image = new IconResourceHandle ( "folder.gif" );
                if(!aNode.Loaded)
                    aNode.Image = new IconResourceHandle ( "folders.gif" );
            }
            return true;
            
        }

        private void mainTreeView_AfterSelect ( object sender , TreeViewEventArgs e )
        {
            try
            {
                //_fileListUI.RootDir = e.Node.Tag.ToString ( );
                _fileListUI.CurrentUser = _currentUser;
                _fileListUI.ParentResourceId = (int)e.Node.Tag;
                _fileListUI.LoadFiles();
            }
            catch (Exception ex)
            {
                throw ex;
            }
         }

        private void mainTreeView_BeforeExpand ( object sender , TreeViewCancelEventArgs e )
        {
            if ( !e.Node.Loaded )
            {
                //HelpClass.LoadDirectory ( e.Node.Nodes , e.Node.Tag.ToString ( ) );
                e.Node.Nodes.Clear();
                HelpClass.LoadDirectory(e.Node.Nodes, _currentUser, (int)e.Node.Tag);
                foreach ( TreeNode aNode in e.Node.Nodes )
                {
                    aNode.NodeFont = _defaultFnt;
                    aNode.Image = new IconResourceHandle ( "folder.gif" );
                    if(!aNode.Loaded)
                    {
                        aNode.Image = new IconResourceHandle ( "folders.gif" );
                    }
                    
                }
                e.Node.Loaded = true;
            }
        }
    }
}