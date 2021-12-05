using MediatR;
using TestWebAPI.DataAccess.Enums;

namespace TestWebAPI.ApplicationServices.API.Domain.Product
{
    public class GetProductsRequest : IRequest<GetProductsResponse>
    {
        public string Name { get; set; }
        public ProductCatergoryEnum? Category { get; set; }
    }
}