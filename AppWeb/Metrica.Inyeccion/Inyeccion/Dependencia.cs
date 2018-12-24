using Transversal.Mapeo;
using Microsoft.Practices.Unity;

namespace Inyeccion.Inyeccion
{
    public class Dependencia
    {
        private static IUnityContainer _container;
        
        static Dependencia()
        {
            _container = new UnityContainer();
            ContenedorInyeccion.ObtenerRegistros(_container);
            var typeAdapterFactory = Resolve<ITypeAdapterFactory>();
            TypeAdapterFactory.SetCurrent(typeAdapterFactory);
        }

        public static T Resolve<T>()
        {
            T ret = default(T);

            if (_container.IsRegistered(typeof(T)))
            {
                ret = _container.Resolve<T>();
            }

            return ret;
        }
    }
}
