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
    public class EspecialidadeController : ControllerBase
    {
        private readonly IEspecialidadeRepository _especialidade;
        public EspecialidadeController()
        {
            _especialidade = new EspecialidadeRepository();
        }

        [HttpPost]
        public IActionResult Post(Especialidade e)
        {
            try
            {
                _especialidade.Cadastrar(e);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        public IActionResult Delete(Guid id)
        {
            try
            {
                _especialidade.Deletar(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
