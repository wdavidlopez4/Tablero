using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tablero.WebApi.Models;

namespace Tablero.WebApi.Services.TareaService
{
    public interface IServiceTarea
    {
        public Task<Tarea> ObtenerTarea(Guid id);

        public Task<IEnumerable<Tarea>> ObtenerTareas();
    }
}
