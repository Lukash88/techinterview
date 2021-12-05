using System.Threading.Tasks;

namespace TestWebAPI.DataAccess.CQRS.Queries
{
    public abstract class QueryBase<TResult>
    {
        public abstract Task<TResult> Execute(TestWebAPIStorageContext context);
    }
}