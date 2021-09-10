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
    class updateprice
    {
        public string url = config.ApiConfig.Host + "/api/updateprice";
        public class param
        {
            /// <summary>
            /// 时长
            /// </summary>
            public static string duration { get; set; }
            /// <summary>
            /// 应用版本ID
            /// </summary>
            public static int grade { get; set; }
            /// <summary>
            /// 价格
            /// </summary>
            public static float price { get; set; }
        }

        public updateprice(string duration, int grade, float price)
        {
            param.duration = duration;
            param.grade = grade;
            param.price = price;
        }
        /// <summary>
        /// 发送请求
        /// </summary>
        /// <returns></returns>
        public bool Request(out string msg)
        {
            string time = LibraryTool.GetTimestampNow().ToString();
            string str = LibraryTool.GetRandomString(8);
            string sign = common.SignCode.GetSign(time, str, param.duration);
            Dictionary<string, object> postData = new Dictionary<string, object>
            {
                {"time",time },{"str",str },{"appid",config.ApiConfig.AppID },{"sign",sign },
                { "duration",param.duration},{ "grade",param.grade},{ "price",param.price}
            };
            string data = common.HttpTool.getPostString(postData);
            string json = common.HttpTool.Post(url, data);
            UpdatePriceJson.Root rt = JsonConvert.DeserializeObject<UpdatePriceJson.Root>(json);
            if (rt.code != 0)
            {
                msg = rt.msg;
                return false;
            }
            else
            {
                msg = rt.msg;
                return true;
            }
        }
    }
}
