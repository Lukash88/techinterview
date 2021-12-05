using System.Threading.Tasks;

namespace TestWebAPI.DataAccess.CQRS.Commands
{
    public class CommandExecutor : ICommandExecutor
    {
        private readonly TestWebAPIStorageContext context;

        public CommandExecutor(TestWebAPIStorageContext context)
        {
            this.context = context;
        }

        public Task<TResult> Execute<TParameters, TResult>(CommandBase<TParameters, TResult> command)
        {
            return command.Execute(this.context);
        }
    }
}