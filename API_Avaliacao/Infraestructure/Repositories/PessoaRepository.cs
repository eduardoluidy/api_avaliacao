using API_Avaliacao.Domain.Entities;
using API_Avaliacao.Domain.Interfaces;
using API_Avaliacao.Infraestructure.Data;

namespace API_Avaliacao.Infraestructure.Repositories
{
    public class PessoaRepository : IPessoaRepository
    {
        private readonly ConnectionDbContext _dbContext;

        public PessoaRepository(ConnectionDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Pessoa> Get()
        {
            return _dbContext.Pessoas.OrderBy(a => a.Id).ToList(); //ordenado pelo id
        }
        
        public Pessoa? GetById(int id)
        {
            return _dbContext.Pessoas.FirstOrDefault(a => a.Id == id);
        }

        public Pessoa? GetByMatricula(string matricula)
        {
            return _dbContext.Pessoas.FirstOrDefault(a => a.Matricula == matricula);
        }

        public void Add(Pessoa pessoa)
        {
            _dbContext.Add(pessoa);
            _dbContext.SaveChanges();
        }

        //public void Update(int id, Pessoa pessoa)
        //{
        //    UpdateParcial(id, pessoa);

        //    /*
        //    var p = _dbContext.Pessoas.First(x => x.Id == id);
        //    if (p == null) { return; }

        //    p.Nome = pessoa.Nome;
        //    p.Matricula = pessoa.Matricula;

        //    pessoa = p;
        //    _dbContext.Update<Pessoa>(pessoa);
        //    _dbContext.SaveChanges();*/

        //    //return retorno;
        //}

        //public void Update(Pessoa pessoa)
        //{
        //    _dbContext.Entry(pessoa).State = EntityState.Modified;
        //    _dbContext.SaveChanges();
        //}

        public bool Delete(int id)
        {
            var pessoa = _dbContext.Pessoas.FirstOrDefault(p => p.Id == id);

            if (pessoa != null)
            {
                _dbContext.Pessoas.Remove(pessoa);
                _dbContext.SaveChanges();
                return true;
            } 
            else 
                return false;
        }


        public void UpdateParcial(int id, Pessoa pessoaPatch)
        {
            var pessoa = _dbContext.Pessoas.FirstOrDefault(p => p.Id == id);

            if (pessoa != null)
            {
                // alterações parciais
                if (!string.IsNullOrEmpty(pessoaPatch.Nome))
                    pessoa.Nome = pessoaPatch.Nome;

                if (!string.IsNullOrEmpty(pessoaPatch.Matricula))
                    pessoa.Matricula = pessoaPatch.Matricula;

                _dbContext.SaveChanges();
            }
        }
    }
}
