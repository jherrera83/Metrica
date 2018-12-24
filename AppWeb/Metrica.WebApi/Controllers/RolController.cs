using Metrica.Entidades;
using System.Collections.Generic;

namespace Metrica.WebApi.Controllers
{
    public class RolController : BaseController
    {
        public IEnumerable<DtoRol> GetRoles()
        {
            return _metricaServicio.Rol.Listar();
        }
    }
}