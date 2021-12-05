using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using TestWebAPI.ApplicationServices.API.Domain.Product;

namespace TestWebAPI.ApplicationServices.API.Handlers
{
    public class RemoveProductHandler : IRequestHandler<RemoveProductRequest, RemoveProductResponse>
    {
        private readonly IMapper mapper;

        public RemoveProductHandler(IMapper mapper)
        {
            this.mapper = mapper;
        }

        public Task<RemoveProductResponse> Handle(RemoveProductRequest request, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }
}
