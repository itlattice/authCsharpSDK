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
    /// <summary>
    /// 获取订单支付状态
    /// </summary>
    class getpaystate
    {
        public string url = config.ApiConfig.Host + "/api/getpaystate";
        public class param
        {
            /// <summary>
            /// 订单号
            /// </summary>
            public static string order { get; set; }
        }

        public getpaystate(string order)
        {
            param.order = order;
        }
        /// <summary>
        /// 发送请求
        /// </summary>
        /// <returns></returns>
        public bool Request(out string msg,out string pay_time)
        {
            string time = LibraryTool.GetTimestampNow().ToString();
            string str = LibraryTool.GetRandomString(8);
            string sign = common.SignCode.GetSign(time, str, param.order);
            Dictionary<string, object> postData = new Dictionary<string, object>
            {
                {"time",time },{"str",str },{"appid",config.ApiConfig.AppID },{"sign",sign },
                { "order",param.order}
            };
            string data = common.HttpTool.getPostString(postData);
            string json = common.HttpTool.Post(url, data);
            GetPayStateJson.Root rt = JsonConvert.DeserializeObject<GetPayStateJson.Root>(json);
            if (rt.code < 0)
            {
                msg = rt.msg;
                pay_time = null;
                return false;
            }
            else if(rt.code==0)
            {
                msg = rt.msg;
                pay_time = null;
                return false;
            }
            else if (rt.code == 1)
            {
                msg = rt.msg;
                pay_time = rt.data.pay_time;
                return true;
            } else
            {
                msg = rt.msg;
                pay_time = null;
                return false;
            }
        }
    }
}
