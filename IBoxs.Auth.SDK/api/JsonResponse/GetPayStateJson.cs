using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBoxs.Auth.SDK.api.JsonResponse
{
   public class GetPayStateJson
    {
        public class Data
        {
            /// <summary>
            /// 
            /// </summary>
            public string order_num { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string pay_time { get; set; }
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
