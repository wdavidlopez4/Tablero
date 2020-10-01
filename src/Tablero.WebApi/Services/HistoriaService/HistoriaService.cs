using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tablero.WebApi.Models;
using Tablero.WebApi.Repositorio;

namespace Tablero.WebApi.Services.HistoriaService
{
    public class HistoriaService : IServiceHistoria
    {
        private readonly IRepositorio repositorio;

        public HistoriaService(IRepositorio repositorio)
        {
            this.repositorio = repositorio;
        }

        public async Task<Historia> ObtenerHistoria(Guid id)
        {
            if (id != null)
            {
                var historia =  await this.repositorio.GetObjet<Historia>(id);

                if (historia != null)
                {
                    return historia;
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

        public Task<IEnumerable<Historia>> ObtenerHistorias()
        {
            var historias = this.repositorio.GetAllObjet<Historia>();
            if (historias != null)
            {
                return historias;
            }
            else
            {
                return null;
            }
        }
    }
}
