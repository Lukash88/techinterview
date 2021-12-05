using System.Threading.Tasks;

namespace TestWebAPI.DataAccess.CQRS.Queries
{
    public interface IQueryExecutor
    {
        Task<TResult> Execute<TResult>(QueryBase<TResult> query);
    }
}