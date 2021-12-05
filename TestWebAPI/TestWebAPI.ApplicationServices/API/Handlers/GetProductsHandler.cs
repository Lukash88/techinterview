using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TestWebAPI.ApplicationServices.API.Domain.Models;
using TestWebAPI.ApplicationServices.API.Domain.Product;
using TestWebAPI.DataAccess.Entities;

namespace TestWebAPI.ApplicationServices.API.Handlers
{
    public class GetProductsHandler : IRequestHandler<GetProductsRequest, GetProductsResponse>
    {
        private readonly IMapper mapper;

        public GetProductsHandler(IMapper mapper)
        {
            this.mapper = mapper;
        }

        public Task<GetProductsResponse> Handle(GetProductsRequest request, CancellationToken cancellationToken)
        {         

            throw new NotImplementedException();
        }
    }
}
