using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AndreAirLinesApi.Model;

namespace AndreAirLinesApi.Data
{
    public class AndreAirLinesApiContext : DbContext
    {
        public AndreAirLinesApiContext (DbContextOptions<AndreAirLinesApiContext> options)
            : base(options)
        {
        }

        public DbSet<AndreAirLinesApi.Model.Aeronave> Aeronave { get; set; }

        public DbSet<AndreAirLinesApi.Model.Aeroporto> Aeroporto { get; set; }

        public DbSet<AndreAirLinesApi.Model.Classe> Classe { get; set; }

        public DbSet<AndreAirLinesApi.Model.Endereco> Endereco { get; set; }

        public DbSet<AndreAirLinesApi.Model.Passageiro> Passageiro { get; set; }

        public DbSet<AndreAirLinesApi.Model.Passagem> Passagem { get; set; }

        public DbSet<AndreAirLinesApi.Model.PrecoBase> PrecoBase { get; set; }

        public DbSet<AndreAirLinesApi.Model.Voo> Voo { get; set; }
    }
}
