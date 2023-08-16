using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using testprog.Core.Helpers;
using testprog.CqrsCore;
using testprog.CqrsCore.Dispatcher;
using testprog.OptionModule.Domain.UseCases.Commands;
using testprog.OptionModule.Domain.UseCases.Handlers.CommandHadlers;
using testprog.OptionModule.Domain.UseCases.Handlers.QueryHandlers;
using testprog.OptionModule.Domain.UseCases.Queries;
using testprog.OptionModule.Infrastructure.ApiDto;
using testprog.PopupModule.Domain;
using testprog.PopupModule.Domain.UseCases.Commands;
using testprog.PopupModule.Domain.UseCases.Handlers.CommandHandlers;
using testprog.PopupModule.Domain.UseCases.Handlers.QueryHandlers;
using testprog.PopupModule.Domain.UseCases.Queries;
using testprog.PopupModule.Infrastructure;
using testprog.PopupModule.Infrastructure.DTOModels;

namespace testprog
{
    public static class Program
    {
        //public static IMapper MyMapper { get; set; }

        public static async Task Main(string[] args)
        {

            var builder = WebAssemblyHostBuilder.CreateDefault();
            //var services = builder.Services.AddBrowserExtensionServices();
            //services.AddSingleton();
            HttpClient client = new HttpClient
            {
                BaseAddress = new Uri("http://sed.rr22.local:8080/")
            };
            //builder.Services.AddLogging();
            var mapperConfiguration = new MapperConfiguration(x =>
            {
                x.AddProfile<MappingProfile>();
            });
            mapperConfiguration.AssertConfigurationIsValid();
            IMapper MyMapper;
            MyMapper = mapperConfiguration.CreateMapper();
            builder.Services.AddSingleton<HttpClient>(client);
            builder.Services.AddSingleton<IQueryDispatcher, QueryDispatcher>();
            builder.Services.AddSingleton<ICommandDispatcher, CommandDispatcher>();
            builder.Services.AddSingleton<IMapper>(MyMapper);
            builder.Services.AddSingleton<IQueryHandler<Login, Task<LoginEntityResponse>>, LoginHandler>();
            builder.Services.AddSingleton<IQueryHandler<GetStorageFieldValue, Task<string?>>, GetStorageFieldValueHandler>();
            builder.Services.AddSingleton<ICommandHandler<SetUserInformation>, SetUserInformationHandler>();
            builder.Services.AddSingleton<ISedTaskRepository, SedTaskRepository>();
            builder.Services.AddSingleton<IQueryHandler<GetAllControlTasks, Task<List<SedTaskDTO>>>, GetAllControlTasksHandler>();
            builder.Services.AddSingleton<IQueryHandler<GetAllDatesOfTasks, List<DateTime>>, GetAllDatesOfTasksHandler>();
            builder.Services.AddSingleton<IQueryHandler<GetSedTasksByDate, List<SedTaskDTO>>, GetSedTasksByDateHandler>();
            builder.Services.AddSingleton<ICommandHandler<AddSedTasks>, AddSedTasksHandler>();
            builder.Services.AddSingleton<ICommandHandler<RemoveAllSedTasks>, RemoveAllSedTasksHandler>();
            builder.RootComponents.Add<App>("#app");
            builder.RootComponents.Add<HeadOutlet>("head::after");
            builder.Services.AddBrowserExtensionServices();
            builder.Services.AddLogging();
            await builder.Build().RunAsync();
        }
    }
}