using SelectorExtensionForChrome.CqrsCore;
using SelectorExtensionForChrome.PopupModule.Domain.UseCases.Commands;
using SelectorExtensionForChrome.PopupModule.Domain.UseCases.Queries;

namespace SelectorExtensionForChrome.PopupModule.Domain.UseCases.Handlers.CommandHandlers
{
    public class RemoveAllSedTasksHandler : ICommandHandler<RemoveAllSedTasks>
    {
        private readonly ISedTaskRepository _repository;
        public RemoveAllSedTasksHandler(ISedTaskRepository repository)
        {
            _repository = repository;
        }
        public void Execute(RemoveAllSedTasks command)
        {
            _repository.RemoveAll();
        }
    }
}