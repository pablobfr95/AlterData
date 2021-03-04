using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace web.api.Contratos
{
    public class ContratoAtualizacaoUsuario
    {
        /// <summary>
        /// Define o login do Usuário.
        /// </summary>
        [DataMember(Name = "login")]
        [Required]
        public string Login { get; set; }
        /// <summary>
        /// Define o senha do Usuário.
        /// </summary>
        [DataMember(Name = "senha")]
        [Required]
        [MinLength(6)]
        public string Senha { get; set; }
        /// <summary>
        /// Define o senha antiga do Usuário.
        /// </summary>
        [DataMember(Name = "senhaAntiga")]
        [Required]
        [MinLength(6)]
        public string SenhaAntiga { get; set; }
        /// <summary>
        /// Obtém ou define o novo email do Usuário.
        /// </summary>
        [DataMember(Name = "novoEmail")]
        [Required]
        [EmailAddress]
        public string NovoEmail { get; set; }
    }
}