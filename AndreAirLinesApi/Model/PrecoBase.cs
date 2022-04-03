using System;

namespace AndreAirLinesApi.Model
{
    public class PrecoBase
    {
        #region Propriedades
        public int Id { get; set; }
        public Aeroporto Origem { get; set; }
        public Aeroporto Destino { get; set; }
        public double Valor { get; set; }
        public double PromocaoPorcentagem { get; set; }
        public Classe Classe { get; set; }
        public DateTime DataInclusao { get; set; }
        #endregion
    }
}
