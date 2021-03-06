using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphQL.Server;
using GraphQL.Server.Ui.Playground;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Tablero.WebApi.GraphGL.SchemaQL;
using Tablero.WebApi.IOC;

namespace Tablero.WebApi
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            RegistarInyecciones(services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //ejecutar graphql
            app.UseGraphQL<SchemaTablero>();

            //ejecutar playground
            app.UseGraphQLPlayground(new GraphQLPlaygroundOptions());

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync("Hello World!");
                });
            });
        }

        public static void RegistarInyecciones(IServiceCollection services)
        {
            InjectionContainer.InyectarQL(services);
            InjectionContainer.InyectarServiciosApp(services);
            InjectionContainer.InyectarRepositorio(services);
            InjectionContainer.InyectarContext(services);
        }
    }
}
