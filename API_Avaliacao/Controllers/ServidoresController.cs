using API_Avaliacao.Application.DTOs;
using API_Avaliacao.Domain.Entities;
using API_Avaliacao.Domain.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace Avaliacao_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServidoresController : ControllerBase
    {
        private readonly IServidorRepository _repository;
        private readonly IMapper _mapper;

        public ServidoresController(IServidorRepository repository, IMapper mapper)
        {
            _mapper = mapper;
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var listaServidores = await _repository.Get();
            List<ServidorDTO> servidoresRetorno = new List<ServidorDTO>();

            foreach (var servidor in listaServidores) {
                servidoresRetorno.Add(_mapper.Map<ServidorDTO>(servidor));
            }
          
            return Ok(servidoresRetorno);
        }
         
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(long id)
        {
            var servidor = await _repository.GetById(id);

            if (servidor == null)
                return NotFound("Não encontrado!");

           return Ok(_mapper.Map<ServidorDTO>(servidor));
        }

        [HttpPost]
        public async Task<ActionResult> Add([FromBody] ServidorDTO servidorDTO)
        {
            try
            {
                var servidor = _mapper.Map<Servidor>(servidorDTO);
                await _repository.Add(servidor);
                return Ok(servidor);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro ao adicionar servidor: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update([FromBody] ServidorDTO servidorDTO, long id)
        {
            var servidor = _mapper.Map<Servidor>(servidorDTO);

            await _repository.UpdateParcial(id, servidor);

            return Ok(servidor);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(long id)
        {
            try
            {
                await _repository.Delete(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro ao excluir o servidor: {ex.Message}");
            }
        }
    }
}
