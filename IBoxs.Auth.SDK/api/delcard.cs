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
    class delcard
    {
        public string url = config.ApiConfig.Host + "/api/delcard";
        public class param
        {
            /// <summary>
            /// Card
            /// </summary>
            public static List<string> card { get; set; }
        }

        public delcard(List<string> card)
        {
            param.card = card;
        }
        /// <summary>
        /// 发送请求
        /// </summary>
        /// <returns></returns>
        public bool Request(out string msg)
        {
            string time = LibraryTool.GetTimestampNow().ToString();
            string str = LibraryTool.GetRandomString(8);
            string sign = common.SignCode.GetSign(time, str, param.card[0]);
            Dictionary<string, object> postData = new Dictionary<string, object>
            {
                {"time",time },{"str",str },{"appid",config.ApiConfig.AppID },{"sign",sign }
            };
            for (int i = 0; i < param.card.Count; i++)
            {
                postData.Add("card[]", param.card[i]);
            }
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
