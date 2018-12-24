using Metrica.Entidades;
using System.Collections.Generic;

namespace Metrica.Negocio.EstadoPago
{
    public interface IBLEstadoPago
    {
        IEnumerable<DtoEstadoPago> Listar();
    }
}