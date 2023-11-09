using webapi.healthClinic.miguel.Domains;

namespace webapi.healthClinic.miguel.Interfaces
{
    public interface IConsultaRepository
    {
        void Cadastrar(Consulta c);
        List<Consulta> ListarTodos(); //somente ADM
        List<Consulta> ListarMinhasMedico(Guid id);//Somente medicos
        List<Consulta> ListarMinhasPaciente(Guid id);//Somente pacientes
        void Deletar(Guid id);
        Consulta BuscarPorPaciente(string nome);
        void Atualizar(Consulta c, Guid id);
    }
}
