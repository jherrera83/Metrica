using Metrica.Entidades;
using System.Collections.Generic;

namespace Metrica.WebApi.Controllers
{
    public class OrdenPagoController : BaseController
    {
        public IEnumerable<DtoOrdenPago> GetOrdenesPagos()
        {
            return _metricaServicio.OrdenPago.Listar();
        }

        public void PostOrdenPago(DtoOrdenPago ordenPago)
        {
            _metricaServicio.OrdenPago.Registrar(ordenPago);
        }

        public void PutOrdenPago(DtoOrdenPago ordenPago)
        {
            _metricaServicio.OrdenPago.Actualizar(ordenPago);
        }

        public DtoOrdenPago GetOrdenPago(int id)
        {
            return _metricaServicio.OrdenPago.Obtener(id);
        }

        public IEnumerable<DtoOrdenPago> GetOrdenesPagoPorSucursalMoneda(int idSucursal, int idMoneda)
        {
            return _metricaServicio.OrdenPago.ListarPorSucursalMoneda(idSucursal, idMoneda);
        }
        public void PutEliminaOrdenPago(DtoOrdenPago ordenPago)
        {
            _metricaServicio.OrdenPago.Eliminar(ordenPago);
        }
    }
}