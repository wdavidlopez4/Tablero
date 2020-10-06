using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tablero.WebApi.GraphGL.Queries
{
    public class Query : ObjectGraphType
    {
        public Query()
        {
            this.Name = "Query";

            //definir queries de nivel inferior
            FieldAsync<BugQuery>("bugQuery", resolve: async Context => await Task.Run(() => new { }));
            FieldAsync<TareaQuery>("tareaQuery", resolve: async Context => await Task.Run(() => new { }));
            FieldAsync<HistoriaQuery>("historiaQuery", resolve: async Context => await Task.Run(() => new { }));
            FieldAsync<EpicQuery>("epicQuery", resolve: async Context => await Task.Run(() => new { }));
        }
    }
}
