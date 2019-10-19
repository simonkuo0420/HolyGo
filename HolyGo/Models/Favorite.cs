namespace HolyGo.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Favorite")]
    public partial class Favorite
    {
        [Key]
        public Guid Guid { get; set; }

        [Required]
        [StringLength(128)]
        public string User_guid { get; set; }

        public Guid Travel_guid { get; set; }

        public virtual AspNetUser AspNetUser { get; set; }

        public virtual Travel Travel { get; set; }
    }
}
