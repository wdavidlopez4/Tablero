using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tablero.WebApi.Models
{
    public class Tarea : ModelBase
    {
        public TipoTarea Tipo { get; set; }

        public string PersonaEncargado { get; set; }

        public List<string> PersonasAsociadas { get; set; }

        public Historia Historia { get; set; }

        public Guid IdHistoria { get; set; }
    }
}
