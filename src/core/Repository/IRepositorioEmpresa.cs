namespace Alterdata.Bimer.Core.Repositorio
{
    using System.Collections.Generic;
    using Alterdata.Bimer.Core.Modelo;

    /// <summary>
    /// Interface para abstração do repositório de empresas
    /// </summary>    
    public interface IRepositorioEmpresa
    {
        /// <summary>
        /// Obtém as empresas.
        /// </summary>
        /// <returns>A lista com todas as entidades de empresa encontradas.</returns>
        IEnumerable<Empresa> ObterTodas();
    }
}