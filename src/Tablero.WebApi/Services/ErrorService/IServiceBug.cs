using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tablero.WebApi.Models;

namespace Tablero.WebApi.Services.ErrorService
{
    public interface IServiceBug
    {
        public Task<Bug> ObtenerError(Guid id);

        public Task<IEnumerable<Bug>> ObtenerErrores();
    }
}
