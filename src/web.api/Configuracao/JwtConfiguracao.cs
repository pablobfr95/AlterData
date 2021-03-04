namespace web.api.Configuracao
{
    public class JwtConfiguracao
    {
        public string Secret { get; set; }
        public int ExpiracaoMinutos { get; set; }
        public string Issuer { get; set; }
    }
}