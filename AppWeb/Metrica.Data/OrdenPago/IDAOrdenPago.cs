using Metrica.Entidades;
using System.Collections.Generic;

namespace Metrica.Data.OrdenPago
{
    public interface IDAOrdenPago
    {
        IEnumerable<DtoOrdenPago> Listar();
        void Registrar(DtoOrdenPago OrdenPago);
        void Actualizar(DtoOrdenPago OrdenPago);
        DtoOrdenPago Obtener(int idOrdenPago);
        IEnumerable<DtoOrdenPago> ListarPorSucursalMoneda(int idSucursal, int idMoneda);
        void Eliminar(DtoOrdenPago OrdenPago);
    }
}