using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HolyGo.ViewModels
{
    public class UsersOrderViewModel
    {
        /// <summary>
        /// 訂單使用者ID
        /// </summary>
        [Display(Name = "Userid")]
        public string User_guid { get; set; }
        /// <summary>
        /// 訂單下單時間
        /// </summary>
        [Display(Name = "下單時間")]
        [DisplayFormat(DataFormatString = "{0:YYYY/MM/DD}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public string DateTime { get; set; }
        /// <summary>
        /// 訂單標題
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// 訂單內容
        /// </summary>
        public string Contents { get; set; }
        /// <summary>
        /// 訂單圖片
        /// </summary>
        public string Images { get; set; }
        /// <summary>
        /// 訂單行程時間
        /// </summary>
        [Display(Name = "行程時間")]
        public string Time { get; set; }
        /// <summary>
        /// 訂單國家
        /// </summary>
        [Display(Name = "國家")]
        public string Country { get; set; }
        /// <summary>
        /// 訂單價錢
        /// </summary>
        public string Cost { get; set; }
    }
}