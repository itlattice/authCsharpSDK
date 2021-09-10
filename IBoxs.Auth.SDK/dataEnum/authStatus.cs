using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBoxs.Auth.SDK.dataEnum
{
    /// <summary>
    /// 授权状态
    /// </summary>
    public enum authStatus
    {
        /// <summary>
        /// 授权正常（状态正常且未过期）
        /// </summary>
        normal=0,
        /// <summary>
        /// 无授权
        /// </summary>
        noMessage=1001,
        /// <summary>
        /// 授权被禁用
        /// </summary>
        banAuth=1010,
        /// <summary>
        /// 授权已过期
        /// </summary>
        overdue=1002,
        /// <summary>
        /// 系统异常(接口请求数据错误)
        /// </summary>
        error=-1
    }
}
