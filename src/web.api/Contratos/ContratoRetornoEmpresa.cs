namespace Alterdata.Bimer.WebAPI.Contratos
{
    using System.Runtime.Serialization;

    /// <summary>
    /// DTO para Endpoints de empresas
    /// </summary>
    [DataContract]
    public class ContratoRetornoEmpresa
    {
        /// <summary>
        /// Obtém ou define o nome da empresa.
        /// </summary>
        [DataMember(Name = "identificador")]
        public int Identificador { get; set; }

        /// <summary>
        /// Obtém ou define o nome da empresa.
        /// </summary>
        [DataMember(Name = "razaoSocial")]
        public string RazaoSocial { get; set; }

        /// <summary>
        /// Obtém ou define o CNPJ da empresa.
        /// </summary>
        [DataMember(Name = "cnpj")]
        public string CNPJ { get; set; }

    }
}