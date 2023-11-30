using API_Avaliacao.Domain.Entities;
using API_Avaliacao.Domain.Interfaces;
using API_Avaliacao.Infraestructure.Data;
using Microsoft.EntityFrameworkCore;

namespace API_Avaliacao.Infraestructure.Repositories
{
    public class ServidorRepository : IServidorRepository
    {
        private readonly ConnectionDbContext _dbContext;

        public ServidorRepository(ConnectionDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        //public List<Servidor> Get()
        //{
        //    return _dbContext.Servidores.ToList();
        //}

        public async Task<List<Servidor>> Get()
        {
            return await _dbContext.Servidores.OrderBy(a => a.Id).ToListAsync();
        }

        public void Add(Servidor servidor)
        {
            _dbContext.Add(servidor);
            _dbContext.SaveChanges();
        }

        public Servidor? GetById(int id)
        {
            return _dbContext.Servidores.FirstOrDefault(a => a.Id == id);
        }

        public Servidor? GetByMatricula(string matricula)
        {
            return _dbContext.Servidores.FirstOrDefault(a => a.Matricula == matricula);
        }

        public bool Delete(int id)
        {
            var pessoa = _dbContext.Servidores.FirstOrDefault(p => p.Id == id);

            if (pessoa != null)
            {
                _dbContext.Pessoas.Remove(pessoa);
                _dbContext.SaveChanges();
                return true;
            }
            else
                return false;
        }


        public void UpdateParcial(int id, Servidor servidorPatch)
        {
            var pessoa = _dbContext.Servidores.FirstOrDefault(p => p.Id == id);

            if (pessoa != null)
            {
                // alterações parciais
                if (!string.IsNullOrEmpty(servidorPatch.Nome))
                    pessoa.Nome = servidorPatch.Nome;

                if (!string.IsNullOrEmpty(servidorPatch.Matricula))
                    pessoa.Matricula = servidorPatch.Matricula;

                _dbContext.SaveChanges();
            }
        }
    }
}
