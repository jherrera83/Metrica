using Metrica.Entidades;
using System.Collections.Generic;

namespace Metrica.Negocio.Rol
{
    public interface IBLRol
    {
        IEnumerable<DtoRol> Listar();
    }
}