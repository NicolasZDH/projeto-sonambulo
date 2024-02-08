namespace Dominio.ObjetoDeValor
{
    public class Feito: ObjetoDeValorBase
    {
        public Guid TarefaId { get; init; }
        public DateTime Data { get; init; }
        public bool Concluido { get; init; }
    }
}
