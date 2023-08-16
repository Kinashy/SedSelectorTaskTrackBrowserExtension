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
    public class GetAllControlTasksHandler : IQueryHandler<GetAllControlTasks, Task<List<SedTaskDTO>>>
    {
        private readonly HttpClient _httpClient;
        private readonly IMapper _mapper;
        public GetAllControlTasksHandler(HttpClient httpClient, IMapper mapper)
        {
            _httpClient = httpClient;
            _mapper = mapper;
        }
        public async Task<List<SedTaskDTO>> Execute(GetAllControlTasks filter)
        {
            TaskControlRequest filterDto = new();
            List<SedTaskDTO> tasks = null;
            filterDto.to = $"{filter.To.ToString("yyyy")}-{filter.To.ToString("MM")}-{filter.To.ToString("dd")}T00:00:00.000+03:00";
            filterDto.from = $"{filter.From.ToString("yyyy")}-{filter.From.ToString("MM")}-{filter.From.ToString("dd")}T00:00:00.000+03:00";
            filterDto.createFrom = $"{filter.CreateFrom.ToString("yyyy")}-{filter.CreateFrom.ToString("MM")}-{filter.CreateFrom.ToString("dd")}T00:00:00.000Z";
            filterDto.createFrom = $"{filter.CreateTo.ToString("yyyy")}-{filter.CreateTo.ToString("MM")}-{filter.CreateTo.ToString("dd")}T00:00:00.000Z";
            filterDto.token = filter.Token;
            //filterDto = _mapper.Map<TaskControlRequest>(filter);
            try
            {
                var response = await _httpClient.PostAsJsonAsync("api/task/taskControl", filterDto);
                if (response.IsSuccessStatusCode)
                {
                    List<ControlTaskEntityResponse> responsed = await response.Content.ReadFromJsonAsync<List<ControlTaskEntityResponse>>();
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
