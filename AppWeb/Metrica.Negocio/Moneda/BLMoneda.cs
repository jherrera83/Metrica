using Metrica.Data.Moneda;
using Metrica.Entidades;
using System.Collections.Generic;

namespace Metrica.Negocio.Moneda
{
    public class BLMoneda : IBLMoneda
    {
        private readonly IDAMoneda _daMoneda;

        public BLMoneda(IDAMoneda daMoneda)
        {
            _daMoneda = daMoneda;
        }

        public IEnumerable<DtoMoneda> Listar()
        {
            return _daMoneda.Listar();
        }
    }
}