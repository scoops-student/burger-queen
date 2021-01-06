using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Diagnostics.Eventing.Reader;
using System.IO;
using System.Linq;
using System.Reflection.Metadata;
using System.Threading.Tasks;
using CatalogAPI.Domain.Interfaces;
using CatalogAPI.Domain.Models;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
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
        private readonly IHostEnvironment environment;

        public CatalogController(ILogger<CatalogController> logger, ICatalogService catalogService, IHostEnvironment environment)
        {
            this.logger = logger;
            this.catalogService = catalogService;
            this.environment = environment;
        }

        /// <summary>
        /// Create a new CatalogItem.
        /// </summary>
        [HttpPost("item", Name = "CreateCatalogItem")]
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

                return this.CreatedAtAction(nameof(GetCatalogItemById), new { id = newItem.Id }, newItem);
            }
            catch (ArgumentException)
            {
                return this.BadRequest();
            }
        }

        /// <summary>
        /// Retrieve all CatalogItems.
        /// </summary>
        [HttpGet("item", Name = "GetAllCatalogItems")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<CatalogItem>>> GetAllCatalogItems()
        {
            return this.Ok(await this.catalogService.GetAllItemsAsync().ConfigureAwait(false));
        }

        /// <summary>
        /// Retrieve 1 CatalogItem by its id.
        /// </summary>
        [HttpGet("item/{id}", Name = "GetCatalogItemById")]
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
        [HttpPut("item", Name = "UpdateCatalogItem")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<CatalogItem>> UpdateCatalogItem(CatalogItem item)
        {
            try
            {

                var updateItem = await this.catalogService.UpdateItem(item).ConfigureAwait(false);

                //return this.ok
                return this.Ok(updateItem);
            }
            catch (ArgumentException)
            {
                return this.BadRequest();
            }
        }

        /// <summary>
        /// Delete 1 CatalogItem by its id.
        /// </summary>
        [HttpDelete("by-item/{id}", Name = "DeleteCatalogItemById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> DeleteCatalogItemById(int id)
        {
            try
            {
                await this.catalogService.DeleteItemById(id).ConfigureAwait(false);

                return this.Ok();
            }
            catch (ArgumentException)
            {
                return this.BadRequest();
            }
        }

        /// <summary>
        /// Create a new CatalogType.
        /// </summary>
        [HttpPost("type", Name = "CreateCatalogType")]
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
                return this.CreatedAtAction(nameof(GetCatalogTypeById), new { id = newItem.Id }, newItem);
            }
            catch (ArgumentException)
            {
                return this.BadRequest();
            }
        }

        /// <summary>
        /// Retrieve all CatalogTypes.
        /// </summary>
        [HttpGet("type", Name = "GetAllCatalogTypes")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<CatalogType>>> GetAllCatalogTypes()
        {
            return this.Ok(await this.catalogService.GetAllTypeAsync().ConfigureAwait(false));
        }

        /// <summary>
        /// Retrieve 1 CatalogType by its id.
        /// </summary>
        [HttpGet("type/{id}", Name = "GetCatalogTypeById")]
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
        [HttpPut("type", Name = "UpdateCatalogType")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<CatalogType>> UpdateCatalogType(CatalogType type)
        {
            try
            {

                var updateType = await this.catalogService.UpdateType(type).ConfigureAwait(false);

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
        [HttpDelete("type/{id}", Name = "DeleteCatalogTypeById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> DeleteCatalogTypeById(int id)
        {
            try
            {

                await this.catalogService.DeleteTypeById(id).ConfigureAwait(false);

                return this.Ok();
            }
            catch (ArgumentException)
            {
                return this.BadRequest();
            }
        }

        /// <summary>
        /// Retrieve all CatalogItems for a given CatalogType, by its id.
        /// </summary>
        [HttpGet("by-type/{id}", Name = "GetCatalogItemsByCatalogTypeId")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<CatalogItem>>> GetCatalogItemsByCatalogTypeId(int id)
        {
            try
            {
                var result = await this.catalogService.GetCatalogItemsByCatalogTypeId(id);
                return this.Ok(result);
            }
            catch (Exception)
            {
                return this.BadRequest();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [HttpPost ("by-item", Name = "PostImage")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> PostImage([FromForm] IFormFile image)
        {
            try
            {
                if (image == null || image.Length == 0)
                {
                    return BadRequest("Upload a file!");
                }

                string fileName = image.FileName;
                string extension = Path.GetExtension(fileName);
                string[] allowedExtension = { ".jpg", ".png", ".bmp" };

                if (!allowedExtension.Contains(extension))
                {
                    return BadRequest("File is not a valid image!");
                }

                string newFileName = $"{Guid.NewGuid()}{extension}";
                string filePath = Path.Combine(this.environment.ContentRootPath, "wwwroot", "Image", newFileName);

                using (var fileStream = new FileStream(filePath, FileMode.Create, FileAccess.Write))
                {
                    await image.CopyToAsync(fileStream);
                }

                return Ok($"Image/{newFileName}");
            }
            catch (Exception)
            {
                return this.BadRequest();
            }
        }
    }
}