using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBoxs.Auth.SDK.result
{
    /// <summary>
    /// 应用版本信息
    /// </summary>
    public class AppGrade
    {
        /// <summary>
        /// 应用版本ID
        /// </summary>
        public int grade { get; private set; }
        /// <summary>
        /// 应用版本名称
        /// </summary>
        public string name { get; private set; }
        /// <summary>
        /// 应用版本说明
        /// </summary>
        public string remarks { get; private set; }

        public AppGrade(int grade,string name,string remarks)
        {
            this.grade = grade;
            this.name = name;
            this.remarks = remarks;
        }
    }
}
