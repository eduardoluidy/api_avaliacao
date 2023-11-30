using API_Avaliacao.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Reflection.Metadata;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;

namespace API_Avaliacao.Infraestructure.Data
{ 
    public class ConnectionDbContext : DbContext
    {
        //p/ criação das migrations usando docker:
        //private string urlConnection = "Data Source=localhost,1433;initial catalog=AvaliacaoDB;User ID=sa;Password=SqlServer2022!;encrypt=False";
        //p/ rodar no docker:
        //private string urlConnection = "Data Source=SqlServer-2022,1433;initial catalog=AvaliacaoDB;User ID=sa;Password=SqlServer2022!;encrypt=False";
        //p/rodar local:
        private string urlConnection = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=AvaliacaoDB;Integrated Security=True";

        /*
        public ConnectionDbContext(DbContextOptions<ConnectionDbContext> options) : base(options)
        {
            //Database.EnsureCreated();
        }*/

        public ConnectionDbContext() : base() { }

        //para geração e acesso das tabelas
        public DbSet<Pessoa> Pessoas { get; set; }
        public DbSet<Servidor> Servidores { get; set; }
        public DbSet<Certame> Certames { get; set; }
        public DbSet<Avaliacao> Avaliadores { get; set; }
        public DbSet<Membro> Membros { get; set; }
        public DbSet<Avaliacao> Avaliacoes { get; set; }
        public DbSet<Comissao> Comissoes { get; set; }
        public DbSet<Lotacao> Lotacoes { get; set; }



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(urlConnection);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Pessoa>().ToTable();
           // modelBuilder.Entity<Pessoa>()
           //  .ToTable("pessoa")
           //   .Property(b => b.Nome);
           // .IsRequired();
           // modelBuilder.Entity<Pessoa>().HasData(
           //    new Pessoa { Id = 1, Nome = "João", Matricula = "123" },
           //    new Pessoa { Id = 2, Nome = "Maria", Matricula = "456" },
           //    new Pessoa { Id = 3, Nome = "Taisa", Matricula = "333" },
           //    new Pessoa { Id = 4, Nome = "José", Matricula = "555" },
           //    new Pessoa { Id = 5, Nome = "Robson", Matricula = "789" },
           //    new Pessoa { Id = 6, Nome = "Eduardo", Matricula = "564" },
           //    new Pessoa { Id = 7, Nome = "Narto", Matricula = "999" }
           //);
        }
    }
}