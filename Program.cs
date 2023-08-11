using System;
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

            builder.RootComponents.Add<App>("#app");
            builder.RootComponents.Add<HeadOutlet>("head::after");
            builder.Services.AddBrowserExtensionServices();
            builder.Services.AddLogging();
            await builder.Build().RunAsync();
        }
    }
}