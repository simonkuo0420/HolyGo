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
        /// 旅遊編號
        /// </summary>
        public Guid Guid { get; set; }
        /// <summary>
        /// 旅遊標題
        /// </summary>
        public string Title { get; set; }
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
}