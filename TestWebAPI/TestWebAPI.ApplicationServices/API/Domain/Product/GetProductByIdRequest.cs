using MediatR;

namespace TestWebAPI.ApplicationServices.API.Domain.Product
{
    public class GetProductByIdRequest : IRequest<GetProductByIdResponse> 
    {
        public int ProductId { get; set; }
    }
}