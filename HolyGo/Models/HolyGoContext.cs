namespace HolyGo.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class HolyGoContext : DbContext
    {
        public HolyGoContext()
            : base("name=HolyGoContext")
        {
        }

        public virtual DbSet<AspNetRole> AspNetRoles { get; set; }
        public virtual DbSet<AspNetUserClaim> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogin> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUser> AspNetUsers { get; set; }
        public virtual DbSet<Favorite> Favorites { get; set; }
        public virtual DbSet<Guide> Guides { get; set; }
        public virtual DbSet<Ticket> Tickets { get; set; }
        public virtual DbSet<Ticket_Combo> Ticket_Combo { get; set; }
        public virtual DbSet<Ticket_Comment> Ticket_Comment { get; set; }
        public virtual DbSet<Ticket_Order> Ticket_Order { get; set; }
        public virtual DbSet<Travel> Travels { get; set; }
        public virtual DbSet<Travel_Combo> Travel_Combo { get; set; }
        public virtual DbSet<Travel_Comment> Travel_Comment { get; set; }
        public virtual DbSet<Travel_Order> Travel_Order { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AspNetRole>()
                .HasMany(e => e.AspNetUsers)
                .WithMany(e => e.AspNetRoles)
                .Map(m => m.ToTable("AspNetUserRoles").MapLeftKey("RoleId").MapRightKey("UserId"));

            modelBuilder.Entity<AspNetUser>()
                .HasMany(e => e.AspNetUserClaims)
                .WithRequired(e => e.AspNetUser)
                .HasForeignKey(e => e.UserId);

            modelBuilder.Entity<AspNetUser>()
                .HasMany(e => e.AspNetUserLogins)
                .WithRequired(e => e.AspNetUser)
                .HasForeignKey(e => e.UserId);

            modelBuilder.Entity<AspNetUser>()
                .HasMany(e => e.Favorites)
                .WithRequired(e => e.AspNetUser)
                .HasForeignKey(e => e.User_guid)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<AspNetUser>()
                .HasMany(e => e.Ticket_Order)
                .WithRequired(e => e.AspNetUser)
                .HasForeignKey(e => e.User_guid)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<AspNetUser>()
                .HasMany(e => e.Travel_Order)
                .WithRequired(e => e.AspNetUser)
                .HasForeignKey(e => e.User_guid)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Guide>()
                .HasMany(e => e.Travels)
                .WithRequired(e => e.Guide)
                .HasForeignKey(e => e.Guide_guid)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Ticket>()
                .HasMany(e => e.Ticket_Combo)
                .WithRequired(e => e.Ticket)
                .HasForeignKey(e => e.Ticket_guid)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Ticket_Combo>()
                .HasMany(e => e.Ticket_Comment)
                .WithRequired(e => e.Ticket_Combo)
                .HasForeignKey(e => e.Combo_guid)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Ticket_Combo>()
                .HasMany(e => e.Travel_Order)
                .WithRequired(e => e.Ticket_Combo)
                .HasForeignKey(e => e.Combo_guid)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Travel>()
                .HasMany(e => e.Favorites)
                .WithRequired(e => e.Travel)
                .HasForeignKey(e => e.Travel_guid)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Travel>()
                .HasMany(e => e.Travel_Combo)
                .WithRequired(e => e.Travel)
                .HasForeignKey(e => e.Travel_guid)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Travel_Combo>()
                .HasMany(e => e.Ticket_Order)
                .WithRequired(e => e.Travel_Combo)
                .HasForeignKey(e => e.Combo_guid)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Travel_Combo>()
                .HasMany(e => e.Travel_Comment)
                .WithRequired(e => e.Travel_Combo)
                .HasForeignKey(e => e.Combo_guid)
                .WillCascadeOnDelete(false);
        }
    }
}
