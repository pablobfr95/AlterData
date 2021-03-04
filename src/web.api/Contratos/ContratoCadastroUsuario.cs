using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using core.Modelo.Auth;

namespace web.api.Contratos
{
    public class ContratoCadastroUsuario
    {
        /// <summary>
        /// Define o login Usuário.
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
        /// Define o email do Usuário.
        /// </summary>
        [DataMember(Name = "email")]
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        
    }
}