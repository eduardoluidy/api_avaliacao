using System.ComponentModel.DataAnnotations;

namespace API_Avaliacao.Domain.Entities
{
    public class Certame
    {
        [Key]
        public long Id { get; set; }
        public string Descricao { get; set; }
        public DateTimeOffset DataInicio { get; set; }
        public DateTimeOffset DataFim { get; set; }
        public ICollection<Pessoa>? pessoas { get; set; }
        public TipoCertameEnum tipo { get; set; } //Antiguidade, Merecimento
    }
}
