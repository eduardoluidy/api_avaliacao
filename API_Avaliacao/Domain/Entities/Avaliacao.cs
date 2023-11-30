using System.ComponentModel.DataAnnotations;

namespace API_Avaliacao.Domain.Entities
{
    public class Avaliacao
    {
        [Key]
        public long Id { get; set; }
        public ICollection<Servidor> Servidores { get; set; }
    }
}
