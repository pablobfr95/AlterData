using System.Collections.Generic;

namespace core.Repository
{
    public interface IRepositorioBase<T> where T : class
    {
        void Adicionar(T entidade);
        void Atualizar(T entidade);
        void Excluir(T entidade);
        T BuscarPorId(int id);
        IEnumerable<T> BuscarTodos();
        
        void Dispose();

        void AbrirTransacao();
        void Commit();
        void RollBack();

        void SalvarAlteracao();
    }
}