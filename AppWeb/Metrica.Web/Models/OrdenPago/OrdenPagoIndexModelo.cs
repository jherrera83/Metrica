using Metrica.Dto;
using System.Collections.Generic;

namespace Metrica.Web.Models.OrdenPago
{
    public class OrdenPagoIndexModelo
    {
        public IEnumerable<DtoOrdenPago> ordenesPago { get; set; }
    }
}