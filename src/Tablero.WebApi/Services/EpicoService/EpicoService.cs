using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tablero.WebApi.Models;
using Tablero.WebApi.Repositorio;

namespace Tablero.WebApi.Services.EpicoService
{
    public class EpicoService : IServiceEpico
    {
        private readonly IRepositorio repositorio;

        public EpicoService(IRepositorio repositorio)
        {
            this.repositorio = repositorio;
        }

        public async Task<Epic> ObtenerEtico(Guid id)
        {
            if (id != null)
            {
                var epic = await this.repositorio.GetObjet<Epic>(id);
                if (epic != null)
                {
                    return epic;
                }
                else
                {
                    return null;
                }
            }
            else
            {
                return null;
            }
        }

        public async Task<IEnumerable<Epic>> ObtenerEticos()
        {
            var epics = await this.repositorio.GetAllObjet<Epic>();
            if (epics != null)
            {
                return epics;
            }
            else
            {
                return null;
            }
        }
    }
}
