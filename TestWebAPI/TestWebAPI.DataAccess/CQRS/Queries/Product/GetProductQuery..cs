using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace TestWebAPI.DataAccess.CQRS.Queries.Product
{
    public class GetProductQuery : QueryBase<Entities.Product>
    {
        public int Id { get; init; }

        public override async Task<Entities.Product> Execute(TestWebAPIStorageContext context)
            => await context.Products.FirstOrDefaultAsync(x => x.Id == this.Id);
    }
}