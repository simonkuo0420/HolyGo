using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HolyGo.ViewModels
{
    public class UserDataViewModel
    {
        public string Id { get; set; }

        [Required]
        [StringLength(30)]
        [Display(Name = "姓氏")]
        public string FirstName { get; set; }

        [Required]
        [StringLength(30)]
        [Display(Name = "名字")]
        public string LastName { get; set; }

        [Required]
        [StringLength(1)]
        [Display(Name = "性別")]
        public string Gender { get; set; }

        [Display(Name = "生日")]
        //[DisplayFormat(DataFormatString = "{0:YYYY-MM-DD}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime Birthday { get; set; }

        [Required]
        [StringLength(10)]
        [Display(Name = "國籍")]
        public string Country { get; set; }

        [Required]
        [StringLength(30)]
        [Display(Name = "城市")]
        public string City { get; set; }

        [Required]
        [StringLength(15)]
        [Display(Name = "電話")]
        public string Phone { get; set; }

        [StringLength(256)]
        [Display(Name = "電子信箱")]
        public string Email { get; set; }


    }
}