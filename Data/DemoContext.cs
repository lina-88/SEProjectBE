﻿using SEProjectBE.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SEProjectBE.Data
{
    public partial class DemoContext : DbContext
    {
        public DbSet<ShoppingCart> ShoppingCarts { get; set; }
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
            modelBuilder.Entity<ShoppingCart>(entity =>
            {
                entity.ToTable("ShoppingCarts");

                entity.HasKey(e => e.Id);

                entity.HasMany(e => e.Products)
                .WithOne(e => e.ShoppingCart)
                .HasForeignKey(e => e.ShoppingCartId);
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.ToTable("Users");
                entity.HasKey(e => e.Id);
                /*
                entity.HasOne(e => e.ShoppingCart)
                      .WithOne(e => e.Users)
                      .HasForeignKey(e => e.Id);
                */
            });


            OnModelCreatingPartial(modelBuilder);
        }
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

      
       
        


    }
}
