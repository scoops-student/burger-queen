using System.Collections.Generic;
using System.Threading.Tasks;
using System.Transactions;
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

        public Task<CatalogItem> DeleteItemById(CatalogItem item, int id)
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

        public Task<CatalogItem> UpdateItem(CatalogItem item, int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<CatalogType> CreateTypeAsync(CatalogType type)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<CatalogType>> GetAllTypeAsync()
        {
            throw new System.NotImplementedException();
        }

        public Task<CatalogType> GetTypeByIdAsync(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<CatalogType> UpdateType(CatalogType type, int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<CatalogType> DeleteTypeById(CatalogType type, int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<CatalogItem> UpdateItem(CatalogItem item)
        {
            throw new System.NotImplementedException();
        }

        public Task DeleteItemById(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<CatalogType> UpdateType(CatalogType type)
        {
            throw new System.NotImplementedException();
        }

        public Task DeleteTypeById(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<CatalogItem>> GetCatalogItemsByCatalogTypeId(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}