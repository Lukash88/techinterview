using MediatR;

namespace TestWebAPI.ApplicationServices.API.Domain.Product
{
    public class RemoveProductRequest : IRequest<RemoveProductResponse>
    {
        public int ProductId { get; set; }
    }
}