using Metrica.Entidades;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Collections.Generic;
using System.Data;

namespace Metrica.Data.Banco
{
    public class DABanco: IDABanco
    {
        public IEnumerable<DtoBanco> Listar()
        {
            var lista = new List<DtoBanco>();
            var oDatabase = DatabaseFactory.CreateDatabase();
            var oDbCommand = oDatabase.GetStoredProcCommand("Banco_Listar");
            using (IDataReader oReader = oDatabase.ExecuteReader(oDbCommand))
            {
                while (oReader.Read())
                {
                    lista.Add(new DtoBanco
                    {
                        IdBanco = Convert.ToInt32(oReader["IdBanco"]),
                        Nombre = oReader["Nombre"].ToString(),
                        Direccion = oReader["Direccion"].ToString()
                    });
                }
            }
            return lista;
        }
        public void Registrar(DtoBanco banco)
        {
            var oDatabase = DatabaseFactory.CreateDatabase();
            var oDbCommand = oDatabase.GetStoredProcCommand("Banco_Insertar",
                banco.Nombre ?? string.Empty,
                banco.Direccion ?? string.Empty
                );

            oDatabase.ExecuteNonQuery(oDbCommand);
        }
        public void Actualizar(DtoBanco banco)
        {

            var oDatabase = DatabaseFactory.CreateDatabase();
            var oDbCommand = oDatabase.GetStoredProcCommand("Banco_Actualizar",
                banco.IdBanco,
                banco.Nombre ?? string.Empty,
                banco.Direccion ?? string.Empty
                );

            oDatabase.ExecuteNonQuery(oDbCommand);

        }
        public void Eliminar(DtoBanco banco)
        {

            var oDatabase = DatabaseFactory.CreateDatabase();
            var oDbCommand = oDatabase.GetStoredProcCommand("Banco_Eliminar",
                banco.IdBanco
                );

            oDatabase.ExecuteNonQuery(oDbCommand);

        }
        public DtoBanco Obtener(int id)
        {
            var entidad = new DtoBanco();
            var oDatabase = DatabaseFactory.CreateDatabase();
            var oDbCommand = oDatabase.GetStoredProcCommand("Banco_Obtener",
             id);

            using (IDataReader oReader = oDatabase.ExecuteReader(oDbCommand))
            {
                while (oReader.Read())
                {
                    entidad.IdBanco = Convert.ToInt32(oReader["IdBanco"]);
                    entidad.Nombre = oReader["Nombre"].ToString();
                    entidad.Direccion = oReader["Direccion"].ToString();
                }
            }
            return entidad;
        }
    }
}