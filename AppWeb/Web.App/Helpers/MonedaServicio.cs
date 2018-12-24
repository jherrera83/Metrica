using Metrica.Dto;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Web.App.Helpers
{
    public class MonedaServicio
    {
        #region PROPIEDADES       
        HttpClient client = new HttpClient();
        #endregion

        #region CONSTRUCTOR
        public MonedaServicio()
        {
            client.BaseAddress = new Uri("http://localhost:65099/api/Moneda/");
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
        }

        #endregion
        public async Task<IEnumerable<DtoMoneda>> Listar()
        {

            HttpResponseMessage response = await client.GetAsync("GetMonedas");
            if (response.IsSuccessStatusCode)
            {
                var stringResult = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<DtoMoneda>>(stringResult);
            }
            return new List<DtoMoneda>();
        }
    }
}
