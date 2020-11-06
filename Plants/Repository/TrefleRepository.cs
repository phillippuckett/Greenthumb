using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Plants.Models;
using System.Text.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Plants.Repository
{
    public class TrefleRepository : ITrefleRepository
    {
        private string baseUrl = "https://trefle.io/api/v1/";
        private string token = "km3qolYTRwDjiRKJL8M2ARoVW77sRUTNVj0RXRN4xYs";

        public async Task<List<apiData>> GetPlantsAsync()
        {
            try
            {
                List<apiData> jsonObject = new List<apiData>();

                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(baseUrl);
                    client.DefaultRequestHeaders.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    HttpResponseMessage res = await client.GetAsync($"plants?token={token}");
                    if (res.IsSuccessStatusCode)
                    {
                        var response = res.Content.ReadAsStringAsync().Result;
                        var value = JsonConvert.DeserializeObject<Trefle>(response);
                        jsonObject = value.data;
                    }
                }
                return jsonObject;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}