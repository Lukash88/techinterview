using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TestWebAPI.ApplicationServices.API.Domain.Product;

namespace TestWebAPI.ApplicationServices.API.Handlers
{
    public class GetProductByIdHandler : IRequestHandler<GetProductByIdRequest, GetProductByIdResponse>
    {
        private readonly IMapper mapper;

        public GetProductByIdHandler(IMapper mapper)
        {
            this.mapper = mapper;
        }

        public Task<GetProductByIdResponse> Handle(GetProductByIdRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
