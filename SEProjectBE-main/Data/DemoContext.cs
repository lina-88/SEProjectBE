using SEProjectBE.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SEProjectBE.Data
{
    public partial class DemoContext : DbContext
    {
        public DbSet<CartItem> CartItems { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Users> Users { get; set; }


        public DemoContext()
        {
             
        }
        public DemoContext(DbContextOptions<DemoContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CartItem>(entity =>
            {
                entity.ToTable("CartItems");

                entity.HasKey(e => e.Id);

            




            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.ToTable("Users");
                entity.HasKey(e => e.Id);

                entity.HasMany(e => e.Products)
                .WithOne(e => e.User)
                .HasForeignKey(e => e.UserId);




            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("Products");

                entity.HasKey(e => e.Id);

                entity.HasMany(e => e.Users)
              .WithOne(e => e.Product)
              .HasForeignKey(e => e.ProductId);



            });

           


            OnModelCreatingPartial(modelBuilder);
        }
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

      
       
        


    }
}
