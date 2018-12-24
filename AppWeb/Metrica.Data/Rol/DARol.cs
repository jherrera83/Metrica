using Metrica.Entidades;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Collections.Generic;
using System.Data;

namespace Metrica.Data.Rol
{
    public class DARol : IDARol
    {
        public IEnumerable<DtoRol> Listar()
        {
            var lista = new List<DtoRol>();
            var oDatabase = DatabaseFactory.CreateDatabase();
            var oDbCommand = oDatabase.GetStoredProcCommand("Rol_Listar");
            using (IDataReader oReader = oDatabase.ExecuteReader(oDbCommand))
            {
                while (oReader.Read())
                {
                    lista.Add(new DtoRol
                    {
                        IdRol = Convert.ToInt32(oReader["IdRol"]),
                        Nombre = oReader["Nombre"].ToString(),
                    });
                }
            }
            return lista;
        }
    }
}