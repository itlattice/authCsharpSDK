using IBoxs.Auth.SDK.common;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static IBoxs.Auth.SDK.api.JsonResponse.DelAuthJson;

namespace IBoxs.Auth.SDK.api
{
    /// <summary>
    /// 删除授权接口
    /// doc:
    /// </summary>
    class delauth
    {
        public string url = config.ApiConfig.Host + "/api/delauth";
        public class param
        {
            /// <summary>
            /// 用户识别码
            /// </summary>
            public static string userkey { get; set; }
        }

        public delauth(string userkey)
        {
            param.userkey = userkey;
        }
        /// <summary>
        /// 发送请求
        /// </summary>
        /// <returns></returns>
        public bool Request()
        {
            string time = LibraryTool.GetTimestampNow().ToString();
            string str = LibraryTool.GetRandomString(8);
            string sign = common.SignCode.GetSign(time, str, param.userkey);
            Dictionary<string, object> postData = new Dictionary<string, object>
            {
                {"time",time },{"str",str },{"appid",config.ApiConfig.AppID },{"sign",sign },
                {"userkey",param.userkey }
            };
            string data =common.HttpTool.getPostString(postData);
            string json = common.HttpTool.Post(url, data);
            Root rt = JsonConvert.DeserializeObject<Root>(json);
            if (rt.code != 0) return false;
            else return true;
        }
    }
}
