using Database.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Database
{
    public class ProductContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<User> Users { get; set; }

        public ProductContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Filename=Database.db", options =>
            {
                options.MigrationsAssembly(Assembly.GetExecutingAssembly().FullName);
            });
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>(entity =>
            {
                entity.Property(e => e.ProductId).ValueGeneratedOnAdd();
                entity.HasKey(e => e.ProductId);

                entity.Property(e => e.ProductName).IsRequired().HasMaxLength(128);
                entity.Property(e => e.ProductNumber).IsRequired();
                entity.Property(e => e.Addon1).IsRequired().HasMaxLength(128);
                entity.Property(e => e.Addon2).IsRequired().HasMaxLength(128);
                entity.Property(e => e.Addon3).IsRequired().HasMaxLength(128);
                entity.Property(e => e.Addon4).IsRequired().HasMaxLength(128);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.UserId).ValueGeneratedOnAdd();
                entity.HasKey(e => e.UserId);

                entity.Property(e => e.Login).IsRequired().HasMaxLength(32);
                entity.Property(e => e.IsAdmin).IsRequired();
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}
