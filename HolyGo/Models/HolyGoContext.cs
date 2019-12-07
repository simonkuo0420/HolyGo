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

        public virtual DbSet<AspNetRoles> AspNetRoles { get; set; }
        public virtual DbSet<AspNetUserClaims> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogins> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUsers> AspNetUsers { get; set; }
        public virtual DbSet<Favorite> Favorite { get; set; }
        public virtual DbSet<Guide> Guide { get; set; }
        public virtual DbSet<Ticket> Ticket { get; set; }
        public virtual DbSet<Ticket_Combo> Ticket_Combo { get; set; }
        public virtual DbSet<Ticket_Comment> Ticket_Comment { get; set; }
        public virtual DbSet<Ticket_Order> Ticket_Order { get; set; }
        public virtual DbSet<Travel> Travel { get; set; }
        public virtual DbSet<Travel_Combo> Travel_Combo { get; set; }
        public virtual DbSet<Travel_Comment> Travel_Comment { get; set; }
        public virtual DbSet<Travel_Order> Travel_Order { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AspNetRoles>()
                .HasMany(e => e.AspNetUsers)
                .WithMany(e => e.AspNetRoles)
                .Map(m => m.ToTable("AspNetUserRoles").MapLeftKey("RoleId").MapRightKey("UserId"));

            modelBuilder.Entity<AspNetUsers>()
                .HasMany(e => e.AspNetUserClaims)
                .WithRequired(e => e.AspNetUsers)
                .HasForeignKey(e => e.UserId);

            modelBuilder.Entity<AspNetUsers>()
                .HasMany(e => e.AspNetUserLogins)
                .WithRequired(e => e.AspNetUsers)
                .HasForeignKey(e => e.UserId);

            modelBuilder.Entity<AspNetUsers>()
                .HasMany(e => e.Favorite)
                .WithRequired(e => e.AspNetUsers)
                .HasForeignKey(e => e.User_guid)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<AspNetUsers>()
                .HasMany(e => e.Ticket_Order)
                .WithRequired(e => e.AspNetUsers)
                .HasForeignKey(e => e.User_guid)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<AspNetUsers>()
                .HasMany(e => e.Travel_Order)
                .WithRequired(e => e.AspNetUsers)
                .HasForeignKey(e => e.User_guid)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Guide>()
                .HasMany(e => e.Travel)
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
                .HasMany(e => e.Ticket_Order)
                .WithRequired(e => e.Ticket_Combo)
                .HasForeignKey(e => e.Combo_guid)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Travel>()
                .HasMany(e => e.Favorite)
                .WithRequired(e => e.Travel)
                .HasForeignKey(e => e.Travel_guid)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Travel>()
                .HasMany(e => e.Travel_Combo)
                .WithRequired(e => e.Travel)
                .HasForeignKey(e => e.Travel_guid)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Travel_Combo>()
                .HasMany(e => e.Travel_Comment)
                .WithRequired(e => e.Travel_Combo)
                .HasForeignKey(e => e.Combo_guid)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Travel_Combo>()
                .HasMany(e => e.Travel_Order)
                .WithRequired(e => e.Travel_Combo)
                .HasForeignKey(e => e.Combo_guid)
                .WillCascadeOnDelete(false);
        }
    }
}
