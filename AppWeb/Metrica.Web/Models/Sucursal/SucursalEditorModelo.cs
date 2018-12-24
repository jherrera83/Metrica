using Metrica.Dto;
using System.Collections.Generic;

namespace Metrica.Web.Models.Sucursal
{
    public class SucursalEditorModelo
    {
        public DtoSucursal sucursal { get; set; }
        public IEnumerable<DtoBanco> bancos { get; set; }
    }
}