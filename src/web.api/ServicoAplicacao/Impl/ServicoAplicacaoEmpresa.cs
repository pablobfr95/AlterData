namespace Alterdata.Bimer.WebAPI.ServicoAplicacao.Impl
{
    using System.Collections.Generic;

    using Alterdata.Bimer.WebAPI.Parsers;
    using Alterdata.Bimer.WebAPI.Contratos;
    using Alterdata.Bimer.Core.Servico;

    /// <summary>
    /// Implementação concreta do serviço de domínio de empresas
    /// </summary>
    public class ServicoAplicacaoEmpresa : IServicoAplicacaoEmpresa
    {
        private IServicoDominioEmpresa _servicoDominioEmpresa;

        public ServicoAplicacaoEmpresa(IServicoDominioEmpresa servicoDominioEmpresa)
        {
            _servicoDominioEmpresa = servicoDominioEmpresa;
        }
        
        public IEnumerable<ContratoRetornoEmpresa> ObterEmpresas()
        {
            var listaEmpresas = _servicoDominioEmpresa.ObterEmpresas();
            return EmpresaParser.Converter(listaEmpresas);
        }
    }
}