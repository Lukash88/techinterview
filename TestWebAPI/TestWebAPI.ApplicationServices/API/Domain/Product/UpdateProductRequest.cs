using MediatR;
using TestWebAPI.DataAccess.Enums;

namespace TestWebAPI.ApplicationServices.API.Domain.Product
{
    public class UpdateProductRequest : IRequest<UpdateProductResponse>
    {
        public int ProductId;
        public string Name { get; set; }
        public string Description { get; set; }
        public ProductCatergoryEnum Category { get; set; }
        public decimal? Price { get; set; }
        public string ImageUrl { get; set; }
        public string ImageThumbnailUrl { get; set; }
    }
}