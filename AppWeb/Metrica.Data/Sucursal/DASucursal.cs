using Metrica.Entidades;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Collections.Generic;
using System.Data;

namespace Metrica.Data.Sucursal
{
    public class DASucursal : IDASucursal
    {
        public IEnumerable<DtoSucursal> Listar()
        {
            var lista = new List<DtoSucursal>();
            var oDatabase = DatabaseFactory.CreateDatabase();
            var oDbCommand = oDatabase.GetStoredProcCommand("Sucursal_Listar");
            using (IDataReader oReader = oDatabase.ExecuteReader(oDbCommand))
            {
                while (oReader.Read())
                {
                    lista.Add(new DtoSucursal
                    {
                        IdSucursal = Convert.ToInt32(oReader["IdSucursal"]),
                        IdBanco = Convert.ToInt32(oReader["IdBanco"]),
                        Nombre = oReader["Nombre"].ToString(),
                        Direccion = oReader["Direccion"].ToString(),
                        NombreBanco = oReader["NombreBanco"].ToString(),
                    });
                }
            }
            return lista;
        }
        public void Registrar(DtoSucursal sucursal)
        {
            var oDatabase = DatabaseFactory.CreateDatabase();
            var oDbCommand = oDatabase.GetStoredProcCommand("Sucursal_Insertar",
                sucursal.IdBanco,
                sucursal.Nombre ?? string.Empty,
                sucursal.Direccion ?? string.Empty
                );

            oDatabase.ExecuteNonQuery(oDbCommand);
        }
        public void Actualizar(DtoSucursal sucursal)
        {
            var oDatabase = DatabaseFactory.CreateDatabase();
            var oDbCommand = oDatabase.GetStoredProcCommand("Sucursal_Actualizar",
                sucursal.IdSucursal,
                sucursal.IdBanco,
                sucursal.Nombre ?? string.Empty,
                sucursal.Direccion ?? string.Empty
                );

            oDatabase.ExecuteNonQuery(oDbCommand);

        }
        public DtoSucursal Obtener(int id)
        {
            var entidad = new DtoSucursal();
            var oDatabase = DatabaseFactory.CreateDatabase();
            var oDbCommand = oDatabase.GetStoredProcCommand("Sucursal_Obtener",
             id);

            using (IDataReader oReader = oDatabase.ExecuteReader(oDbCommand))
            {
                while (oReader.Read())
                {
                    entidad.IdSucursal = Convert.ToInt32(oReader["IdSucursal"]);
                    entidad.IdBanco = Convert.ToInt32(oReader["IdBanco"]);
                    entidad.Nombre = oReader["Nombre"].ToString();
                    entidad.Direccion = oReader["Direccion"].ToString();
                    entidad.NombreBanco = oReader["NombreBanco"].ToString();
                }
            }
            return entidad;
        }
        public IEnumerable<DtoSucursal> ListarPorBanco(int id)
        {
            var lista = new List<DtoSucursal>();
            var oDatabase = DatabaseFactory.CreateDatabase();
            var oDbCommand = oDatabase.GetStoredProcCommand("Sucursales_PorBanco",
             id);

            using (IDataReader oReader = oDatabase.ExecuteReader(oDbCommand))
            {
                while (oReader.Read())
                {
                    lista.Add(new DtoSucursal
                    {
                        IdSucursal = Convert.ToInt32(oReader["IdSucursal"]),
                        IdBanco = Convert.ToInt32(oReader["IdBanco"]),
                        Nombre = oReader["Nombre"].ToString(),
                        Direccion = oReader["Direccion"].ToString(),
                        NombreBanco = oReader["NombreBanco"].ToString(),
                    });
                }
            }
            return lista;
        }
        public void Eliminar(DtoSucursal sucursal)
        {
            var oDatabase = DatabaseFactory.CreateDatabase();
            var oDbCommand = oDatabase.GetStoredProcCommand("Sucursal_Eliminar",
                sucursal.IdSucursal
                );

            oDatabase.ExecuteNonQuery(oDbCommand);

        }
    }
}