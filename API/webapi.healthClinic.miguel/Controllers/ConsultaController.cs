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
    public class ConsultaController : ControllerBase
    {
        private readonly IConsultaRepository _consulta;
        public ConsultaController()
        {
            _consulta = new ConsultaRepository();
        }

        [HttpPost]
        public IActionResult Post(Consulta c)
        {
            try
            {
                _consulta.Cadastrar(c);
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
                return Ok(_consulta.ListarTodos());
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("IdPaciente")]
        public IActionResult GetMyPatient(Guid id)
        {
            try
            {
                return Ok(_consulta.ListarMinhasPaciente(id));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("IdMedico")]
        public IActionResult GetMyDoctor(Guid id)
        {
            try
            {
                return Ok(_consulta.ListarMinhasMedico(id));
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
                _consulta.Deletar(id);
                return NoContent();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("Paciente")]
        public IActionResult GetByName(string name)
        {
            try
            {

                return Ok(_consulta.BuscarPorPaciente(name));
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

        [HttpPut]
        public IActionResult Put(Consulta c, Guid id)
        {
            try
            {
                _consulta.Atualizar(c, id);
                return NoContent();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
