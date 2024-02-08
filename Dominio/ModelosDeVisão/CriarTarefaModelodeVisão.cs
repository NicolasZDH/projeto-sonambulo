using Dominio.Enumeradore;
using System.ComponentModel.DataAnnotations;

namespace WebApi.ModelosDeVisão
{
    public class CriarTarefaModelodeVisão
    {
        [Required]
        public string Nome { get; init; }
        [Required]
        public string Descricao { get; init; }
        [Required]
        public int QuantidadePorPeriodo { get; init; }
        [Required]
        public EPeriodicidade Periodicidade { get; init; }
    }
}
