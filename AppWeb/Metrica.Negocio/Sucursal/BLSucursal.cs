using Metrica.Data.Sucursal;
using Metrica.Entidades;
using System.Collections.Generic;

namespace Metrica.Negocio.Sucursal
{
    public class BLSucursal : IBLSucursal
    {
        private readonly IDASucursal _daSucursal;

        public BLSucursal(IDASucursal daSucursal)
        {
            _daSucursal = daSucursal;
        }
        public IEnumerable<DtoSucursal> Listar()
        {
            return _daSucursal.Listar();
        }
        public void Registrar(DtoSucursal sucursal)
        {
            _daSucursal.Registrar(sucursal);
        }
        public void Actualizar(DtoSucursal sucursal)
        {
            _daSucursal.Actualizar(sucursal);
        }
        public DtoSucursal Obtener(int id)
        {
            return _daSucursal.Obtener(id);
        }
        public IEnumerable<DtoSucursal> ListarPorBanco(int id)
        {
            return _daSucursal.ListarPorBanco(id);
        }
        public void Eliminar(DtoSucursal sucursal)
        {
            _daSucursal.Eliminar(sucursal);
        }
    }
}