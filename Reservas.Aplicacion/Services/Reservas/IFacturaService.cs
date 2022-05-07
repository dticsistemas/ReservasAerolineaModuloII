using Reservas.Dominio.Models.Pagos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reservas.Aplicacion.Services.Reservas
{
    public interface IFacturaService
    {
        Task<string> GenerarNroFacturaAsync();

        Task<string> EnviarEmailFactura(Factura factura);
    }
}
