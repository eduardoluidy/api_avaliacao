using API_Avaliacao.Domain.Entities;

namespace API_Avaliacao.Infraestructure.Interfaces
{
    public interface IPessoaRepository
    {
        List<Pessoa> Get();
        Pessoa? GetByMatricula(string matricula);
        Pessoa GetById(int id);
        void Add(Pessoa pessoa);
        void UpdateParcial(int id, Pessoa pessoa);
        bool Delete(int id);
    }
}



