using Metrica.Dto;
using System.Collections.Generic;

namespace Metrica.Web.Models.Sucursal
{
    public class SucursalIndexModelo
    {
        public IEnumerable<DtoSucursal> sucursales { get; set; }
    }
}