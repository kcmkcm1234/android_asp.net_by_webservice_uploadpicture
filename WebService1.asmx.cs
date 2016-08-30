using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.IO;

namespace PXQShare.Web
{
    /// <summary>
    /// WebService1 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消对下行的注释。
    // [System.Web.Script.Services.ScriptService]
    public class WebService1 : System.Web.Services.WebService
    {

        
        [WebMethod]
        public bool FileUploadImage(string title, string contect, string bytestr)
        {
            string name = "";
            if (bytestr == "")
            {
                return false;
            }
            try
            {
                name = DateTime.Now.Year.ToString() + DateTime.Now.Month + DateTime.Now.Day + DateTime.Now.Hour + DateTime.Now.Minute + DateTime.Now.Second;
                bool flag = StringToFile(bytestr, "D:\\" + name + ".jpg");
                return true;
            }
            catch
            {
                return false;
            }

        }
        protected System.Drawing.Image Base64StringToImage(string strbase64)
        {
            try
            {
                byte[] arr = Convert.FromBase64String(strbase64);
                MemoryStream ms = new MemoryStream(arr);               
                ms.Write(arr, 0, arr.Length);
                System.Drawing.Image image = System.Drawing.Image.FromStream(ms);
                ms.Close();
                return image;
                //return bmp; 
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>  
        /// 把经过base64编码的字符串保存为文件  
        /// </summary>  
        /// <param name="base64String">经base64加码后的字符串 </param>  
        /// <param name="fileName">保存文件的路径和文件名 </param>  
        /// <returns>保存文件是否成功 </returns>  
        public static bool StringToFile(string base64String, string fileName)
        {
            //string path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().GetName().CodeBase) + @"/beapp/" + fileName;  

            System.IO.FileStream fs = new System.IO.FileStream(fileName, System.IO.FileMode.Create);
            System.IO.BinaryWriter bw = new System.IO.BinaryWriter(fs);
            if (!string.IsNullOrEmpty(base64String) && File.Exists(fileName))
            {
                bw.Write(Convert.FromBase64String(base64String));
            }
            bw.Close();
            fs.Close();
            return true;
        }


    }
}
