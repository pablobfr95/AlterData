using System;

namespace core.Modelo.Auth
{
    public class UsuarioToken
    {
        public string Token { get; set; }
        public DateTime Expiration { get; set; }
    }
}