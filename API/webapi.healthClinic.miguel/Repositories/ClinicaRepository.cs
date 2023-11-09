using webapi.healthClinic.miguel.Contexts;
using webapi.healthClinic.miguel.Domains;
using webapi.healthClinic.miguel.Interfaces;

namespace webapi.healthClinic.miguel.Repositories
{
    public class ClinicaRepository : IClinicaRepository
    {
        private Context _context { get; set; }

        public ClinicaRepository()
        {
            _context = new Context();
        }

        public void Atualizar(Clinica c, Guid id)
        {
            try
            {
                Clinica clic = _context.Clinica.Find(id)!;
                if (clic != null)
                {
                    clic.Endereco = c.Endereco;
                    clic.NomeFantasia = c.NomeFantasia;
                    clic.CNPJ = c.CNPJ;
                }
                _context.Clinica.Update(clic!);
                _context.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Cadastrar(Clinica c)
        {
            try
            {
                _context.Clinica.Add(c);
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
                Usuario c = _context.Usuario.Find(id)!;
                if (c != null)
                {
                    _context.Remove(c);
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
