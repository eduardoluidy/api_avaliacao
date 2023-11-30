using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API_Avaliacao.Domain.Entities
{
    [Table("comissoes")]
    public class Comissao
    {
        [Key]
        public long Id { get; set; }
        public string? Descricao { get; set; }
        public DateTimeOffset DataInicio { get; set; }
        public DateTimeOffset? DataFim { get; set; }
        public ICollection<Membro>? Membros { get; set; }     
    }

}
