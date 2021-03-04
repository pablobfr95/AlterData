using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using web.api.Contratos;
using web.api.ServicoAplicacao;

namespace web.api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class ClienteController : ControllerBase
    {
        private readonly IServicoAplicacaoCliente _servicoAplicacaoCliente;

        public ClienteController(IServicoAplicacaoCliente servicoAplicacaoCliente)
        {
            _servicoAplicacaoCliente = servicoAplicacaoCliente;
        }

        [HttpGet("ObterTodos")]
        public IActionResult Listar()
        {
            try
            {
                return Ok(_servicoAplicacaoCliente.ObterTodos());
            }
            catch (System.Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("BuscarPorId")]
        public IActionResult BuscarPorId(int id)
        {
            try
            {
                var cliente = _servicoAplicacaoCliente.BuscarPorId(id);
                if (cliente == null) return NotFound("Cliente não encontrado com Id informado !");
                return Ok(cliente);
            }
            catch (System.Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("BuscarPorNome")]
        [Authorize(Roles = "admin")]
        public IActionResult BuscarPorNome(string nome)
        {
            try
            {
                var cliente = _servicoAplicacaoCliente.BuscarPorNome(nome);
                if (cliente == null) return NotFound("Cliente não encontrado com o nome informado !");
                return Ok(cliente);
            }
            catch (System.Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("BuscarPorEndereco")]
        [Authorize(Roles = "admin")]
        public IActionResult BuscarPorEndereco(string endereco)
        {
            try
            {
                var cliente = _servicoAplicacaoCliente.BuscarPorEndereco(endereco);
                if (cliente == null) return NotFound("Cliente não encontrado com Id informado !");
                return Ok(cliente);
            }
            catch (System.Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost]
        public IActionResult Criar([FromBody]ContratoRetornoCliente contrato)
        {
            try
            {
                _servicoAplicacaoCliente.Adicionar(contrato);
                return StatusCode(201, "Cliente criado com sucesso !");
            }
            catch (System.Exception ex)
            {
                 return StatusCode(500, ex.Message);
            }
        }
        [HttpPut("Ativar")]
        public IActionResult Ativar([FromBody] ContratoRetornoCliente contrato)
        {
            try
            {
                var cliente = _servicoAplicacaoCliente.BuscarPorId(contrato.Id);
                if (cliente == null) return NotFound("Cliente não encontrado com o Id informado !");
                if (cliente.Status == "A") return BadRequest("Cliente já se encontrado com status Ativo !");
                _servicoAplicacaoCliente.Ativar(cliente);
                return Ok();
            }
            catch (System.Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut("Inativar")]
        public IActionResult Inativar([FromBody] ContratoRetornoCliente contrato)
        {
            try
            {
                var cliente = _servicoAplicacaoCliente.BuscarPorId(contrato.Id);
                if (cliente == null) return NotFound("Cliente não encontrado com o Id informado !");
                if (cliente.Status == "I") return BadRequest("Cliente já se encontrado com status Inativo !");
                _servicoAplicacaoCliente.Inativar(cliente);
                return Ok();
            }
            catch (System.Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPatch]
        public IActionResult Atualizar([FromBody]ContratoRetornoCliente contrato)
        {
            try
            {
                if (_servicoAplicacaoCliente.BuscarPorId(contrato.Id) == null) return NotFound("Cliente não econtrado com Id informado !");
                _servicoAplicacaoCliente.Atualizar(contrato);
                return Ok();
            }
            catch (System.Exception ex)
            {
                 return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete]
        public IActionResult Remover(int id)
        {
            try
            {
                var cliente = _servicoAplicacaoCliente.BuscarPorId(id);
                if (cliente == null) return NotFound("Cliente não encontrado com o Id informado !");
                _servicoAplicacaoCliente.Remover(id);
                return Ok();
            }
            catch (System.Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        
    }
}