using System.ComponentModel.DataAnnotations;

namespace AndreAirLinesApi.Model
{
    public class Aeroporto
    {
        #region Propriedades
        [Key]
        public string Sigla { get; set; }

        public string Nome { get; set; }


        public virtual Endereco Endereco { get; set; }

        #endregion
    }
}