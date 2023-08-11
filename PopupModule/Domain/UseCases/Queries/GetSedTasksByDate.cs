using System;
using System.Collections.Generic;
using testprog.CqrsCore;
using testprog.PopupModule.Infrastructure.DTOModels;

namespace testprog.PopupModule.Domain.UseCases.Queries
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