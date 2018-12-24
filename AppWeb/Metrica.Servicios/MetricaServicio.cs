using Inyeccion.Inyeccion;
using Metrica.Negocio.Banco;
using Metrica.Negocio.EstadoPago;
using Metrica.Negocio.Moneda;
using Metrica.Negocio.OrdenPago;
using Metrica.Negocio.Rol;
using Metrica.Negocio.Sucursal;

namespace Metrica.Servicios
{
    public class MetricaServicio
    {
        private static MetricaServicio _metricaServicio = null;

        public IBLBanco Banco { get { return Dependencia.Resolve<IBLBanco>(); } }
        public IBLEstadoPago EstadoPago { get { return Dependencia.Resolve<IBLEstadoPago>(); } }
        public IBLMoneda Moneda { get { return Dependencia.Resolve<IBLMoneda>(); } }
        public IBLOrdenPago OrdenPago { get { return Dependencia.Resolve<IBLOrdenPago>(); } }
        public IBLRol Rol { get { return Dependencia.Resolve<IBLRol>(); } }
        public IBLSucursal Sucursal { get { return Dependencia.Resolve<IBLSucursal>(); } }

        public MetricaServicio() { }

        public static MetricaServicio ObtenerServicio()
        {
            if (_metricaServicio == null)
                _metricaServicio = new MetricaServicio();
            return _metricaServicio;
        }

    }
}