﻿using API_Avaliacao.Domain.Entities;


namespace API_Avaliacao.Infraestructure.Interfaces
{
    public interface IServidorRepository
    {
        Task<List<Servidor>> Get();
        Task<Servidor> GetByMatricula(string matricula);
        Task<Servidor> GetById(long id);
        Task Add(Servidor servidor);
        Task UpdateParcial(long id, Servidor servidor);
        Task Delete(long id);
    }
}
