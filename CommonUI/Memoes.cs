#region Using

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;

using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Forms;

using MidLayer;
using System.IO;
using System.Collections;
using ICSharpCode.SharpZipLib.GZip;
using ICSharpCode.SharpZipLib.Zip;

#endregion

namespace CommonUI
{
    public partial class Memoes : UserControl
    {
        CUserEntity _currentUser;

        public CUserEntity CurrentUser
        {
            get { return _currentUser; }
            set { _currentUser = value; }
        }

        public Memoes()
        {
            InitializeComponent();
            fbdialogSave.ShowNewFolderButton = false;
            fbdialogSave.Title = "请选择目标目录";
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            fbdialogSave.ShowDialog();
            fbdialogSave.Closed += new EventHandler(fbdialogSave_Closed);
        }

        void fbdialogSave_Closed(object sender, EventArgs e)
        {
            FolderBrowserDialog folderPath = (FolderBrowserDialog)sender;
            string savePath = null;
            if (folderPath.DialogResult != DialogResult.OK)
                return;

            savePath = folderPath.SelectedPath.ToString();
            

            try
            {
                COrganizeEntity currentOrg = new COrganizeEntity().Load(_currentUser.Usr_Organize);
                savePath += @"\";
                savePath += currentOrg.Org_Name;
                savePath += ".zip";
                string orignPath = Context.Server.MapPath("~/App_Data/" + currentOrg.Org_Name);
                ZipFiles(orignPath, savePath);
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("系统错误：" + ex.Message, "文档管理系统", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {

        }

        public void ZipFiles(string inputFolderPath, string outputPathAndFile)
        {
            ArrayList fileLst = GenerateFileList(inputFolderPath); // generate file list
            int TrimLength = (Directory.GetParent(inputFolderPath)).ToString().Length;
            TrimLength += 1;
            FileStream ostream;
            byte[] obuffer;
            string outPath = outputPathAndFile;
            ZipOutputStream oZipStream = new ZipOutputStream(System.IO.File.Create(outPath)); // create zip stream

            oZipStream.SetLevel(9); // maximum compression
            ZipEntry oZipEntry;
            int nCurProgress =0;
            int nTotalCnt = fileLst.Count;
            foreach (string Fil in fileLst) // for each file, generate a zipentry
            {
                oZipEntry = new ZipEntry(Fil.Remove(0, TrimLength));
                oZipStream.PutNextEntry(oZipEntry);
                if (!Fil.EndsWith(@"/")) // if a file ends with '/' its a directory
                {
                    ostream = System.IO.File.OpenRead(Fil);
                    obuffer = new byte[ostream.Length];
                    ostream.Read(obuffer, 0, obuffer.Length);
                    oZipStream.Write(obuffer, 0, obuffer.Length);
                }
                nCurProgress++;
                prgbMemo.Value = nCurProgress * 100 / nTotalCnt;
            }
            oZipStream.Finish();
            oZipStream.Close();
            prgbMemo.Value = 0;
        }

        private static ArrayList GenerateFileList(string Dir)
        {
            ArrayList fils = new ArrayList();
            bool Empty = true;
            foreach (string file in Directory.GetFiles(Dir)) // add each file in directory
            {
                fils.Add(file);
                Empty = false;
            }
            if (Empty)
            {
                if (Directory.GetDirectories(Dir).Length == 0) // if directory is completely empty, add it
                {
                    fils.Add(Dir + @"/");
                }
            }
            foreach (string dirs in Directory.GetDirectories(Dir)) // recursive
            {
                foreach (object obj in GenerateFileList(dirs))
                {
                    fils.Add(obj);
                }
            }
            return fils; // return file list
        }
   }
}