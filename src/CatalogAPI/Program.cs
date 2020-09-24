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

            using (var db = new CatalogContext())
            {
                db.CatalogTypes.Add(new CatalogType { Type = "New Catalogtype" });
                db.SaveChanges();

                foreach (var catalogtype in db.CatalogTypes)
                {
                    Console.WriteLine(catalogtype.Type);
                }
            }
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();

            var host = CreateWebHostBuilder(args).Build();

            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                try
                {
                    var context = services.GetRequiredService<CatalogContext>();
                    //DbInitialize.Initialize(context);
                    context.GetType().ToString();
                }
                catch (Exception ex)
                {

                    var logger = services.GetRequiredService<ILogger<Program>>();
                    logger.LogError(ex, "An error occured while seeding the database.");
                }
            }
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
