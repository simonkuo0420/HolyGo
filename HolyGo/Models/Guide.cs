namespace HolyGo.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Guide")]
    public partial class Guide
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Guide()
        {
            Travels = new HashSet<Travel>();
        }

        [Key]
        public Guid Guid { get; set; }

        [Required]
        [StringLength(256)]
        public string Email { get; set; }

        [Required]
        [StringLength(30)]
        public string Firstname { get; set; }

        [Required]
        [StringLength(30)]
        public string Lastname { get; set; }

        [Required]
        [StringLength(1)]
        public string Gender { get; set; }

        public DateTime? Birthday { get; set; }

        [Required]
        [StringLength(30)]
        public string Country { get; set; }

        [StringLength(30)]
        public string City { get; set; }

        [StringLength(15)]
        public string Phone { get; set; }

        public string Photo { get; set; }

        [Required]
        public string License { get; set; }

        [Required]
        [StringLength(3)]
        public string Status { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Travel> Travels { get; set; }
    }
}
