using Microsoft.EntityFrameworkCore;
using TestWebAPI.DataAccess.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace TestWebAPI.DataAccess.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder
               .Property(x => x.Name)
               .IsRequired()
               .HasMaxLength(30);

            builder
                .Property(x => x.Description)
                .IsRequired()
                .HasMaxLength(500);

            builder
               .Property(x => x.Category)
               .IsRequired();

            builder
               .Property(x => x.Price)
               .HasPrecision(14, 2)
               .IsRequired(false);


            builder
                .Property(x => x.ImageUrl)
                .HasMaxLength(200);

            builder
                .Property(x => x.ImageThumbnailUrl)
                .HasMaxLength(200);

            builder
                .Property(x => x.StockLevel)
                .IsRequired();
        }
    }
}