using API_Avaliacao.Domain.Entities;


namespace API_Avaliacao.Domain.Interfaces
{
    public interface IServidorRepository
    {
        Task<List<Servidor>> Get();
        Servidor? GetByMatricula(string matricula);
        Servidor GetById(int id);
        void Add(Servidor servidor);
        void UpdateParcial(int id, Servidor servidor);
        bool Delete(int id);
    }
}
