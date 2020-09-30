using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tablero.WebApi.Models
{
    public enum Estados
    {
        activo = 0, 
        inactivo = 2,
        completado = 3,
        erronero = 4,
        faltante = 5
    }
}
