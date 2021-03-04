using System;
using System.Collections.Generic;
using System.Linq;

namespace core.Modelo
{
    public class Cliente : EntidadeBase
    {
        public string Nome { get; private set; }
        public string Endereco { get; private set; }
        public DateTime DataNascimento { get; private set; }
        public char Status { get;  set; } = 'A';

        public virtual IEnumerable<Contato> Contatos { get; set; }

        public Cliente()
        {
            
        }
        
        public Cliente(string nome, string endereco, string dataNascimento, IEnumerable<Contato> contatos)
        {
            Validar(nome, endereco, dataNascimento, contatos);
            Nome = nome;
            Endereco = endereco;
            DataNascimento = Convert.ToDateTime(dataNascimento);
            Contatos = contatos;
            
        }
        public Cliente(int id, string nome, string endereco, string dataNascimento, IEnumerable<Contato> contatos)
        {
            ValidarAtualizacao(id, nome, endereco, dataNascimento, contatos);
            Identificador = id;
            Nome = nome;
            Endereco = endereco;
            DataNascimento = Convert.ToDateTime(dataNascimento);
            Contatos = contatos;
            
        }
        private void ValidarAtualizacao(int id, string nome, string endereco, string dataNascimento, IEnumerable<Contato> contatos)
        {
            if (id == 0) throw new ArgumentNullException(nameof(id));
            Validar(nome, endereco, dataNascimento, contatos);
        }

        private void Validar(string nome, string endereco, string dataNascimento, IEnumerable<Contato> contatos)
        {
            if (string.IsNullOrEmpty(nome) || string.IsNullOrWhiteSpace(nome)) throw new ArgumentNullException(nameof(nome));
            if (string.IsNullOrEmpty(endereco) || string.IsNullOrWhiteSpace(endereco)) throw new ArgumentNullException(nameof(endereco));
            DateTime dataNascimentoDate;
            if (!DateTime.TryParse(dataNascimento, out dataNascimentoDate)) throw new ArgumentException(nameof(dataNascimento));
            if (Convert.ToDateTime(dataNascimento) >= DateTime.Now ) throw new ArgumentNullException(nameof(dataNascimento));
            if (contatos.Count() < 2) throw new ArgumentException("Informe pelo menos 2 contatos para poder Salvar o Cliente");
            
        }

    }
}