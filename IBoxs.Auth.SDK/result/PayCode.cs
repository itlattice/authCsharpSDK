using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IBoxs.Auth.SDK.api.JsonResponse;

namespace IBoxs.Auth.SDK.result
{
    /// <summary>
    /// 购买授权支付信息对象
    /// </summary>
    public class PayCode
    {
        public string Url { get; private set; }
        /// <summary>
        /// 
        /// </summary>
        public double Price { get; private set; }
        /// <summary>
        /// 
        /// </summary>
        public string Order { get; private set; }

        public Image payCodeImg { get; private set; }

        public PayCode(GetPayCodeJson.Root rt)
        {
            if (rt.code != 0)
            {
                this.Order = null;
                this.payCodeImg = null;
                this.Price = 0;
                this.Url = null;
                return;
            }
            else
            {
                this.Order = rt.data.order;
                this.payCodeImg = common.LibraryTool.GetErCode(rt.data.url);
                this.Price = rt.data.price;
                this.Url = rt.data.url;
            }
        }
    }
}
