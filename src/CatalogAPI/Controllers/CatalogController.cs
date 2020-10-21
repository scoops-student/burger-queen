using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Reflection.Metadata;
using System.Threading.Tasks;
using CatalogAPI.Domain.Interfaces;
using CatalogAPI.Domain.Models;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.VisualBasic;

namespace CatalogAPI.Controllers
{
    [Produces("application/json")]
    [ApiController]
    [Route("[controller]")]
    public class CatalogController : ControllerBase
    {
        private readonly ILogger<CatalogController> logger;
        private readonly ICatalogService catalogService;

        public CatalogController(ILogger<CatalogController> logger, ICatalogService catalogService)
        {
            this.logger = logger;
            this.catalogService = catalogService;
        }

        /// <summary>
        /// Create a new CatalogItem.
        /// </summary>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<CatalogItem>> CreateCatalogItem(CatalogItem item)
        {
            try
            {
                if (item == null)
                {
                    // this.logger.LogError("Item object sent from client is null");
                    return this.BadRequest("item object is null");
                }

                if (this.ModelState.IsValid == false)
                {
                    // this.logger.LogError("Invalid item object sent from client");
                    return this.BadRequest("Invalid model object");
                }

                var newItem = await this.catalogService.CreateItemAsync(item).ConfigureAwait(false);

                return this.CreatedAtAction("GetCatalogItemById", newItem.Id, newItem);
            }
            catch (ArgumentException)
            {
                return this.BadRequest();
            }
        }

        /// <summary>
        /// Retrieve all CatalogItems.
        /// </summary>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<CatalogItem>>> GetAllCatalogItems()
        {
            return this.Ok(await this.catalogService.GetAllItemsAsync().ConfigureAwait(false));
        }

        /// <summary>
        /// Retrieve 1 CatalogItem by its id.
        /// </summary>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<CatalogItem>> GetCatalogItemById(int id)
        {
            try
            {
                var getItem = await this.catalogService.GetItemByIdAsync(id).ConfigureAwait(false);
                if (getItem == null)
                {
                    // this.logger.LogError("");
                    return this.BadRequest();
                }

                return this.Ok(getItem);
            }
            catch (ArgumentException)
            {
                return this.BadRequest();
            }
        }

        /// <summary>
        /// Update a CatalogItem.
        /// </summary>
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status202Accepted)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<CatalogItem>> UpdateCatalogItem(CatalogItem item, int id)
        {
            try
            {
                if (id != item.Id)
                {
                    return this.BadRequest();
                }

                var updateItem = await this.catalogService.UpdateItem(item, id).ConfigureAwait(false);
                item = updateItem;
                if (updateItem == null)
                {
                    return this.BadRequest();
                }

                return this.Ok(item);
            }
            catch (ArgumentException)
            {
                return this.BadRequest();
            }
        }

        /// <summary>
        /// Delete 1 CatalogItem by its id.
        /// </summary>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<CatalogItem>> DeleteCatalogItemById(CatalogItem item, int id)
        {
            try
            {
                var deleteItem = await this.catalogService.DeleteItemById(item, id).ConfigureAwait(false);
                if (deleteItem == null)
                {
                    // this.logger.LogError($"item whit id {id}, hasn't been found in the database");
                    return this.BadRequest();
                }

                return this.Ok(deleteItem);
            }
            catch (ArgumentException)
            {
                return this.BadRequest();
            }
        }

        /// <summary>
        /// Create a new CatalogType.
        /// </summary>
        [HttpPost("type")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<CatalogType>> CreateCatalogType(CatalogType type)
        {
            try
            {
                if (type == null)
                {
                    // this.logger.LogError("Type object sent from client is null");
                    return this.BadRequest();
                }

                if (this.ModelState.IsValid == false)
                {
                    // this.logger.LogError("Invalid type object sent from client");
                    return this.BadRequest();
                }

                var newItem = await this.catalogService.CreateTypeAsync(type).ConfigureAwait(false);
                return this.CreatedAtAction("GetCatalogTypeById", newItem.Id, newItem);
            }
            catch (ArgumentException)
            {
                return this.BadRequest();
            }
        }

        /// <summary>
        /// Retrieve all CatalogTypes.
        /// </summary>
        [HttpGet("type")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<CatalogType>>> GetAllCatalogTypes()
        {
            return this.Ok(await this.catalogService.GetAllTypeAsync().ConfigureAwait(false));
        }

        /// <summary>
        /// Retrieve 1 CatalogType by its id.
        /// </summary>
        [HttpGet("type/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<CatalogType>> GetCatalogTypeById(int id)
        {
            try
            {
                var getType = await this.catalogService.GetTypeByIdAsync(id).ConfigureAwait(false);
                if (getType == null)
                {
                    // this.logger.LogError("");
                    return this.BadRequest();
                }

                return this.Ok(getType);
            }
            catch (ArgumentException)
            {
                return this.BadRequest();
            }
        }

        /// <summary>
        /// Update a CatalogType.
        /// </summary>
        [HttpPut("type")]
        [ProducesResponseType(StatusCodes.Status202Accepted)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<CatalogType>> UpdateCatalogType(CatalogType type, int id)
        {
            try
            {
                if (id != type.Id)
                {
                    return this.BadRequest();
                }

                var updateType = await this.catalogService.UpdateType(type, id).ConfigureAwait(false);

                if (updateType == null)
                {
                    return this.BadRequest();
                }

                return this.Ok(updateType);
            }
            catch (ArgumentException)
            {
                return this.BadRequest();
            }
        }

        /// <summary>
        /// Delete 1 CatalogType by its id.
        /// </summary>
        [HttpDelete("type/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<CatalogType>> DeleteCatalogTypeById(CatalogType type, int id)
        {
            try
            {
                if (id == null)
                {
                    return this.BadRequest();
                }

                var deleteType = await this.catalogService.DeleteTypeById(type, id).ConfigureAwait(false);
                if (deleteType == null)
                {
                    // this.logger.LogError("");
                    return this.BadRequest();
                }

                return this.Ok(deleteType);
            }
            catch (ArgumentException)
            {
                return this.BadRequest();
            }
        }

        /// <summary>
        /// Retrieve all CatalogItems for a given CatalogType, by its id.
        /// </summary>
        [HttpGet("by-type/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<CatalogItem>>> GetCatalogItemsByCatalogTypeId(int id)
        {
            throw new NotImplementedException();
        }
    }
}
