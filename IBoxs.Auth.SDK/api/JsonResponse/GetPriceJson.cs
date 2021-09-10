using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBoxs.Auth.SDK.api.JsonResponse
{
   public class GetPriceJson
    {
        public class Data
        {
            /// <summary>
            /// 
            /// </summary>
            public float price { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public int aid { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string time { get; set; }
            /// <summary>
            /// 1月
            /// </summary>
            public string timename { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string grade { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string grade_name { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string grade_remarks { get; set; }
        }

        public class Root
        {
            /// <summary>
            /// 
            /// </summary>
            public int code { get; set; }
            /// <summary>
            /// 获取成功
            /// </summary>
            public string msg { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public Data data { get; set; }
        }
    }
}
