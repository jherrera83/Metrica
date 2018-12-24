using System.Web.Http;

namespace Metrica.WebApi
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Configuración y servicios de API web

            // Rutas de API web
            config.MapHttpAttributeRoutes();
            
            config.Routes.MapHttpRoute(
             name: "Api3",
             routeTemplate: "api/{controller}/{action}/{id}",
             defaults: new
             {
                 id = RouteParameter.Optional,

             }
         );

            config.Routes.MapHttpRoute(
           name: "Api4",
           routeTemplate: "api/{controller}/{action}/{idSucursal}/{idMoneda}",
           defaults: new
           {
               idSucursal = RouteParameter.Optional,
               idMoneda = RouteParameter.Optional
           }
       );

            config.Routes.MapHttpRoute(
              name: "Api2",
              routeTemplate: "api/{controller}/{action}"
          );

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
