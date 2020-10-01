using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tablero.WebApi.Models;
using Tablero.WebApi.Repositorio;

namespace Tablero.WebApi.Services.ErrorService
{
    public class BugService : IServiceBug
    {
        private readonly IRepositorio repositorio;

        public BugService(IRepositorio repositorio)
        {
            this.repositorio = repositorio;
        }

        public Task<Bug> ObtenerError(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Bug>> ObtenerErrores()
        {
            throw new NotImplementedException();
        }
    }
}
