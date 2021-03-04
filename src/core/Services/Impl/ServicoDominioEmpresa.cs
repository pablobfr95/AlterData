namespace Alterdata.Bimer.Core.Servico.Impl
{
    using System.Collections.Generic;

    using Alterdata.Bimer.Core.Modelo;
    using Alterdata.Bimer.Core.Repositorio;

    /// <summary>
    /// Implementação concreta do serviço de domínio de empresas
    /// </summary>
    public class ServicoDominioEmpresa : IServicoDominioEmpresa
    {
        private IRepositorioEmpresa _repositorio;

        public ServicoDominioEmpresa(IRepositorioEmpresa repositorio)
        {
            _repositorio = repositorio;
        }

        public IEnumerable<Empresa> ObterEmpresas()
        {
            return _repositorio.ObterTodas();
        }
    }
}