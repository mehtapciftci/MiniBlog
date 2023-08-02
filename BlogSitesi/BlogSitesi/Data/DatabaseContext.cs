﻿using BlogSitesi.Entities;
using Microsoft.EntityFrameworkCore;

namespace BlogSitesi.Data
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Contact> Contacts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category
                {
                    Id = 1,
                    Name = "Genel",
                    IsActive = true
                });
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = 1,
                    IsActive = true,
                    IsAdmin = true,
                    Name = "Admin",
                    Surname = "User",
                    Email = "admin@blogger.com",
                    Password = "123",
                    UserName = "Admin"
                });
            base.OnModelCreating(modelBuilder);
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=Mehtapspc;database=BlogSitesi;integrated security=true; TrustServerCertificate=True");
            base.OnConfiguring(optionsBuilder);
        }
    }
}
