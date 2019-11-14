using EatingApp.Core.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace EatingApp.DAL
{
    public class FoodApiContext: DbContext
    {
        private const string connectionString = @"server=localhost; database=EatingAppDb; Integrated Security=true;";

        public DbSet<User> Users { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductType> ProductTypes { get; set; }
        
        public FoodApiContext(DbContextOptions options): base(options)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer(connectionString);            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>(entity =>
            {
                entity.HasOne(entity => entity.User)
                .WithMany(entity => entity.Orders)
                .HasForeignKey(entity => entity.UserId)
                .HasConstraintName("Order_User");

                entity.HasOne(entity => entity.Status)
                .WithMany(entity => entity.Orders)
                .HasForeignKey(entity => entity.StatusId)
                .HasConstraintName("Order_Status");

                entity.Property(entity => entity.Id).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<OrderItem>(entity =>
            {
                entity.HasOne(entity => entity.Order)
                .WithMany(entity => entity.Items)
                .HasForeignKey(entity => entity.OrderId)
                .HasConstraintName("OrderItem_Order");

                entity.HasOne(entity => entity.Product)
                .WithMany(entity => entity.Items)
                .HasForeignKey(entity => entity.ProductId)
                .HasConstraintName("OrderItem_Product");

                entity.Property(entity => entity.Id).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasOne(entity => entity.ProductType)
                .WithMany(entity => entity.Products)
                .HasForeignKey(entity => entity.ProductTypeId)
                .HasConstraintName("Product_ProductType");

                entity.Property(entity => entity.Id).ValueGeneratedOnAdd();
            });
            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(entity => entity.Id).ValueGeneratedOnAdd();
            });
            modelBuilder.Entity<ProductType>(entity =>
            {
                entity.Property(entity => entity.Id).ValueGeneratedOnAdd();
            });
        }
    }
}
