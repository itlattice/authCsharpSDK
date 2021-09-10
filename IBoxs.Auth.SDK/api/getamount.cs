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
    class getamount
    {
        public string url = config.ApiConfig.Host + "/api/getamount";
        public class param
        {

        }

        public getamount()
        {

        }
        /// <summary>
        /// 发送请求
        /// </summary>
        /// <returns></returns>
        public AmountInfo Request()
        {
            string time = LibraryTool.GetTimestampNow().ToString();
            string str = LibraryTool.GetRandomString(8);
            string sign = common.SignCode.GetSign(time, str, "getamount");
            Dictionary<string, object> postData = new Dictionary<string, object>
            {
                {"time",time },{"str",str },{"appid",config.ApiConfig.AppID },{"sign",sign }
            };
            string data = common.HttpTool.getPostString(postData);
            string json = common.HttpTool.Post(url, data);
            GetAmountJson.Root rt = JsonConvert.DeserializeObject<GetAmountJson.Root>(json);
            if (rt.code != 0) return null;
            else
            {
                return (new AmountInfo(rt));
            }
        }
    }
}
