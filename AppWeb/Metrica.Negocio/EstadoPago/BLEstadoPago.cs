using Metrica.Data.EstadoPago;
using Metrica.Entidades;
using System.Collections.Generic;

namespace Metrica.Negocio.EstadoPago
{
    public class BLEstadoPago : IBLEstadoPago
    {
        private readonly IDAEstadoPago _daEstadoPago;

        public BLEstadoPago(IDAEstadoPago dataEstadoPago)
        {
            _daEstadoPago = dataEstadoPago;
        }

        public IEnumerable<DtoEstadoPago> Listar()
        {
            return _daEstadoPago.Listar();
        }
    }
}