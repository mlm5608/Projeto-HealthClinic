using webapi.healthClinic.miguel.Domains;

namespace webapi.healthClinic.miguel.Interfaces
{
    public interface IEspecialidadeRepository
    {
        void Cadastrar(Especialidade e);
        void Deletar(Guid id);
    }
}
