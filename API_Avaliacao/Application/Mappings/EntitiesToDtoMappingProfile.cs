using API_Avaliacao.Application.DTOs;
using API_Avaliacao.Domain.Entities;
using AutoMapper;

namespace API_Avaliacao.Application.Mappings
{
    public class EntitiesToDtoMappingProfile : Profile
    {
        public EntitiesToDtoMappingProfile()
        {
            CreateMap<Servidor, ServidorDTO>().ReverseMap();
        }
        
    }
}
