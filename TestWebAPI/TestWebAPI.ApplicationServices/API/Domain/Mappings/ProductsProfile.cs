namespace TestWebAPI.ApplicationServices.API.Domain.Mappings
{
    using AutoMapper;
    using TestWebAPI.ApplicationServices.API.Domain.Product;
    using TestWebAPI.DataAccess.Entities;

    public class ProductsProfile : Profile
    {
        public ProductsProfile()
        {
            this.CreateMap<AddProductRequest, Product>()
                .ForMember(x => x.Name, y => y.MapFrom(z => z.Name))
                .ForMember(x => x.Description, y => y.MapFrom(z => z.Description))
                .ForMember(x => x.Category, y => y.MapFrom(z => z.Category))
                .ForMember(x => x.Price, y => y.MapFrom(z => z.Price))
                .ForMember(x => x.ImageUrl, y => y.MapFrom(z => z.ImageUrl))
                .ForMember(x => x.ImageThumbnailUrl, y => y.MapFrom(z => z.ImageUrl));

            this.CreateMap<Product, Models.ProductDto>()
                .ForMember(x => x.Id, y => y.MapFrom(z => z.Id))
                .ForMember(x => x.Name, y => y.MapFrom(z => z.Name))
                .ForMember(x => x.Description, y => y.MapFrom(z => z.Description))
                .ForMember(x => x.Category, y => y.MapFrom(z => z.Category))
                .ForMember(x => x.Price, y => y.MapFrom(z => z.Price))
                .ForMember(x => x.ImageUrl, y => y.MapFrom(z => z.ImageUrl))
                .ForMember(x => x.ImageThumbnailUrl, y => y.MapFrom(z => z.ImageUrl))
                .ForMember(x => x.StockLevel, y => y.MapFrom(z => z.StockLevel));

            this.CreateMap<RemoveProductRequest, Product>()
                .ForMember(x => x.Id, y => y.MapFrom(z => z.ProductId));

            this.CreateMap<UpdateProductRequest, Product>()
                .ForMember(x => x.Id, y => y.MapFrom(z => z.ProductId))
               .ForMember(x => x.Name, y => y.MapFrom(z => z.Name))
                .ForMember(x => x.Description, y => y.MapFrom(z => z.Description))
                .ForMember(x => x.Category, y => y.MapFrom(z => z.Category))
                .ForMember(x => x.Price, y => y.MapFrom(z => z.Price))
                .ForMember(x => x.ImageUrl, y => y.MapFrom(z => z.ImageUrl))
                .ForMember(x => x.ImageThumbnailUrl, y => y.MapFrom(z => z.ImageUrl));
        }
    }
}