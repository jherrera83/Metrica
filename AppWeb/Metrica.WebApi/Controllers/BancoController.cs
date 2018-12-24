using Metrica.Entidades;
using System.Collections.Generic;

namespace Metrica.WebApi.Controllers
{
    public class BancoController : BaseController
    {
        public IEnumerable<DtoBanco> GetBancos()
        {
            return _metricaServicio.Banco.Listar();
        }

        public void PostBanco(DtoBanco banco)
        {
            _metricaServicio.Banco.Registrar(banco);
        }

        public void PutBanco(DtoBanco banco)
        {
            _metricaServicio.Banco.Actualizar(banco);
        }

        public DtoBanco GetBanco(int id)
        {
            return _metricaServicio.Banco.Obtener(id);
        }
        public void PutEliminaBanco(DtoBanco banco)
        {
            _metricaServicio.Banco.Eliminar(banco);
        }
    }
}
