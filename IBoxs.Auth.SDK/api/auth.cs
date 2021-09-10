using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IBoxs.Auth.SDK.common;
using Newtonsoft.Json;
using static IBoxs.Auth.SDK.api.JsonResponse.AuthJson;

namespace IBoxs.Auth.SDK.api
{
    /// <summary>
    /// 授权验证接口
    /// doc:
    /// </summary>
    class auth
    {
        public string url = config.ApiConfig.Host + "/api/auth";
        public class param
        {
            /// <summary>
            /// 用户识别码
            /// </summary>
            public static string userkey { get; set; }
        }

        public auth(string userkey)
        {
            param.userkey = userkey;
        }
        /// <summary>
        /// 发送请求
        /// </summary>
        /// <returns></returns>
        public result.AuthResult Request(out string errormsg)
        {
            string time = LibraryTool.GetTimestampNow().ToString();
            string str = LibraryTool.GetRandomString(8);
            string sign = common.SignCode.GetSign(time, str, param.userkey);
            SDK.result.AuthResult.requestSign = sign;
            Dictionary<string, object> postData = new Dictionary<string, object>
            {
                {"time",time },{"str",str },{"appid",config.ApiConfig.AppID },{"sign",sign },
                {"userkey",param.userkey }
            };
            string data = common.HttpTool.getPostString(postData);
            string json=common.HttpTool.Post(url, data);
            Root rt = JsonConvert.DeserializeObject<Root>(json);
            result.AuthResult result = new result.AuthResult(rt, rt.sign);
            errormsg = rt.msg;
            return result;
        }
    }
}
