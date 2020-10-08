using CatalogAPI.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace CatalogAPI.Infrastructure
{
    public class CatalogContext : DbContext
    { 

        // Create tables for the database. Tables have the same name as the DbSet and they're plural
        public DbSet<CatalogItem> CatalogItems { get; set; }
        public DbSet<CatalogType> CatalogTypes { get; set; }

        //Set table names singular
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CatalogType>().ToTable("CatalogType");
            modelBuilder.Entity<CatalogItem>().ToTable("CatalogItem");
        }
    }
}
