using Metrica.Entidades;
using System.Collections.Generic;

namespace Metrica.Negocio.Sucursal
{
    public interface IBLSucursal
    {
        IEnumerable<DtoSucursal> Listar();
        void Registrar(DtoSucursal Sucursal);
        void Actualizar(DtoSucursal Sucursal);
        DtoSucursal Obtener(int id);
        IEnumerable<DtoSucursal> ListarPorBanco(int id);
        void Eliminar(DtoSucursal Sucursal);
    }
}