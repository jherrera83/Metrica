using Metrica.Dto;
using System.Collections.Generic;

namespace Web.App.Models.OrdenPago
{
    public class OrdenPagoEditorModelo
    {
        public DtoOrdenPago ordenPago { get; set; }
        public IEnumerable<DtoMoneda> monedas { get; set; }
        public IEnumerable<DtoEstadoPago> estadosPago { get; set; }
        public IEnumerable<DtoBanco> bancos { get; set; }
        public IEnumerable<DtoSucursal> sucursales { get; set; }
    }
}