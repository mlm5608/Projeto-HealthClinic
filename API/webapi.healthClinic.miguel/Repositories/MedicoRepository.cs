using webapi.healthClinic.miguel.Contexts;
using webapi.healthClinic.miguel.Domains;
using webapi.healthClinic.miguel.Interfaces;

namespace webapi.healthClinic.miguel.Repositories
{
    public class MedicoRepository : IMedicoRepository
    {
        private Context _context { get; set; }
        public MedicoRepository()
        {
            _context= new Context();
        }
        public void Atualizar(Medico m, Guid id)
        {
            try
            {
                Medico med = _context.Medico.Find(id)!;
                if (med != null)
                {
                    med.CRM = m.CRM;
                    med.IdUsuario = m.IdUsuario;
                    med.IdEspecialidade = m.IdEspecialidade;
                }
                _context.Medico.Update(med!);
                _context.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Medico BuscarPorNome(string nome)
        {
            try
            {
                return _context.Medico.FirstOrDefault(u => u.Usuario!.Nome == nome)!;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Cadastrar(Medico m)
        {
            try
            {
                _context.Medico.Add(m);
                _context.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Deletar(Guid id)
        {
            Medico med = _context.Medico.Find(id)!;
            if (med != null)
            {
                _context.Remove(med);
            }
            _context.SaveChanges();
        }

        public List<Medico> ListarPorEspecialidade(Guid id)
        {
            List<Medico> lista = new List<Medico>();

            foreach (Medico mi in _context.Medico)
            {
                if (mi.IdEspecialidade == id)
                {
                    lista.Add(mi);
                }
            }
            return lista;
        }

        public List<Medico> ListarTodos()
        {
            return _context.Medico.ToList();
        }
    }
}
