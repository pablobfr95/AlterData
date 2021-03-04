using System.Collections.Generic;
using core.Modelo;

namespace core.Repository
{
    public interface IRepositorioCliente : IRepositorioBase<Cliente>
    {
         IEnumerable<Cliente> BuscarPorNome(string nome);

         IEnumerable<Cliente> BuscarPorEndereco(string nome);
    }
}