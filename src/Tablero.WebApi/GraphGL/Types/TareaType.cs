using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tablero.WebApi.Models;

namespace Tablero.WebApi.GraphGL.Types
{
    public class TareaType : ObjectGraphType<Tarea>
    {
        public TareaType()
        {
            this.Name = "tarea";
            ConfigurarCampos();
        }

        private void ConfigurarCampos()
        {
            Field(x => x.Id, type: typeof(IdGraphType)).Description("identificador de la tarea");
            Field(x => x.Comentario, type: typeof(StringGraphType)).Description("comentario de la tarea");
            Field(x => x.Descripcion, type: typeof(StringGraphType)).Description("descripcion de la tarea");
            Field(x => x.Estado, type: typeof(EstadoType)).Description("estado de la tarea");
            Field(x => x.Historia, type: typeof(HistoriaType)).Description("historia de la tarea");
            Field(x => x.IdHistoria, type: typeof(StringGraphType)).Description("identificador historia de la tarea");
            Field(x => x.PersonaEncargado, type: typeof(StringGraphType)).Description("encargado de la tarea");
            Field(x => x.PersonasAsociadas, type: typeof(ListGraphType<StringGraphType>)).Description("asociados de la tarea");
            Field(x => x.Tipo, type: typeof(TipoType)).Description("tipo de tarea");
        }
    }
}
