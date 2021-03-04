namespace Alterdata.Bimer.WebAPI.Parsers
{
    using System.Collections.Generic;
    using System.Linq;

    using Alterdata.Bimer.WebAPI.Contratos;
    using Alterdata.Bimer.Core.Modelo;

    /// <summary>
    /// Mapeador entre entidades e DTOs de empresas
    /// </summary>
    public static class EmpresaParser
    {
        /// <summary>
        /// Converte um modelo de domínio de empresa em um DTO de empresa.
        /// </summary>
        /// <param name="empresa">O modelo a ser convertido.</param>
        /// <returns>O DTO convertido.</returns>
        public static ContratoRetornoEmpresa Converter(Empresa empresa)
        {
            return new ContratoRetornoEmpresa
            {
                RazaoSocial = empresa.RazaoSocial,
                CNPJ = empresa.CNPJ,
                Identificador = empresa.Identificador
            };
        }

        /// <summary>
        /// Converte um DTO de empresa em um modelo de domínio de empresa.
        /// </summary>
        /// <param name="contratoRetornoEmpresa">O DTO a ser convertido.</param>
        /// <returns>O modelo convertido.</returns>
        public static Empresa Converter(ContratoRetornoEmpresa contratoRetornoEmpresa)
        {
            return new Empresa
            {
                RazaoSocial = contratoRetornoEmpresa.RazaoSocial,
                CNPJ = contratoRetornoEmpresa.CNPJ,
                Identificador = contratoRetornoEmpresa.Identificador
            };
        }

        /// <summary>
        /// Converte uma lista de modelos de domínio de empresa em uma lista de DTOs de empresa.
        /// </summary>
        /// <param name="empresas">Os modelos a serem convertidos.</param>
        /// <returns>Os DTOs convertidos.</returns>
        public static IEnumerable<ContratoRetornoEmpresa> Converter(IEnumerable<Empresa> empresas)
        {
            return empresas.Select(empresa => Converter(empresa));
        }
    }
}