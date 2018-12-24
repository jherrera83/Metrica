using Metrica.Dto;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Metrica.Web.Helpers
{
    public class OrdenPagoServicio
    {
        #region PROPIEDADES       
        HttpClient client = new HttpClient();
        #endregion

        #region CONSTRUCTOR
        public OrdenPagoServicio()
        {
            client.BaseAddress = new Uri("http://localhost:65099/api/OrdenPago/");
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
        }
        #endregion

        public async Task<IEnumerable<DtoOrdenPago>> Listar()
        {

            HttpResponseMessage response = await client.GetAsync("GetOrdenesPagos");
            if (response.IsSuccessStatusCode)
            {
                var stringResult = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<DtoOrdenPago>>(stringResult);
            }
            return new List<DtoOrdenPago>();
        }

        public async Task<DtoOrdenPago> Obtener(int id)
        {
            HttpResponseMessage response = await client.GetAsync(string.Format("GetOrdenPago/{0}", id.ToString()));
            if (response.IsSuccessStatusCode)
            {
                var stringResult = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<DtoOrdenPago>(stringResult);
            }
            return new DtoOrdenPago();
        }

        public async Task Registrar(DtoOrdenPago OrdenPago)
        {
            var myContent = JsonConvert.SerializeObject(OrdenPago);
            var buffer = System.Text.Encoding.UTF8.GetBytes(myContent);
            var byteContent = new ByteArrayContent(buffer);
            byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            HttpResponseMessage response = await client.PostAsync("PostOrdenPago", byteContent);
            if (response.IsSuccessStatusCode)
            {

            }
        }

        public async Task Actualizar(DtoOrdenPago OrdenPago)
        {
            var myContent = JsonConvert.SerializeObject(OrdenPago);
            var buffer = System.Text.Encoding.UTF8.GetBytes(myContent);
            var byteContent = new ByteArrayContent(buffer);
            byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            HttpResponseMessage response = await client.PutAsync("PutOrdenPago", byteContent);
            if (response.IsSuccessStatusCode)
            {

            }
        }

        public async Task Eliminar(DtoOrdenPago OrdenPago)
        {
            var myContent = JsonConvert.SerializeObject(OrdenPago);
            var buffer = System.Text.Encoding.UTF8.GetBytes(myContent);
            var byteContent = new ByteArrayContent(buffer);
            byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            HttpResponseMessage response = await client.PutAsync("PutEliminaOrdenPago", byteContent);
            if (response.IsSuccessStatusCode)
            {

            }

        }


    }
}
