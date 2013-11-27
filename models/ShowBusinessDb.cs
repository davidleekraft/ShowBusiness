using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace UnhandledExceptionProject.Models
{
    public class ShowBusinessDb : DbContext
    {
        public ShowBusinessDb() : base ("name=DefaultConnection") {  }

        public DbSet<Garment> Garments { get; set; }
        public DbSet<Prop> Props { get; set; }
        public DbSet<Performer> Performers { get; set; }
        public DbSet<Production> Productions { get; set; }
        public DbSet<Alteration> Alterations { get; set; }
        public DbSet<Damage> Damages { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Costume> Costumes { get; set; }
        public DbSet<Material> Materials { get; set; }
        public DbSet<Pattern> Patterns { get; set; }
        public DbSet<Rental> Rentals { get; set; }
        public DbSet<Renter> Renters { get; set; }
        public DbSet<Size> Sizes { get; set; }
        public DbSet<User_status> User_Status { get; set; }
        public DbSet<Storage> Storage { get; set; }

        public DbSet<User> Users { get; set; }

    }
}