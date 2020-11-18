using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using CatalogAPI.Domain.Interfaces;
using CatalogAPI.Domain.Models;
using CatalogAPI.Infrastructure;
using CatalogAPI.Infrastructure.Migrations;
using CatalogAPI.Infrastructure.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Microsoft.VisualBasic;
using Newtonsoft.Json;

namespace CatalogAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            this.Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                  builder =>
                  {
                      builder
                          .AllowAnyHeader()
                          .AllowAnyMethod()
                          .AllowAnyOrigin();
                  });
            });

            services.AddControllers();



            // Register the Swagger generator, defining 1 or more Swagger documents
            services.AddSwaggerGen(c =>
            {
                var xmlfile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlpath = Path.Combine(AppContext.BaseDirectory, xmlfile);

                c.IncludeXmlComments(xmlpath);
            });

            var useXml = false; // = Configuration.useXml

            if (useXml == true)
            {
                services.AddTransient<ICatalogService, CatalogXmlService>();
            }
            else
            {
                services.AddTransient<ICatalogService, CatalogEntityFrameworkService>();
                services.AddDbContext<CatalogContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            }
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //app.UseHttpsRedirection();

            app.UseStaticFiles();

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
    });

            app.UseRouting();
            app.UseCors("CorsPolicy");

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            UpdateDatabase(app);
        }

        private static void UpdateDatabase(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices
                .GetRequiredService<IServiceScopeFactory>()
                .CreateScope())
            {
                using (var context = serviceScope.ServiceProvider.GetRequiredService<CatalogContext>())
                {
                    context.Database.Migrate();
                    var jsonDataType = File.ReadAllText("TestDataType.json");
                    var jsonDataItem = File.ReadAllText("TestDataItem.json");
                    var catalogtype = JsonConvert.DeserializeObject<IEnumerable<CatalogType>>(jsonDataType);
                    var catalogitem = JsonConvert.DeserializeObject<IEnumerable<CatalogItem>>(jsonDataItem);

                    if (context.CatalogTypes.Count() == 0)
                    {
                        context.CatalogTypes.AddRange(catalogtype);
                        context.SaveChanges();
                    }

                    if (context.CatalogItems.Count() == 0)
                    {
                        context.CatalogItems.AddRange(catalogitem);
                        context.SaveChanges();
                    }

                }
            }
        }
    }
}
