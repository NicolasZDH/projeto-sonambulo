using Dominio.ObjetoDeValor;
using WebApi.ModelosDeVisão;

namespace Dominio.Entidade
{
    public class Sonho : RaizDeAgregado
    {
        public Guid PessoaId { get; init; }
        public string Descricao { get; init; }
        public DateTime Criacao { get; init; }
        public DateTime? Realizacao { get; private set; }
        public List<Tarefa>? Tarefas { get; init; }
        public List<Recordacao>? Recordacoes { get; init; }

        public bool EhReal() => Realizacao is not null;
        
        public Sonho() { }

        public Sonho(CriarSonhoModelodeVisão modeloSonho)
        {
            Id = Guid.NewGuid();
            PessoaId = new Guid("59116F1A-7CE1-4FBF-8F99-EAE6C6EF195D");
            Descricao = modeloSonho.Descricao;
            Criacao = DateTime.Now.ToUniversalTime();
            Tarefas = modeloSonho.Tarefas.Select(modeloTarefa => new Tarefa(modeloTarefa)).ToList();
        }

        public void TornarReal()
        {
            this.Realizacao = DateTime.Now;

            this.Tarefas.ForEach(tarefa => { tarefa.Desativar(); });

            // TODO: Adicionar recordacao

            throw new NotImplementedException();
        }
    }
}
