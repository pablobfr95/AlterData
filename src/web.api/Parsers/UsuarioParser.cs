using core.Modelo.Auth;
using web.api.Contratos;

namespace web.api.Parsers
{
    public static class UsuarioParser
    {
        public static Usuario Converter(ContratoLogin login)
        {
            return new Usuario{
                UserName = login.Login,
            };
        }

        public static Usuario Converter(ContratoCadastroUsuario usuario)
        {
            return new Usuario{
                UserName = usuario.Login,
                Email = usuario.Email,
            };
        }
    }
}