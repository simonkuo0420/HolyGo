using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HolyGo.ViewModels
{
    public class MemberViewModel : Controller
    {
        [Required]
        [StringLength(30)]
        [Display(Name = "姓氏")]
        public string FirstName { get; set; }

        [Required]
        [StringLength(30)]
        public string LastName { get; set; }

        [Required]
        [StringLength(1)]
        public string Gender { get; set; }

        public DateTime Birthday { get; set; }

        [Required]
        [StringLength(10)]
        public string Country { get; set; }

        [Required]
        [StringLength(30)]
        public string City { get; set; }

        [Required]
        [StringLength(15)]
        public string Phone { get; set; }

        public bool Status { get; set; }

        [StringLength(256)]
        public string Email { get; set; }

        public bool EmailConfirmed { get; set; }
        [Required]
        [StringLength(256)]
        public string UserName { get; set; }
    }
}