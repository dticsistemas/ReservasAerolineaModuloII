using Microsoft.EntityFrameworkCore;
using Reservas.Dominio.Models.Vuelos;
using Reservas.Dominio.Repositories.Vuelos;
using Reservas.Infraestructura.EntityFramework.Contexts;
using ShareKernel.Cores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reservas.Infraestructura.EntityFramework.Repository
{
    public class VueloRepository : IVueloRepository
    {
        public readonly DbSet<Vuelo> _vuelos;

        public VueloRepository(WriteDbContext context)
        {
            _vuelos = context.Vuelo;
        }

        public async Task CreateAsync(Vuelo obj)
        {
            await _vuelos.AddAsync(obj);
        }       
        public async Task<Vuelo> FindByIdAsync(Guid id)
        {
            return await _vuelos.SingleOrDefaultAsync(x => x.Id == id);
        }

        public Task UpdateAsync(Vuelo obj)
        {
            _vuelos.Update(obj);

            return Task.CompletedTask;
        }


    }
}
