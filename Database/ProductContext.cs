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

        public ProductContext()
        {

        }

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
                entity.HasIndex(e => e.ProductNumber).IsUnique();
                
                entity.Property(e => e.Tag).IsRequired().HasMaxLength(128);
                entity.HasIndex(e => e.Tag).IsUnique();

                entity.Property(e => e.Addon1).HasMaxLength(128);
                entity.Property(e => e.Addon2).HasMaxLength(128);
                entity.Property(e => e.Addon3).HasMaxLength(128);
                entity.Property(e => e.Addon4).HasMaxLength(128);
            });
        }
    }
}
