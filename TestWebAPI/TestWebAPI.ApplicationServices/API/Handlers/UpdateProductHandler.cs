using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using TestWebAPI.ApplicationServices.API.Domain.Product;
using TestWebAPI.DataAccess.CQRS.Commands;
using TestWebAPI.DataAccess.CQRS.Commands.Product;
using TestWebAPI.DataAccess.CQRS.Queries;
using TestWebAPI.DataAccess.CQRS.Queries.Product;

namespace TestWebAPI.ApplicationServices.API.Handlers
{
    public class UpdateProductHandler : IRequestHandler<UpdateProductRequest, UpdateProductResponse>
    {
        private readonly IMapper mapper;
        private readonly ICommandExecutor commandExecutor;
        private readonly IQueryExecutor queryExecutor;

        public UpdateProductHandler(IMapper mapper, ICommandExecutor commandExecutor, IQueryExecutor queryExecutor)
        {
            this.mapper = mapper;
            this.commandExecutor = commandExecutor;
            this.queryExecutor = queryExecutor;
        }

        public async Task<UpdateProductResponse> Handle(UpdateProductRequest request, CancellationToken cancellationToken)
        {
            var query = new GetProductQuery()
            {
                Id = request.ProductId
            };
            var getProduct = await this.queryExecutor.Execute(query);
            if (getProduct == null)
            {
                return new UpdateProductResponse();
            }

            var mappedProduct = this.mapper.Map<DataAccess.Entities.Product>(request);
            var command = new UpdateProductCommand()
            {
                Parameter = mappedProduct
            };
            var productFromDb = await this.commandExecutor.Execute(command);

            return new UpdateProductResponse()
            {
                Data = this.mapper.Map<Domain.Models.ProductDto>(productFromDb)
            };
        }
    }
}