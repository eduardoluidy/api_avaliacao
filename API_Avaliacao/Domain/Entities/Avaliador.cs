using System.ComponentModel.DataAnnotations;

namespace API_Avaliacao.Domain.Entities
{
    public class Avaliador : Pessoa
    {
        //[Key]
        //public int Id { get; set; }
        public string? descricao {  get; set; }
        public DateTimeOffset PeriodoInicio { get; set; }
        public DateTimeOffset PeriodoFim { get; set; }
    }
}
