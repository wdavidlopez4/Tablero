using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tablero.WebApi.Models;

namespace Tablero.WebApi.GraphGL.Types
{
    public class BugType : ObjectGraphType<Bug>
    {
        public BugType()
        {
            this.Name = "bug";
            ConfigurarCampos();
        }

        private void ConfigurarCampos()
        {
            Field(x => x.Id, type: typeof(IdGraphType)).Description("id de el error");
            Field(x => x.Comentario, type: typeof(StringGraphType)).Description("comentario de el error");
            Field(x => x.Descripcion, type: typeof(StringGraphType)).Description("descripcion de el error");
            Field(x => x.Encargado, type: typeof(StringGraphType)).Description("encargado de el error");
            Field(x => x.Estado, type: typeof(EstadoType)).Description("estado de el error");
            Field(x => x.Historia, type: typeof(HistoriaType)).Description("historia de el error");
            Field(x => x.IdHistoria, type: typeof(StringGraphType)).Description("id hstoria de el error");
            Field(x => x.Testeres, type: typeof(ListGraphType<StringGraphType>)).Description("testeres de el error");
        }
    }
}
