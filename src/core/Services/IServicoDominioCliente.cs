using System.Collections.Generic;
using core.Modelo;

namespace core.Services
{
    public interface IServicoDominioCliente : IServicoDominioBase<Cliente>
    {
         void Ativar(Cliente cliente);

         void Inativar(Cliente cliente);

         void Adicionar(Cliente cliente, IEnumerable<Contato> contatos);

         IEnumerable<Cliente> BuscarPorNome(string nome);
         IEnumerable<Cliente> BuscarPorEndereco(string endereco);

    }
}