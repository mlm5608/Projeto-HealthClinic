using Microsoft.AspNetCore.Authorization;
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
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioRepository _usuario;
        public UsuarioController()
        {
            _usuario = new UsuarioRepository();
        }

        [HttpPost]
        public IActionResult Post(Usuario u)
        {
            try
            {
                _usuario.Cadastrar(u);
                return Ok();
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }


        [HttpGet]
        [Authorize(Roles = "ADM")]
        public IActionResult Get()
        {
            try
            {
                return Ok(_usuario.Listar());
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            try
            {
                return Ok(_usuario.BuscarPorId(id));
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
                _usuario.Deletar(id);
                return NoContent();
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public IActionResult Put(Guid id, Usuario u)
        {
            try
            {
                _usuario.Atualizar(id, u);
                return NoContent();
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
    }
}
