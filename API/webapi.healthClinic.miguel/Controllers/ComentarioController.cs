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
    public class ComentarioController : ControllerBase
    {
        private readonly IComentarioRepository _comentario;
        public ComentarioController()
        {
            _comentario= new ComentarioRepository();
        }

        [HttpPost]
        public IActionResult Post(Comentario c)
        {
            try
            {
                _comentario.Cadastrar(c);
                return Ok();
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
                _comentario.Deletar(id);
                return NoContent();
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
                return Ok(_comentario.ListarTodos());
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetMy(Guid id)
        {
            try
            {
                return Ok(_comentario.ListarMeus(id));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("paciente")]
        public IActionResult GetByPatient(string cpf)
        {
            try
            {
                return Ok(_comentario.BuscarPorPaciente(cpf));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
