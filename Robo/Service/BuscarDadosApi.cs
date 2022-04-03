using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using AndreAirLinesApi.Model;
using Newtonsoft.Json;

namespace Robo.Service
{
    internal class BuscarDadosApi
    {
        static readonly HttpClient client = new HttpClient();
        public static async Task<string> BuscarPrecoBaseApi()
        {

            try
            {
                HttpResponseMessage response = await client.GetAsync("https://localhost:44396/api/PrecosBase");
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();
                string relatorio = JsonConvert.DeserializeObject<string>(responseBody);
                return relatorio;

            }
            catch (HttpRequestException e)
            {
                Console.WriteLine("\nException Caught!");
                Console.WriteLine("Message :{0} ", e.Message);
                throw;
            }
        }
    }
}
