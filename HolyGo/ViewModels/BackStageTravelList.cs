using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HolyGo.ViewModels
{
    public class BackStageTravelList
    {
        [Key]
        public Guid Guid { get; set; }

        [Required]
        [StringLength(100)]
        public string Title { get; set; }

        public int Time { get; set; }

        [Required]
        [StringLength(30)]
        public string Country { get; set; }

        [Required]
        [StringLength(30)]
        public string City { get; set; }

        public int Count { get; set; }
    }
}