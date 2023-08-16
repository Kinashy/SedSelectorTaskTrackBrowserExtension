using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SelectorExtensionForChrome.CqrsCore;
using SelectorExtensionForChrome.PopupModule.Infrastructure.DTOModels;

namespace SelectorExtensionForChrome.PopupModule.Domain.UseCases.Queries
{
    public class GetAllControlTasks : IQuery<Task<List<SedTaskDTO>>>
    {
        public string Token { get; }
        public DateTime CreateFrom { get; }
        public DateTime CreateTo { get; }
        public DateTime From { get; }
        public DateTime To { get; }
        public GetAllControlTasks(string token, DateTime createFrom, DateTime createTo, DateTime from, DateTime to) 
        {
            Token = token;
            CreateFrom = createFrom;
            CreateTo = createTo;
            From = from;
            To = to;
        }
    }
}
