using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using webapi.healthClinic.miguel.Domains;
using webapi.healthClinic.miguel.Interfaces;
using webapi.healthClinic.miguel.Repositories;
using webapi.healthClinic.miguel.VielModels;

namespace webapi.healthClinic.miguel.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class LoginController : ControllerBase
    {
        private IUsuarioRepository _usuarioRepository;
        public LoginController()
        {
            _usuarioRepository = new UsuarioRepository();
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel user)
        {
            try
            {
                Usuario usuario = _usuarioRepository.BuscarPorEmailESenha(user.Email!, user.Senha!);

                if (usuario != null)
                {
                    var Claims = new[]
                        {
                        new Claim(JwtRegisteredClaimNames.Jti, usuario.IdUsuario.ToString()),
                        new Claim(JwtRegisteredClaimNames.Name, usuario.Nome!),
                        new Claim(JwtRegisteredClaimNames.Email, usuario.Email!),
                        new Claim(ClaimTypes.Role, usuario.TipoUsuario!.Titulo!)
                    };
                    var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("Webapi_Health_Clinic_Miguel_Tarde_2Semestre"));

                    var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                    var token = new JwtSecurityToken
                    (
                    //emissor do token
                    issuer: "webapi.healthClinic.miguel",

                    //destinatario
                    audience: "webapi.healthClinic.miguel",

                    //dados definidos nas claims
                    claims: Claims,

                    //tempo de expiração
                    expires: DateTime.Now.AddMinutes(40),

                    //Credenciais do token
                    signingCredentials: creds
                    );

                    return StatusCode(200, new
                    {
                        Token = new JwtSecurityTokenHandler().WriteToken(token)
                    });
                }

                return StatusCode(404);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
