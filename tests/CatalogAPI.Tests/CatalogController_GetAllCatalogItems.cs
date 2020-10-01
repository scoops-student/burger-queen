using CatalogAPI.Controllers;
using CatalogAPI.Model;
using Microsoft.Extensions.Logging;
using Moq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace CatalogAPI.Tests
{
    public class CatalogController_GetAllCatalogItems
    {
        CatalogController _controller;

        public CatalogController_GetAllCatalogItems()
        {
            var loggerMock = new Mock<ILogger<CatalogController>>();
            this._controller = new CatalogController(loggerMock.Object);
        }

        [Fact]
        public async Task ReturnsCorrectType()
        {

            var result = await _controller.GetAllCatalogItems();

            Assert.True(result.Value is IEnumerable<CatalogItem>);
        }

    }
}
