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

        public async Task<List<Servidor>> Get()
        {
            return await _dbContext.Servidores.OrderBy(a => a.Id).ToListAsync();
        }

        public async Task Add(Servidor servidor)
        {
            _dbContext.Add(servidor);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<Servidor> GetById(long id)
        {
            var servidor = await _dbContext.Servidores.FindAsync(id);
            //if (servidor == null)
            //{
            //    throw new InvalidOperationException();
            //}
            return servidor;
        }

        public async Task<Servidor> GetByMatricula(string matricula)
        {
            return await _dbContext.Servidores.FirstOrDefaultAsync(a => a.Matricula == matricula);
        }

        public async Task Delete(long id)
        {
            var servidor = await _dbContext.Servidores.FindAsync(id);

            if (servidor != null)
            {
                _dbContext.Pessoas.Remove(servidor);
                await _dbContext.SaveChangesAsync();            
            }
        }

        public async Task UpdateParcial(long id, Servidor servidorPatch)
        {
            var servidor = await _dbContext.Servidores.FindAsync(id);

            if (servidor != null)
            {
                // alterações parciais
                if (!string.IsNullOrEmpty(servidorPatch.Nome))
                    servidor.Nome = servidorPatch.Nome;

                if (!string.IsNullOrEmpty(servidorPatch.Matricula))
                    servidor.Matricula = servidorPatch.Matricula;
                
                if (!string.IsNullOrEmpty(servidorPatch.Email))
                    servidor.Email = servidorPatch.Email;
                
                if (!string.IsNullOrEmpty(servidorPatch.Cpf))
                    servidor.Cpf = servidorPatch.Cpf;

                if (servidorPatch.Lotacao is not null)
                    servidor.Lotacao = servidorPatch.Lotacao;

                //_dbContext.SaveChanges();
                await _dbContext.SaveChangesAsync();

            }
        }       
    }
}
