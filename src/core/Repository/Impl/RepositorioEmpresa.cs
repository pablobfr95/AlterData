namespace Alterdata.Bimer.Core.Repositorio.Impl
{
    using System.Collections.Generic;
    using System.Data;
    using Alterdata.Bimer.Core.Modelo;
    using Dapper;

    /// <summary>
    /// Implementação concreta do respositório de empresas
    /// </summary>
    public class RepositorioEmpresa : IRepositorioEmpresa
    {
        private IDbConnection _connection;

        public RepositorioEmpresa(IDbConnection connection)
        {
            _connection = connection;
        }

        public IEnumerable<Empresa> ObterTodas()
        {
            var retorno = _connection.Query<Empresa>(@"
                SELECT
                    ID as Identificador,
                    RAZAO_SOCIAL as RazaoSocial,
                    CNPJ
                FROM
                    Empresas
            ");           
            return retorno;
        }
    }
}