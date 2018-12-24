using Metrica.Entidades;
using System.Collections.Generic;

namespace Metrica.Negocio.Moneda
{
    public interface IBLMoneda
    {
        IEnumerable<DtoMoneda> Listar();
    }
}