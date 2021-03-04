using System;

namespace core.Modelo
{
    public class Contato : EntidadeBase
    {
        public string Tipo { get; set; }
        public string Descricao { get; set; }
        public int ClienteId { get; set; }
        public virtual Cliente Cliente { get; set; }
        public Contato()
        {
            
        }

        public Contato(string tipoContato, string descricaoContato)
        {
            Validar(tipoContato, descricaoContato);
            Tipo = tipoContato;
            Descricao = descricaoContato;
        }

        private  void Validar(string tipoContato, string descricaoContato)
        {
            if (string.IsNullOrEmpty(tipoContato) || string.IsNullOrEmpty(tipoContato)) throw new ArgumentException(nameof(tipoContato));
            if (string.IsNullOrEmpty(descricaoContato) || string.IsNullOrEmpty(descricaoContato)) throw new ArgumentException(nameof(descricaoContato));

        }

    }
}