using System;
using System.Collections.Generic;
using System.Linq;
using core.Modelo;
using core.Repository;

namespace core.Services.Impl
{
    public class ServicoDominioCliente : ServicoDominioBase<Cliente>, IServicoDominioCliente
    {
        private readonly IRepositorioCliente _repositorioCliente;
        private readonly IRepositorioContato _repositorioContato;

        public ServicoDominioCliente(IRepositorioCliente repositorioCliente, IRepositorioContato repositorioContato)
            : base(repositorioCliente)
        {
            _repositorioCliente = repositorioCliente;
            _repositorioContato = repositorioContato;
        }

        public void Adicionar(Cliente cliente, IEnumerable<Contato> contatos)
        {
             ValidarQuantidadeMinimaContatosDiferentes(contatos);

             cliente.Contatos = cliente.Contatos.ToList();
           
            _repositorioCliente.AbrirTransacao();

            _repositorioCliente.Adicionar(cliente);
     
            try
            {
                _repositorioCliente.Commit();
            }
            catch (System.Exception)
            {
                 _repositorioCliente.RollBack();
                 throw new ArgumentException("Erro ao commitar transações");
            }
        }

        public void Ativar(Cliente cliente)
        {
            cliente.Status = 'A';
            _repositorioCliente.Atualizar(cliente);
        }

        public override void Atualizar(Cliente cliente)
        {
            ValidarQuantidadeMinimaContatosDiferentes(cliente.Contatos);
            
            /*Precisa ser um ICollection para poder salvar */
            cliente.Contatos = cliente.Contatos.ToList();

            _repositorioCliente.AbrirTransacao();

            _repositorioContato.ExcluirContatosAntigos(_repositorioContato.BuscarPorCliente(cliente.Identificador));

             _repositorioCliente.Atualizar(cliente);

            try
            {
                _repositorioCliente.Commit();
            }
            catch (System.Exception)
            {
                 _repositorioCliente.RollBack();
                 throw new ArgumentException("Erro ao commitar transações");
            }
        }

        public IEnumerable<Cliente> BuscarPorEndereco(string endereco)
        {
            return _repositorioCliente.BuscarPorEndereco(endereco);
        }

        public IEnumerable<Cliente> BuscarPorNome(string nome)
        {
            return _repositorioCliente.BuscarPorNome(nome);
        }

        public void Inativar(Cliente cliente)
        {
            cliente.Status = 'I';
            _repositorioCliente.Atualizar(cliente);
        }

        private void ValidarQuantidadeMinimaContatosDiferentes(IEnumerable<Contato> contatos)
        {
            var contatosList = contatos.ToList().GroupBy(c => c.Tipo.ToUpper()).Select(c => c.First());
            if (contatosList.Count() < 2 ) throw new ArgumentException("Cliente precisa ter ao menos 2 contatos diferentes !");   
        }
        
        
    }
}