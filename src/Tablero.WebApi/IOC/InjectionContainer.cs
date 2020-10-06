using GraphQL;
using GraphQL.Server;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tablero.WebApi.Context;
using Tablero.WebApi.GraphGL.SchemaQL;
using Tablero.WebApi.Repositorio;
using Tablero.WebApi.Services.EpicoService;
using Tablero.WebApi.Services.ErrorService;
using Tablero.WebApi.Services.HistoriaService;
using Tablero.WebApi.Services.TareaService;

namespace Tablero.WebApi.IOC
{
    public class InjectionContainer
    {
        public static void InyectarQL(IServiceCollection service)
        {
            //configuar servidor de pruebas para la api kestrel "se deme configurar con IIS para el despliege"
            service.Configure<KestrelServerOptions>(ops => { ops.AllowSynchronousIO = true; });

            //configurar schema
            service.AddScoped<IDependencyResolver>(x => new FuncDependencyResolver(x.GetRequiredService));
            service.AddScoped<SchemaTablero>();

            //confirmar si se configuro graphql "muestra las execciones en tiempo de desarrollo"
            service.AddGraphQL(x => { x.ExposeExceptions = true; }).AddGraphTypes(ServiceLifetime.Scoped);
        }

        public static void InyectarServiciosApp(IServiceCollection service)
        {
            service.AddScoped<IServiceBug, BugService>();
            service.AddScoped<IServiceTarea, TareaService>();
            service.AddScoped<IServiceHistoria, HistoriaService>();
            service.AddScoped<IServiceEpico, EpicoService>();
        }

        public static void InyectarContext(IServiceCollection service)
        {
            //configurar db 
            service.AddDbContext<TableroContext>(options => options.UseInMemoryDatabase(databaseName: "test"));
        }

        public static void InyectarRepositorio(IServiceCollection service)
        {
            service.AddScoped<IRepositorio, RepositorioTablero>();
        }


    }
}
