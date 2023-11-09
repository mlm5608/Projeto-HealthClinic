using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;
using webapi.healthClinic.miguel.Domains;
using webapi.healthClinic.miguel.Interfaces;
using webapi.healthClinic.miguel.Repositories;

namespace webapi.healthClinic.miguel.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class PacienteController : ControllerBase
    {
        private readonly IPacienteRepository _paciente;

        public PacienteController()
        {
            _paciente = new PacienteRepository();
        }

        [HttpPost]
        public IActionResult Post(Paciente p)
        {
            try
            {
                _paciente.Cadastrar(p);
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
                return Ok(_paciente.ListarTodos());
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
                _paciente.Deletar(id);
                return NoContent();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("cpf")]
        public IActionResult GetByCPF(string cpf)
        {
            try
            {
                return Ok(_paciente.BuscarPorCPF(cpf));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut]
        public IActionResult Put(Paciente p, Guid id)
        {
            try
            {
                _paciente.Atualizar(p, id);
                return NoContent();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    } 
}
