using System;
using System.Collections.Generic;
using SelectorExtensionForChrome.CqrsCore;
using SelectorExtensionForChrome.PopupModule.Infrastructure.DTOModels;

namespace SelectorExtensionForChrome.PopupModule.Domain.UseCases.Queries
{
    public class GetSedTasksByDate : IQuery<List<SedTaskDTO>>
    {
        public DateTime ExecutionDate { get; }
        public GetSedTasksByDate(DateTime executionDate)
        {
            ExecutionDate = executionDate;
        }
    }
}