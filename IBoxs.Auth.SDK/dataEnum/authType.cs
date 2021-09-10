using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBoxs.Auth.SDK.dataEnum
{
    /// <summary>
    /// 授权获得方式
    /// </summary>
    public enum authType
    {
        /// <summary>
        /// 直接购买
        /// </summary>
        purchase =0,
        /// <summary>
        /// 授权码获取
        /// </summary>
        card=1,
        /// <summary>
        /// 应用作者赠送
        /// </summary>
        give=2
    }
}
