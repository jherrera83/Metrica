using Metrica.Dto;
using System.Collections.Generic;

namespace Web.App.Models.OrdenPago
{
    public class OrdenPagoSeleccioneModelo
    {
        public IEnumerable<DtoBanco> bancos { get; set; }
    }
}