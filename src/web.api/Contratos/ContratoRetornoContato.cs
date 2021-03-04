using System.Runtime.Serialization;

namespace web.api.Contratos
{
    public class ContratoRetornoContato
    {
        /// <summary>
        /// Obtém ou define o Id do Contato.
        /// </summary>
        [DataMember(Name = "id")]
        public int Id { get; set; }
        /// <summary>
        /// Obtém ou define o Tipo do Contato.
        /// </summary>
        [DataMember(Name = "tipo")]
        public string Tipo { get; set; }
        /// <summary>
        /// Obtém ou define o Descrição.
        /// </summary>
        [DataMember(Name = "descricao")]
        public string Descricao { get; set; }
        
        
    }
}