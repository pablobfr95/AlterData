using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace web.api.Contratos
{
    public class ContratoLogin
    {
        /// <summary>
        /// Define o login do Usuário.
        /// </summary>
        [DataMember(Name = "login")]
        [Required]
        public string Login { get; set; }

        /// <summary>
        /// Define a senha do Usuário.
        /// </summary>
        [DataMember(Name = "senha")]
        [Required]
        public string Senha { get; set; }

    }
}