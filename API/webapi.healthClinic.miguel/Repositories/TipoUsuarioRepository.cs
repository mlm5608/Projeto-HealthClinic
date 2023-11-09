using webapi.healthClinic.miguel.Contexts;
using webapi.healthClinic.miguel.Domains;
using webapi.healthClinic.miguel.Interfaces;

namespace webapi.healthClinic.miguel.Repositories
{
    public class TipoUsuarioRepository : ITipoUsuarioRepository
    {
        private Context _context { get; set; }

        public TipoUsuarioRepository()
        {
            _context= new Context();
        }
        public void Cadastrar(TipoUsuario tp)
        {
            try
            {
                _context.TipoUsuario.Add(tp);
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
                TipoUsuario t = _context.TipoUsuario.Find(id)!;
                if (t != null) 
                { 
                    _context.Remove(t);
                }
                _context.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
