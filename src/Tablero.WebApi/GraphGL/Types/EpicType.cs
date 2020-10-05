using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tablero.WebApi.Models;

namespace Tablero.WebApi.GraphGL.Types
{
    public class EpicType : ObjectGraphType<Epic>
    {
        public EpicType()
        {
            this.Name = "epic";
        }

        private void ConfigurarCampos()
        {
            Field(x => x.Id, type: typeof(IdGraphType)).Description("identificador de epic");
            Field(x => x.Comentario, type: typeof(StringGraphType)).Description("comentario de epic");
            Field(x => x.Descripcion, type: typeof(StringGraphType)).Description("desp de epic");
            Field(x => x.DuracionDeSpring, type: typeof(IntGraphType)).Description("duracion de epic");
            Field(x => x.Estado, type: typeof(EstadoType)).Description("estdao de epic");
            Field(x => x.Historias, type: typeof(ListGraphType<HistoriaType>)).Description("hists de epic");
            Field(x => x.ObjetivoGeneral, type: typeof(StringGraphType)).Description("objetivo de epic");
        }
    }
}
