using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBoxs.Auth.SDK.config
{
    /// <summary>
    /// Api配置
    /// </summary>
   public class ApiConfig
    {
        /// <summary>
        /// 网关地址
        /// </summary>
        public static string Host
        {
            get
            {
                return "https://auth.itgz8.com";
            }
        }
        /// <summary>
        /// APPID
        /// </summary>
        public static string AppID { get; set; }
        /// <summary>
        /// APPSecret
        /// </summary>
        public static string AppSecret { get; set; }
    }
}
