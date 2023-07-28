using System;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace testprog
{
    public static class Program
    {
        public static async Task Main(string[] args)
        {

            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.Services.AddScoped(sp =>
            new HttpClient
            {
                BaseAddress = new Uri("http://sed.rr22.local:8080/")
            });
            //builder.Services.AddLogging();
            builder.RootComponents.Add<App>("#app");
            builder.RootComponents.Add<HeadOutlet>("head::after");
            //builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("http://sed.rr22.local:8080/") });
            builder.Services.AddBrowserExtensionServices();
            builder.Services.AddLogging();
            //builder.Services.AddScoped(sp => );
            await builder.Build().RunAsync();
        }
    }
}