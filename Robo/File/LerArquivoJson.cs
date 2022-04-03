using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AndreAirLinesApi.Model;
using Newtonsoft.Json;

namespace Robo.File
{
    internal class LerArquivoJson
    {
        public static List<Voo>? GetDataVoo(string pathFile)
        {
            StreamReader lerArquivo = new StreamReader(pathFile);
            string jsonString = lerArquivo.ReadToEnd();
            var lstVoo = JsonConvert.DeserializeObject<List<Voo>>(jsonString) as List<Voo>;
            if (lstVoo != null)
                return lstVoo;
            return null;

        }
    }
}
