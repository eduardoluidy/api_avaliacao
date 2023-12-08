using API_Avaliacao.Domain.Entities;
using System.Numerics;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace API_Avaliacao.Application.DTOs
{
    public class ServidorDTO
    {
        public long Id { get; set; }
        public string? Nome { get; set; }
        public string? Email { get; set; }
        public string? Matricula { get; set; }
        public string? Cpf { get; set; }
        public Lotacao? Lotacao { get; set; }
        //public ICollection<Certame>? Certames { get; set; }
        //public Avaliacao? Avaliacao { get; set; }

        //conversão implicita de servidor p/ servidordto
        //public static implicit operator ServidorDTO(Servidor s) => new ServidorDTO() { Id = s.Id, Nome = s.Nome };

    }


}
