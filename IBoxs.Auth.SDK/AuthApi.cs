using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IBoxs.Auth.SDK.result;
using IBoxs.Auth.SDK.api;
using System.Drawing;
using IBoxs.Auth.SDK.dataEnum;

/// <summary>
/// 授权系统SDK入口类
/// </summary>
namespace IBoxs.Auth.SDK
{
    /// <summary>
    /// 系统api
    /// </summary>
    public class AuthApi
    {
        /***************************************************
         * 说明
         * 1.时长标识规则参考：https://auth.itgz8.com/doc/getpaycode.html  （在页面底部）
         * 2.开发文档：https://auth.itgz8.com/doc/index.html
         */
        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="AppID">AppID</param>
        /// <param name="AppSecret">AppSecret</param>
        public AuthApi(string AppID, string AppSecret)
        {
            config.ApiConfig.AppID = AppID;
            config.ApiConfig.AppSecret = AppSecret;
        }

        #region 授权类接口
        /// <summary>
        /// 授权验证
        /// </summary>
        /// <param name="userkey">用户识别码</param>
        /// <returns>验证结果</returns>
        public result.AuthResult Auth(string userkey, out string msg)
        {
            api.auth auth = new api.auth(userkey);
            return auth.Request(out msg);
        }
        /// <summary>
        /// 添加授权（直接添加写入，若为用户购买授权，请调用购买授权接口），若非新用户的，本接口将修改用户授权
        /// </summary>
        /// <param name="userkey">用户识别码</param>
        /// <param name="expire">授权到期时间（Unix时间戳）</param>
        /// <param name="grade">授权应用版本ID（单版本应用本参数固定为0，多版本应用必须传入本参数）</param>
        /// <returns>是否为新用户</returns>
        public bool AddAuth(string userkey, int expire, out string msg, int grade = 0)
        {
            api.addauth addauth = new addauth(userkey, expire, grade);
            return addauth.Request(out msg);
        }
        /// <summary>
        /// 删除授权(授权直接删除，继续进行授权验证将返回无授权，本接口删除后5分钟内生效)
        /// </summary>
        /// <param name="userkey">用户识别码</param>
        /// <returns>是否成功</returns>
        public bool DelAuth(string userkey)
        {
            api.delauth delauth = new delauth(userkey);
            return delauth.Request();
        }
        #endregion

        #region 购买授权类接口
        /// <summary>
        /// 购买授权获取支付二维码
        /// </summary>
        /// <param name="userkey">用户识别码</param>
        /// <param name="duration">授权时长标识</param>
        /// <param name="payType">支付方式</param>
        /// <param name="price">收费价格（获取系统设置价格时无需传入）</param>
        /// <param name="reson">失败原因（未失败为null）</param>
        /// <param name="grade">版本ID（可通过获取版本列表接口获得，单版本无需传入，多版本必须传入）</param>
        /// <returns>结果对象</returns>
        public PayCode GetPayCode(string userkey, string duration, PayType payType, out string reson, int grade = 0, float price = 0)
        {
            api.getpaycode getpaycode = new api.getpaycode(userkey, duration, payType, grade, price);
            return getpaycode.Request(out reson);
        }
        /// <summary>
        /// 获取支付订单状态
        /// </summary>
        /// <param name="order">订单号</param>
        /// <param name="msg">返回消息</param>
        /// <param name="paytime">支付时间，未支付为null</param>
        /// <returns>是否已支付，已支付返回true</returns>
        public bool GetPayState(string order, out string msg, out string paytime)
        {
            api.getpaystate getpaystate = new getpaystate(order);
            return getpaystate.Request(out msg, out paytime);
        }
        #endregion

        #region 应用类接口
        /// <summary>
        /// 修改应用价格接口（无价格信息时将配置价格信息）
        /// </summary>
        /// <param name="duration">时长标识</param>
        /// <param name="grade">应用版本ID（单版本应用无需传入，多版本应用必须传入）</param>
        /// <param name="price">价格（系统未配置价格信息时必须传入，若系统内有配置时则可传入，也可不传入，有传入的以此价格为准，未传入的则获取系统配置的价格）</param>
        /// <param name="msg">返回信息</param>
        /// <returns>是否成功</returns>
        public bool UpdatePrice(string duration, float price, out string msg, int grade = 0)
        {
            api.updateprice updateprice = new api.updateprice(duration, grade, price);
            return updateprice.Request(out msg);
        }
        /// <summary>
        /// 获取应用版本列表
        /// </summary>
        /// <returns>应用版本列表信息，单版本应用返回null</returns>
        public List<AppGrade> GetGradeList()
        {
            api.getgradelist getgradelist = new api.getgradelist();
            return getgradelist.Request();
        }
        /// <summary>
        /// 获取应用价格（系统内的配置）
        /// </summary>
        /// <param name="duration">时长标识</param>
        /// <param name="grade">应用版本ID</param>
        /// <param name="msg">返回信息</param>
        /// <returns>价格数据信息(无信息时返回null)</returns>
        public AppPrice GetPrice(string duration, out string msg, int grade=0)
        {
            api.getprice getgradelist = new getprice(duration, grade);
            return getgradelist.Request(out msg);
        }
        #endregion

        #region 卡密类接口
        /// <summary>
        /// 添加卡密信息
        /// </summary>
        /// <param name="card">要添加的卡密列表（将自动去重）</param>
        /// <param name="duration">时长标识</param>
        /// <param name="grade">应用版本ID</param>
        /// <returns>添加是否成功</returns>
        public bool AddCard(List<string> card,string duration,out string resonseJson, int grade=0)
        {
            api.addcard addcard = new addcard(card,duration,grade);
            return addcard.Request(out resonseJson);
        }
        /// <summary>
        /// 使用卡密（卡密使用后即获得卡密对应的授权）
        /// </summary>
        /// <param name="card">卡密信息</param>
        /// <param name="userkey">用户识别码</param>
        /// <param name="msg">返回信息</param>
        /// <returns>是否使用成功</returns>
        public bool UseCard(string card,string userkey,out string msg)
        {
            api.usecard usecard = new usecard(card, userkey);
            return usecard.Request(out msg);
        }
        /// <summary>
        /// 删除卡密信息（直接删除，不论卡密是否已被使用）
        /// </summary>
        /// <param name="card">卡密</param>
        /// <param name="msg">返回的信息</param>
        /// <returns>是否删除成功</returns>
        public bool DelCard(List<string> card, out string msg)
        {
            api.delcard delcard = new delcard(card);
            return delcard.Request(out msg);
        }
        /// <summary>
        /// 获取卡密信息
        /// </summary>
        /// <param name="card">卡密</param>
        /// <param name="msg">返回的数据</param>
        /// <returns>卡密信息</returns>
        public CardInfo GetCardInfo(string card, out string msg)
        {
            api.getcardinfo getcard = new getcardinfo(card);
            return getcard.Request(out msg);
        }
        #endregion

        #region 用户数据类接口
        /// <summary>
        /// 获取账户余额
        /// </summary>
        /// <returns>账户余额信息</returns>
        public AmountInfo GetAmount()
        {
            api.getamount getcard = new getamount();
            return getcard.Request();
        }
        /// <summary>
        /// 获取系统账单
        /// </summary>
        /// <param name="limit">获取最近几条（最大20条，如需更多请到系统内查询）</param>
        /// <returns>账单列表</returns>
        public List<BillInfo> GetBill(int limit=20)
        {
            api.getbill getbill = new getbill(limit);
            return getbill.Request();
        }
        #endregion
    }
}
