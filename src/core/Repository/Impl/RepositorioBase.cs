using System;
using System.Collections.Generic;
using System.Linq;
using core.Modelo;
using core.Repository.Context;
using Microsoft.EntityFrameworkCore;

namespace core.Repository.Impl
{
    public abstract class RepositorioBase<T> : IDisposable, IRepositorioBase<T> where T : EntidadeBase
    {
        private readonly APIClienteContext _context;

        public RepositorioBase(APIClienteContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public void AbrirTransacao()
        {
            _context.Database.BeginTransaction();
        }

        public virtual void Adicionar(T entidade)
        {
            _context.Set<T>().Add(entidade);
            _context.SaveChanges();
        }

        public virtual void Atualizar(T entidade)
        {
            _context.Entry(entidade).State = EntityState.Modified;
            _context.SaveChanges();
            
        }

        public virtual T BuscarPorId(int id) => _context.Set<T>().AsNoTracking().FirstOrDefault(t => t.Identificador == id);


        public virtual IEnumerable<T> BuscarTodos() => _context.Set<T>().AsNoTracking().ToList();

        public void Commit()
        {
            _context.Database.CommitTransaction();
        }

        public virtual void Dispose()
        {
            _context.Dispose();
        }

        public virtual void Excluir(T entidade)
        {
            _context.Set<T>().Remove(entidade);
            _context.SaveChanges();
        }

        public void RollBack()
        {
            _context.Database.RollbackTransaction();
        }

        public void SalvarAlteracao()
        {
            _context.SaveChanges();
        }
    }
}