using Metrica.Dto;
using System.Collections.Generic;

namespace Web.App.Models.Sucursal
{
    public class SucursalEditorModelo
    {
        public DtoSucursal sucursal { get; set; }
        public IEnumerable<DtoBanco> bancos { get; set; }
    }
}