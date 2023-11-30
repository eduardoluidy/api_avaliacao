using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API_Avaliacao.Domain.Entities
{
    //[Table("pessoas")]
    public abstract class Pessoa
    {
        [Key]
        public long Id { get; set; }

        //[Required(ErrorMessage ="O nome é obrigatório")]
        public string? Nome { get; set; }

        public string? Email { get; set; }
        //[Required(ErrorMessage = "A matrícula é obrigatória"), MinLength(5, ErrorMessage = "Tamanho mínimo é de 5 caracteres")]
        public string? Matricula { get; set; }

        [Required(ErrorMessage = "O CPF é obrigatório"), StringLength(11, ErrorMessage ="Tamanho inválido")] //verificar!!!
        public string? Cpf { get; set; }

        //[Required(ErrorMessage = "A lotação é obrigatória")]
        public Lotacao? Lotacao { get; set; }

        public ICollection<Certame>? Certames { get; set; }

    }
}
