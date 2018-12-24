using Metrica.Entidades;
using System.Collections.Generic;

namespace Metrica.Data.EstadoPago
{
    public interface IDAEstadoPago
    {
        IEnumerable<DtoEstadoPago> Listar();
    }
}
