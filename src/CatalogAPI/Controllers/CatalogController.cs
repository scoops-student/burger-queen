using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Net;
using System.Reflection.Metadata;
using System.Threading.Tasks;
using CatalogAPI.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace CatalogAPI.Controllers
{
    [Produces("application/json")]
    [ApiController]
    [Route("[controller]")]
    public class CatalogController : ControllerBase
    {
        public IActionResult Index()
        {
            var webClient = new WebClient();
            var json = webClient.DownloadString(@"C:\Users\ayoub\OneDrive\Bureau\Scoops\burger-queen\src\CatalogAPI\TestData.json");
            var catalogdatas = JsonConvert.DeserializeObject<Catalogs>(json);
            return View(catalogdatas);
            throw new NotImplementedException();
        }

        private readonly ILogger<CatalogController> logger;

        public CatalogController(ILogger<CatalogController> logger)
        {
            this.logger = logger;
        }

        /// <summary>
        /// Create a new CatalogItem.
        /// </summary>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<CatalogItem>> CreateCatalogItem(CatalogItem item)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Retrieve all CatalogItems.
        /// </summary>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<CatalogItem>>> GetAllCatalogItems()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Retrieve 1 CatalogItem by its id.
        /// </summary>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<CatalogItem>> GetCatalogItemById(long id)
        {
            throw new NotImplementedException();
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
