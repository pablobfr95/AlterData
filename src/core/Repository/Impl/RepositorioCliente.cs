using System.Collections.Generic;
using System.Linq;
using core.Modelo;
using core.Repository.Context;
using Microsoft.EntityFrameworkCore;

namespace core.Repository.Impl
{
    public class RepositorioCliente : RepositorioBase<Cliente>, IRepositorioCliente
    {
        private readonly APIClienteContext _context;

        public RepositorioCliente(APIClienteContext context) : base(context)
        {
            _context = context;
        }

        public override Cliente BuscarPorId(int id) => _context.Cliente.Include(c => c.Contatos).AsNoTracking().FirstOrDefault(c => c.Identificador == id);

        public override IEnumerable<Cliente> BuscarTodos() => _context.Cliente.Include(c => c.Contatos).AsNoTracking();

        public override void Atualizar(Cliente entidade)
        {
            _context.Cliente.Attach(entidade);
            _context.Entry(entidade).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public override void Adicionar(Cliente entidade)
        {
            _context.Cliente.Attach(entidade);
            _context.Set<Cliente>().Add(entidade);
            _context.SaveChanges();
        }

        public IEnumerable<Cliente> BuscarPorNome(string nome) 
                                    => _context.Cliente.Include(c => c.Contatos).Where(c => c.Nome.Contains(nome)).AsNoTracking();
        

        public IEnumerable<Cliente> BuscarPorEndereco(string nome)
                                    => _context.Cliente.Include(c => c.Contatos).Where(c => c.Endereco.Contains(nome)).AsNoTracking();
        
    }
}