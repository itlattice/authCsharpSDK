using IBoxs.Auth.SDK.api.JsonResponse;
using IBoxs.Auth.SDK.common;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBoxs.Auth.SDK.api
{
    class usecard
    {
        public string url = config.ApiConfig.Host + "/api/usecard";
        public class param
        {
            /// <summary>
            /// Card
            /// </summary>
            public static string card { get; set; }
            /// <summary>
            /// 用户识别码
            /// </summary>
            public static string userkey { get; set; }
        }

        public usecard(string card, string userkey)
        {
            param.card = card;
            param.userkey = userkey;
        }
        /// <summary>
        /// 发送请求
        /// </summary>
        /// <returns></returns>
        public bool Request(out string msg)
        {
            string time = LibraryTool.GetTimestampNow().ToString();
            string str = LibraryTool.GetRandomString(8);
            string sign = common.SignCode.GetSign(time, str, param.card);
            Dictionary<string, object> postData = new Dictionary<string, object>
            {
                {"time",time },{"str",str },{"appid",config.ApiConfig.AppID },{"sign",sign },
                { "card",param.card},{ "userkey",param.userkey}
            };
            string data = common.HttpTool.getPostString(postData);
            string json = common.HttpTool.Post(url, data);
            GetPayStateJson.Root rt = JsonConvert.DeserializeObject<GetPayStateJson.Root>(json);
            if (rt.code == 0)
            {
                msg = rt.msg;
                return true;
            }
            else
            {
                msg = rt.msg;
                return false;
            }
        }
    }
}
