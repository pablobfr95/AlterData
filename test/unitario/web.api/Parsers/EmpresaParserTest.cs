namespace unitario.web.api.Parsers
{
    using Alterdata.Bimer.Core.Modelo;
    using Alterdata.Bimer.WebAPI.Parsers;
    using NUnit.Framework;

    [TestFixture]
    public class EmpresaParserTest
    {
        private Empresa _stubEmpresa;

        [SetUp]        
        public void SetUp()
        {
            _stubEmpresa = new Empresa
            {
                CNPJ = "00.000.000/0000-00",
                RazaoSocial = "Padaria do Zé Ltda.",
                Identificador = 1
            };
        }

        [TestCase(Description = "Esse é um teste unitário de exemplo")]
        public void Deve_Converter_Um_Model_De_Empresas_Para_Um_Contrato_De_Empresa_Com_Sucesso()
        {
            var empresaConvertida = EmpresaParser.Converter(_stubEmpresa);
            Assert.AreEqual(_stubEmpresa.Identificador, empresaConvertida.Identificador);
            Assert.AreEqual(_stubEmpresa.RazaoSocial, empresaConvertida.RazaoSocial);
            Assert.AreEqual(_stubEmpresa.CNPJ, empresaConvertida.CNPJ);
        }
    }
}