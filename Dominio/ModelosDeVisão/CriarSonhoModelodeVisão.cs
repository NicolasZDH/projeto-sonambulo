using System.ComponentModel.DataAnnotations;

namespace WebApi.ModelosDeVisão
{
    public class CriarSonhoModelodeVisão
    {
        [Required]
        public string Descricao { get; init; }
        [Required]
        public List<CriarTarefaModelodeVisão> Tarefas { get; init; }
    }
}
