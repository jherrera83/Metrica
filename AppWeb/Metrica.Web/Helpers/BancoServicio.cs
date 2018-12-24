using Metrica.Dto;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Metrica.Web.Helpers
{
    public class BancoServicio
    {
        #region PROPIEDADES       
        HttpClient client = new HttpClient();
        #endregion

        #region CONSTRUCTOR
        public BancoServicio()
        {
            client.BaseAddress = new Uri("http://localhost:65099/api/Banco/");
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
        }
        #endregion

        public async Task<IEnumerable<DtoBanco>> Listar()
        {

            HttpResponseMessage response = await client.GetAsync("GetBancos");
            if (response.IsSuccessStatusCode)
            {
                var stringResult = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<DtoBanco>>(stringResult);
            }
            return new List<DtoBanco>();
        }

        public async Task<DtoBanco> Obtener(int id)
        {
            HttpResponseMessage response = await client.GetAsync(string.Format("GetBanco/{0}", id.ToString()));
            if (response.IsSuccessStatusCode)
            {
                var stringResult = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<DtoBanco>(stringResult);
            }
            return new DtoBanco();
        }

        public async Task Registrar(DtoBanco banco)
        {
            var myContent = JsonConvert.SerializeObject(banco);
            var buffer = System.Text.Encoding.UTF8.GetBytes(myContent);
            var byteContent = new ByteArrayContent(buffer);
            byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            HttpResponseMessage response = await client.PostAsync("PostBanco", byteContent);
            if (response.IsSuccessStatusCode)
            {

            }

        }

        public async Task Actualizar(DtoBanco banco)
        {
            var myContent = JsonConvert.SerializeObject(banco);
            var buffer = System.Text.Encoding.UTF8.GetBytes(myContent);
            var byteContent = new ByteArrayContent(buffer);
            byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            HttpResponseMessage response = await client.PutAsync("PutBanco", byteContent);
            if (response.IsSuccessStatusCode)
            {

            }

        }

        public async Task Eliminar(DtoBanco banco)
        {
            var myContent = JsonConvert.SerializeObject(banco);
            var buffer = System.Text.Encoding.UTF8.GetBytes(myContent);
            var byteContent = new ByteArrayContent(buffer);
            byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            HttpResponseMessage response = await client.PutAsync("PutEliminaBanco", byteContent);
            if (response.IsSuccessStatusCode)
            {

            }

        }
    }
}
