using GraphQL;
using GraphQL.Language.AST;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Threading.Tasks;
using Tablero.WebApi.GraphGL.Types;
using Tablero.WebApi.Services.EpicoService;

namespace Tablero.WebApi.GraphGL.Queries
{
    public class EpicQuery : ObjectGraphType
    {
        private readonly IServiceEpico serviceEpico;

        public EpicQuery(IServiceEpico serviceEpico)
        {
            this.Name = "epicQuery";
            this.serviceEpico = serviceEpico;

            //realizar consultas
            ObtenerEpicaPorId();
            ObtenerEpicos();
        }

        private void ObtenerEpicaPorId()
        {
            FieldAsync<EpicType>("EpicaPorId", "obtenemos la epica por id", 
                arguments: new QueryArguments(new QueryArgument<IdGraphType> { Name = "id", Description = "identificador"}), 
                resolve: async context =>
                {
                    var id = context.GetArgument<string>("id");
                    var epic = await this.serviceEpico.ObtenerEtico(Guid.Parse(id));

                    if (epic != null)
                    {
                        return epic;
                    }
                    else
                    {
                        throw new ExecutionError("parametros incorrectos para epico");
                    }
                }
                );
        }

        private void ObtenerEpicos()
        {
            FieldAsync<EpicType>("ObtenerEpicos", "obtenemos una lista de epicos",
                resolve: async context =>
                {
                    var epicos = await this.serviceEpico.ObtenerEticos();
                    if (epicos != null)
                    {
                        return epicos;
                    }
                    else
                    {
                        throw new ExecutionError("no se pudo recuperar los objetos de epico");
                    }
                });
        }
    }
}
