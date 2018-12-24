using Metrica.Entidades;
using System.Collections.Generic;

namespace Metrica.Negocio.Banco
{
    public interface IBLBanco
    {
        IEnumerable<DtoBanco> Listar();
        void Registrar(DtoBanco banco);
        void Actualizar(DtoBanco banco);
        DtoBanco Obtener(int id);
        void Eliminar(DtoBanco banco);
    }
}