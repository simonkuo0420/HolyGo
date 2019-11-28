using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HolyGo.ViewModels
{
    public class TopTicketViewModel
    {
        /// <summary>
        /// 旅遊編號
        /// </summary>
        public Guid Guid { get; set; }
        /// <summary>
        /// 票券標題
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// 票券時長
        /// </summary>
        public int Time { get; set; }
        /// <summary>
        /// 票券國家
        /// </summary>
        public string Country { get; set; }
        /// <summary>
        /// 票券城市
        /// </summary>
        public string City { get; set; }
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