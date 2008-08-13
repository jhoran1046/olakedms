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
using Gizmox.WebGUI.Common.Gateways;
using Gizmox.WebGUI.Common.Interfaces;
using Gizmox.WebGUI.Common.Resources;

using System.Configuration;

#endregion

namespace CommonUI
{
    public partial class Memoes : UserControl,IGatewayControl
    {
        CUserEntity _currentUser;
        String _temperoryFolder;

        public String TemperoryFolder
        {
            get { return _temperoryFolder; }
            set { _temperoryFolder = value; }
        }

        public CUserEntity CurrentUser
        {
            get { return _currentUser; }
            set { _currentUser = value; }
        }

        public Memoes()
        {
            InitializeComponent();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            try
            {
                COrganizeEntity currentOrg = new COrganizeEntity().Load(_currentUser.GetUserOrganize().Org_Id);
                CResourceEntity orgRes = new CResourceEntity().Load(currentOrg.Org_Resource);
                //string rootDir = Context.Server.MapPath("~/App_data");
                string rootDir = ConfigurationManager.AppSettings["UserData"];
                _temperoryFolder = rootDir + DateTime.Now.ToString("yyyy-MM-dd") + currentOrg.Org_Name;
                DirectoryInfo di = Directory.CreateDirectory(_temperoryFolder);

                Context.Session["temperoryFolder"] = _temperoryFolder;

                string outputPath = _temperoryFolder + @"\";
                outputPath += currentOrg.Org_Name;
                outputPath += ".zip";
                string orignPath = orgRes.MakeFullPath();
                ZipFiles(orignPath, outputPath);

                LinkParameters objlinkParameters = new LinkParameters();
                objlinkParameters.Target = "_self";
                Link.Open(new Gizmox.WebGUI.Common.Gateways.GatewayReference(this, "Download"), objlinkParameters);

                //System.IO.File.Delete(outputPath);
                //di.Delete();
            }
            catch (Exception ex)
            {
                MessageBox.Show("系统错误：" + ex.Message, "文档管理系统", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }
                
        IGatewayHandler IGatewayControl.GetGatewayHandler(IContext objContext,string strAction)
        {
            if(strAction == "Download")
            {
                string orgName = _currentUser.GetUserOrganize().Org_Name;
                String fileName = "attachment; filename=\"" + orgName + ".zip\"";
                string filePath = _temperoryFolder + @"\" + orgName + ".zip";
                objContext.HttpContext.Response.AddHeader("content-disposition", fileName);
                objContext.HttpContext.Response.WriteFile(filePath);
            }
            return null;
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