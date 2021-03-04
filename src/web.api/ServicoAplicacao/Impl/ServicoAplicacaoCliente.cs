using System;
using System.Collections.Generic;
using core.Services;
using web.api.Contratos;
using web.api.Parsers;

namespace web.api.ServicoAplicacao.Impl
{
    public class ServicoAplicacaoCliente : IServicoAplicacaoCliente
    {
        private readonly IServicoDominioCliente _servicoDominioCliente;
        
        
        public ServicoAplicacaoCliente(IServicoDominioCliente servicoDominioCliente, IServicoDominioContato servicoDominioContato)
        {
            _servicoDominioCliente = servicoDominioCliente ?? throw new ArgumentNullException(nameof(servicoDominioCliente));
            
        }

        public void Adicionar(ContratoRetornoCliente contrato)
        {
            var cliente = ClienteParser.Converter(contrato);
            var contatos = ContatoParser.Converter(contrato.Contatos);
            _servicoDominioCliente.Adicionar(cliente, contatos);
        }

        public void Ativar(ContratoRetornoCliente contrato)
        {
            var cliente = ClienteParser.ConverterAtualizacao(contrato);
            _servicoDominioCliente.Ativar(cliente);
        }

        public void Atualizar(ContratoRetornoCliente contrato)
        {
            var cliente = ClienteParser.ConverterAtualizacao(contrato);
            _servicoDominioCliente.Atualizar(cliente);
        }

        public IEnumerable<ContratoRetornoCliente> BuscarPorEndereco(string endereco)
        {
            var clientes = _servicoDominioCliente.BuscarPorEndereco(endereco);
            return ClienteParser.Converter(clientes);
        }

        public ContratoRetornoCliente BuscarPorId(int id)
        {
            var cliente = _servicoDominioCliente.BuscarPorId(id);
            if (cliente == null) return null;
            return ClienteParser.Converter(cliente);
        }

        public IEnumerable<ContratoRetornoCliente> BuscarPorNome(string nome)
        {
            var clientes = _servicoDominioCliente.BuscarPorNome(nome);
            return ClienteParser.Converter(clientes);
        }

        public void Inativar(ContratoRetornoCliente contrato)
        {
            var cliente = ClienteParser.ConverterAtualizacao(contrato);
            _servicoDominioCliente.Inativar(cliente);
        }

        public IEnumerable<ContratoRetornoCliente> ObterTodos()
        {
            var clientes = _servicoDominioCliente.BuscarTodos();
            return ClienteParser.Converter(clientes);
        }

        public void Remover(int id)
        {
            _servicoDominioCliente.Excluir(_servicoDominioCliente.BuscarPorId(id));
        }
    } 
}