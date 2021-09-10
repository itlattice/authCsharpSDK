using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBoxs.Auth.SDK.api.JsonResponse
{
   public class GetAmountJson
    {
        public class Data
        {
            /// <summary>
            /// 
            /// </summary>
            public string balance { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string nowith { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string frozen { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string unsettled { get; set; }
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
