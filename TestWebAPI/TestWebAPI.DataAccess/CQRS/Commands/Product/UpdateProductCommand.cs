using System.Threading.Tasks;

namespace TestWebAPI.DataAccess.CQRS.Commands.Product
{
    public class UpdateProductCommand : CommandBase<Entities.Product, Entities.Product>
    {
        public override async Task<Entities.Product> Execute(TestWebAPIStorageContext context)
        {
            context.ChangeTracker.Clear();
            context.Products.Update(this.Parameter);
            await context.SaveChangesAsync();

            return this.Parameter;
        }
    }
}