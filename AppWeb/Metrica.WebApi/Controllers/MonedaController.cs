using Metrica.Entidades;
using System.Collections.Generic;

namespace Metrica.WebApi.Controllers
{
    public class MonedaController : BaseController
    {
        public IEnumerable<DtoMoneda> GetMonedas()
        {
            return _metricaServicio.Moneda.Listar();
        }
    }
}