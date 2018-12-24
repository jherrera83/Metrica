using Metrica.Entidades;
using System.Collections.Generic;

namespace Metrica.WebApi.Controllers
{
    public class EstadoPagoController : BaseController
    {
        public IEnumerable<DtoEstadoPago> GetEstadosPago()
        {
            return _metricaServicio.EstadoPago.Listar();
        }
    }
}