using System.Collections.Generic;
using System.Threading.Tasks;
using SelectorExtensionForChrome.CqrsCore;
using SelectorExtensionForChrome.PopupModule.Domain.UseCases.Queries;
using SelectorExtensionForChrome.PopupModule.Infrastructure.DTOModels;

namespace SelectorExtensionForChrome.PopupModule.Domain.UseCases.Handlers.QueryHandlers
{
    public class GetSedTasksByDateHandler : IQueryHandler<GetSedTasksByDate, List<SedTaskDTO>>
    {
        private readonly ISedTaskRepository _repository;
        public GetSedTasksByDateHandler(ISedTaskRepository repository)
        {
            _repository = repository;
        }
        public List<SedTaskDTO> Execute(GetSedTasksByDate query)
        {
            return _repository.GetAllByDate(query.ExecutionDate);
        }
    }
}