using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HolyGo.ViewModels
{
    public class MemberViewModel
    {
        [Display(Name = "姓氏")]
        public string FirstName { get; set; }
        [Display(Name = "名字")]
        public string LastName { get; set; }
        [Display(Name = "性別")]
        public string Gender { get; set; }
        [Display(Name = "生日")]
        public DateTime Birthday { get; set; }
        [Display(Name = "國家")]
        public string Country { get; set; }
        [Display(Name = "地區")]
        public string City { get; set; }
        [Display(Name = "電話")]
        public string Phone { get; set; }
        [Display(Name = "電子信箱")]
        public string Email { get; set; }
        [Display(Name = "信箱驗證")]
        public bool EmailConfirmed { get; set; }
    }
}