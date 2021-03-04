using System.Collections.Generic;
using core.Modelo;

namespace core.Repository
{
    public interface IRepositorioContato : IRepositorioBase<Contato>
    {
         void ExcluirContatosAntigos(IEnumerable<Contato> contatosAntigos);

         IEnumerable<Contato> BuscarPorCliente(int idCliente);

    }
}