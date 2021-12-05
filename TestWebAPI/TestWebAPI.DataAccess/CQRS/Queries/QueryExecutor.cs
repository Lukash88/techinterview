using System.Threading.Tasks;

namespace TestWebAPI.DataAccess.CQRS.Queries
{
    public class QueryExecutor : IQueryExecutor
    {
        private readonly TestWebAPIStorageContext context;

        public QueryExecutor(TestWebAPIStorageContext context)
        {
            this.context = context;
        }

        public async Task<TResult> Execute<TResult>(QueryBase<TResult> query)
        {
            return await query.Execute(this.context);
        }
    }
}