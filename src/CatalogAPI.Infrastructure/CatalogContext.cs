using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CatalogAPI.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace CatalogAPI.Infrastructure
{
    public class CatalogContext : DbContext
    {
        public CatalogContext(DbContextOptions<CatalogContext> options)
            : base(options)
        {
        }

        // Create tables for the database. Tables have the same name as the DbSet and they're plural
        public DbSet<CatalogItem> CatalogItems { get; set; }

        public DbSet<CatalogType> CatalogTypes { get; set; }

        // Set table names singular
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CatalogType>().ToTable("CatalogType");
            modelBuilder.Entity<CatalogItem>().ToTable("CatalogItem");

            modelBuilder.Entity<CatalogType>().Property(c => c.Id);
            modelBuilder.Entity<CatalogType>().Property(c => c.Type).IsRequired();
            //modelBuilder.Entity<CatalogType>().Property(c => c.CatalogItem);

            modelBuilder.Entity<CatalogItem>().Property(c => c.Id);
            modelBuilder.Entity<CatalogItem>().Property(c => c.Name).IsRequired();
            modelBuilder.Entity<CatalogItem>().Property(c => c.Description);
            modelBuilder.Entity<CatalogItem>().Property(c => c.Price);
            modelBuilder.Entity<CatalogItem>().Property(c => c.PictureUri);
            modelBuilder.Entity<CatalogItem>().Property(c => c.CatalogTypeId);
        }
    }
}
