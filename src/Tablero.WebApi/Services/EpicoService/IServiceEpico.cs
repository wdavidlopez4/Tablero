using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tablero.WebApi.Models;

namespace Tablero.WebApi.Services.EpicoService
{
    public interface IServiceEpico
    {
        public Task<Epic> ObtenerEtico(Guid id);

        public Task<IEnumerable<Epic>> ObtenerEticos();
    }
}
