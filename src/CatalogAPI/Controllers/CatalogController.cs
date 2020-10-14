using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Reflection.Metadata;
using System.Threading.Tasks;
using CatalogAPI.Domain.Interfaces;
using CatalogAPI.Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

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
            if (this.ModelState.IsValid == false)
            {
                return this.BadRequest();
            }

            var newItem = await this.catalogService.CreateItemAsync(item).ConfigureAwait(false);

            return this.CreatedAtAction("GetCatalogItemById", newItem.Id, newItem);
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
                return this.Ok(await this.catalogService.GetItemByIdAsync(id).ConfigureAwait(false));
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
        public async Task<ActionResult<CatalogItem>> UpdateCatalogItem(CatalogItem item)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Delete 1 CatalogItem by its id.
        /// </summary>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<CatalogItem>> DeleteCatalogItemById(long id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Create a new CatalogType.
        /// </summary>
        [HttpPost("type")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<CatalogType>> CreateCatalogType(CatalogType catalogtype)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Retrieve all CatalogTypes.
        /// </summary>
        [HttpGet("type")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<CatalogType>>> GetAllCatalogTypes()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Retrieve 1 CatalogType by its id.
        /// </summary>
        [HttpGet("type/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<CatalogType>> GetCatalogTypeById(long id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Update a CatalogType.
        /// </summary>
        [HttpPut("type")]
        [ProducesResponseType(StatusCodes.Status202Accepted)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<CatalogType>> UpdateCatalogType(CatalogType type)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Delete 1 CatalogType by its id.
        /// </summary>
        [HttpDelete("type/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<CatalogType>> DeleteCatalogTypeById(long id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Retrieve all CatalogItems for a given CatalogType, by its id.
        /// </summary>
        [HttpGet("by-type/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<CatalogItem>>> GetCatalogItemsByCatalogTypeId(long id)
        {
            throw new NotImplementedException();
        }
    }
}
