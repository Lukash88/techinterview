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
    public class UpdateProductHandler : IRequestHandler<UpdateProductRequest, UpdateProductResponse>
    {
        private readonly IMapper mapper; 

        public UpdateProductHandler(IMapper mapper)
        {
            this.mapper = mapper;
        }

        public Task<UpdateProductResponse> Handle(UpdateProductRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
