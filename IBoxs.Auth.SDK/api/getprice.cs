using IBoxs.Auth.SDK.api.JsonResponse;
using IBoxs.Auth.SDK.common;
using IBoxs.Auth.SDK.result;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBoxs.Auth.SDK.api
{
   public class getprice
    {
        public string url = config.ApiConfig.Host + "/api/getprice";
        public class param
        {
            /// <summary>
            /// 时长参数
            /// </summary>
            public static string duration { get; set; }
            /// <summary>
            /// 应用版本ID
            /// </summary>
            public static int grade { get; set; }
        }

        public getprice(string duration,int grade)
        {
            param.duration = duration;
            param.grade = grade;
        }
        /// <summary>
        /// 发送请求
        /// </summary>
        /// <returns></returns>
        public AppPrice Request(out string msg)
        {
            string time = LibraryTool.GetTimestampNow().ToString();
            string str = LibraryTool.GetRandomString(8);
            string sign = common.SignCode.GetSign(time, str, param.duration);
            Dictionary<string, object> postData = new Dictionary<string, object>
            {
                {"time",time },{"str",str },{"appid",config.ApiConfig.AppID },{"sign",sign },
                { "duration",param.duration},{ "grade",param.grade}
            };
            string data = common.HttpTool.getPostString(postData);
            string json = common.HttpTool.Post(url, data);
            GetPriceJson.Root rt = JsonConvert.DeserializeObject<GetPriceJson.Root>(json);
            if (rt.code != 0)
            {
                msg = rt.msg;
                return null;
            }
            else
            {
                msg = null;
                AppPrice ap = new AppPrice(rt);
                return ap;
            }
        }
    }
}
