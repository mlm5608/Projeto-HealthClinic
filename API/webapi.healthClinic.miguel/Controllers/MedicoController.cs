using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using webapi.healthClinic.miguel.Domains;
using webapi.healthClinic.miguel.Interfaces;
using webapi.healthClinic.miguel.Repositories;

namespace webapi.healthClinic.miguel.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class MedicoController : ControllerBase
    {
        private readonly IMedicoRepository _medico;
        public MedicoController()
        {
            _medico = new MedicoRepository();
        }

        [HttpPost]
        public IActionResult Post(Medico m)
        {
            try
            {
                _medico.Cadastrar(m);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_medico.ListarTodos());
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("IdEspecialidade")]
        public IActionResult GetByspecialty(Guid IdEspecialidade)
        {
            try
            {
                return Ok(_medico.ListarPorEspecialidade(IdEspecialidade));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete]
        public IActionResult Delete(Guid id) 
        {
            try
            {
                _medico.Deletar(id);
                return NoContent();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("{nome}", Name = "GetByName")]
        public IActionResult GetByName(string nome) 
        {
            try
            {
                return Ok(_medico.BuscarPorNome(nome));
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

        [HttpPut]
        public IActionResult Put(Medico m, Guid id)
        {
            try
            {
                _medico.Atualizar(m, id);
                return NoContent();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
