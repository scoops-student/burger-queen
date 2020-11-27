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

            await this.catalogContext.SaveChangesAsync();

            return item;
        }

        public async Task DeleteItemById(int id)
        {
            var deleteItem = await this.catalogContext.CatalogItems.FirstOrDefaultAsync(di => di.Id == id);

            if (deleteItem == null)
            {
                throw new ArgumentException();
            }

            this.catalogContext.CatalogItems.Remove(deleteItem);
            await this.catalogContext.SaveChangesAsync();

            return;
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

        public async Task<CatalogItem> UpdateItem(CatalogItem item)
        {
            var updateItem = await this.catalogContext.CatalogItems.FirstOrDefaultAsync(ui => ui.Id == item.Id);

            if (updateItem == null)
            {
                throw new ArgumentException();
            }

            updateItem.Name = item.Name;
            updateItem.Description = item.Description;
            updateItem.Price = item.Price;
            updateItem.PictureUri = item.PictureUri;
            updateItem.CatalogTypeId = item.CatalogTypeId;

            this.catalogContext.CatalogItems.Update(updateItem);
            await this.catalogContext.SaveChangesAsync();
            return updateItem;
        }

        public async Task<CatalogType> CreateTypeAsync(CatalogType type)
        {
            this.catalogContext.CatalogTypes.Add(type);
            await this.catalogContext.SaveChangesAsync();
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

        public async Task<CatalogType> UpdateType(CatalogType type)
        {
            var updateType = await this.catalogContext.CatalogTypes.FirstOrDefaultAsync(ut => ut.Id == type.Id);
            if ( updateType == null)
            {
                throw new ArgumentException();
            }

            updateType.Id = type.Id;
            updateType.Type = type.Type;

            this.catalogContext.CatalogTypes.Update(updateType);
            await this.catalogContext.SaveChangesAsync();
            return type;
        }

        public async Task DeleteTypeById(int id)
        {
            var deleteType = await this.catalogContext.CatalogTypes.FirstOrDefaultAsync(dt => dt.Id == id);

            if (deleteType == null)
            {
                throw new ArgumentException();
            }

            this.catalogContext.CatalogTypes.Remove(deleteType);
            await this.catalogContext.SaveChangesAsync();

            return;
        }

        public async Task<IEnumerable<CatalogItem>> GetCatalogItemsByCatalogTypeId(int id)
        {
            var catalogType = this.catalogContext.CatalogTypes.Where(x => x.Id == id).FirstOrDefault();
            if (catalogType == null)
            {
                throw new ArgumentException();
            }

            var items = await this.catalogContext.CatalogItems.Where(x => x.CatalogTypeId == catalogType.Id).ToListAsync();

            return items;
        }
    }
}
