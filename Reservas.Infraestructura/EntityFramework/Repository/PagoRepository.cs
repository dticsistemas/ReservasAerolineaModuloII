using Microsoft.EntityFrameworkCore;
using Reservas.Dominio.Models.Pagos;
using Reservas.Dominio.Repositories.Pagos;
using Reservas.Infraestructura.EntityFramework.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reservas.Infraestructura.EntityFramework.Repository
{
    public class PagoRepository : IPagoRepository
    {
        public readonly DbSet<Pago> _pagos;

        public PagoRepository(WriteDbContext context)
        {
            _pagos = context.Pago;
        }

        public async Task CreateAsync(Pago obj)
        {
            await _pagos.AddAsync(obj);
        }

        public async Task<Pago> FindByIdAsync(Guid id)
        {
            return await _pagos.SingleOrDefaultAsync(x => x.Id == id);
        }

        public Task UpdateAsync(Pago obj)
        {
            _pagos.Update(obj);

            return Task.CompletedTask;
        }
    }
}
