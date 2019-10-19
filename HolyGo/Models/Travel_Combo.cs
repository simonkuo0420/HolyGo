namespace HolyGo.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Travel_Combo
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Travel_Combo()
        {
            Ticket_Order = new HashSet<Ticket_Order>();
            Travel_Comment = new HashSet<Travel_Comment>();
        }

        [Key]
        public Guid Guid { get; set; }

        public Guid Travel_guid { get; set; }

        [Required]
        [StringLength(100)]
        public string Title { get; set; }

        [Required]
        public string Contents { get; set; }

        public int Cost { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Ticket_Order> Ticket_Order { get; set; }

        public virtual Travel Travel { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Travel_Comment> Travel_Comment { get; set; }
    }
}
