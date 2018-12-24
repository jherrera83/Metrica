using Metrica.Entidades;
using System.Collections.Generic;

namespace Metrica.Data.Sucursal
{
    public interface IDASucursal
    {
        IEnumerable<DtoSucursal> Listar();
        void Registrar(DtoSucursal Sucursal);
        void Actualizar(DtoSucursal Sucursal);
        DtoSucursal Obtener(int idSucursal);

        IEnumerable<DtoSucursal> ListarPorBanco(int id);
        void Eliminar(DtoSucursal Sucursal);
    }
}
