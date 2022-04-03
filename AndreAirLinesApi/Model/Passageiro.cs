using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace AndreAirLinesApi.Model
{
    public class Passageiro
    {
        #region Propriedades
        [Key]
        public string? Cpf { get; set; }

        [Column("Nome", TypeName = "varchar(50)")]
        public string? Nome { get; set; }


        public string? Telefone { get; set; }

        [JsonProperty("DataNascimento")]
        public DateTime? DataNascimento { get; set; }


        public string? Email { get; set; }


        public virtual Endereco Endereco { get; set; }

        #endregion
    }
}
