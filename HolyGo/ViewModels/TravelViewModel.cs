using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HolyGo.ViewModels
{
    public class TravelViewModel
    {
        /// <summary>
        /// 行程編號
        /// </summary>
        public Guid Guid { get; set; }
        /// <summary>
        /// 行程標題
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// 行程內容
        /// </summary>
        public string Contents { get; set; }
        /// <summary>
        /// 行程時長
        /// </summary>
        public int Time { get; set; }
        /// <summary>
        /// 行程國家
        /// </summary>
        public string Country { get; set; }
        /// <summary>
        /// 行程城市
        /// </summary>
        public string City { get; set; }
        /// <summary>
        /// 行程圖片
        /// </summary>
        public string Images { get; set; }
        /// <summary>
        /// 行程說明
        /// </summary>
        public string Explain { get; set; }
    }
}