using ShareKernel.Cores;
using ShareKernel.Rules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reservas.Dominio.Models.Pagos.ValueObjetcs
{
    public record CodigoComprobanteValue : ValueObject
    {
        public string Value { get; }

        public CodigoComprobanteValue(string value)
        {
            CheckRule(new StringNotNullOrEmptyRule(value));
            //TODO: validar el formato del codigo de reserva
            Value = value;
        }


        public static implicit operator string(CodigoComprobanteValue value)
        {
            return value.Value;
        }

        public static implicit operator CodigoComprobanteValue(string value)
        {
            return new CodigoComprobanteValue(value);
        }



    }
}
