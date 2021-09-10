using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBoxs.Auth.SDK.api.JsonResponse
{
   public class GetBillJson
    {
        public class DataItem
        {
            /// <summary>
            /// 
            /// </summary>
            public string order { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string @abstract { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string amount { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public int type { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public int state { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string time { get; set; }
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
            public List<DataItem> data { get; set; }
        }
    }
}
