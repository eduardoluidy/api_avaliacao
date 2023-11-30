using API_Avaliacao.Domain.Entities;
using API_Avaliacao.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Avaliacao_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServidorController : Controller
    {
        private readonly IServidorRepository _repository;

        public ServidorController(IServidorRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var listaServidores = await _repository.Get();

            return Ok(listaServidores);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var usuario = _repository.GetById(id);
            if (usuario == null)
                return NotFound("Não encontrado!");

            return Ok(usuario);
        }

        [HttpPost]
        public IActionResult Add([FromBody] Servidor servidor)
        {
            _repository.Add(servidor);
            return Ok(servidor);
        }

        [HttpPut("{id}")]
        public IActionResult Update([FromBody] Servidor servidor, int id)
        {
            _repository.UpdateParcial(id, servidor);

            return Ok(servidor);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _repository.Delete(id);

            return Ok();
        }
    }
}
