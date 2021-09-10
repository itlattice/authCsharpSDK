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
   public class getcardinfo
    {
        public string url = config.ApiConfig.Host + "/api/getcardinfo";
        public class param
        {
            /// <summary>
            /// Card
            /// </summary>
            public static string card { get; set; }
        }

        public getcardinfo(string card)
        {
            param.card = card;
        }
        /// <summary>
        /// 发送请求
        /// </summary>
        /// <returns></returns>
        public CardInfo Request(out string msg)
        {
            string time = LibraryTool.GetTimestampNow().ToString();
            string str = LibraryTool.GetRandomString(8);
            string sign = common.SignCode.GetSign(time, str, param.card);
            Dictionary<string, object> postData = new Dictionary<string, object>
            {
                {"time",time },{"str",str },{"appid",config.ApiConfig.AppID },{"sign",sign },{"card",param.card }
            };
            string data = common.HttpTool.getPostString(postData);
            string json = common.HttpTool.Post(url, data);
            GetCardJson.Root rt = JsonConvert.DeserializeObject<GetCardJson.Root>(json);
            if (rt.code == 0)
            {
                msg = rt.msg;
                CardInfo info = new CardInfo(rt);
                return info;
            }
            else
            {
                msg = rt.msg;
                return null;
            }
        }
    }
}
