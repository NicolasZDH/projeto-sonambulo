using System.ComponentModel.DataAnnotations;

namespace Dominio.Entidade
{
    public class Pessoa: EntidadeBase
    {
        public string Nome { get; init; }
        public string Email { get; init; }
        public string Senha { get; init; }
        public List<Sonho> Sonhos { get; init; }
    }
}
