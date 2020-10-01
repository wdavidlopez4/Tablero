using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tablero.WebApi.Models;
using Tablero.WebApi.Repositorio;

namespace Tablero.WebApi.Services.TareaService
{
    public class TareaService : IServiceTarea
    {
        private readonly IRepositorio repositorio;

        public TareaService(IRepositorio repositorio)
        {
            this.repositorio = repositorio;
        }

        public Task<Tarea> ObtenerTarea(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Tarea>> ObtenerTareas()
        {
            throw new NotImplementedException();
        }
    }
}
