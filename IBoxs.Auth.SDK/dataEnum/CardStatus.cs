using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBoxs.Auth.SDK.dataEnum
{
    public enum CardStatus
    {
        /// <summary>
        /// 正常
        /// </summary>
        nomal = 0,
        /// <summary>
        /// 已使用
        /// </summary>
        used = 1,
        /// <summary>
        /// 已核销
        /// </summary>
        writeoff = 2,
        /// <summary>
        /// 禁用
        /// </summary>
        ban = 3
    }
}
