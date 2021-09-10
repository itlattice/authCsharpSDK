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
   public class getgradelist
    {
        public string url = config.ApiConfig.Host + "/api/getgradelist";
        public class param
        {

        }

        public getgradelist()
        {
            
        }
        /// <summary>
        /// 发送请求
        /// </summary>
        /// <returns></returns>
        public List<result.AppGrade> Request()
        {
            string time = LibraryTool.GetTimestampNow().ToString();
            string str = LibraryTool.GetRandomString(8);
            string sign = common.SignCode.GetSign(time, str, "getgradelist");
            Dictionary<string, object> postData = new Dictionary<string, object>
            {
                {"time",time },{"str",str },{"appid",config.ApiConfig.AppID },{"sign",sign }
            };
            string data = common.HttpTool.getPostString(postData);
            string json = common.HttpTool.Post(url, data);
            GetGradeListJson.Root rt = JsonConvert.DeserializeObject<GetGradeListJson.Root>(json);
            if (rt.code != 0) return null;
            else
            {
                List<result.AppGrade> ret = new List<result.AppGrade>();
                List<GetGradeListJson.DataItem> datas = new List<GetGradeListJson.DataItem>();
                datas = rt.data;
                for(int i=0;i<datas.Count;i++)
                {
                    result.AppGrade grade = new result.AppGrade(datas[i].grade, datas[i].name, datas[i].remarks);
                    ret.Add(grade);
                }
                return ret;
            }
        }
    }
}
