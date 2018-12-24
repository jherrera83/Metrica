using Metrica.Data.Banco;
using Metrica.Entidades;
using System.Collections.Generic;

namespace Metrica.Negocio.Banco
{
    public class BLBanco : IBLBanco
    {
        private readonly IDABanco _daBanco;

        public BLBanco(IDABanco daBanco)
        {
            _daBanco = daBanco;
        }

        public IEnumerable<DtoBanco> Listar()
        {            
            return _daBanco.Listar();
        }
        public void Registrar(DtoBanco banco)
        {
            _daBanco.Registrar(banco);
        }
        public void Actualizar(DtoBanco banco)
        {
            _daBanco.Actualizar(banco);
        }
        public DtoBanco Obtener(int id)
        {
            return _daBanco.Obtener(id);
        }
        public void Eliminar(DtoBanco banco)
        {
            _daBanco.Eliminar(banco);
        }
    }
}