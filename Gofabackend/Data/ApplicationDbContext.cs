using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Gofabackend.Models;
using System;
using System.Reflection.Emit;

namespace Gofabackend.Data
{
    public class ApplicationDbContext : IdentityDbContext<User, Role, string>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Warehouse> Warehouses { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Shelf> Shelf { get; set; }
        public DbSet<ItemType> ItemType { get; set; }
        public DbSet<Model1> Model1 { get; set; }
        public DbSet<Shelf> Shelves { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // Seed predefined roles
            builder.Entity<Role>().HasData(
                new Role { Id = Guid.NewGuid().ToString(), Name = "VHF", NormalizedName = "VHF" },
                new Role { Id = Guid.NewGuid().ToString(), Name = "HF", NormalizedName = "HF" },
                new Role { Id = Guid.NewGuid().ToString(), Name = "Transit", NormalizedName = "TRANSIT" },
                new Role { Id = Guid.NewGuid().ToString(), Name = "Sparepart", NormalizedName = "SPAREPART" },
                new Role { Id = Guid.NewGuid().ToString(), Name = "Electronics", NormalizedName = "ELECTRONICS" },
                new Role { Id = Guid.NewGuid().ToString(), Name = "Manager", NormalizedName = "MANAGER" }
            );

    
            
    }
}}