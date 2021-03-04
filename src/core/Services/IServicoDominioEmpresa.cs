namespace Alterdata.Bimer.Core.Servico
{
    using System.Collections.Generic;

    using Alterdata.Bimer.Core.Modelo;

    /// <summary>
    /// Interface para abstração do serviço de domínio de empresas
    /// </summary>
    public interface IServicoDominioEmpresa
    {
        /// <summary>
        /// Obtém as empresas.
        /// </summary>
        /// <returns>A lista com todas as entidades de empresa encontradas.</returns>
        IEnumerable<Empresa> ObterEmpresas();
    }
}