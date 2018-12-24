using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;

namespace Transversal.Mapeo
{
    /// <summary>
    /// Extensiones de maper, 
    /// </summary>
    public static class ProjectionsExtensionMethods
    {
        
        /// <summary>
        /// Proyecta como la entidad solicitada
        /// </summary>
        /// <typeparam name="TProjection">entidad solicitada</typeparam>
        /// <param name="item">elemento a proyectar</param>
        /// <returns>entidad proyectada</returns>
        public static TProjection ProyectarComo<TProjection>(this Object item)
            where TProjection : class,new()
        {
            if (item == null) return null;
            var adapter = TypeAdapterFactory.CreateAdapter();
            return adapter.Adapt<TProjection>(item);
        }

        
        /// <summary>
        /// Proyecta una lista a otro tipo de lista.
        /// </summary>
        /// <typeparam name="TSource">Tipo Origen</typeparam>
        /// <typeparam name="TProjection">Tipo Destino</typeparam>
        /// <param name="items">Lista</param>
        /// <returns>Lista Proyectada</returns>
        public static List<TProjection> ProyectarComoLista<TSource, TProjection>(this IEnumerable<TSource> items)
            where TProjection : class
        {
            if (items == null) return null;
            if (!items.Any()) return new List<TProjection>();

            var adapter = TypeAdapterFactory.CreateAdapter();
            return adapter.Adapt<List<TProjection>>(items);
        }

        /// <summary>
        /// Proyecta una lista de objetos en un lista del tipo destino.
        /// </summary>
        /// <typeparam name="TProjection">Tipo destino</typeparam>
        /// <param name="items">Lista de objetos</param>
        /// <returns>Lista Proyectada</returns>
        public static List<TProjection> ProyectarComoLista<TProjection>(this IEnumerable<object> items)
            where TProjection : class,new()
        {
            try
            {
                if (items == null) return null;
                if (!items.Any()) return new List<TProjection>();

                var adapter = TypeAdapterFactory.CreateAdapter();
                return adapter.Adapt<List<TProjection>>(items);
            }
            catch (Exception ex)
            {

                throw ex;
            }
            
        }

        /// <summary>
        /// Proyecta un diccionario como lista
        /// </summary>
        /// <typeparam name="TProjection">Tipo destino</typeparam>
        /// <param name="items">Diccionario</param>
        /// <returns>Lista proyectada</returns>
        public static List<TProjection> ProyectarComoLista<TProjection>(this Dictionary<string, string> items)
            where TProjection : class,new()
        {
            if (items == null) return null;
            if (!items.Any()) return new List<TProjection>();

            var adapter = TypeAdapterFactory.CreateAdapter();
            return adapter.Adapt<List<TProjection>>(items);
        }

        /// <summary>
        /// Converts a DataTable to a list with generic objects
        /// </summary>
        /// <typeparam name="T">Generic object</typeparam>
        /// <param name="table">DataTable</param>
        /// <returns>List with generic objects</returns>
        public static List<T> DataTableToList<T>(this DataTable table) where T : class, new()
        {
            try
            {
                List<T> list = new List<T>();

                foreach (var row in table.AsEnumerable())
                {
                    T obj = new T();

                    foreach (var prop in obj.GetType().GetProperties())
                    {
                        try
                        {
                            PropertyInfo propertyInfo = obj.GetType().GetProperty(prop.Name);
                            propertyInfo.SetValue(obj, Convert.ChangeType(row[prop.Name], propertyInfo.PropertyType), null);
                        }
                        catch
                        {
                            continue;
                        }
                    }

                    list.Add(obj);
                }

                return list;
            }
            catch
            {
                return null;
            }
        }
    }
}
