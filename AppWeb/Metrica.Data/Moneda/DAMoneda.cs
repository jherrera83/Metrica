using Metrica.Entidades;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Collections.Generic;
using System.Data;

namespace Metrica.Data.Moneda
{
    public class DAMoneda : IDAMoneda
    {
        public IEnumerable<DtoMoneda> Listar()
        {
            var lista = new List<DtoMoneda>();
            var oDatabase = DatabaseFactory.CreateDatabase();
            var oDbCommand = oDatabase.GetStoredProcCommand("Moneda_Listar");
            using (IDataReader oReader = oDatabase.ExecuteReader(oDbCommand))
            {
                while (oReader.Read())
                {
                    lista.Add(new DtoMoneda
                    {
                        IdMoneda = Convert.ToInt32(oReader["IdMoneda"]),
                        Nombre = oReader["Nombre"].ToString(),
                    });
                }
            }
            return lista;
        }

    }
}