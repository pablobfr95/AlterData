using System;
using System.Collections.Generic;
using System.Linq;
using core.Modelo;
using web.api.Contratos;

namespace web.api.Parsers
{
    public static class ClienteParser
    {
        
        public static ContratoRetornoCliente Converter(Cliente cliente)
        {
            return new ContratoRetornoCliente
            {
                Id = cliente.Identificador,
                Nome = cliente.Nome,
                Endereco = cliente.Endereco,
                DataNascimento = cliente.DataNascimento.ToShortDateString(),
                Status = cliente.Status.ToString(),
                Contatos = ContatoParser.Converter(cliente.Contatos)
            };
        }

        public static Cliente Converter (ContratoRetornoCliente contratoRetornoCliente)
        {
            return new Cliente(contratoRetornoCliente.Nome, contratoRetornoCliente.Endereco,
                                contratoRetornoCliente.DataNascimento, ContatoParser.Converter(contratoRetornoCliente.Contatos));
        }

        public static Cliente ConverterAtualizacao(ContratoRetornoCliente contratoRetornoCliente)
        {
            return new Cliente(contratoRetornoCliente.Id, contratoRetornoCliente.Nome, contratoRetornoCliente.Endereco,
                                contratoRetornoCliente.DataNascimento, ContatoParser.Converter(contratoRetornoCliente.Contatos));
        }

        public static IEnumerable<ContratoRetornoCliente> Converter(IEnumerable<Cliente> clientes)
        {
            if (clientes == null) return null;
            return clientes.Select( cliente => Converter(cliente));
        }

        

    }
}