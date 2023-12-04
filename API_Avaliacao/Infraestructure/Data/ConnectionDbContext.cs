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
        //private string urlConnection = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=AvaliacaoDB;Integrated Security=True;Globalization Invariant=True;";


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

        }
    }
}