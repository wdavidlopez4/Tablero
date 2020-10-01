using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tablero.WebApi.Models;

namespace Tablero.WebApi.Services.HistoriaService
{
    public interface IServiceHistoria
    {
        public Task<Historia> ObtenerHistoria(Guid id);

        public Task<IEnumerable<Historia>> ObtenerHistorias();
    }
}
