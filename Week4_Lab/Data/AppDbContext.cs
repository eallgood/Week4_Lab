using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Week4_Lab.Data.Entities;

namespace Week4_Lab.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext()
        {
            this.Configuration.LazyLoadingEnabled = false;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer(new AppDbInitializer());
        }

        public virtual DbSet<Pet> Pets { get; set; }
        public virtual DbSet<User> Users { get; set; }

        public class AppDbInitializer : DropCreateDatabaseIfModelChanges<AppDbContext>
        {

        }
    }
}