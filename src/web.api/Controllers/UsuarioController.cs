using System.Linq;
using System.Threading.Tasks;
using core.Modelo.Auth;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using web.api.Contratos;
using web.api.ServicoAplicacao;

namespace web.api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class UsuarioController : ControllerBase
    {
        private readonly UserManager<Usuario> _userManager;
        private readonly RoleManager<Role> _roleManager;


        public UsuarioController(UserManager<Usuario> userManager, RoleManager<Role> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        [HttpPost("CriarFuncao")]
        [AllowAnonymous]
        
        public async Task<IActionResult> CriarFuncao([FromBody] ContratoRetornoRole contrato)
        {
            try
            {
                if (!ModelState.IsValid) return BadRequest("Descricao Obrigatória !");
                var role = new Role{
                   Name = contrato.Nome
                };

                var resultado = await _roleManager.CreateAsync(role);

                if (resultado.Succeeded) return Created("", "Função criada com sucesso !");

                return Problem(resultado.Errors.FirstOrDefault().Description, null, 500);

            }
            catch (System.Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost("AssociarFuncao")]
        public async Task<IActionResult> AssociarFuncao([FromBody] ContratroAssociacaoFuncaoUsuario contrato)
        {
            try
            {
                if (!ModelState.IsValid) return BadRequest();

                var user = await _userManager.FindByNameAsync(contrato.Login);

                if(user == null) return NotFound("Usuário não encontrado !");

                var resultado = await _userManager.AddToRoleAsync(user, contrato.Role);

                if (resultado.Succeeded) return Ok("Função associado ao usuário com sucesso !");

                return Problem(resultado.Errors.FirstOrDefault().Description, null, 500);
            }
            catch (System.Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost("Criar")]
        [AllowAnonymous]
        public async Task<IActionResult> Criar([FromBody] ContratoCadastroUsuario contrato)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var user = Parsers.UsuarioParser.Converter(contrato);
                    var resultado = await _userManager.CreateAsync(user, contrato.Senha);
                    if (resultado.Succeeded) return StatusCode(201, "Usuário criado Com sucesso");
                    else
                    {
                        return Problem(resultado.Errors.FirstOrDefault().Description, null, 500);
                    }
                }
                else
                {
                    return BadRequest("Parametros Inválidos !");
                }
            }
            catch (System.Exception ex)
            {
                 return StatusCode(500, ex.Message);
            }
        }

        [HttpPatch]
        public async Task<IActionResult> Atualizar([FromBody] ContratoAtualizacaoUsuario contrato)
        {
            try
            {
                if (ModelState.IsValid)
                {
                   
                    var usuario = await _userManager.FindByNameAsync(contrato.Login);
                    if (usuario == null) return NotFound("Login não encontrado !");
                    var tokenTrocarEmail = await _userManager.GenerateChangeEmailTokenAsync(usuario, contrato.NovoEmail);
                    var resultadoTrocaEmail = await _userManager.ChangeEmailAsync(usuario, contrato.NovoEmail, tokenTrocarEmail);
                    if (!resultadoTrocaEmail.Succeeded) return Problem(resultadoTrocaEmail.Errors.FirstOrDefault().Description, null, 500);
                    var resultadoTrocaSenha = await _userManager.ChangePasswordAsync(usuario, contrato.SenhaAntiga, contrato.Senha);
                    if(!resultadoTrocaSenha.Succeeded) return Problem(resultadoTrocaSenha.Errors.FirstOrDefault().Description, null, 500);
                    return Ok();
                }
                else
                {
                    return BadRequest("Parametros Inválidos !");
                }
            }
            catch (System.Exception ex)
            {
                 return StatusCode(500, ex.Message);
            }
        }
        [HttpDelete]
        [Authorize(Roles = "teste")]
        public async Task<IActionResult> Remover(string username)
        {
            try
            {
                var usuario = await _userManager.FindByNameAsync(username);
                if (usuario == null) return NotFound("Usuário não encontrado com o login informado !");
                var resultado = await _userManager.DeleteAsync(usuario);
                if (!resultado.Succeeded) return Problem(resultado.Errors.FirstOrDefault().Description, null, 500);
                return Ok("Usuário removido com sucesso !");
            }
            catch (System.Exception ex)
            {
                 return StatusCode(500, ex.Message);
            }
        }

    }
}