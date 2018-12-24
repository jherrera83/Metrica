using Metrica.Entidades;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Collections.Generic;
using System.Data;

namespace Metrica.Data.OrdenPago
{
    public class DAOrdenPago : IDAOrdenPago
    {
        public IEnumerable<DtoOrdenPago> Listar()
        {
            var lista = new List<DtoOrdenPago>();
            var oDatabase = DatabaseFactory.CreateDatabase();
            var oDbCommand = oDatabase.GetStoredProcCommand("OrdenPago_Listar");
            using (IDataReader oReader = oDatabase.ExecuteReader(oDbCommand))
            {
                while (oReader.Read())
                {
                    lista.Add(new DtoOrdenPago
                    {
                        IdOrdenPago = Convert.ToInt32(oReader["IdOrdenPago"]),
                        IdSucursal = Convert.ToInt32(oReader["IdSucursal"]),
                        IdMoneda = Convert.ToInt32(oReader["IdMoneda"]),
                        Monto = Convert.ToDecimal(oReader["Monto"]),
                        IdEstadoPago = Convert.ToInt32(oReader["IdEstadoPago"]),
                        FechaPago = Convert.ToDateTime(oReader["FechaPago"]),
                        NombreMoneda = oReader["NombreMoneda"].ToString(),
                        NombreEstadoPago = oReader["NombreEstadoPago"].ToString(),
                        NombreSucursal = oReader["NombreSucursal"].ToString(),
                        NombeBanco = oReader["NombreBanco"].ToString(),
                    });
                }
            }
            return lista;
        }
        public void Registrar(DtoOrdenPago ordenPago)
        {
            var oDatabase = DatabaseFactory.CreateDatabase();
            var oDbCommand = oDatabase.GetStoredProcCommand("OrdenPago_Insertar",
               ordenPago.IdSucursal,
               ordenPago.IdMoneda,
               ordenPago.Monto,
               ordenPago.IdEstadoPago
                );

            oDatabase.ExecuteNonQuery(oDbCommand);
        }
        public void Actualizar(DtoOrdenPago ordenPago)
        {
            var oDatabase = DatabaseFactory.CreateDatabase();
            var oDbCommand = oDatabase.GetStoredProcCommand("OrdenPago_Actualizar",
                ordenPago.IdOrdenPago,
               ordenPago.IdSucursal,
               ordenPago.IdMoneda,
               ordenPago.Monto,
               ordenPago.IdEstadoPago
                );

            oDatabase.ExecuteNonQuery(oDbCommand);

        }
        public DtoOrdenPago Obtener(int id)
        {
            var entidad = new DtoOrdenPago();
            var oDatabase = DatabaseFactory.CreateDatabase();
            var oDbCommand = oDatabase.GetStoredProcCommand("OrdenPago_Obtener",
             id);

            using (IDataReader oReader = oDatabase.ExecuteReader(oDbCommand))
            {
                while (oReader.Read())
                {
                    entidad.IdOrdenPago = Convert.ToInt32(oReader["IdOrdenPago"]);
                    entidad.IdSucursal = Convert.ToInt32(oReader["IdSucursal"]);
                    entidad.IdMoneda = Convert.ToInt32(oReader["IdMoneda"]);
                    entidad.Monto = Convert.ToDecimal(oReader["Monto"]);
                    entidad.IdEstadoPago = Convert.ToInt32(oReader["IdEstadoPago"]);
                    entidad.FechaPago = Convert.ToDateTime(oReader["FechaPago"]);
                    entidad.IdBanco = Convert.ToInt32(oReader["IdBanco"]);
                    entidad.NombreMoneda = oReader["NombreMoneda"].ToString();
                    entidad.NombreEstadoPago = oReader["NombreEstadoPago"].ToString();
                    entidad.NombreSucursal = oReader["NombreSucursal"].ToString();
                    entidad.NombeBanco = oReader["NombreBanco"].ToString();
                }
            }

            return entidad;
        }
        public IEnumerable<DtoOrdenPago> ListarPorSucursalMoneda(int idSucursal, int idMoneda)
        {
            var lista = new List<DtoOrdenPago>();
            var oDatabase = DatabaseFactory.CreateDatabase();
            var oDbCommand = oDatabase.GetStoredProcCommand("OrdenesPago_PorSucursalMoneda");
            using (IDataReader oReader = oDatabase.ExecuteReader(oDbCommand))
            {
                while (oReader.Read())
                {
                    lista.Add(new DtoOrdenPago
                    {
                        IdOrdenPago = Convert.ToInt32(oReader["IdOrdenPago"]),
                        IdSucursal = Convert.ToInt32(oReader["IdSucursal"]),
                        IdMoneda = Convert.ToInt32(oReader["IdMoneda"]),
                        Monto = Convert.ToDecimal(oReader["Monto"]),
                        IdEstadoPago = Convert.ToInt32(oReader["IdEstadoPago"]),
                        FechaPago = Convert.ToDateTime(oReader["FechaPago"]),
                        NombreMoneda = oReader["NombreMoneda"].ToString(),
                        NombreEstadoPago = oReader["NombreEstadoPago"].ToString(),
                        NombreSucursal = oReader["NombreSucursal"].ToString(),
                        NombeBanco = oReader["NombreBanco"].ToString(),
                    });
                }
            }
            return lista;
        }
        public void Eliminar(DtoOrdenPago ordenPago)
        {
            var oDatabase = DatabaseFactory.CreateDatabase();
            var oDbCommand = oDatabase.GetStoredProcCommand("OrdenPago_Eliminar",
                ordenPago.IdOrdenPago
                );

            oDatabase.ExecuteNonQuery(oDbCommand);

        }
    }
}