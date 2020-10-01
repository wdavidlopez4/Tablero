using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tablero.WebApi.Models;

namespace Tablero.WebApi.Repositorio
{
    public interface IRepositorio
    {
        public Task<T> GetObjet<T>(Guid id) where T : class;

        public Task<IEnumerable<T>> GetAllObjet<T>() where T : class;
    }
}
