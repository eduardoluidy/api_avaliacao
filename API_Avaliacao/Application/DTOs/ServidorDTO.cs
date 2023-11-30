using API_Avaliacao.Domain.Entities;

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
        public ICollection<Certame>? Certames { get; set; }
        public Avaliacao? Avaliacao { get; set; }

    }
}
