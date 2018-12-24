using Metrica.Dto;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Metrica.Web.Helpers
{
    public class RolServicio
    {
        #region PROPIEDADES       
        HttpClient client = new HttpClient();
        #endregion

        #region CONSTRUCTOR
        public RolServicio()
        {
            client.BaseAddress = new Uri("http://localhost:65099/api/Rol/");
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
        }

        #endregion

        public async Task<IEnumerable<DtoRol>> Listar()
        {

            HttpResponseMessage response = await client.GetAsync("GetRoles");
            if (response.IsSuccessStatusCode)
            {
                var stringResult = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<DtoRol>>(stringResult);
            }
            return new List<DtoRol>();
        }
    }
}