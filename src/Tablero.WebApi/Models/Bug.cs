using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tablero.WebApi.Models
{
    public class Bug : ModelBase
    {
        public string Encargado { get; set; }

        public List<string> Testeres { get; set; }

    }
}
