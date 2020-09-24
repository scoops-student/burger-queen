using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Reflection.Metadata;
using System.Threading.Tasks;
using CatalogAPI.Model;
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

        public CatalogController(ILogger<CatalogController> logger)
        {
            this.logger = logger;
        }

        // CatalogTitem
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<CatalogItem>> CreateCatalogItem(CatalogItem item)
        {
            throw new NotImplementedException();
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<CatalogItem>>> GetAllCatalogItems()
        {
            throw new NotImplementedException();
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<CatalogItem>> GetCatalogItemById(long id)
        {
            throw new NotImplementedException();
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status202Accepted)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<CatalogItem>> UpdateCatalogItem(CatalogItem item)
        {
            throw new NotImplementedException();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<CatalogItem>> DeleteCatalogItemById(long id)
        {
            throw new NotImplementedException();
        }

        // CatalogItem
        [HttpPost("type")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<CatalogType>> CreateCatalogType(CatalogType catalogtype)
        {
            throw new NotImplementedException();
        }

        [HttpGet("type")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<CatalogType>>> GetAllCatalogTypes()
        {
            throw new NotImplementedException();
        }

        [HttpGet("type/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<CatalogType>> GetCatalogTypeById(long id)
        {
            throw new NotImplementedException();
        }

        [HttpPut("type")]
        [ProducesResponseType(StatusCodes.Status202Accepted)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<CatalogType>> UpdateCatalogType(CatalogType type)
        {
            throw new NotImplementedException();
        }

        [HttpDelete("type/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<CatalogType>> DeleteCatalogTypeById(long id)
        {
            throw new NotImplementedException();
        }

        // CatalogItem aan de hand van het CatalogType
        [HttpGet("by-type/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<CatalogItem>>> GetCatalogItemsByCatalogTypeId(long id)
        {
            throw new NotImplementedException();
        }
    }
}
