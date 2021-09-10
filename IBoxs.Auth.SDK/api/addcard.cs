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
    class addcard
    {
        public string url = config.ApiConfig.Host + "/api/addcard";
        public class param
        {
            /// <summary>
            /// Card
            /// </summary>
            public static List<string> card { get; set; }
            /// <summary>
            /// 时长
            /// </summary>
            public static string duration { get; set; }
            
            /// <summary>
            /// 应用版本ID
            /// </summary>
            public static int grade { get; set; }
        }

        public addcard(List<string> card, string duration, int grade = 0)
        {
            param.card = card;
            param.duration = duration;
            param.grade = grade;
        }

        public bool Request(out string responseJson)
        {
            if (param.card.Count < 1)
            {
                responseJson = "卡密不能为空";
                return false;
            }
            string time = LibraryTool.GetTimestampNow().ToString();
            string str = LibraryTool.GetRandomString(8);
            string sign = common.SignCode.GetSign(time, str, param.card[0]);
            Dictionary<string, object> postData = new Dictionary<string, object>
            {
                {"time",time },{"str",str },{"appid",config.ApiConfig.AppID },{"sign",sign },
                { "duration",param.duration},{ "grade",param.grade}
            };
            for(int i=0;i<param.card.Count;i++)
            {
                postData.Add("card[]", param.card[i]);
            }
            string data = common.HttpTool.getPostString(postData);
            string json = common.HttpTool.Post(url, data);
            GetPayStateJson.Root rt = JsonConvert.DeserializeObject<GetPayStateJson.Root>(json);
            if (rt.code == 0)
            {
                responseJson = json;
                return true;
            }
            else
            {
                responseJson = json;
                return false;
            }
        }
    }
}
