﻿using AspNetCoreMVCProjesi.Entities;
using Microsoft.EntityFrameworkCore;

namespace AspNetCoreMVCProjesi.Data
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }
        public DbSet<User> Users { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Slider> Sliders { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = 1,
                    IsActive = true,
                    IsAdmin = true,
                    UserName = "Admin",
                    Password = "123",
                    Email = "admin@admin.com",
                    Name = "Admin",
                    Surname = "User"
                });
            modelBuilder.Entity<Category>().HasData(
                new Category
                {
                    Id = 1,
                    Name = "Elektronik",
                    IsActive = true
                },
                new Category
                {
                    Id = 2,
                    Name = "Bilgisayar",
                    IsActive = true
                }
                );
            modelBuilder.Entity<Brand>().HasData(
                new Brand
                {
                    Id = 1,
                    Name = "Samsung"
                },
                new Brand
                {
                    Id = 2,
                    Name = "Monster"
                }
                );
            modelBuilder.Entity<Product>().HasData(
                        new Product { Id = 1, CategoryId = 1, BrandId = 1, Name = "Monitör", Price = 1984, Stock = 3 },
                        new Product { Id = 2, CategoryId = 1, BrandId = 1, Name = "Led TV", Price = 5500, Stock = 5 },
                        new Product { Id = 3, CategoryId = 1, BrandId = 1, Name = "LCD TV", Price = 3500, Stock = 7 },
                        new Product { Id = 4, CategoryId = 2, BrandId = 2, Name = "Oyuncu PC", Price = 18000, Stock = 3 },
                        new Product { Id = 5, CategoryId = 2, BrandId = 2, Name = "Laptop", Price = 13000, Stock = 5 },
                        new Product { Id = 6, CategoryId = 2, BrandId = 2, Name = "Dizüstü", Price = 23500, Stock = 7 }
                );
            base.OnModelCreating(modelBuilder);
        }
    }
}