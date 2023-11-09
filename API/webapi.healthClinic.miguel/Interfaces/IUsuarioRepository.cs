using webapi.healthClinic.miguel.Domains;

namespace webapi.healthClinic.miguel.Interfaces
{
    public interface IUsuarioRepository
    {
        void Cadastrar(Usuario novoUsuario);
        Usuario BuscarPorId(Guid id);
        Usuario BuscarPorEmailESenha(string email, string senha);
        void Deletar(Guid id);
        List<Usuario> Listar();
        void Atualizar(Guid id, Usuario usuario);
    }
}
