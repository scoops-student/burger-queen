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

        Task<CatalogItem> UpdateItem(CatalogItem item);

        Task DeleteItemById(int id);
    }
}