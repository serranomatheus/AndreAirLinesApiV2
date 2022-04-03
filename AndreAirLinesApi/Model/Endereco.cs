using Newtonsoft.Json;

namespace AndreAirLinesApi.Model
{
    public class Endereco
    {
        #region Propriedades
        public int Id { get; set; }
        public string Bairro { get; set; }
        [JsonProperty("Localidade")]
        public string Cidade { get; set; }
        public string Pais { get; set; }
       // [JsonProperty("Cep")]
        public string CEP { get; set; }
        public string Logradouro { get; set; }
        [JsonProperty("Uf")]
        public string Estado { get; set; }
        public int Numero { get; set; }
        public string Complemento { get; set; }

        public Endereco(string bairro, string cidade, string logradouro, string estado, string complemento,int numero)
        {
            Bairro = bairro;
            Cidade = cidade;
            Logradouro = logradouro;
            Estado = estado;
            Complemento = complemento;
            Pais = "Brasil";
            Numero = numero;
            
            
        }
        #endregion
    }
}