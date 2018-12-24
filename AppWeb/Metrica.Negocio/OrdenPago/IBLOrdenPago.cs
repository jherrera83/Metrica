using Metrica.Entidades;
using System.Collections.Generic;

namespace Metrica.Negocio.OrdenPago
{
    public interface IBLOrdenPago
    {
        IEnumerable<DtoOrdenPago> Listar();
        void Registrar(DtoOrdenPago OrdenPago);
        void Actualizar(DtoOrdenPago OrdenPago);
        DtoOrdenPago Obtener(int id);
        IEnumerable<DtoOrdenPago> ListarPorSucursalMoneda(int idSucursal, int idMoneda);
        void Eliminar(DtoOrdenPago OrdenPago);
    }
}