using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBoxs.Auth.SDK.api.JsonResponse
{
   public class GetCardJson
    {
        public class Use_user
        {
            /// <summary>
            /// 
            /// </summary>
            public string user_key { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string use_time { get; set; }
        }

        public class Data
        {
            /// <summary>
            /// 
            /// </summary>
            public string app { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public int grade { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string grade_name { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public int state { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string create_time { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public Use_user use_user { get; set; }
        }

        public class Root
        {
            /// <summary>
            /// 
            /// </summary>
            public int code { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string msg { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public Data data { get; set; }
        }
    }
}
