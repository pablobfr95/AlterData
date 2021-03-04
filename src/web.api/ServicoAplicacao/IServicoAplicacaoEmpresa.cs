namespace Alterdata.Bimer.WebAPI.ServicoAplicacao
{
    using System.Collections.Generic;
    using Alterdata.Bimer.WebAPI.Contratos;

    /// <summary>
    /// Interface para abstração do serviço de aplicação de empresas
    /// </summary>
    public interface IServicoAplicacaoEmpresa
    {
        /// <summary>
        /// Obtém todas as empresas cadastradas.
        /// </summary>
        /// <returns>As empresas cadastradas.</returns>
        IEnumerable<ContratoRetornoEmpresa> ObterEmpresas();
    }
}