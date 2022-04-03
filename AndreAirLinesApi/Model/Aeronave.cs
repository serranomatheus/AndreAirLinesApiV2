using Newtonsoft.Json;

namespace AndreAirLinesApi.Model
{
    public class Aeronave
    {
        #region Propriedades
        [JsonProperty("Codigo")]
        public string Id { get; set; }
        [JsonProperty("Nome")]
        public string Nome { get; set; }

        [JsonProperty("Capacidade")]
        public int Capacidade { get; set; }
        #endregion
    }
}