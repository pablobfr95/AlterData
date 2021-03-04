using System.Collections.Generic;
using web.api.Contratos;

namespace web.api.ServicoAplicacao
{
    public interface IServicoAplicacaoCliente
    {
         IEnumerable<ContratoRetornoCliente> ObterTodos();
         ContratoRetornoCliente BuscarPorId(int id);
         IEnumerable<ContratoRetornoCliente> BuscarPorNome(string nome);
         IEnumerable<ContratoRetornoCliente> BuscarPorEndereco(string endereco);
         void Adicionar(ContratoRetornoCliente contrato);
         void Atualizar(ContratoRetornoCliente contrato);
         void Remover(int id);
         void Ativar(ContratoRetornoCliente contrato);
         void Inativar(ContratoRetornoCliente contrato);
    }
}