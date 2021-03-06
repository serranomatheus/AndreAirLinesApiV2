// <auto-generated />
using System;
using AndreAirLinesApi.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AndreAirLinesApi.Migrations
{
    [DbContext(typeof(AndreAirLinesApiContext))]
    partial class AndreAirLinesApiContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.15")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("AndreAirLinesApi.Model.Aeronave", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("Capacidade")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Aeronave");
                });

            modelBuilder.Entity("AndreAirLinesApi.Model.Aeroporto", b =>
                {
                    b.Property<string>("Sigla")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int?>("EnderecoId")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Sigla");

                    b.HasIndex("EnderecoId");

                    b.ToTable("Aeroporto");
                });

            modelBuilder.Entity("AndreAirLinesApi.Model.Classe", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Descricao")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Classe");
                });

            modelBuilder.Entity("AndreAirLinesApi.Model.Endereco", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Bairro")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CEP")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Cidade")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Complemento")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Estado")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Logradouro")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Numero")
                        .HasColumnType("int");

                    b.Property<string>("Pais")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Endereco");
                });

            modelBuilder.Entity("AndreAirLinesApi.Model.Passageiro", b =>
                {
                    b.Property<string>("Cpf")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime?>("DataNascimento")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("EnderecoId")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .HasColumnType("varchar(50)")
                        .HasColumnName("Nome");

                    b.Property<string>("Telefone")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Cpf");

                    b.HasIndex("EnderecoId");

                    b.ToTable("Passageiro");
                });

            modelBuilder.Entity("AndreAirLinesApi.Model.Passagem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("ClasseId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DataCadastro")
                        .HasColumnType("datetime2");

                    b.Property<string>("PassageiroCpf")
                        .HasColumnType("nvarchar(450)");

                    b.Property<double>("Valor")
                        .HasColumnType("float");

                    b.Property<int?>("VooId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ClasseId");

                    b.HasIndex("PassageiroCpf");

                    b.HasIndex("VooId");

                    b.ToTable("Passagem");
                });

            modelBuilder.Entity("AndreAirLinesApi.Model.PrecoBase", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("ClasseId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DataInclusao")
                        .HasColumnType("datetime2");

                    b.Property<string>("DestinoSigla")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("OrigemSigla")
                        .HasColumnType("nvarchar(450)");

                    b.Property<double>("PromocaoPorcentagem")
                        .HasColumnType("float");

                    b.Property<double>("Valor")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("ClasseId");

                    b.HasIndex("DestinoSigla");

                    b.HasIndex("OrigemSigla");

                    b.ToTable("PrecoBase");
                });

            modelBuilder.Entity("AndreAirLinesApi.Model.Voo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AeronaveId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("DestinoSigla")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("HorarioDesembarque")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("HorarioEmbarque")
                        .HasColumnType("datetime2");

                    b.Property<string>("OrigemSigla")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("AeronaveId");

                    b.HasIndex("DestinoSigla");

                    b.HasIndex("OrigemSigla");

                    b.ToTable("Voo");
                });

            modelBuilder.Entity("AndreAirLinesApi.Model.Aeroporto", b =>
                {
                    b.HasOne("AndreAirLinesApi.Model.Endereco", "Endereco")
                        .WithMany()
                        .HasForeignKey("EnderecoId");

                    b.Navigation("Endereco");
                });

            modelBuilder.Entity("AndreAirLinesApi.Model.Passageiro", b =>
                {
                    b.HasOne("AndreAirLinesApi.Model.Endereco", "Endereco")
                        .WithMany()
                        .HasForeignKey("EnderecoId");

                    b.Navigation("Endereco");
                });

            modelBuilder.Entity("AndreAirLinesApi.Model.Passagem", b =>
                {
                    b.HasOne("AndreAirLinesApi.Model.Classe", "Classe")
                        .WithMany()
                        .HasForeignKey("ClasseId");

                    b.HasOne("AndreAirLinesApi.Model.Passageiro", "Passageiro")
                        .WithMany()
                        .HasForeignKey("PassageiroCpf");

                    b.HasOne("AndreAirLinesApi.Model.Voo", "Voo")
                        .WithMany()
                        .HasForeignKey("VooId");

                    b.Navigation("Classe");

                    b.Navigation("Passageiro");

                    b.Navigation("Voo");
                });

            modelBuilder.Entity("AndreAirLinesApi.Model.PrecoBase", b =>
                {
                    b.HasOne("AndreAirLinesApi.Model.Classe", "Classe")
                        .WithMany()
                        .HasForeignKey("ClasseId");

                    b.HasOne("AndreAirLinesApi.Model.Aeroporto", "Destino")
                        .WithMany()
                        .HasForeignKey("DestinoSigla");

                    b.HasOne("AndreAirLinesApi.Model.Aeroporto", "Origem")
                        .WithMany()
                        .HasForeignKey("OrigemSigla");

                    b.Navigation("Classe");

                    b.Navigation("Destino");

                    b.Navigation("Origem");
                });

            modelBuilder.Entity("AndreAirLinesApi.Model.Voo", b =>
                {
                    b.HasOne("AndreAirLinesApi.Model.Aeronave", "Aeronave")
                        .WithMany()
                        .HasForeignKey("AeronaveId");

                    b.HasOne("AndreAirLinesApi.Model.Aeroporto", "Destino")
                        .WithMany()
                        .HasForeignKey("DestinoSigla");

                    b.HasOne("AndreAirLinesApi.Model.Aeroporto", "Origem")
                        .WithMany()
                        .HasForeignKey("OrigemSigla");

                    b.Navigation("Aeronave");

                    b.Navigation("Destino");

                    b.Navigation("Origem");
                });
#pragma warning restore 612, 618
        }
    }
}
