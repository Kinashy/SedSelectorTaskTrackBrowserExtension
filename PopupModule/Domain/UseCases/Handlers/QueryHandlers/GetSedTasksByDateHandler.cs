using System.Collections.Generic;
using System.Threading.Tasks;
using testprog.CqrsCore;
using testprog.PopupModule.Domain.UseCases.Queries;
using testprog.PopupModule.Infrastructure.DTOModels;

namespace testprog.PopupModule.Domain.UseCases.Handlers.QueryHandlers
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
