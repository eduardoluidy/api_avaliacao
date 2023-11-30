using System.ComponentModel.DataAnnotations;

namespace API_Avaliacao.Domain.Entities
{
    public class Lotacao
    {
        [Key]
        public long Id { get; set; }
        public string? Descricao { get; set; }
        public ICollection<Pessoa>? Pessoas { get; set; }
    }
}
