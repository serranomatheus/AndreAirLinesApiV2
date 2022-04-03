using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using Robo.File;

namespace Robo.Service
{
    internal class InserirDadosApiRobo
    {
        static readonly HttpClient client = new HttpClient();

        public static async Task InserirDadosApi()
        {

            string pathFile = @"C:\Users\matheus\Downloads\GenerateDados(100).json";
            var voo = LerArquivoJson.GetDataVoo(pathFile);
            try
            {
                client.BaseAddress = new Uri("https://localhost:44302/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = await client.GetAsync("api/Voos");
                response.EnsureSuccessStatusCode();
                voo.ForEach(p => client.PostAsJsonAsync("api/Voos", p));
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine("\nExceprion Caught!");
                Console.WriteLine("Message: {0}", e.Message);
            }
        }
    }
}

