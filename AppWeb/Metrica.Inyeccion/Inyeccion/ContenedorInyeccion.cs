#region ESPACIOS DE NOMBRES

using Metrica.Data.Banco;
using Metrica.Data.EstadoPago;
using Metrica.Data.Moneda;
using Metrica.Data.OrdenPago;
using Metrica.Data.Rol;
using Metrica.Data.Sucursal;
using Metrica.Negocio.Banco;
using Metrica.Negocio.EstadoPago;
using Metrica.Negocio.Moneda;
using Metrica.Negocio.OrdenPago;
using Metrica.Negocio.Rol;
using Metrica.Negocio.Sucursal;
using Microsoft.Practices.Unity;
using Transversal.Mapeo;

#endregion

namespace Inyeccion.Inyeccion
{
    /// <summary>
    /// Contenedor de Contratos y Implementacion
    /// </summary>
    public sealed class ContenedorInyeccion
    {

        /// <summary>
        /// Flujo base
        /// </summary>
        /// <param name="container">container</param>
        public static void ObtenerRegistros(IUnityContainer container)
        {
            RegistroBase(container);
            RegistroAccesoData(container);
            RegistroNegocio(container);
        }

        /// <summary>
        /// RegistroBase
        /// </summary>
        /// <param name="container">container</param>
        private static void RegistroBase(IUnityContainer container)
        {
            //BASE
            container.RegisterType<ITypeAdapterFactory, AutomapperTypeAdapterFactory>(new ContainerControlledLifetimeManager());//Singleton
        }

        /// <summary>
        /// RegistroRepositorios
        /// </summary>
        /// <param name="container">container</param>
        private static void RegistroAccesoData(IUnityContainer container)
        {
            container.RegisterType<IDABanco, DABanco>(new TransientLifetimeManager());
            container.RegisterType<IDAEstadoPago, DAEstadoPago>(new TransientLifetimeManager());
            container.RegisterType<IDAMoneda, DAMoneda>(new TransientLifetimeManager());
            container.RegisterType<IDAOrdenPago, DAOrdenPago>(new TransientLifetimeManager());
            container.RegisterType<IDARol, DARol>(new TransientLifetimeManager());
            container.RegisterType<IDASucursal, DASucursal>(new TransientLifetimeManager());
        }

        /// <summary>
        /// RegistroServicios
        /// </summary>
        /// <param name="container">container</param>
        private static void RegistroNegocio(IUnityContainer container)
        {

            container.RegisterType<IBLBanco, BLBanco>(new TransientLifetimeManager());
            container.RegisterType<IBLEstadoPago, BLEstadoPago>(new TransientLifetimeManager());
            container.RegisterType<IBLMoneda, BLMoneda>(new TransientLifetimeManager());
            container.RegisterType<IBLOrdenPago, BLOrdenPago>(new TransientLifetimeManager());
            container.RegisterType<IBLRol, BLRol>(new TransientLifetimeManager());
            container.RegisterType<IBLSucursal, BLSucursal>(new TransientLifetimeManager());
        }

    }
}