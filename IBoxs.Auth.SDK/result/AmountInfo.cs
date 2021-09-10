using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBoxs.Auth.SDK.result
{
    /// <summary>
    /// 用户账户余额信息
    /// </summary>
   public class AmountInfo
    {
        /// <summary>
        /// 可提现余额
        /// </summary>
        public double Banlance { get; private set; }
        /// <summary>
        /// 用户不可提现余额
        /// </summary>
        public double NoWith { get; private set; }
        /// <summary>
        /// 用户临时冻结余额
        /// </summary>
        public double Frozen { get; private set; }
        /// <summary>
        /// 用户待结算余额
        /// </summary>
        public double Unsettled { get; private set; }

        public AmountInfo(api.JsonResponse.GetAmountJson.Root rt)
        {
            this.Banlance =Convert.ToDouble( rt.data.balance);
            this.Frozen = Convert.ToDouble(rt.data.frozen);
            this.NoWith = Convert.ToDouble(rt.data.nowith);
            this.Unsettled = Convert.ToDouble(rt.data.unsettled);
        }
    }
}
