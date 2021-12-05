using System.Threading.Tasks;

namespace TestWebAPI.DataAccess.CQRS.Commands
{
    public interface ICommandExecutor
    {
        Task<TResult> Execute<TParameters, TResult>(CommandBase<TParameters, TResult> command);
    }
}