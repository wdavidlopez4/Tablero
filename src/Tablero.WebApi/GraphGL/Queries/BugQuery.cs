using GraphQL;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tablero.WebApi.GraphGL.Types;
using Tablero.WebApi.Services.ErrorService;

namespace Tablero.WebApi.GraphGL.Queries
{
    public class BugQuery : ObjectGraphType
    {
        private readonly IServiceBug serviceBug;

        public BugQuery(IServiceBug serviceBug)
        {
            this.Name = "bugQuery";
            this.serviceBug = serviceBug;

            //hacer consultas
            ObtenerBugPorId();
            ObtenerBugs();
        }

        private void ObtenerBugPorId()
        {
            FieldAsync<BugType>("bugPorId", "obtener el bug por id", 
                arguments: new QueryArguments(new QueryArgument<IdGraphType> { Name = "id", Description = "identificador del bug"}), 
                resolve: async context => 
                {
                    var id = context.GetArgument<string>("id");
                    var bug = await this.serviceBug.ObtenerError(Guid.Parse(id));

                    if (bug != null)
                    {
                        return bug;
                    }
                    else
                    {
                        throw new ExecutionError("parametros incorrectos para bug");
                    }
                }
                );
        }

        private void ObtenerBugs()
        {
            FieldAsync<BugType>("ObtenerBugs", "obtenemos todos los errores", 
                resolve: async context => 
                {
                    var historias = await this.serviceBug.ObtenerErrores();
                    if (historias != null)
                    {
                        return historias;
                    }
                    else
                    {
                        throw new ExecutionError("se se pudo recuperrar los objetos bug");
                    }
                }
                );
        }
    }
}
