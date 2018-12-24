using Metrica.Dto;
using System.Collections.Generic;

namespace Metrica.Web.Models.OrdenPago
{
    public class OrdenPagoSeleccioneModelo
    {
        public IEnumerable<DtoBanco> bancos { get; set; }
    }
}