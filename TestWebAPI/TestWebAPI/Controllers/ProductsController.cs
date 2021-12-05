using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestWebAPI.ApplicationServices.API.Domain.Product;

namespace TestWebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IMediator mediator;
        private readonly ILogger<ProductsController> logger;

        public ProductsController(IMediator mediator, ILogger<ProductsController> logger)
        {
            this.mediator = mediator;
            this.logger = logger;
            this.logger.LogInformation("We are in Products");
        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetAllProducts([FromQuery] GetProductsRequest request)
        {
            var response = await this.mediator.Send(request);

            return this.Ok(response);
        }

        [HttpGet]
        [Route("{productId}")]
        public async Task<IActionResult> GetProductById([FromRoute] int productId)
        {
            var request = new GetProductByIdRequest()
            {
                ProductId = productId
            };

            throw new NotImplementedException();
        }

        [HttpPost]
        [Route("")]
        public async Task<IActionResult> AddProduct([FromBody] AddProductRequest request)
        {
            throw new NotImplementedException();
        }

        [HttpDelete]
        [Route("{productId}")]
        public async Task<IActionResult> RemoveProductById([FromRoute] int productId)
        {
            var request = new RemoveProductRequest()
            {
                ProductId = productId
            };

            throw new NotImplementedException();
        }

        [HttpPut]
        [Route("{productId}")]
        public async Task<IActionResult> UpdateProductById([FromRoute] int productId, [FromBody] UpdateProductRequest request)
        {
            request.ProductId = productId;

            throw new NotImplementedException();
        }

    }
}
