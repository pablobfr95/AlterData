using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace web.api.Contratos
{
    [DataContract]
    public class ContratoRetornoCliente
    {
        /// <summary>
        /// Obtém ou define o Id do cliente.
        /// </summary>
        [DataMember(Name = "id")]
        public int Id { get; set; }
        /// <summary>
        /// Obtém ou define o nome do cliente.
        /// </summary>
        [DataMember(Name = "nome")]
        public string Nome { get; set; }
        /// <summary>
        /// Obtém ou define o endereco do cliente.
        /// </summary>
        [DataMember(Name = "endereco")]
        public string Endereco { get; set; }
        /// <summary>
        /// Obtém ou define o data de nascimento do cliente.
        /// </summary>
        [DataMember(Name = "dataNascimento")]
        public string DataNascimento { get; set; }
        /// <summary>
        /// Obtém ou define o status do cliente.
        /// </summary>
        [DataMember(Name = "status")]
        public string Status { get; set; }
         /// <summary>
        /// Obtém ou define os contatos do cliente.
        /// </summary>
        [DataMember(Name = "contatos")]
        public IEnumerable<ContratoRetornoContato> Contatos { get; set; }
    }
}