using GraphQL;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tablero.WebApi.GraphGL.Types;
using Tablero.WebApi.Services.HistoriaService;

namespace Tablero.WebApi.GraphGL.Queries
{
    public class HistoriaQuery : ObjectGraphType
    {
        private readonly IServiceHistoria serviceHistoria;

        public HistoriaQuery(IServiceHistoria serviceHistoria)
        {
            this.Name = "historiaQuery";
            this.serviceHistoria = serviceHistoria;

            //hacemos las consultas 
            ObtenerHistoriaPorId();
            ObtenerHistorias();
        }

        private void ObtenerHistoriaPorId()
        {
            FieldAsync<HistoriaType>("HistoriaPorId", "obtenermos una historia por id",
                arguments: new QueryArguments(new QueryArgument<IdGraphType> { Name = "id", Description = "identificador de la historia"}), 
                resolve: async context =>
                {
                    //recuperar argumnetos y llamamos al servicio
                    var id = context.GetArgument<string>("id");
                    var historia =  await this.serviceHistoria.ObtenerHistoria(Guid.Parse(id));

                    //conprovar
                    if (historia != null)
                    {
                        return historia;
                    }
                    else
                    {
                        throw new ExecutionError("parametros incorrectos para historia");
                    }
                }
                );
        }

        private void ObtenerHistorias()
        {
            FieldAsync<HistoriaType>("obtenerHistorias", "obtenemos todas las historias", 
                resolve: async context => 
                {
                    var historias = await this.serviceHistoria.ObtenerHistorias();
                    if (historias != null)
                    {
                        return historias;
                    }
                    else
                    {
                        throw new ExecutionError("no se pudo recuperar los objetos de historias");
                    }
                }
                );
        }
    }
}
