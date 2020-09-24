using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CatalogAPI.Infrastructure;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;
using CatalogAPI.Model;

namespace CatalogAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {

            var host = CreateWebHostBuilder(args).Build();

            host.Run();
        }

        public static IHostBuilder CreateWebHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
