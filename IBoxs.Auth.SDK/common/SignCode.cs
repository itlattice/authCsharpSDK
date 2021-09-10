using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace IBoxs.Auth.SDK.common
{
   public class SignCode
    {
        /// <summary>
        /// 计算sign
        /// </summary>
        /// <param name="time">时间戳</param>
        /// <param name="str">随机字符串</param>
        /// <param name="param">标准参值</param>
        /// <returns>sign</returns>
        public static string GetSign(string time,string str,string param)
        {
            //md5(md5(APPID + 时间戳 + 标准参值 + 随机字符串) + AppSecret)
            string signTemp = md5(config.ApiConfig.AppID + time + param + str);
            signTemp = md5(signTemp + config.ApiConfig.AppSecret);
            return signTemp;
        }

        /// <summary>
        /// MD5加密
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string md5(string str)
        {
            byte[] result = Encoding.Default.GetBytes(str.Trim());  //tbPass为输入密码的文本框
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            byte[] output = md5.ComputeHash(result);
            string st = BitConverter.ToString(output).Replace("-", "").ToLower().Trim().ToString(); //
            // SplachForm f = new SplachForm();
            //   f.ShowDialog();
            return st;
        }
    }
}
