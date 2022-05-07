using ShareKernel.Cores;
using ShareKernel.Rules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reservas.Dominio.Models.Reservas.ValueObjects
{
    public record TipoReservaValue : ValueObject
    {
        public string Value { get; }

        public TipoReservaValue(string value)
        {
            CheckRule(new StringNotNullOrEmptyRule(value));
            //TODO: validar el formato del tipo de reserva
            Value = value;
        }


        public static implicit operator string(TipoReservaValue value)
        {
            return value.Value;
        }

        public static implicit operator TipoReservaValue(string value)
        {
            return new TipoReservaValue(value);
        }



    }
}
