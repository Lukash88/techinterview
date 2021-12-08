using FluentAssertions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;
using System.Threading.Tasks;
using TestWebAPI.Controllers;

namespace TestWebAPI.Tests.Controllers
{
    public class ProductControllerTests
    {
        private Mock<IMediator> _mockMediator;
        private Mock<ILogger<ProductsController>> _mockLogger;
        private ProductsController _productsController;

        private void Init()
        {
            _mockMediator = new Mock<IMediator>();
            _mockLogger = new Mock<ILogger<ProductsController>>();
            _productsController = new ProductsController(_mockMediator.Object, _mockLogger.Object);
            
        }      

        [Test]
        public async Task GetProductById_WhenIdIsLowerThan1_ShouldReturnBadRequest()
        {
            Init();

            var result = await _productsController.GetProductById(-9);

            result.Should().BeOfType<BadRequestResult>();

        }

        [Test]
        public async Task GetProductById_WhenIdDoesNotExist_ShouldReturnNotFoundt()
        {
            Init();

            var result = await _productsController.GetProductById(99999);

            result.Should().BeOfType<NotFoundResult>();
        }

        [Test]
        public async Task GetProductById_WhenIdExists_ShouldReturnOkResult()
        {
            Init();

            var result = await _productsController.GetProductById(2);

            result.Should().BeOfType<OkResult>();
        }

        [Test]
        public async Task GetProductById_WhenProductIdExists_ShouldReturnProduct()
        {
            Init();

            var result = await _productsController.GetProductById(3);

            result.Should().BeOfType<OkResult>();

            result.Should().BeOfType<OkObjectResult>();
        }
        [Test]
        public void GetProductById_WhenIMediatorFails_ShouldLogError()
        {
            Init();
        }

        [Test]
        public void GetProductById_WhenIMediatorFails_ShouldReturnBadRequest()
        {
            Init();
        }
    }
}
