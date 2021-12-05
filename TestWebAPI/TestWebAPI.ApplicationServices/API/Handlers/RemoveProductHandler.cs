using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using TestWebAPI.ApplicationServices.API.Domain.Product;
using TestWebAPI.DataAccess.CQRS.Commands;
using TestWebAPI.DataAccess.CQRS.Commands.Product;
using TestWebAPI.DataAccess.CQRS.Queries;
using TestWebAPI.DataAccess.CQRS.Queries.Product;
using TestWebAPI.DataAccess.Entities;

namespace TestWebAPI.ApplicationServices.API.Handlers
{
    public class RemoveProductHandler : IRequestHandler<RemoveProductRequest, RemoveProductResponse>
    {
        private readonly IMapper mapper;
        private readonly ICommandExecutor commandExecutor;
        private readonly IQueryExecutor queryExecutor;

        public RemoveProductHandler(IMapper mapper, ICommandExecutor commandExecutor, IQueryExecutor queryExecutor)
        {
            this.mapper = mapper;
            this.commandExecutor = commandExecutor;
            this.queryExecutor = queryExecutor;
        }

        public async Task<RemoveProductResponse> Handle(RemoveProductRequest request, CancellationToken cancellationToken)
        {
            var query = new GetProductQuery()
            {
                Id = request.ProductId
            };
            var getProduct = await this.queryExecutor.Execute(query);
            if (getProduct == null)
            {
                return new RemoveProductResponse();
            }

            var mappedProduct = mapper.Map<Product>(request);
            var command = new RemoveProductCommand()
            {
                Parameter = mappedProduct
            };
            var removedProduct = await this.commandExecutor.Execute(command);
            var response = new RemoveProductResponse()
            {
                Data = this.mapper.Map<Domain.Models.ProductDto>(removedProduct)
            };

            return response;
        }
    }
}