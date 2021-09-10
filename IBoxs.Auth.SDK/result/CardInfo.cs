using IBoxs.Auth.SDK.dataEnum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBoxs.Auth.SDK.result
{
   public class CardInfo
    {
        /// <summary>
        /// 
        /// </summary>
        public string AppID { get;private set; }
        public int Grade { get; private set; }
        public string Grade_Name { get; private set; }
        public CardStatus State { get; private set; }

        public DateTime Create_time { get; private set; }
        
            public string userkey { get; set; }

            public string useTime { get; set; }
        

        public CardInfo(api.JsonResponse.GetCardJson.Root rt)
        {
            this.AppID = rt.data.app;
            this.Grade = rt.data.grade;
            this.Grade_Name = rt.data.grade_name;
            this.State = (CardStatus)rt.data.state;
            this.Create_time = Convert.ToDateTime(rt.data.create_time);
            this.userkey = rt.data.use_user.user_key;
            this.useTime = rt.data.use_user.use_time;
        }
    }
}
