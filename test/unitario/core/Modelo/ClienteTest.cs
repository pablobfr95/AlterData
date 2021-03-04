using System;
using System.Collections.Generic;
using core.Modelo;
using NUnit.Framework;

namespace unitario.core.Modelo
{
    [TestFixture]
    public class ClienteTest
    {
        private ICollection<Contato> contatos;


        public void Setup()
        {
            for (var i = 0; i < 2; i++)
            {
                contatos.Add(new Contato("Telefone", "2154632456"));
            }
        }

        
        [TestCase(1, "Pablo Rodrigues", "Teste de Endereco", "12/01/1990")]
        [TestCase(2, "Pablo Rodrigues", "Teste de Endereco", "12/01/1990")]
        [TestCase(4, "Pablo Rodrigues", "Teste de Endereco", "12/01/1990")]
        [TestCase(9, "Pablo Rodrigues", "Teste de Endereco", "12/01/1990")]
        public void Dados_Corretos_Para_Atualizacao_Cliente_Nao_Deve_Gerar_Exception(int id, string nome, string endereco, string dataNascimento)
        {
           Assert.DoesNotThrow(() => new Cliente(id, nome, endereco, dataNascimento, contatos));
        }

        [TestCase(1, "", "Teste de Endereco", "12/01/1990")]
        [TestCase(0, "Pablo Rodrigues", "Teste de Endereco", "12/01/1990")]
        [TestCase(1, "Pablo Rodrigues", "", "12/01/1990")]
        [TestCase(1, "Pablo Rodrigues", "Teste de Endereco", "999999999")]
        public void Dados_Incorretos_Para_Atualizacao_Cliente_Deve_Gerar_Exception(int id, string nome, string endereco, string dataNascimento)
        {
            Assert.Throws<Exception>(() => new Cliente(id, nome, endereco, dataNascimento, contatos));
        }

        [TestCase("Pablo Rodrigues", "Teste de Endereco", "12/01/1990")]
        [TestCase("Pablo Rodrigues", "Teste de Endereco 5", "01/01/1990")]
        [TestCase("Pablo Rodrigues", "Teste de Endereco 9", "30/01/1990")]
        [TestCase("Pablo Rodrigues", "Teste de Endereco 8", "25/01/1990")]
        public void Dados_Corretos_Para_Inclusao_Cliente_Nao_Deve_Gerar_Exception(string nome, string endereco, string dataNascimento)
        {
            Assert.DoesNotThrow(() => new Cliente(nome, endereco, dataNascimento, contatos));
        }

        
    }
}