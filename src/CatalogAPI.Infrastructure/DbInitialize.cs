﻿using System.Linq;
using CatalogAPI.Domain.Models;
using Microsoft.EntityFrameworkCore.Internal;

namespace CatalogAPI.Infrastructure
{
    public static class DbInitialize
    {
        public static void Initialize(CatalogContext context)
        {
            context.Database.EnsureCreated();

            if (context.CatalogTypes.Any())
            {
                return;
            }

            var catalogtypes = new CatalogType[]
            {
                new CatalogType { Type = "Portie frieten" },
                new CatalogType { Type = "Burgers" },
                new CatalogType { Type = "Menu's" },
                new CatalogType { Type = "Frisdrank" },
                new CatalogType { Type = "Dessert" },
            };
        }
    }
}
