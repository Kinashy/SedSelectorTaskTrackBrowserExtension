using AutoMapper;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using testprog.CqrsCore;
using testprog.PopupModule.Domain.UseCases.Queries;
using testprog.PopupModule.Infrastructure.ApiDto;
using testprog.PopupModule.Infrastructure.DTOModels;

namespace testprog.PopupModule.Domain.UseCases.Handlers.QueryHandlers
{
    public class GetAllTasksHandler : IQueryHandler<GetAllTasks, Task<List<SedTaskDTO>>>
    {
        private readonly HttpClient _httpClient;
        private readonly IMapper _mapper;
        GetAllTasksHandler(HttpClient httpClient, IMapper mapper)
        {
            _httpClient = httpClient;
            _mapper = mapper;
        }
        public async Task<List<SedTaskDTO>> Execute(GetAllTasks filter)
        {
            TaskControlFIlter filterDto = new TaskControlFIlter();
            List<SedTaskDTO> tasks = null;
            filterDto = _mapper.Map<TaskControlFIlter>(filter);
            try
            {
                var response = await _httpClient.PostAsJsonAsync("api/task/taskControl", filter);
                if (response.IsSuccessStatusCode)
                {
                    List<SedTask> responsed = await response.Content.ReadFromJsonAsync<List<SedTask>>();
                    tasks = _mapper.Map<List<SedTaskDTO>>(responsed);
                }
                else
                {
                    tasks = null;
                }
            }
            catch
            {
                tasks = null;
            }
            return tasks;
        }
    }
}
