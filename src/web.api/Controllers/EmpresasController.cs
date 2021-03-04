namespace Alterdata.Bimer.WebAPI.Controllers
{
    using System.Collections.Generic;
    using System;

    using Alterdata.Bimer.WebAPI.Contratos;
    using Alterdata.Bimer.WebAPI.ServicoAplicacao;

    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Authorization;

    /// <summary>
    /// Controladora de Empresas
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class EmpresasController : ControllerBase
    {
        private IServicoAplicacaoEmpresa _servicoAplicacaoEmpresa;

        public EmpresasController(IServicoAplicacaoEmpresa servicoAplicacaoEmpresa)
        {
            _servicoAplicacaoEmpresa = servicoAplicacaoEmpresa;
        }

        /// <summary>
        /// Obtém todas as empresas cadastradas.
        /// </summary>
        /// <returns>As empresas cadastradas.</returns>
        [HttpGet]
        public ActionResult<IEnumerable<ContratoRetornoEmpresa>> ObterTodos()
        {
            try
            {
                return Ok(_servicoAplicacaoEmpresa.ObterEmpresas());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}