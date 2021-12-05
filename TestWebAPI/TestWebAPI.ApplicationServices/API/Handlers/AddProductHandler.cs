using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using TestWebAPI.ApplicationServices.API.Domain.Product;
using TestWebAPI.DataAccess.CQRS.Commands;
using TestWebAPI.DataAccess.CQRS.Commands.Product;
using TestWebAPI.DataAccess.Entities;

namespace TestWebAPI.ApplicationServices.API.Handlers
{
    public class AddProductHandler : IRequestHandler<AddProductRequest, AddProductResponse>
    {
        private readonly IMapper mapper;
        private readonly ICommandExecutor commandExecutor;

        public AddProductHandler(IMapper mapper, ICommandExecutor commandExecutor)
        {
            this.mapper = mapper;
            this.commandExecutor = commandExecutor;
        }

        public async Task<AddProductResponse> Handle(AddProductRequest request, CancellationToken cancellationToken)
        {
            var product = this.mapper.Map<Product>(request);
            var command = new AddProductCommand()
            {
                Parameter = product
            };
            var addedProduct = await this.commandExecutor.Execute(command);
            var response = new AddProductResponse()
            {
                Data = this.mapper.Map<Domain.Models.ProductDto>(addedProduct)
            };

            return response;
        }
    }
}