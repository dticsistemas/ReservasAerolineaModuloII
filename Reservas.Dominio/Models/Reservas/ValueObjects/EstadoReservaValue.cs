using ShareKernel.Cores;
using ShareKernel.Rules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reservas.Dominio.Models.Reservas.ValueObjects
{
    public record EstadoReservaValue : ValueObject
    {
        public string Value { get; }

        public EstadoReservaValue(string value)
        {
            CheckRule(new StringNotNullOrEmptyRule(value));
            //TODO: validar el formato del estado de reserva
            Value = value;
        }


        public static implicit operator string(EstadoReservaValue value)
        {
            return value.Value;
        }

        public static implicit operator EstadoReservaValue(string value)
        {
            return new EstadoReservaValue(value);
        }



    }
}
