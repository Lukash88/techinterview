using MediatR;

namespace TestWebAPI.ApplicationServices.API.Domain.Product
{
    public class GetProductsRequest : IRequest<GetProductsResponse>
    {
        public string Name { get; set; }
    }
}
