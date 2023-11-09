using Microsoft.EntityFrameworkCore;
using webapi.healthClinic.miguel.Contexts;
using webapi.healthClinic.miguel.Domains;
using webapi.healthClinic.miguel.Interfaces;
using webapi.healthClinic.miguel.Utils;

namespace webapi.healthClinic.miguel.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly Context _context;

        public UsuarioRepository()
        {
            _context = new Context();
        }

        public void Atualizar(Guid id, Usuario usuario)
        {
            try
            {
                Usuario u = _context.Usuario.Find(id)!;
                if (u != null)
                {
                    u.Email = usuario.Email;
                    u.Senha = usuario.Senha;
                    u.IdTipoUsuario = usuario.IdTipoUsuario;
                }
                _context.Usuario.Update(u!);
                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Usuario BuscarPorEmailESenha(string email, string senha)
        {
            Usuario userBuscado = _context.Usuario.Include(x => x.TipoUsuario)
                .FirstOrDefault(u => u.Email == email)!;

            if (userBuscado != null)
            {
                bool conference = Criptografia.CompararHash(senha, userBuscado.Senha!);
                if (conference)
                {
                    return userBuscado;
                }
            }
            return null!;
        }

        public Usuario BuscarPorId(Guid id)
        {
            try
            {
                Usuario usuarioBuscado = _context.Usuario
                .Select(u => new Usuario
                {
                    IdUsuario = u.IdUsuario,
                    IdTipoUsuario = u.IdTipoUsuario,
                    Nome = u.Nome,
                    Email = u.Email,

                    TipoUsuario = new TipoUsuario
                    {
                        IdTipoUsuario = u.IdTipoUsuario,
                        Titulo = u.TipoUsuario!.Titulo
                    }
                }).FirstOrDefault(u => u.IdUsuario == id)!;

                return usuarioBuscado;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Cadastrar(Usuario novoUsuario)
        {
            try
            {
                novoUsuario.Senha = Criptografia.GerarHash(novoUsuario.Senha!);
                _context.Usuario.Add(novoUsuario);
                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Deletar(Guid id)
        {
            try
            {
                Usuario u = _context.Usuario.Find(id)!;
                if (u != null)
                {
                    _context.Remove(u);
                }
                _context.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Usuario> Listar()
        {
            try
            {
                return _context.Usuario.ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
