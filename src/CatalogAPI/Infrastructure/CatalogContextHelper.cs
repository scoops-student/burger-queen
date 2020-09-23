using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CatalogAPI.Model;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Logging;

namespace CatalogAPI.Infrastructure
{
    public class CatalogContextHelper
    {
        public async Task SeedFromFilesAsync(CatalogContext context, IWebHostEnvironment env, ILogger<CatalogContextHelper> logger)
        {
            var contentRootPath = env.ContentRootPath;
        }

        private IEnumerable<CatalogType> GetCatalogTypesFromFile(string contentRootPath, ILogger<CatalogContextHelper> logger)
        {
            throw new NotImplementedException();
        }

        private IEnumerable<CatalogItem> GetCatalogItemsFromFile(string contentRootPath, ILogger<CatalogContextHelper> logger)
        {
            throw new NotImplementedException();
        }
    }
}
