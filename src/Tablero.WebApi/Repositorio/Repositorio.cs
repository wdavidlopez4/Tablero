using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tablero.WebApi.Context;

namespace Tablero.WebApi.Repositorio
{
    public class Repositorio : IRepositorio
    {
        private readonly TableroContext tableroContext;

        public Repositorio(TableroContext tableroContext)
        {
            this.tableroContext = tableroContext;
        }

        public async Task<IEnumerable<T>> GetAllObjet<T>() where T : class
        {
            try
            {
                return await this.tableroContext.Set<T>().ToListAsync();
            }
            catch (Exception e)
            {

                throw new Exception("no se pudo traer las lista de entidades", e);
            }
        }

        public async Task<T> GetObjet<T>(Guid id) where T : class
        {
            try
            {
                return await this.tableroContext.Set<T>().FindAsync(id);
            }
            catch (Exception e)
            {

                throw new Exception("no se pudo traer la entidad", e);
            }
        }
    }
}
