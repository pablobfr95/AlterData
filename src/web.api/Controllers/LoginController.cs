using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using core.Modelo.Auth;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using web.api.Configuracao;
using web.api.Contratos;
using web.api.ServicoAplicacao;

namespace web.api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LoginController : ControllerBase
    {
        private readonly UserManager<Usuario> _userManager;
        private readonly JwtConfiguracao _jwtConfiguracao;

        public LoginController(UserManager<Usuario> userManager, IOptionsSnapshot<JwtConfiguracao> jwtConfiguracao,  RoleManager<Role> roleManager)
        {
            _userManager = userManager;
            _jwtConfiguracao = jwtConfiguracao.Value;
        }

        [HttpPost]
        public async Task<IActionResult> Login([FromBody] ContratoLogin login)
        {
            try
            {
                var user = await _userManager.FindByNameAsync(login.Login);
                if (user == null) return NotFound("Usuário não encontrado !");
                
                var senhaCorreta = await _userManager.CheckPasswordAsync(user, login.Senha);
                if (!senhaCorreta) return BadRequest("Senha Incorreta !");

                var roles = await _userManager.GetRolesAsync(user);

                var token = GenerateJwt(user, roles);

                return Ok(token);
                
            }
            catch (System.Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        private UsuarioToken GenerateJwt(Usuario user, IList<string> roles)
        {

            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString())
            };

            var roleClaims = roles.Select(r => new Claim(ClaimTypes.Role, r));
            claims.AddRange(roleClaims);

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtConfiguracao.Secret));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expires = DateTime.Now.AddMinutes(_jwtConfiguracao.ExpiracaoMinutos);

            var token = new JwtSecurityToken(
                issuer: _jwtConfiguracao.Issuer,
                audience: _jwtConfiguracao.Issuer,
                claims,
                expires : expires,
                signingCredentials : creds
            );

            var tokenGerado = new UsuarioToken();
            tokenGerado.Token = new JwtSecurityTokenHandler().WriteToken(token);
            tokenGerado.Expiration = DateTime.Now.AddMinutes(_jwtConfiguracao.ExpiracaoMinutos);
            return tokenGerado;
           
        }
    }
}