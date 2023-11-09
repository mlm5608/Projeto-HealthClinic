using webapi.healthClinic.miguel.Contexts;
using webapi.healthClinic.miguel.Domains;
using webapi.healthClinic.miguel.Interfaces;

namespace webapi.healthClinic.miguel.Repositories
{
    public class ConsultaRepository : IConsultaRepository
    {
        private Context _context { get; set; }
        public ConsultaRepository()
        {
            _context= new Context();
        }
        public void Atualizar(Consulta c, Guid id)
        {
            try
            {
                Consulta cons = _context.Consulta.Find(id)!;
                if (cons != null)
                {
                    cons.Prontuario = c.Prontuario;
                    cons.Data = c.Data;
                    cons.Hora = c.Hora;
                    cons.IdMedico = c.IdMedico;
                    cons.IdPaciente = c.IdPaciente;
                    cons.IdClinica = c.IdClinica;
                }
                _context.Consulta.Update(cons!);
                _context.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Consulta BuscarPorPaciente(string nome)
        {
            try
            {
                return _context.Consulta.FirstOrDefault(c => c.Paciente!.Usuario!.Nome == nome)!;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Cadastrar(Consulta c)
        {
            try
            {
                _context.Consulta.Add(c);
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
                Consulta conc = _context.Consulta.Find(id)!;
                if (conc != null)
                {
                    _context.Remove(conc);
                }
                _context.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Consulta> ListarMinhasMedico(Guid id)
        {
            try
            {
                List<Consulta> list = new List<Consulta>();
                foreach (Consulta conc in _context.Consulta)
                {
                    if (conc.IdMedico == id)
                    {
                        list.Add(conc);
                    }
                }
                return list;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Consulta> ListarMinhasPaciente(Guid id)
        {
            try
            {
                List<Consulta> list = new List<Consulta>();
                foreach (Consulta conc in _context.Consulta)
                {
                    if (conc.IdPaciente == id)
                    {
                        list.Add(conc);
                    }
                }
                return list;
            }
            catch (Exception)
            {

                throw;
            } 
        }

        public List<Consulta> ListarTodos()
        {
            return _context.Consulta.ToList();
        }
    }
}
