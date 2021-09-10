using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using ThoughtWorks.QRCode.Codec;

namespace IBoxs.Auth.SDK.common
{
    public class LibraryTool
    {
        /// <summary>
        /// 对Url进行编码
        /// </summary>
        /// <param name="url">url</param>
        /// <param name="isUpper">编码字符是否转成大写,范例,"http://"转成"http%3A%2F%2F"</param>
        public static string UrlEncode(string url, bool isUpper = false)
        {
            return System.Web.HttpUtility.UrlEncode(url);
        }

        /// <summary>
        /// 判断是否是数字
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool IsInt(string value)
        {
            try
            {
                double j = Convert.ToDouble(value);
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// 将Unicode转为字符串
        /// </summary>
        /// <param name="srcText"></param>
        /// <returns></returns>
        public static string UnicodeToString(string srcText)
        {
            string de = Regex.Unescape(srcText);
            de = System.Web.HttpUtility.UrlEncode(de, Encoding.UTF8);
            return de;
        }

        /// <summary>
        /// 获取当前时间戳
        /// </summary>
        /// <returns></returns>
        public static int GetTimestampNow()
        {
            return GetTimestamp(DateTime.Now);
        }

        /// <summary>
        /// 获取时间戳
        /// </summary>
        /// <param name="d"></param>
        /// <returns></returns>
        public static int GetTimestamp(DateTime d)
        {
            if (d == null)
            {
                d = DateTime.Now;
            }
            TimeSpan ts = d - new DateTime(1970, 1, 1, 8, 0, 0, 0);
            try
            {
                return Convert.ToInt32(ts.TotalSeconds);
            }
            catch
            {
                return 2047413647;
            }
        }

        /// <summary>
        /// 时间戳转换为北京时间
        /// </summary>
        /// <param name="timeStamp">时间戳</param>
        /// <returns></returns>
        public static DateTime GetDateTime(long timeStamp)
        {
            DateTime dtStart = Convert.ToDateTime("1970-01-01 8:00:00");
            DateTime d = dtStart.AddSeconds(timeStamp);
            return d;
        }

        ///<summary>
        ///生成随机字符串 
        ///</summary>
        ///<param name="length">目标字符串的长度</param>
        ///<returns>指定长度的随机字符串</returns>
        public static string GetRandomString(int length)
        {
            byte[] b = new byte[4];
            new System.Security.Cryptography.RNGCryptoServiceProvider().GetBytes(b);
            Random r = new Random(BitConverter.ToInt32(b, 0));
            string s = null, str = ""; str += "0123456789"; str += "abcdefghijklmnopqrstuvwxyz".ToUpper();
            for (int i = 0; i < length; i++)
            {
                s += str.Substring(r.Next(0, str.Length - 1), 1);
            }
            return s;
        }

        /// <summary>
        /// 生成二维码
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public static Image GetErCode(string url)
        {
            Bitmap bt;
            QRCodeEncoder qrCodeEncoder = new QRCodeEncoder();
            bt = qrCodeEncoder.Encode(url, Encoding.UTF8);
            Image map = bt;
            return map;
        }
    }
}
