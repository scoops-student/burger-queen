using System.Collections.Generic;
using System.Threading.Tasks;
using CatalogAPI.Domain.Interfaces;
using CatalogAPI.Domain.Models;

namespace CatalogAPI.Infrastructure.Services
{
    public class CatalogXmlService : ICatalogService
    {
        public Task<CatalogItem> CreateItemAsync(CatalogItem item)
        {
            throw new System.NotImplementedException();
        }

        public Task DeleteItemById(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<CatalogItem>> GetAllItemsAsync()
        {
            throw new System.NotImplementedException();
        }

        public Task<CatalogItem> GetItemByIdAsync(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<CatalogItem> UpdateItem(CatalogItem item)
        {
            throw new System.NotImplementedException();
        }
    }
}
