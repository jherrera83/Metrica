using Metrica.Dto;
using System.Collections.Generic;

namespace Web.App.Models.OrdenPago
{
    public class OrdenPagoIndexModelo
    {
        public IEnumerable<DtoOrdenPago> ordenesPago { get; set; }
    }
}