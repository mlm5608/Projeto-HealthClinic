using webapi.healthClinic.miguel.Domains;

namespace webapi.healthClinic.miguel.Interfaces
{
    public interface IMedicoRepository
    {
        void Cadastrar(Medico m);
        List<Medico> ListarTodos();
        List<Medico> ListarPorEspecialidade(Guid id);
        void Deletar(Guid id);
        Medico BuscarPorNome(string nome);
        void Atualizar(Medico m, Guid id);
    }
}
