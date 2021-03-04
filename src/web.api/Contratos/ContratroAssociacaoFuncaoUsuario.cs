using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace web.api.Contratos
{
    public class ContratroAssociacaoFuncaoUsuario
    {
        /// <summary>
        /// Define o login do usuário.
        /// </summary>
        [Required]
        [DataMember(Name = "login")]
        public string Login { get; set; }
        /// <summary>
        /// Define o nome da função para ser associado ao usuário.
        /// </summary>
        [Required]
        [DataMember(Name = "role")]
        public string Role { get; set; }
    }
}