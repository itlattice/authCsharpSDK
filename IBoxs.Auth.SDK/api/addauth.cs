using IBoxs.Auth.SDK.common;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static IBoxs.Auth.SDK.api.JsonResponse.AddAuthJson;

namespace IBoxs.Auth.SDK.api
{
    /// <summary>
    /// 添加授权接口
    /// doc:
    /// </summary>
    class addauth
    {
        public string url = config.ApiConfig.Host + "/api/addauth";
        public class param
        {
            /// <summary>
            /// 授权到期时间
            /// </summary>
            public static int expire { get; set; }
            /// <summary>
            /// 应用版本ID
            /// </summary>
            public static int grade { get; set; }
            /// <summary>
            /// 用户识别码
            /// </summary>
            public static string userkey { get; set; }
        }

        public addauth(string userkey,int expire,int grade)
        {
            param.expire = expire;
            param.grade = grade;
            param.userkey = userkey;
        }

        public bool Request(out string msg)
        {
            string time = LibraryTool.GetTimestampNow().ToString();
            string str = LibraryTool.GetRandomString(8);
            string sign = common.SignCode.GetSign(time, str, param.userkey);
            SDK.result.AuthResult.requestSign = sign;
            Dictionary<string, object> postData = new Dictionary<string, object>
            {
                {"time",time },{"str",str },{"appid",config.ApiConfig.AppID },{"sign",sign },
                {"userkey",param.userkey},{"grade",param.grade},{"expire",param.expire}
            };
            string data = common.HttpTool.getPostString(postData);
            string json = common.HttpTool.Post(url, data);
            Root rt = JsonConvert.DeserializeObject<Root>(json);
            msg = rt.msg;
            if(rt.code!=0)
            {
                return false;
            }
            else
            {
                return rt.data.is_new;
            }
        }
    }
}
