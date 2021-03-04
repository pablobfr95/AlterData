using System.Collections.Generic;
using core.Modelo;

namespace core.Services
{
    public interface IServicoDominioBase<T> where T : EntidadeBase
    {
        void Adicionar(T entidade);
        void Atualizar(T entidade);
        void Excluir(T entidade);
        T BuscarPorId(int id);
        IEnumerable<T> BuscarTodos();
       
    }
}