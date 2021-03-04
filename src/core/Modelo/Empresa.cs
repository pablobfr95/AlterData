using core.Modelo;

namespace Alterdata.Bimer.Core.Modelo
{    
    /// <summary>
    /// Modelo de domínio que representa uma Empresa
    /// </summary>
    public class Empresa : EntidadeBase
    {
        
        /// <summary>
        /// Obtém ou define a razão social da empresa.
        /// </summary>
        public string RazaoSocial { get; set; }

        /// <summary>
        /// Obtém ou define o CNPJ da empresa.
        /// </summary>
        public string CNPJ { get; set; }
    }
}