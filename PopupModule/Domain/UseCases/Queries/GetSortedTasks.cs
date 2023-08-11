using System.Collections.Generic;
using System.Threading.Tasks;
using testprog.CqrsCore;
using testprog.PopupModule.Infrastructure.DTOModels;

namespace testprog.PopupModule.Domain.UseCases.Queries
{
    public class GetSortedTasks : IQuery<Task<List<SedTaskDTO>>>
    {
        public string Token { get; }
        public string UserId { get; }
        public List<SedTaskDTO> SourceTasks { get; }
        public GetSortedTasks(string token, string userId, List<SedTaskDTO> source)
        {
            Token = token;
            UserId = userId;
            SourceTasks = source;
        }
    }
}