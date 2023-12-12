using API_Avaliacao.Domain.Entities;
using API_Avaliacao.Domain.Interfaces;
using API_Avaliacao.Infraestructure.Interfaces;

namespace API_Avaliacao.Domain.Services
{
    public class ServidorService : IServidorService
    {

        private readonly IServidorRepository _servidorRepository;

        public ServidorService(IServidorRepository servidorRepository)
        {
            _servidorRepository = servidorRepository;
        }


        public async Task Add(Servidor servidor)
        {
            await _servidorRepository.Add(servidor);
        }

        public async Task Delete(long id)
        {
            await _servidorRepository.Delete(id);
        }

        public async Task<List<Servidor>> Get()
        {
            return await _servidorRepository.Get();
        }

        public async Task<Servidor> GetById(long id)
        {
            return await _servidorRepository.GetById(id);
        }

        public async Task UpdateParcial(long id, Servidor servidor)
        {
            await _servidorRepository.UpdateParcial(id, servidor);
        }
    }
}
