namespace HolyGo.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Travel_Order
    {
        [Key]
        public Guid Guid { get; set; }

        [Required]
        [StringLength(128)]
        public string User_guid { get; set; }

        public Guid Combo_guid { get; set; }

        public DateTime Datetime { get; set; }

        [Required]
        [StringLength(3)]
        public string Status { get; set; }

        public virtual AspNetUsers AspNetUsers { get; set; }

        public virtual Travel_Combo Travel_Combo { get; set; }
    }
}
