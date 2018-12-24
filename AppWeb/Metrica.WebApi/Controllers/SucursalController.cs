using Metrica.Entidades;
using System.Collections.Generic;

namespace Metrica.WebApi.Controllers
{
    public class SucursalController : BaseController
    {
        public IEnumerable<DtoSucursal> GetSucursales()
        {
            return _metricaServicio.Sucursal.Listar();
        }

        public void PostSucursal(DtoSucursal sucursal)
        {
            _metricaServicio.Sucursal.Registrar(sucursal);
        }

        public void PutSucursal(DtoSucursal sucursal)
        {
            _metricaServicio.Sucursal.Actualizar(sucursal);
        }

        public DtoSucursal GetSucursal(int id)
        {
            return _metricaServicio.Sucursal.Obtener(id);
        }
        public IEnumerable<DtoSucursal> GetSucursalesPorBanco(int id)
        {
            return _metricaServicio.Sucursal.ListarPorBanco(id);
        }
        public void PutEliminaSucursal(DtoSucursal sucursal)
        {
            _metricaServicio.Sucursal.Eliminar(sucursal);
        }
    }
}