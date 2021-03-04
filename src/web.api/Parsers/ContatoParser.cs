using System.Collections.Generic;
using System.Linq;
using core.Modelo;
using web.api.Contratos;

namespace web.api.Parsers
{
    public static class ContatoParser
    {
        public static ContratoRetornoContato Converter(Contato contato)
        {
            return new ContratoRetornoContato
            {
                Id = contato.Identificador,
                Tipo = contato.Tipo,
                Descricao = contato.Descricao
            };
        }

        public static Contato Converter(ContratoRetornoContato contratoRetornoContato)
        {
            return new Contato(contratoRetornoContato.Tipo.ToUpper(), contratoRetornoContato.Descricao);
        }

        public static IEnumerable<ContratoRetornoContato> Converter(IEnumerable<Contato> contatos)
        {
            if (contatos == null) return null;
            return contatos.Select(contato => Converter(contato));
        }

        public static IEnumerable<Contato> Converter(IEnumerable<ContratoRetornoContato> contatos)
        {
            if (contatos == null) return null;
            return contatos.Select(contato => Converter(contato));
        }
    }
}