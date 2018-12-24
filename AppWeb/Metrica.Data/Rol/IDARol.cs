using Metrica.Entidades;
using System.Collections.Generic;

namespace Metrica.Data.Rol
{
    public interface IDARol
    {
        IEnumerable<DtoRol> Listar();
    }
}