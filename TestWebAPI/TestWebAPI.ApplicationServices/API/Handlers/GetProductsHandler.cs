using AutoMapper;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using TestWebAPI.ApplicationServices.API.Domain.Models;
using TestWebAPI.ApplicationServices.API.Domain.Product;
using TestWebAPI.DataAccess.CQRS.Queries;
using TestWebAPI.DataAccess.CQRS.Queries.Product;

namespace TestWebAPI.ApplicationServices.API.Handlers
{
    public class GetProductsHandler : IRequestHandler<GetProductsRequest, GetProductsResponse>
    {
        private readonly IMapper mapper;
        private readonly IQueryExecutor queryExecutor;

        public GetProductsHandler(IMapper mapper, IQueryExecutor queryExecutor)
        {
            this.mapper = mapper;
            this.queryExecutor = queryExecutor;
        }

        public async Task<GetProductsResponse> Handle(GetProductsRequest request, CancellationToken cancellationToken)
        {
            var query = new GetProductsQuery
            { 
                Name = request.Name,
                Category = request.Category
            };
            var productsFromDb = await this.queryExecutor.Execute(query);
            if (productsFromDb == null)
            {
                return new GetProductsResponse()
                {
                    Data = null
                };
            }

            var mappedProducts = this.mapper.Map<List<ProductDto>>(productsFromDb);
            var response = new GetProductsResponse()
            { 
                Data = mappedProducts
            };
            
            return response;           
        }
    }
}