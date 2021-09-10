using IBoxs.Auth.SDK.api.JsonResponse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBoxs.Auth.SDK.result
{
   public class AppPrice
    {
        /// <summary>
        /// 价格信息
        /// </summary>
        public float price { get;private set; }
        /// <summary>
        /// aid
        /// </summary>
        public int aid { get; private set; }
        /// <summary>
        /// 时长参数
        /// </summary>
        public string duration { get; private set; }
        /// <summary>
        /// 时长参数中文
        /// </summary>
        public string duration_name { get; private set; }
        /// <summary>
        /// 应用版本ID
        /// </summary>
        public int grade { get; private set; }
        /// <summary>
        /// 应用版本名称
        /// </summary>
        public string grade_name { get; private set; }
        /// <summary>
        /// 应用版本说明
        /// </summary>
        public string grade_remarks { get; private set; }

        public AppPrice(GetPriceJson.Root rt)
        {
            this.aid = rt.data.aid;
            this.duration = rt.data.time;
            this.duration_name = rt.data.timename;
            this.grade =Convert.ToInt32( rt.data.grade);
            this.grade_name = rt.data.grade_name;
            this.grade_remarks = rt.data.grade_remarks;
            this.price = rt.data.price;    
        }
    }
}
