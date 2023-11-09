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
    public class TipoUsuarioController : ControllerBase
    {
        private readonly ITipoUsuarioRepository _tipoUsuario;
        public TipoUsuarioController()
        {
            _tipoUsuario = new TipoUsuarioRepository();
        }

        [HttpPost]
        public IActionResult Post(TipoUsuario tp)
        {
            try
            {
                _tipoUsuario.Cadastrar(tp);
                return Ok();
            }
            catch (Exception x)
            {
                return BadRequest(x.Message);
            }
        }

        [HttpDelete]
        public IActionResult Delete(Guid id)
        {
            try
            {
                _tipoUsuario.Deletar(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
