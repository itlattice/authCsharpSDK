using IBoxs.Auth.SDK.common;
using IBoxs.Auth.SDK.dataEnum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IBoxs.Auth.SDK.api.JsonResponse;
using Newtonsoft.Json;
using System.Drawing;

namespace IBoxs.Auth.SDK.api
{
    /// <summary>
    /// 购买授权获取支付二维码接口
    /// </summary>
    class getpaycode
    {
        public string url = config.ApiConfig.Host + "/api/getpaycode";
        public class param
        {
            /// <summary>
            /// 用户识别码
            /// </summary>
            public static string userkey { get; set; }
            /// <summary>
            /// 时长
            /// </summary>
            public static string duration { get; set; }
            /// <summary>
            /// 支付方式
            /// </summary>
            public static PayType payType { get; set; }
            /// <summary>
            /// 应用版本ID
            /// </summary>
            public static int grade { get; set; }
            /// <summary>
            /// 价格
            /// </summary>
            public static float price { get; set; }
        }

        public getpaycode(string userkey, string duration, PayType payType, int grade = 0, float price = 0)
        {
            param.userkey = userkey;
            param.duration = duration;
            param.grade = grade;
            param.payType = payType;
            param.price = price;
        }
        /// <summary>
        /// 发送请求
        /// </summary>
        /// <returns></returns>
        public result.PayCode Request(out string msg)
        {
            string time = LibraryTool.GetTimestampNow().ToString();
            string str = LibraryTool.GetRandomString(8);
            string sign = common.SignCode.GetSign(time, str, param.userkey);
            Dictionary<string, object> postData = new Dictionary<string, object>
            {
                {"time",time },{"str",str },{"appid",config.ApiConfig.AppID },{"sign",sign },
                { "userkey",param.userkey},{ "duration",param.duration},{ "grade",param.grade},
                { "payType",(int)param.payType},{ "price",param.price}
            };
            string data = common.HttpTool.getPostString(postData);
            string json = common.HttpTool.Post(url, data);
            GetPayCodeJson.Root rt = JsonConvert.DeserializeObject<GetPayCodeJson.Root>(json);
            if(rt.code!=0)
            {
                msg = rt.msg;
                return (new result.PayCode(rt));
            }
            else
            {
                msg = null;
                return (new result.PayCode(rt));
            }
        }
    }
}
