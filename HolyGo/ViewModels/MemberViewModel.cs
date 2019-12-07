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
        [Required]
        [Display(Name = "姓氏")]
        public string FirstName { get; set; }
        [Required]
        [Display(Name = "名字")]
        public string LastName { get; set; }
        [Required]
        [Display(Name = "性別")]
        public string Gender { get; set; }
        [Required]
        [Display(Name = "生日")]
        [DataType(DataType.Date)]
        public DateTime Birthday { get; set; }
        [Required]
        [Display(Name = "國家")]
        public string Country { get; set; }
        [Required]
        [Display(Name = "電話")]
        public string Phone { get; set; }
        [Required]
        [Display(Name = "電子信箱")]
        public string Email { get; set; }
    }
}