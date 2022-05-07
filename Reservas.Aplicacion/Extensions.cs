using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Reservas.Aplicacion.Services.Reservas;
using Reservas.Dominio.Factories.Pagos;
using Reservas.Dominio.Factories.Reservas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Reservas.Aplicacion
{
    public static class Extensions
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddTransient<IReservaService, ReservaService>();
            services.AddTransient<IReservaFactory, ReservaFactory>();

            services.AddTransient<IPagoService, PagoService>();
            services.AddTransient<IPagoFactory, PagoFactory>();

            services.AddTransient<IFacturaService, FacturaService>();
            services.AddTransient<IFacturaFactory, FacturaFactory>();

            return services;
        }

    }
}
