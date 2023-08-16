using SelectorExtensionForChrome.CqrsCore;
using SelectorExtensionForChrome.PopupModule.Domain.UseCases.Commands;

namespace SelectorExtensionForChrome.PopupModule.Domain.UseCases.Handlers.CommandHandlers
{
    public class AddSedTasksHandler : ICommandHandler<AddSedTasks>
    {
        private readonly ISedTaskRepository _repository;
        public AddSedTasksHandler(ISedTaskRepository repository)
        {
            _repository = repository;
        }
        public void Execute (AddSedTasks command) 
        {
            _repository.AddList(command.SedTasks);
        }
    }
}
