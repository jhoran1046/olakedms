using System;
using System.Security.Cryptography;
using System.Text;
using System.Xml;
using System.Windows.Forms;
using System.Data;
using System.Reflection;
using System.Collections.Generic;
using System.Collections;


namespace Framework.Util
{
	/// <summary>
	/// //杂项辅助函数
	/// </summary>
	public class CHelperClass
	{
		public CHelperClass()
		{
			// 
			// TODO: 在此处添加构造函数逻辑
			//
		}
        /// <summary>
        /// Splits the assemb string.传入的字符串应有如下格式：
        /// Assembly::TypeName__KeyString1__KeyString2__,要求”__“,“::”不能在真正的名字中存在
        /// </summary>
        /// <param name="wholeStr">The whole STR.</param>
        /// <returns>
        /// 返回值:
        /// 0.Assembly,
        /// 1.TypeName
        /// 2.KeyString1
        /// 3.KeyString2
        /// ....
        /// </returns>
        static public List<string> SplitAssembString(string wholeStr)
        {
            List<string> ret = new List<string>();
           
            //assembly
            int nAssemEnd = wholeStr.IndexOf ( "::" );
            string assemblyString = wholeStr.Substring ( 0 , nAssemEnd );
            ret.Add ( assemblyString );

            //type
            int typeEnd = wholeStr.IndexOf ( "__" );
            string typeStr;
            //实际上，应该不会==-1.因为key是必须的，但是有可能此函数用于别的用途。
            if(typeEnd==-1)
            {
                typeStr = wholeStr.Substring ( nAssemEnd + 2 );
            }
            else
            {
                typeStr = wholeStr.Substring ( nAssemEnd + 2 , typeEnd - nAssemEnd - 2 );
            }
            ret.Add ( typeStr );

            int keySplitterPos = typeEnd;
            while ( keySplitterPos != -1 )
            {
                int nextSplitter = wholeStr.IndexOf ( "__" , keySplitterPos + 2 );
                int nLen = nextSplitter - keySplitterPos - 2;
                //not found
                string key;
                if(nLen<0)
                {
                    key =  wholeStr.Substring(keySplitterPos+2);
                }
                else
                {
                    key = wholeStr.Substring ( keySplitterPos + 2 , nLen );
                }
               ret.Add ( key );
               keySplitterPos = nextSplitter;
            }
            return ret;
    
            

        }
        /// <summary>
        /// Creates the obj dynamically.
        /// </summary>
        /// <param name="refString">
        /// The ref string.格式如下 AssemblyName::FullName
        /// 如：SEDLDataModel::SEDLDataModel.Nodes.CEmployeeNode
        /// </param>
        /// <returns></returns>
        static public  object CreateObjDynamically(string assemStr,string typeName)
        {
            
            Assembly assem =  Assembly.Load ( assemStr );
            if(assem==null)
            {
                throw new Exception ( "error in load " + assemStr );
            }
            object result = assem.CreateInstance ( typeName );
            if(null==result)
            {
                throw new Exception ( "error in load " + typeName );
            }
            return result;

        }
        static public DataGridViewColumn CreateDataColumn(string fieldName, string dispName)
        {
            //DataGridViewColumn aCol = new DataGridViewColumn();//提示“DataGridView 控件中至少有一列没有单元格模板”
            DataGridViewTextBoxColumn aCol = new DataGridViewTextBoxColumn();// 20080222修改
            aCol.DataPropertyName = fieldName; // "Fld_OrderNo";
            aCol.Name = dispName;// "OrderNo";
            aCol.CellTemplate = new DataGridViewTextBoxCell();
            return aCol;
        }

		//////////////////////////////////////////////////////////////////////////
		// Method:    ConvertDateTimeFormat
		// FullName:  ClassLibrary.CHelperClass.ConvertDateTimeFormat
		// Access:    public 
		// Returns:   ClassLibrary.CHelperClass.string
		// Parameter: DateTime dateTime
		//把 诸如 2007-2-15 转换为 2007/2/15
		//////////////////////////////////////////////////////////////////////////
		static public string ConvertDateTimeFormat(DateTime dateTime)
		{
			return dateTime.ToString().Replace("-","/");
		}
		static public bool CovertStringToInt(string numberStr,ref int numberInt )
		{
			try
			{
				numberInt = int.Parse(numberStr);
			}
			catch (System.Exception e)
			{
				string ex = e.ToString();
				return false;
			}
			return true;
		}
		//////////////////////////////////////////////////////////////////////////
		// Method:    StringCompare
		// FullName:  ClassLibrary.CHelperClass.StringCompare
		// Access:    public static 
		// Returns:   bool
		// Parameter: string s1
		// Parameter: string s2
		//去掉字符串末尾的空格来判断是否相等
		//////////////////////////////////////////////////////////////////////////
		static public bool StringCompare(string s1,string s2)
		{
			return (s2.Trim()==s1.Trim());
		}

		static  public string UserMd5(string str)
		{
			string cl = str;
			string pwd = "";
			MD5 md5 = MD5.Create();//实例化一个md5对像
			// 加密后是一个字节类型的数组，这里要注意编码UTF8/Unicode等的选择　
			byte[] s = md5.ComputeHash(Encoding.UTF8.GetBytes(cl));
			// 通过使用循环，将字节类型的数组转换为字符串，此字符串是常规字符格式化所得
			for (int i = 0; i < s.Length; i++)
			{
				// 将得到的字符串使用十六进制类型格式。格式后的字符是小写的字母，如果使用大写（X）则格式后的字符是大写字符 

				pwd = pwd + s[i].ToString("X2");
                
			}
			return pwd;
		}
		//////////////////////////////////////////////////////////////////////////
		// Method:    CreateStep
		// FullName:  ClassLibrary.CHelperClass.CreateStep
		// Access:    public static 
		// Returns:   int
		// Parameter: string name
		// 生成编码时AscII码的偏移量
		//////////////////////////////////////////////////////////////////////////
		static public int CreateStep(string name)
		{
			int step =0;
			byte[] a= Encoding.ASCII.GetBytes(name);
			for (int i=0;i<a.Length;i++)
			{
				int byteI = (int)a[i];
				step = step+byteI;
			}
			step = step/a.Length;
			return step;
		}

		//////////////////////////////////////////////////////////////////////////
		// Method:    DisCode
		// FullName:  ClassLibrary.CHelperClass.DisCode
		// Access:    public static 
		// Returns:   string
		// Parameter: string oldcode
		// Parameter: string name
		// 进行解码操作;
		//////////////////////////////////////////////////////////////////////////
		static public string DisCode(string oldcode,string name)
		{
			string newcode="";
			int step = CreateStep(name);
			for (int i=0;i<oldcode.Length;i=i+3)
			{
				string strI = oldcode.Substring(i,3);
				int intI = int.Parse(strI)-step;
				char charI = (char)intI;
				if (newcode!="")
				{
					newcode = newcode + charI.ToString(); 
				}
				else
				{
					newcode = charI.ToString(); 
				}
			}
			return newcode;
		}

		//////////////////////////////////////////////////////////////////////////
		// Method:    CreateCode
		// FullName:  ClassLibrary.CHelperClass.CreateCode
		// Access:    public static 
		// Returns:   string
		// Parameter: string oldcode
		// Parameter: string name
		// 对字符串进行编码
		//////////////////////////////////////////////////////////////////////////
		static public string CreateCode(string oldcode,string name)
		{
			string newcode="";
			byte[] a= Encoding.ASCII.GetBytes(oldcode);
			string newcode_0 = "00";
			int step = CreateStep(name);
			for (int i=0;i<a.Length;i++)
			{
				byte byteI = a[i];
				int newbyte= (int)byteI+step;
				string byteStr = newcode_0+newbyte.ToString();
				if (newcode!="")
				{
					newcode = newcode + byteStr.Substring(byteStr.Length-3,3); 
				}
				else
				{
					newcode = byteStr.Substring(byteStr.Length-3,3);
				}
				
			}
			return newcode;
		}

		
		//////////////////////////////////////////////////////////////////////////
		// Method:    SaveSettings
		// FullName:  ClassLibrary.CHelperClass.SaveSettings
		// Access:    public static 
		// Returns:   bool
		// Parameter: string path
		// Parameter: CDBAccessor accessor1
		// Parameter: CDBAccessor accessor2
		// 保存设置信息
		//////////////////////////////////////////////////////////////////////////
// 		static public  bool SaveSettings(string path,CDBAccessor accessor1,CDBAccessor accessor2)
// 		{
// 			try
// 			{
// 				XmlDocument doc = new XmlDocument();
// 				
// 				doc.LoadXml("<item></item>");
// 
// 				// Add a price element.
// 				XmlElement newElem = doc.CreateElement("DatabaseServer");
// 				newElem.InnerText = accessor1.DatabaseServer;
// 				doc.DocumentElement.AppendChild(newElem);
// 				XmlElement newElem_1=doc.CreateElement("DatabaseName");
// 				newElem_1.InnerText=accessor1.DatabaseName;
// 				doc.DocumentElement.AppendChild(newElem_1);
// 				XmlElement newElem_2=doc.CreateElement("DatabaseID");
// 				newElem_2.InnerText=accessor1.DatabaseID;
// 				doc.DocumentElement.AppendChild(newElem_2);
// 				XmlElement newElem_3=doc.CreateElement("DatabasePassword");
// 				newElem_3.InnerText=accessor1.DatabasePassword;
// 				doc.DocumentElement.AppendChild(newElem_3);
// 			
// 				XmlElement newElem_4=doc.CreateElement("DatabaseServer2");
// 				newElem_4.InnerText=accessor2.DatabaseServer;
// 				doc.DocumentElement.AppendChild(newElem_4);
// 				XmlElement newElem_5=doc.CreateElement("DatabaseName2");
// 				newElem_5.InnerText=accessor2.DatabaseName;
// 				doc.DocumentElement.AppendChild(newElem_5);
// 				XmlElement newElem_6=doc.CreateElement("DatabaseID2");
// 				newElem_6.InnerText=accessor2.DatabaseID;
// 				doc.DocumentElement.AppendChild(newElem_6);
// 				XmlElement newElem_7=doc.CreateElement("DatabasePassword2");
// 				newElem_7.InnerText=accessor2.DatabasePassword;
// 				doc.DocumentElement.AppendChild(newElem_7);
// 				// Save the document to a file and auto-indent the output.
// 				XmlTextWriter writer = new XmlTextWriter(path,null);
// 				writer.Formatting = Formatting.Indented;
// 				doc.Save(writer);
// 				writer.Close();
// 				doc=null;
// 				return true;
// 			}
// 			catch (System.Exception ex)
// 			{
// 				string exp = ex.ToString();
// 				return false;
// 			}
// 		
// 		}



	}
}
