using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Dominio.Enumeradore;
using Dominio.Extensao;

namespace Dominio.ObjetoDeValor
{
    public class Periodicidade
    {
        private Periodicidade(EPeriodicidade enumPeriodicidade)
        {
            Id = (int)enumPeriodicidade;
            Name = enumPeriodicidade.ToString();
            Description = enumPeriodicidade.GetEnumDescription();
        }

        protected Periodicidade() { } //For EF

        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public static implicit operator Periodicidade(EPeriodicidade enumPeriodicidade) => new Periodicidade(enumPeriodicidade);

        public static implicit operator EPeriodicidade(Periodicidade periodicidade) => (EPeriodicidade)periodicidade.Id;
    }
}
