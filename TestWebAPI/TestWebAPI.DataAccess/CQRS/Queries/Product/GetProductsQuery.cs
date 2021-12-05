using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestWebAPI.DataAccess.Enums;

namespace TestWebAPI.DataAccess.CQRS.Queries.Product
{
    public class GetProductsQuery : QueryBase<List<Entities.Product>>
    {
        public string Name { get; init; }
        public ProductCatergoryEnum? Category { get; init; }

        public async override Task<List<Entities.Product>> Execute(TestWebAPIStorageContext context)
        {
            if (!string.IsNullOrEmpty(Name) && Category == null )
            {
                var result = await context.Products.Where(x => x.Name.Contains(this.Name)).ToListAsync();
                if (result.Count == 0)
                {
                    return null;
                }

                return result;
            }
            else if (string.IsNullOrEmpty(Name) && Category != null)
            {
                var result = await context.Products.Where(x => x.Category == this.Category).ToListAsync();
                if (result.Count == 0)
                {
                    return null;
                }

                return result;
            }
            else if (!string.IsNullOrEmpty(Name) && Category != null)
            {
                var result = await context.Products.Where(x => x.Category == this.Category && x.Name.Contains(this.Name)).ToListAsync();
                if (result.Count == 0)
                {
                    return null;
                }

                return result;
            }

            return await context.Products.ToListAsync();
        }
    }
}