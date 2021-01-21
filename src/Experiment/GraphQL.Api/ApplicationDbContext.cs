﻿using GraphQL.Api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace GraphQL.Api
{
    public class ApplicationDbContext : DbContext
    {
        public static readonly ILoggerFactory MyLoggerFactory =
            LoggerFactory.Create(builder => { builder.AddConsole(); });

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Item> Items { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseLoggerFactory(MyLoggerFactory);

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Item>().ToTable("Items");
            modelBuilder.Entity<Item>().HasKey(p => p.Barcode);

            modelBuilder.Entity<Item>().HasData(new Item
            {
                Barcode = "123",
                Title = "Headphone",
                SellingPrice = 50
            });

            modelBuilder.Entity<Item>().HasData(new Item
            {
                Barcode = "456",
                Title = "Keyboard",
                SellingPrice = 40
            });
            modelBuilder.Entity<Item>().HasData(new Item
            {
                Barcode = "789",
                Title = "Monitor",
                SellingPrice = 100
            });

            modelBuilder.Entity<Customer>().HasKey(p => p.CustomerId);
            modelBuilder.Entity<Customer>().HasMany(p => p.Orders)
                .WithOne()
                .HasForeignKey(p => p.CustomerId);

            modelBuilder.Entity<Order>().HasKey(p => p.OrderId);

            base.OnModelCreating(modelBuilder);
        }
    }
}
