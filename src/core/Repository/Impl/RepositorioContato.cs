using System.Collections.Generic;
using System.Linq;
using core.Modelo;
using core.Repository.Context;
using Microsoft.EntityFrameworkCore;

namespace core.Repository.Impl
{
    public class RepositorioContato : RepositorioBase<Contato>, IRepositorioContato
    {
        private readonly APIClienteContext _context;
        public RepositorioContato(APIClienteContext context) : base(context)
        {
            _context = context;
        }

        public IEnumerable<Contato> BuscarPorCliente(int idCliente)
        {
            return _context.Set<Contato>().AsNoTracking().Where(c => c.ClienteId == idCliente);
        }

        public void ExcluirContatosAntigos(IEnumerable<Contato> contatosAntigos)
        {
            _context.Set<Contato>().RemoveRange(contatosAntigos);
            _context.SaveChanges();
        }
    }
}