using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tablero.WebApi.Models
{
    public abstract class ModelBase
    {
        public Guid Id { get; set; }

        public string Descripcion { get; set; }

        public string Comentario { get; set; }

        public Estados Estado { get; set; }
    }
}
