using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Reservas.Dominio.Repositories;
using Reservas.Dominio.Repositories.Reservas;
using Reservas.Infraestructura.EntityFramework;
using Reservas.Infraestructura.MemoryRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

using Reservas.Aplicacion;
using Reservas.Infraestructura.EntityFramework.Contexts;
using Microsoft.EntityFrameworkCore;
using Reservas.Infraestructura.EntityFramework.Repository;
using Reservas.Dominio.Repositories.Pagos;
using Reservas.Dominio.Repositories.Vuelos;

namespace Reservas.Infraestructura
{
    public static class Extensions
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddApplication();
            services.AddMediatR(Assembly.GetExecutingAssembly());

            var connectionString =
                configuration.GetConnectionString("ReservaDbConnectionString");

            services.AddDbContext<ReadDbContext>(context =>
                context.UseSqlServer(connectionString));
            services.AddDbContext<WriteDbContext>(context =>
                context.UseSqlServer(connectionString));

            services.AddScoped<IReservaRepository, ReservaRepository>();

            services.AddScoped<IVueloRepository, VueloRepository>();

            services.AddScoped<IPagoRepository, PagoRepository>();

            services.AddScoped<IFacturaRepository, FacturaRepository>();


            services.AddScoped<IUnitOfWork, UnitOfWork>();


            return services;
        }


    }
}
