using Metrica.Entidades;
using System.Collections.Generic;

namespace Metrica.Data.Banco
{
    public interface IDABanco
    {
        IEnumerable<DtoBanco> Listar();
        void Registrar(DtoBanco banco);
        void Actualizar(DtoBanco banco);
        DtoBanco Obtener(int idBanco);
        void Eliminar(DtoBanco banco);
    }
}