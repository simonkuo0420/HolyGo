using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HolyGo.ViewModels
{
    /// <summary>
    /// 旅遊資料
    /// </summary>
    public partial class TopTravelViewModel
    {
        /// <summary>
        /// 旅遊標題
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// 旅遊內容
        /// </summary>
        public string Contents { get; set; }
        /// <summary>
        /// 旅遊時長
        /// </summary>
        public int Time { get; set; }
        /// <summary>
        /// 旅遊國家
        /// </summary>
        public string Country { get; set; }
        /// <summary>
        /// 旅遊城市
        /// </summary>
        public string City { get; set; }
        /// <summary>
        /// 旅遊圖片
        /// </summary>
        public string Images { get; set; }
        /// <summary>
        /// 旅遊價錢
        /// </summary>
        public int Cost { get; set; }
    }

    /// <summary>
    /// 票券資料
    /// </summary>
    public class TopTicketViewModel
    {
        /// <summary>
        /// 票券標題
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// 票券內容
        /// </summary>
        public string Contents { get; set; }
        /// <summary>
        /// 票券國家
        /// </summary>
        public string Country { get; set; }
        /// <summary>
        /// 票券圖片
        /// </summary>
        public string Images { get; set; }
        /// <summary>
        /// 票券價錢
        /// </summary>
        public int Cost { get; set; }
    }
}