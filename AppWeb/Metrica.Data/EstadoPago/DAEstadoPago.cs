using Metrica.Entidades;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Collections.Generic;
using System.Data;

namespace Metrica.Data.EstadoPago
{
    public class DAEstadoPago : IDAEstadoPago
    {
        public IEnumerable<DtoEstadoPago> Listar()
        {
            var lista = new List<DtoEstadoPago>();
            var oDatabase = DatabaseFactory.CreateDatabase();
            var oDbCommand = oDatabase.GetStoredProcCommand("EstadoPago_Listar");
            using (IDataReader oReader = oDatabase.ExecuteReader(oDbCommand))
            {
                while (oReader.Read())
                {
                    lista.Add(new DtoEstadoPago
                    {
                        IdEstadoPago = Convert.ToInt32(oReader["IdEstadoPago"]),
                        Nombre = oReader["Nombre"].ToString(),
                    });
                }
            }
            return lista;
        }
    }
}