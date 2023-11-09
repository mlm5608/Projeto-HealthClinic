using webapi.healthClinic.miguel.Domains;

namespace webapi.healthClinic.miguel.Interfaces
{
    public interface IComentarioRepository
    {
        void Cadastrar(Comentario c);
        void Deletar(Guid id);
        List<Comentario> ListarTodos();
        List<Comentario> ListarMeus(Guid id);
        Comentario BuscarPorPaciente(string cpf);
    }
}
