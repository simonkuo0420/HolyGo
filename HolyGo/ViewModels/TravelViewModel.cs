﻿using System;
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
        /// 行程時長
        /// </summary>
        public DateTime Time { get; set; }
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
        public string Explain { get; set; }
        /// <summary>
        /// 行程價錢
        /// </summary>
        public int Cost { get; set; }
    }
}