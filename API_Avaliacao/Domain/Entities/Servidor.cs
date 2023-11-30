using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API_Avaliacao.Domain.Entities
{

    //[Table("servidores")]
    public class Servidor : Pessoa
    {
        //[ForeignKey("pessoas")]
        //public int PessoaId { get; set; }
        public Avaliacao? Avaliacao { get; set; }

    }
}
