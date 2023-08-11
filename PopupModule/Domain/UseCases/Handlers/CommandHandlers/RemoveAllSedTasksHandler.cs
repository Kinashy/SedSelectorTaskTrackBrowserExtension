using testprog.CqrsCore;
using testprog.PopupModule.Domain.UseCases.Commands;
using testprog.PopupModule.Domain.UseCases.Queries;

namespace testprog.PopupModule.Domain.UseCases.Handlers.CommandHandlers
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