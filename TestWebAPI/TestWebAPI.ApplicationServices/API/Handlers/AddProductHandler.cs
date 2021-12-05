using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using TestWebAPI.ApplicationServices.API.Domain.Product;

namespace TestWebAPI.ApplicationServices.API.Handlers
{
    public class AddProductHandler : IRequestHandler<AddProductRequest, AddProductResponse>
    {
        private readonly IMapper mapper;

        public AddProductHandler(IMapper mapper)
        {
            this.mapper = mapper;
        }

        public Task<AddProductResponse> Handle(AddProductRequest request, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }
}
