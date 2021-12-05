using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using TestWebAPI.ApplicationServices.API.Domain.Models;
using TestWebAPI.ApplicationServices.API.Domain.Product;
using TestWebAPI.DataAccess.CQRS.Queries;
using TestWebAPI.DataAccess.CQRS.Queries.Product;

namespace TestWebAPI.ApplicationServices.API.Handlers
{
    public class GetProductByIdHandler : IRequestHandler<GetProductByIdRequest, GetProductByIdResponse>
    {
        private readonly IMapper mapper;
        private readonly IQueryExecutor queryExecutor;

        public GetProductByIdHandler(IMapper mapper, IQueryExecutor queryExecutor)
        {
            this.mapper = mapper;
            this.queryExecutor = queryExecutor;
        }

        public async Task<GetProductByIdResponse> Handle(GetProductByIdRequest request, CancellationToken cancellationToken)
        {
            var query = new GetProductQuery
            {
                Id = request.ProductId
            };
            var productFromDb = await this.queryExecutor.Execute(query);
            if (productFromDb == null)
            {
                return new GetProductByIdResponse()
                {
                    Data = null
                };
            }

            var mappedProduct = this.mapper.Map<ProductDto>(productFromDb);
            var response = new GetProductByIdResponse()
            {
                Data = mappedProduct
            };

            return response;
        }
    }
}