using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace IBoxs.Auth.SDK.common
{
    /// <summary>
    /// Http 工具类
    /// </summary>
    public class HttpTool
    {
        /// <summary>
        /// post数据
        /// </summary>
        /// <param name="postData"></param>
        /// <returns></returns>
        public static string getPostString(Dictionary<string,object> postData)
        {
            string poststring = "";
            foreach (KeyValuePair<string, object> kvp in postData)
            {
                poststring += kvp.Key + "=" + kvp.Value.ToString() + "&";
            }
            poststring = poststring.Substring(0, poststring.Length - 1);
            return poststring;
        }

        /// <summary>
        /// 使用默认编码对 URL 进行编码
        /// </summary>
        /// <param name="url">要编码的地址</param>
        /// <returns>编码后的地址</returns>
        public static string UrlEncode(string url)
        {
            return HttpUtility.UrlEncode(url);
        }

        /// <summary>
        /// 使用指定的编码 <see cref="Encoding"/> 对 URL 进行编码
        /// </summary>
        /// <param name="url">要编码的地址</param>
        /// <param name="encoding">编码类型</param>
        /// <returns>编码后的地址</returns>
        public static string UrlEncode(string url, Encoding encoding)
        {
            return HttpUtility.UrlEncode(url, encoding);
        }

        /// <summary>
        /// 使用默认编码对 URL 进行解码
        /// </summary>
        /// <param name="url">要解码的地址</param>
        /// <returns>编码后的地址</returns>
        public static string UrlDecode(string url)
        {
            return HttpUtility.UrlDecode(url);
        }

        /// <summary>
        /// 使用指定的编码 <see cref="Encoding"/> 对 URL 进行解码
        /// </summary>
        /// <param name="url">要解码的地址</param>
        /// <param name="encoding">编码类型</param>
        /// <returns>编码后的地址</returns>
        public static string UrlDecode(string url, Encoding encoding)
        {
            return HttpUtility.UrlDecode(url, encoding);
        }
        
        /// <summary>
        /// 发起GET请求
        /// </summary>
        /// <param name="url">地址</param>
        /// <returns>返回内容</returns>
        public static string GET(string url)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "GET";
            request.ContentType = "text/html;charset=UTF-8";
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream myResponseStream = response.GetResponseStream();
            StreamReader myStreamReader = new StreamReader(myResponseStream, Encoding.UTF8);
            string retString = myStreamReader.ReadToEnd();
            myStreamReader.Close();
            myResponseStream.Close();
            return retString;
        }
        /// <summary>
        /// 发起post请求
        /// </summary>
        /// <param name="url"></param>
        /// <param name="postData"></param>
        /// <returns></returns>
        public static string Post(string url, string postData)
        {
            System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "POST";
            byte[] byteArray = Encoding.UTF8.GetBytes(postData);
            request.ContentType = "application/x-www-form-urlencoded";
            request.UserAgent = "Mozilla/5.0 (Windows NT 6.1) AppleWebKit/535.2 (KHTML, like Gecko) Chrome/15.0.874.121 Safari/535.2";
            request.ProtocolVersion = HttpVersion.Version11;
            request.AllowAutoRedirect = true;
            request.ContentLength = byteArray.Length;
            Stream dataStream = request.GetRequestStream();
            dataStream.Write(byteArray, 0, byteArray.Length);
            dataStream.Close();
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            dataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(dataStream);
            string responseFromServer = reader.ReadToEnd();
            reader.Close();
            dataStream.Close();
            response.Close();
            return responseFromServer;
        }
    }
}

