using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tablero.WebApi.Models;

namespace Tablero.WebApi.GraphGL.Types
{
    public class HistoriaType : ObjectGraphType<Historia>
    {
        public HistoriaType()
        {
            this.Name = "historia";
            ConfigurarCampos();
        }

        private void ConfigurarCampos()
        {
            Field(x => x.Id, type: typeof(IdGraphType)).Description("identificador de historia");
            Field(x => x.Bugs, type: typeof(ListGraphType<BugType>)).Description("errores de historia");
            Field(x => x.Comentario, type: typeof(StringGraphType)).Description("coment de historia");
            Field(x => x.Descripcion, type: typeof(StringGraphType)).Description("despt de historia");
            Field(x => x.Epic, type: typeof(EpicType)).Description("epico de historia");
            Field(x => x.Estado, type: typeof(EstadoType)).Description("estado de historia");
            Field(x => x.IdEpic, type: typeof(StringGraphType)).Description("id epico de historia");
            Field(x => x.PersonaEncargado, type: typeof(StringGraphType)).Description("encargado de historia");
            Field(x => x.PersonasAsociadas, type: typeof(ListGraphType<StringGraphType>)).Description("asociado de historia");
            Field(x => x.Supervisor, type: typeof(StringGraphType)).Description("supervisor de historia");
            Field(x => x.Tareas, type: typeof(ListGraphType<TareaType>)).Description("tareas de historia");

        }
    }
}
