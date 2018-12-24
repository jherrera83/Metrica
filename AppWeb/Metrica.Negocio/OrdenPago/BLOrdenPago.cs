using Metrica.Data.OrdenPago;
using Metrica.Entidades;
using System.Collections.Generic;

namespace Metrica.Negocio.OrdenPago
{
    public class BLOrdenPago : IBLOrdenPago
    {
        private readonly IDAOrdenPago _daOrdenPago;

        public BLOrdenPago(IDAOrdenPago daOrdenPago)
        {
            _daOrdenPago = daOrdenPago;
        }

        public IEnumerable<DtoOrdenPago> Listar()
        {
            return _daOrdenPago.Listar();
        }
        public void Registrar(DtoOrdenPago ordenPago)
        {
            _daOrdenPago.Registrar(ordenPago);
        }
        public void Actualizar(DtoOrdenPago ordenPago)
        {
            _daOrdenPago.Actualizar(ordenPago);
        }
        public DtoOrdenPago Obtener(int id)
        {
            return _daOrdenPago.Obtener(id);
        }

        public IEnumerable<DtoOrdenPago> ListarPorSucursalMoneda(int idSucursal, int idMoneda)
        {
            return _daOrdenPago.ListarPorSucursalMoneda(idSucursal, idMoneda);
        }
        public void Eliminar(DtoOrdenPago ordenPago)
        {
            _daOrdenPago.Eliminar(ordenPago);
        }
    }
}