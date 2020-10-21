using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CatalogAPI.Domain.Interfaces;
using CatalogAPI.Domain.Models;
using Microsoft.EntityFrameworkCore;

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

        public async Task<CatalogItem> DeleteItemById(CatalogItem item, int id)
        {
            var deleteItem = await this.catalogContext.CatalogItems.FirstOrDefaultAsync(di => di.Id == id);
            if (deleteItem != null)
            {
                this.catalogContext.CatalogItems.Remove(deleteItem);
                await this.catalogContext.SaveChangesAsync();
                return deleteItem;
            }

            return null;
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

        public async Task<CatalogItem> UpdateItem(CatalogItem item, int id)
        {
            var updateItem = await this.catalogContext.CatalogItems.FirstOrDefaultAsync(ui => ui.Id == item.Id);
            if (updateItem != null)
            {
                updateItem.Name = item.Name;
                updateItem.Description = item.Description;
                updateItem.Price = item.Price;
                updateItem.PictureUri = item.PictureUri;
                updateItem.CatalogTypeId = item.CatalogTypeId;
                updateItem.CatalogType = item.CatalogType;
                await this.catalogContext.SaveChangesAsync();
                return updateItem;
            }

            return null;
        }

        public async Task<CatalogType> CreateTypeAsync(CatalogType type)
        {
            this.catalogContext.CatalogTypes.Add(type);
            await this.catalogContext.SaveChangesAsync().ConfigureAwait(false);
            return type;
        }

        public Task<IEnumerable<CatalogType>> GetAllTypeAsync()
        {
            return Task.FromResult<IEnumerable<CatalogType>>(this.catalogContext.CatalogTypes);
        }

        public Task<CatalogType> GetTypeByIdAsync(int id)
        {
            var type = this.catalogContext.CatalogTypes.Where(x => x.Id == id).FirstOrDefault();
            if (type == null)
            {
                throw new ArgumentException();
            }

            return Task.FromResult<CatalogType>(type);
        }

        public async Task<CatalogType> UpdateType(CatalogType type, int id)
        {
            var updateType = await this.catalogContext.CatalogTypes.FirstOrDefaultAsync(ut => ut.Id == type.Id);
            if (updateType != null)
            {
                updateType.Id = type.Id;
                updateType.Type = type.Type;

                await this.catalogContext.SaveChangesAsync();
                return updateType;
            }

            return null;
        }

        public async Task<CatalogType> DeleteTypeById(CatalogType type, int id)
        {
            var deleteType = await this.catalogContext.CatalogTypes.FirstOrDefaultAsync(dt => dt.Id == id);
            if (deleteType != null)
            {
                this.catalogContext.CatalogTypes.Remove(deleteType);
                await this.catalogContext.SaveChangesAsync();
                return deleteType;
            }

            return null;
        }
    }
}
