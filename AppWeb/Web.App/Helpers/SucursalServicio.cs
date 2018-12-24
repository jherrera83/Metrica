using Metrica.Dto;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Web.App.Helpers
{
    public class SucursalServicio
    {
        #region PROPIEDADES       
        HttpClient client = new HttpClient();
        #endregion

        #region CONSTRUCTOR
        public SucursalServicio()
        {
            client.BaseAddress = new Uri("http://localhost:65099/api/Sucursal/");
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
        }
        #endregion

        public async Task<IEnumerable<DtoSucursal>> Listar()
        {

            HttpResponseMessage response = await client.GetAsync("GetSucursales");
            if (response.IsSuccessStatusCode)
            {
                var stringResult = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<DtoSucursal>>(stringResult);
            }
            return new List<DtoSucursal>();
        }

        public async Task<DtoSucursal> Obtener(int id)
        {
            HttpResponseMessage response = await client.GetAsync(string.Format("GetSucursal/{0}", id.ToString()));
            if (response.IsSuccessStatusCode)
            {
                var stringResult = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<DtoSucursal>(stringResult);
            }
            return new DtoSucursal();
        }

        public async Task Registrar(DtoSucursal Sucursal)
        {
            var myContent = JsonConvert.SerializeObject(Sucursal);
            var buffer = System.Text.Encoding.UTF8.GetBytes(myContent);
            var byteContent = new ByteArrayContent(buffer);
            byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            HttpResponseMessage response = await client.PostAsync("PostSucursal", byteContent);
            if (response.IsSuccessStatusCode)
            {

            }

        }

        public async Task Actualizar(DtoSucursal Sucursal)
        {
            var myContent = JsonConvert.SerializeObject(Sucursal);
            var buffer = System.Text.Encoding.UTF8.GetBytes(myContent);
            var byteContent = new ByteArrayContent(buffer);
            byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            HttpResponseMessage response = await client.PutAsync("PutSucursal", byteContent);
            if (response.IsSuccessStatusCode)
            {

            }

        }

        public async Task Eliminar(DtoSucursal Sucursal)
        {
            var myContent = JsonConvert.SerializeObject(Sucursal);
            var buffer = System.Text.Encoding.UTF8.GetBytes(myContent);
            var byteContent = new ByteArrayContent(buffer);
            byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            HttpResponseMessage response = await client.PutAsync("PutEliminaSucursal", byteContent);
            if (response.IsSuccessStatusCode)
            {

            }

        }

        public async Task<IEnumerable<DtoSucursal>> ListarPorBanco(int id)
        {

            HttpResponseMessage response = await client.GetAsync(string.Format("GetSucursalesPorBanco/{0}", id.ToString()));
            if (response.IsSuccessStatusCode)
            {
                var stringResult = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<DtoSucursal>>(stringResult);
            }
            return new List<DtoSucursal>();
        }
    }
}
