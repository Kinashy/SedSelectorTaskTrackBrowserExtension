using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using SelectorExtensionForChrome.CqrsCore;
using SelectorExtensionForChrome.PopupModule.Domain.UseCases.Queries;
using SelectorExtensionForChrome.PopupModule.Infrastructure.ApiDto;
using SelectorExtensionForChrome.PopupModule.Infrastructure.DTOModels;

namespace SelectorExtensionForChrome.PopupModule.Domain.UseCases.Handlers.QueryHandlers
{
    public class GetSortedTasksHandler : IQueryHandler<GetSortedTasks, Task<List<SedTaskDTO>>>
    {
        private readonly HttpClient _httpClient;
        private readonly IMapper _mapper;
        public GetSortedTasksHandler(IMapper mapper, HttpClient httpClient) 
        {
            _httpClient = httpClient;
            _mapper = mapper;
        }
        public async Task<List<SedTaskDTO>> Execute(GetSortedTasks taskQuery)
        {
            List<SedTaskDTO> sortedTasks;
            List<SedTaskDTO> excessTasks = new();
            try
            {
                foreach (var task in taskQuery.SourceTasks)
                {
                    TasksOfDocumentRequest body = new();
                    body.documentID = task.DocumentID;
                    body.token = taskQuery.Token;
                    var response = await _httpClient.PostAsJsonAsync("api/task/tasksOfDocument", body);
                    if (response.IsSuccessStatusCode)
                    {
                        var allDocumentTasks = await response.Content.ReadFromJsonAsync<List<TasksOfDocumentEntityResponse>>();
                        bool isForUser = allDocumentTasks.Any(
                        i =>
                    i.controllers.Any(j => j.id == taskQuery.UserId) ||
                    i.responsibles.Any(j => j.id == taskQuery.UserId) ||
                    i.creator.id == taskQuery.UserId ||
                    i.executors.Any(j => j.id == taskQuery.UserId) ||
                    i.signers.Any(j => j.id == taskQuery.UserId) ||
                    i.forInformation.Any(j => j.id == taskQuery.UserId)
                    );
                        if (!isForUser)
                        {
                            excessTasks.Add(task);
                        }
                    }
                    else
                    {
                        sortedTasks = null;
                        throw new System.Exception("Not success status code for api/task/tasksOfDocument");
                    }
                }
                sortedTasks = taskQuery.SourceTasks.Except(excessTasks).ToList();
            }
            catch
            {
                sortedTasks = null;
            }
            return sortedTasks;
        }
    }
}
