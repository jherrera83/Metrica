using System;

namespace Metrica.Entidades
{
    public class DtoOrdenPago
    {
        public int IdOrdenPago { get; set; }
        public int IdSucursal { get; set; }
        public decimal Monto { get; set; }
        public int IdEstadoPago { get; set; }
        public int IdMoneda { get; set; }
        public DateTime FechaPago { get; set; }
        public string NombreSucursal { get; set; }
        public string NombeBanco { get; set; }
        public string NombreMoneda { get; set; }
        public string NombreEstadoPago { get; set; }
        public int IdBanco { get; set; }
    }
}