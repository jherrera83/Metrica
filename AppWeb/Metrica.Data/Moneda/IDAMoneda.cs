using Metrica.Entidades;
using System.Collections.Generic;

namespace Metrica.Data.Moneda
{
    public interface IDAMoneda
    {
        IEnumerable<DtoMoneda> Listar();
    }
}
