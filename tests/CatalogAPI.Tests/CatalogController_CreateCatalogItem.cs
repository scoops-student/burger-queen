using CatalogAPI.Controllers;
using CatalogAPI.Model;
using Microsoft.Extensions.Logging;
using Moq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace CatalogAPI.Tests
{
    public class CatalogController_CreateCatalogItem
    {
        CatalogController _controller;

        public CatalogController_CreateCatalogItem()
        {
            var loggerMock = new Mock<ILogger<CatalogController>>();
            this._controller = new CatalogController(loggerMock.Object);
        }

        [Fact]
        public async Task ReturnsCorrectType()
        {

            var result = await _controller.CreateCatalogItem(new CatalogItem());

            Assert.True(result.Value is IEnumerable<CatalogItem>);
        }

        [Fact]
        public async Task SetsValidId()
        {

            var result = await _controller.CreateCatalogItem(new CatalogItem());

            Assert.NotEqual(0, result.Value.Id);
        }
    }
}
