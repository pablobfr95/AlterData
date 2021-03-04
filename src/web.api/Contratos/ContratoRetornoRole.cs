using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace web.api.Contratos
{
    public class ContratoRetornoRole
    {
        /// <summary>
        /// Define o nome da Função do usuário.
        /// </summary>
        [Required]
        [DataMember(Name = "nome")]
        public string Nome { get; set; }
    }
}