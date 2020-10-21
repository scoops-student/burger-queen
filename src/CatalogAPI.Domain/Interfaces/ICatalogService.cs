using System.Collections.Generic;
using System.Threading.Tasks;
using CatalogAPI.Domain.Models;

namespace CatalogAPI.Domain.Interfaces
{
    public interface ICatalogService
    {
        Task<CatalogItem> CreateItemAsync(CatalogItem item);

        Task<IEnumerable<CatalogItem>> GetAllItemsAsync();

        Task<CatalogItem> GetItemByIdAsync(int id);

        Task<CatalogItem> UpdateItem(CatalogItem item, int id);

        Task<CatalogItem> DeleteItemById(CatalogItem item, int id);

        Task<CatalogType> CreateTypeAsync(CatalogType type);

        Task<IEnumerable<CatalogType>> GetAllTypeAsync();

        Task<CatalogType> GetTypeByIdAsync(int id);

        Task<CatalogType> UpdateType(CatalogType type, int id);

        Task<CatalogType> DeleteTypeById(CatalogType type, int id);
    }
}