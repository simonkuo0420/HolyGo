namespace HolyGo.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Ticket_Order
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

        public virtual AspNetUser AspNetUser { get; set; }

        public virtual Travel_Combo Travel_Combo { get; set; }
    }
}
