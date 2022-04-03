using System;

namespace AndreAirLinesApi.Model
{
    public class Passagem
    {
        #region Propriedades
        public int Id { get; set; }
        public Voo Voo { get; set; }
        public Passageiro Passageiro { get; set; }
        public double Valor { get; set; }
        public Classe Classe { get; set; }
        public DateTime DataCadastro { get; set; }
        #endregion
    }
}
