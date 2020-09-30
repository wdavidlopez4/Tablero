using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tablero.WebApi.Models
{
    public class Epic : ModelBase
    {
        public string ObjetivoGeneral { get; set; }

        public int DuracionDeSpring { get; set; }

        public List<Historia> Historias { get; set; }

    }
}
