using System.Threading.Tasks;

namespace TestWebAPI.DataAccess.CQRS.Commands.Product
{
    public class AddProductCommand : CommandBase<Entities.Product, Entities.Product>
    {
        public override async Task<Entities.Product> Execute(TestWebAPIStorageContext context)
        {
            await context.Products.AddAsync(this.Parameter);
            await context.SaveChangesAsync();

            return this.Parameter;
        }
    }
}