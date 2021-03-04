using System;
using System.Collections.Generic;
using core.Modelo;
using core.Repository;

namespace core.Services.Impl
{
    public abstract class ServicoDominioBase<T> : IServicoDominioBase<T> where T : EntidadeBase
    {
        private readonly IRepositorioBase<T> _repositorio;
        public ServicoDominioBase(IRepositorioBase<T> repositorio)
        {
            _repositorio = repositorio ?? throw new ArgumentException(nameof(repositorio));
        }
        public virtual void Adicionar(T entidade) => _repositorio.Adicionar(entidade);


        public virtual void Atualizar(T entidade) => _repositorio.Atualizar(entidade);


        public virtual T BuscarPorId(int id) => _repositorio.BuscarPorId(id);


        public virtual IEnumerable<T> BuscarTodos() => _repositorio.BuscarTodos();

        public virtual void Excluir(T entidade) => _repositorio.Excluir(entidade);
    }
}