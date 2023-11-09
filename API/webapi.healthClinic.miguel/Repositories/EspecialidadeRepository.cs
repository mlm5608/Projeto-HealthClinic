using webapi.healthClinic.miguel.Contexts;
using webapi.healthClinic.miguel.Domains;
using webapi.healthClinic.miguel.Interfaces;

namespace webapi.healthClinic.miguel.Repositories
{
    public class EspecialidadeRepository : IEspecialidadeRepository
    {
        private Context _context { get; set; }
        public EspecialidadeRepository()
        {
            _context= new Context();
        }
        public void Cadastrar(Especialidade e)
        {
            try
            {
                _context.Especialidade.Add(e);
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
                Especialidade esp = _context.Especialidade.Find(id)!;
                if (esp != null)
                {
                    _context.Remove(esp);
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
