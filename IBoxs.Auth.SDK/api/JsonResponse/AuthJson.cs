using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBoxs.Auth.SDK.api.JsonResponse
{
   public class AuthJson
    {
        public class Data
        {
            /// <summary>
            /// 
            /// </summary>
            public string appid { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public int grade { get; set; }
            /// <summary>
            /// ssssssssss删除
            /// </summary>
            public string grade_name { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string auth_time { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public int type { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string stop_time { get; set; }
        }

        public class Root
        {
            /// <summary>
            /// 
            /// </summary>
            public int code { get; set; }
            /// <summary>
            /// 授权正常
            /// </summary>
            public string msg { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public Data data { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string sign { get; set; }
        }
    }
}
