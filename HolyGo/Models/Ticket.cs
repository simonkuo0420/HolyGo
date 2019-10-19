namespace HolyGo.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Ticket")]
    public partial class Ticket
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Ticket()
        {
            Ticket_Combo = new HashSet<Ticket_Combo>();
        }

        [Key]
        public Guid Guid { get; set; }

        [Required]
        [StringLength(100)]
        public string Title { get; set; }

        [Required]
        public string Contents { get; set; }

        public DateTime Time { get; set; }

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

        public int Favorite { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Ticket_Combo> Ticket_Combo { get; set; }
    }
}
