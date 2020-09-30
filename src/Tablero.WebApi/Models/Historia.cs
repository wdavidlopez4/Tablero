using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tablero.WebApi.Models
{
    public class Historia : ModelBase
    {
        public string PersonaEncargado { get; set; }

        public List<string> PersonasAsociadas { get; set; }

        public string Supervisor { get; set; }
    }
}
