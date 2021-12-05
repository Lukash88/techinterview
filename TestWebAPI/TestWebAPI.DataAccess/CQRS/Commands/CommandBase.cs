using System.Threading.Tasks;

namespace TestWebAPI.DataAccess.CQRS.Commands
{
    public abstract class CommandBase<TParameter, TResult>
    {
        public TParameter Parameter { get; set; }

        public abstract Task<TResult> Execute(TestWebAPIStorageContext context);
    }
}