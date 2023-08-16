using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using SelectorExtensionForChrome.Core.Helpers;
using SelectorExtensionForChrome.CqrsCore;
using SelectorExtensionForChrome.CqrsCore.Dispatcher;
using SelectorExtensionForChrome.OptionModule.Domain.UseCases.Commands;
using SelectorExtensionForChrome.OptionModule.Domain.UseCases.Handlers.CommandHadlers;
using SelectorExtensionForChrome.OptionModule.Domain.UseCases.Handlers.QueryHandlers;
using SelectorExtensionForChrome.OptionModule.Domain.UseCases.Queries;
using SelectorExtensionForChrome.OptionModule.Infrastructure.ApiDto;
using SelectorExtensionForChrome.PopupModule.Domain;
using SelectorExtensionForChrome.PopupModule.Domain.UseCases.Commands;
using SelectorExtensionForChrome.PopupModule.Domain.UseCases.Handlers.CommandHandlers;
using SelectorExtensionForChrome.PopupModule.Domain.UseCases.Handlers.QueryHandlers;
using SelectorExtensionForChrome.PopupModule.Domain.UseCases.Queries;
using SelectorExtensionForChrome.PopupModule.Infrastructure;
using SelectorExtensionForChrome.PopupModule.Infrastructure.DTOModels;

namespace SelectorExtensionForChrome
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