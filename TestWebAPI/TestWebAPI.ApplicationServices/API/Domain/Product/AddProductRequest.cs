using MediatR;
using TestWebAPI.DataAccess.Enums;

namespace TestWebAPI.ApplicationServices.API.Domain.Product
{
    public class AddProductRequest : IRequest<AddProductResponse>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public ProductCatergoryEnum Category { get; set; }
        public decimal? Price { get; set; }
        public string ImageUrl { get; set; }
        public string ImageThumbnailUrl { get; set; }
        public int StockLevel { get; set; }
    }
}