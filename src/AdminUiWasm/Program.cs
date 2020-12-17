using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Tewr.Blazor.FileReader;

namespace AdminUiWasm
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");

            builder.Services.AddFileReaderService(options =>
            {
                options.UseWasmSharedBuffer = true;
            });

            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress), });
            builder.Services.AddTransient(sp => new CatalogApi.catalog_apiClient("https://localhost:5001", sp.GetService<HttpClient>()));

            await builder.Build().RunAsync();
        }
    }
}
