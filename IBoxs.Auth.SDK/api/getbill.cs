using IBoxs.Auth.SDK.common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IBoxs.Auth.SDK.api.JsonResponse;
using Newtonsoft.Json;
using IBoxs.Auth.SDK.result;

namespace IBoxs.Auth.SDK.api
{
    public class getbill
    {
        public string url = config.ApiConfig.Host + "/api/getbill";
        public class param
        {
            /// <summary>
            /// Card
            /// </summary>
            public static int limit { get; set; }
        }

        public getbill(int limit)
        {
            param.limit = limit;
        }
        /// <summary>
        /// 发送请求
        /// </summary>
        /// <returns></returns>
        public List<BillInfo> Request()
        {
            string time = LibraryTool.GetTimestampNow().ToString();
            string str = LibraryTool.GetRandomString(8);
            string sign = common.SignCode.GetSign(time, str, "getbill");
            Dictionary<string, object> postData = new Dictionary<string, object>
            {
                {"time",time },{"str",str },{"appid",config.ApiConfig.AppID },{"sign",sign },
                    { "limit",param.limit}
            };
            string data = common.HttpTool.getPostString(postData);
            string json = common.HttpTool.Post(url, data);
            GetBillJson.Root rt = JsonConvert.DeserializeObject<GetBillJson.Root>(json);
            if (rt.code == 0)
            {
                List<BillInfo> binfo = new List<BillInfo>();
                for(int i=0;i<rt.data.Count;i++)
                {
                    binfo.Add((new BillInfo()));
                }
                return binfo;
            }
            else
            {
                return null;
            }
        }
    }
}

