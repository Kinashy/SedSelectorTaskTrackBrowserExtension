using System;
using System.Collections.Generic;
using SelectorExtensionForChrome.CqrsCore;
using SelectorExtensionForChrome.PopupModule.Domain.UseCases.Queries;

namespace SelectorExtensionForChrome.PopupModule.Domain.UseCases.Handlers.QueryHandlers
{
    public class GetAllDatesOfTasksHandler : IQueryHandler<GetAllDatesOfTasks, List<DateTime>>
    {
        private readonly ISedTaskRepository _taskRepository;
        public GetAllDatesOfTasksHandler(ISedTaskRepository taskRepository) 
        {
            _taskRepository = taskRepository;
        }
        public List<DateTime> Execute(GetAllDatesOfTasks query)
        {
            return _taskRepository.GetDates();
        }
    }
}