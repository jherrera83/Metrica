using Metrica.Dto;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Metrica.Web.Helpers
{
    public class EstadoPagoServicio
    {
        #region PROPIEDADES       
        HttpClient client = new HttpClient();
        #endregion

        #region CONSTRUCTOR
        public EstadoPagoServicio()
        {
            client.BaseAddress = new Uri("http://localhost:65099/api/EstadoPago/");
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
        }
        #endregion

        public async Task<IEnumerable<DtoEstadoPago>> Listar()
        {

            HttpResponseMessage response = await client.GetAsync("GetEstadosPago");
            if (response.IsSuccessStatusCode)
            {
                var stringResult = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<DtoEstadoPago>>(stringResult);
            }
            return new List<DtoEstadoPago>();
        }
    }
}
