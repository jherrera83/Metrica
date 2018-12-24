using Metrica.Servicios;
using System.Web.Http;

namespace Metrica.WebApi.Controllers
{
    public class BaseController : ApiController
    {
        public readonly MetricaServicio _metricaServicio;

        public BaseController()
        {
            _metricaServicio = MetricaServicio.ObtenerServicio();
        }
    }
}