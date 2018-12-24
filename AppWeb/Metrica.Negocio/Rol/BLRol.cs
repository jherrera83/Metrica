using Metrica.Data.Rol;
using Metrica.Entidades;
using System.Collections.Generic;

namespace Metrica.Negocio.Rol
{
    public class BLRol : IBLRol
    {
        private readonly IDARol _daRol;

        public BLRol(IDARol daRol)
        {
            _daRol = daRol;
        }

        public IEnumerable<DtoRol> Listar()
        {
            return _daRol.Listar();
        }
    }
}