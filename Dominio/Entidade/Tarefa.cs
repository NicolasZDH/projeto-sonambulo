using Dominio.Enumeradore;
using Dominio.ObjetoDeValor;
using WebApi.ModelosDeVisão;

namespace Dominio.Entidade
{
    public class Tarefa: EntidadeBase
    {
        public string Nome { get; init; }
        public string Descricao { get; init; }
        public List<Feito> Feitos { get; init; }
        public int QuantidadePorPeriodo { get; init; }
        public bool Ativa { get; private set; }
        public List<Recordacao> Recordacoes { get; init; }
        public EPeriodicidade Periodicidade { get; init; }

        public Tarefa() { }

        public Tarefa(CriarTarefaModelodeVisão modeloTarefa)
        {
            Nome = modeloTarefa.Nome;
            Descricao = modeloTarefa.Descricao;
            Feitos = new List<Feito>();
            QuantidadePorPeriodo = modeloTarefa.QuantidadePorPeriodo;
            Recordacoes = new List<Recordacao>();
            Periodicidade = modeloTarefa.Periodicidade;
            Ativa = true;
        }

        public void Desativar() => this.Ativa = false; 
    }
}
