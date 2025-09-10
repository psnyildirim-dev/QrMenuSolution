using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using QrMenu.Domain.Entities;

namespace QrMenu.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Category> Categories { get; set; }
        public DbSet<MenuItem> MenuItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().ToTable("categories");
            modelBuilder.Entity<Category>().Property(c => c.Id).HasColumnName("id");
            modelBuilder.Entity<Category>().Property(c => c.Name).HasColumnName("name");

            modelBuilder.Entity<MenuItem>().ToTable("menu_items");



            modelBuilder.Entity<MenuItem>().Property(m => m.Id).HasColumnName("id");
            modelBuilder.Entity<MenuItem>().Property(m => m.Name).HasColumnName("name");
            modelBuilder.Entity<MenuItem>().Property(m => m.Price).HasColumnName("price");
            modelBuilder.Entity<MenuItem>().Property(m => m.ImageUrl).HasColumnName("image_url");
            modelBuilder.Entity<MenuItem>().Property(m => m.CategoryId).HasColumnName("category_id");

            modelBuilder.Entity<MenuItem>()
                .HasOne(m => m.Category)
                .WithMany(c => c.MenuItems)
                .HasForeignKey(m => m.CategoryId);

            base.OnModelCreating(modelBuilder);
        }
    }
}
