using webapi.healthClinic.miguel.Contexts;
using webapi.healthClinic.miguel.Domains;
using webapi.healthClinic.miguel.Interfaces;

namespace webapi.healthClinic.miguel.Repositories
{
    public class PacienteRepository : IPacienteRepository
    {
        private Context _context { get; set; }
        public PacienteRepository()
        {
            _context= new Context();
        }

        public void Atualizar(Paciente p, Guid id)
        {
            try
            {
                Paciente pac = _context.Paciente.Find(id)!;
                if (pac != null)
                {
                    pac.CPF = p.CPF;
                    pac.IdUsuario = p.IdUsuario;
                }
                _context.Paciente.Update(pac!);
                _context.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Paciente BuscarPorCPF(string cpf)
        {
            try
            {
                return _context.Paciente.FirstOrDefault(p => p.CPF == cpf)!;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Cadastrar(Paciente p)
        {
            try
            {
                _context.Paciente.Add(p);
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
                Paciente p = _context.Paciente.Find(id)!;
                if (p != null)
                {
                    _context.Remove(p);
                }
                _context.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Paciente> ListarTodos()
        {
            return _context.Paciente.ToList();
        }
    }
}
