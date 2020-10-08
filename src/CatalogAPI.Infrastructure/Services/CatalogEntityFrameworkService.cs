using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CatalogAPI.Domain.Interfaces;
using CatalogAPI.Domain.Models;

namespace CatalogAPI.Infrastructure.Services
{
    public class CatalogEntityFrameworkService : ICatalogService
    {
        private readonly CatalogContext catalogContext;

        public CatalogEntityFrameworkService(CatalogContext catalogContext)
        {
            this.catalogContext = catalogContext;
        }

        public async Task<CatalogItem> CreateItemAsync(CatalogItem item)
        {
            this.catalogContext.CatalogItems.Add(item);

            await this.catalogContext.SaveChangesAsync().ConfigureAwait(false);

            return item;
        }

        public Task DeleteItemById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<CatalogItem>> GetAllItemsAsync()
        {
            return Task.FromResult<IEnumerable<CatalogItem>>(this.catalogContext.CatalogItems);
        }

        public Task<CatalogItem> GetItemByIdAsync(int id)
        {
            var item = this.catalogContext.CatalogItems.Where(x => x.Id == id).FirstOrDefault();

            if (item == null)
            {
                throw new ArgumentException();
            }

            return Task.FromResult<CatalogItem>(item);
        }

        public Task<CatalogItem> UpdateItem(CatalogItem item)
        {
            throw new NotImplementedException();
        }
    }
}
