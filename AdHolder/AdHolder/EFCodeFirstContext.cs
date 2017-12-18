using AdHolder.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace AdHolder
{
    public class EFCodeFirstContext : DbContext
    {
        public EFCodeFirstContext()
            : base("name=DBConnectionString")
        {
        }

        public DbSet<Register> Register { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<City> City { get; set; }
        public DbSet<Area> Area { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //Configure domain classes using Fluent API here

            Database.SetInitializer<DbContext>(new DropCreateDatabaseIfModelChanges<DbContext>());
            base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Entity<Register>().ToTable("Register");
            modelBuilder.Entity<Product>().ToTable("Product");
            modelBuilder.Entity<City>().ToTable("City");
            modelBuilder.Entity<Area>().ToTable("Area");
        }

    }
}