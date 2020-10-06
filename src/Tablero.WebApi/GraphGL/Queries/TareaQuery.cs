using GraphQL;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tablero.WebApi.GraphGL.Types;
using Tablero.WebApi.Services.TareaService;

namespace Tablero.WebApi.GraphGL.Queries
{
    public class TareaQuery : ObjectGraphType
    {
        private readonly IServiceTarea serviceTarea;

        public TareaQuery(IServiceTarea serviceTarea)
        {
            this.Name = "tareaQuery";
            this.serviceTarea = serviceTarea;

            //realizar tareas
            ObtenerTareaPorId();
            ObtenerTareas();
        }

        private void ObtenerTareaPorId()
        {
            FieldAsync<TareaType>("TareaPorId", "obtener la tarea por id", 
                arguments: new QueryArguments(new QueryArgument<IdGraphType> { Name = "id", Description = "identificador de tareas"}), 
                resolve: async context =>
                {
                    //obtenermos los argumentos y ejecutar el servicio
                    var id = context.GetArgument<string>("id");
                    var tarea= await this.serviceTarea.ObtenerTarea(Guid.Parse(id));

                    //verificamos
                    if (tarea != null)
                    {
                        return tarea;
                    }
                    else
                    {
                        throw new ExecutionError("parametros incorrectos para tarea");
                    }
                });
        }

        private void ObtenerTareas()
        {
            FieldAsync<TareaType>("ObtenerTareas", "obtener todas las tareas", 
                resolve: async context => 
                {
                    var tareas = await this.serviceTarea.ObtenerTareas();
                    if (tareas != null)
                    {
                        return tareas;
                    }
                    else
                    {
                        throw new ExecutionError("no se pudo recuperar la tarea");
                    }
                }
                );
        }
    }
}
