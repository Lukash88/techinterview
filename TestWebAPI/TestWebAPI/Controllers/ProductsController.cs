using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Swashbuckle.AspNetCore.Annotations;
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
        public System.Net.Http.HttpContent Content { get; set; }

        public ProductsController(IMediator mediator, ILogger<ProductsController> logger)
        {
            this.mediator = mediator;
            this.logger = logger;
            this.logger.LogInformation("We are in Products");
        }

        [HttpGet]
        [SwaggerOperation(Summary = "Retrieves filtered products or all products", 
                          Description = "Possible filtering using product names or categories or both of them")]
        [Route("")]
        public async Task<IActionResult> GetAllProducts([FromQuery] GetProductsRequest request)
        {
            var response = await this.mediator.Send(request);
            
            return this.Ok(response);
        }

        [HttpGet]
        [SwaggerOperation(Summary = "Retrieves a specific products by unique id")]
        [Route("{productId}")]
        public async Task<IActionResult> GetProductById([FromRoute] int productId)
        {
            var request = new GetProductByIdRequest()
            {
                ProductId = productId
            };
            if (request.ProductId <= 0)
            {
                return BadRequest();
            }

            var response = await this.mediator.Send(request);
            if (response == null)
            {
                return this.NotFound();
            }

            return this.Ok(response);
        }

        [HttpPost]
        [SwaggerOperation(Summary = "Creates a new product")]
        [Route("")]
        public async Task<IActionResult> AddProduct([FromBody] AddProductRequest request)
        {
            var response = await this.mediator.Send(request);

            return this.Ok(response);
        }

        [HttpDelete]
        [SwaggerOperation(Summary = "Removes a existing product by unique id")]
        [Route("{productId}")]
        public async Task<IActionResult> RemoveProductById([FromRoute] int productId)
        {
            var request = new RemoveProductRequest()
            {
                ProductId = productId
            };
            var response = await this.mediator.Send(request);

            return this.Ok(response);
        }

        [HttpPut]
        [SwaggerOperation(Summary = "Updates a existing product by unique id")]
        [Route("{productId}")]
        public async Task<IActionResult> UpdateProductById([FromRoute] int productId, [FromBody] UpdateProductRequest request)
        {
            request.ProductId = productId;
            var response = await this.mediator.Send(request);

            return this.Ok(response);
        }

    }
}