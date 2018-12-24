using Metrica.Dto;
using System.Collections.Generic;

namespace Web.App.Models.Sucursal
{
    public class SucursalIndexModelo
    {
        public IEnumerable<DtoSucursal> sucursales { get; set; }
    }
}