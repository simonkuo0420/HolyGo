namespace HolyGo.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Travel")]
    public partial class Travel
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Travel()
        {
            Favorite = new HashSet<Favorite>();
            Travel_Combo = new HashSet<Travel_Combo>();
        }

        [Key]
        public Guid Guid { get; set; }

        public Guid Guide_guid { get; set; }

        [Required]
        [StringLength(100)]
        public string Title { get; set; }

        [Required]
        public string Contents { get; set; }

        public int Time { get; set; }

        [Required]
        [StringLength(30)]
        public string Country { get; set; }

        [Required]
        [StringLength(30)]
        public string City { get; set; }

        [Required]
        public string Images { get; set; }

        [Required]
        [StringLength(3)]
        public string Status { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Favorite> Favorite { get; set; }

        public virtual Guide Guide { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Travel_Combo> Travel_Combo { get; set; }
    }
}
