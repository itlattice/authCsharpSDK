using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBoxs.Auth.SDK.result
{
    /// <summary>
    /// 授权验证结果
    /// </summary>
    public class AuthResult
    {
        /// <summary>
        /// 授权状态
        /// </summary>
        public dataEnum.authStatus authStatus { get; private set; }
        /// <summary>
        /// 应用APPID（无则为空）
        /// </summary>
        public string appid { get; private set; }
        /// <summary>
        /// 授权版本ID（无则为0，单版本应用为0）
        /// </summary>
        public int grade { get; private set; }
        /// <summary>
        /// 授权版本名称（无则为空）
        /// </summary>
        public string grade_name { get; private set; }
        /// <summary>
        /// 首次授权时间（无则为MinValue）
        /// </summary>
        public DateTime auth_time { get; private set; }
        /// <summary>
        /// 授权方式
        /// </summary>
        public dataEnum.authType type { get; private set; }
        /// <summary>
        /// 到期时间（无则为null）
        /// </summary>
        public string stop_time { get; private set; }
        /// <summary>
        /// 反向验证sign（无为null，一般无需二次验证，若验证不通过，这里直接返回为无授权）
        /// </summary>
        public string sign { get; private set; }

        public static string requestSign { get; set; }

        public AuthResult(api.JsonResponse.AuthJson.Root rt, string sign)
        {
            if (rt.code < 0)
            {
                this.authStatus = dataEnum.authStatus.error;
                this.appid = config.ApiConfig.AppID;
                this.grade = 0;
                this.grade_name = "";
                this.auth_time = DateTime.MinValue;
                this.type = dataEnum.authType.purchase;
                this.stop_time = null;
                this.sign = sign;
                return;
            }
            if ((dataEnum.authStatus)rt.code == dataEnum.authStatus.banAuth || (dataEnum.authStatus)rt.code == dataEnum.authStatus.noMessage)
            {
                this.authStatus = (dataEnum.authStatus)rt.code;
                this.appid = config.ApiConfig.AppID;
                this.grade = 0;
                this.grade_name = "";
                this.auth_time = DateTime.MinValue;
                this.type = dataEnum.authType.purchase;
                this.stop_time = null;
                this.sign = sign;
                return;
            }
            string signTemp = common.SignCode.md5(common.SignCode.md5(rt.data.grade.ToString() + rt.data.auth_time.ToString() + rt.data.appid + requestSign) + config.ApiConfig.AppSecret);
            if (sign != signTemp)
            {
                this.authStatus = dataEnum.authStatus.noMessage;
                this.appid = config.ApiConfig.AppID;
                this.grade = 0;
                this.grade_name = "";
                this.auth_time = DateTime.MinValue;
                this.type = dataEnum.authType.purchase;
                this.stop_time = null;
                this.sign = sign;
                return;
            }
            this.authStatus = (dataEnum.authStatus)rt.code;
            this.appid = config.ApiConfig.AppID;
            this.grade = rt.data.grade;
            this.grade_name = rt.data.grade_name;
            this.auth_time = Convert.ToDateTime(rt.data.auth_time);
            this.type = (dataEnum.authType)rt.data.type;
            this.stop_time = rt.data.stop_time == "永久授权" ? "永久授权" : rt.data.stop_time;
            this.sign = sign;
        }
    }
}
