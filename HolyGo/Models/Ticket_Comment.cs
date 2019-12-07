namespace HolyGo.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Ticket_Comment
    {
        [Key]
        public Guid Guid { get; set; }

        public Guid Combo_guid { get; set; }

        [Required]
        [StringLength(100)]
        public string Title { get; set; }

        [Required]
        public string Contents { get; set; }

        public int StarCount { get; set; }

        public DateTime Datetime { get; set; }

        public virtual Ticket_Combo Ticket_Combo { get; set; }
    }
}
