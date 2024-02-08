using Dominio.Entidade;
using Dominio.ObjetoDeValor;
using Infraestrutura.Dados.Mapeamento;
using Microsoft.EntityFrameworkCore;

namespace Infraestutura.Dados
{
    public class ContextoDadosSonambulo : DbContext
    {
        private bool _inicializado { get; set; } = false;
        private string _baseDadosNomeArquivo;
        public DbSet<Pessoa> Pessoas { get; set; }
        public DbSet<Sonho> Sonhos { get; set; }
        public DbSet<Tarefa> Tarefas { get; set; }
        public DbSet<Feito> Feitos { get; set; }
        public DbSet<Recordacao> recordacoes { get; set; }
        //public DbSet<Periodicidade> Periodicidades { get; set; }

        /// <summary>
        /// Constructor for creating migrations
        /// </summary>
        public ContextoDadosSonambulo(string? baseDadosNomeArquivo = null)
        {
            _baseDadosNomeArquivo = baseDadosNomeArquivo is null ? Path.Combine("../", "aap.db") : baseDadosNomeArquivo;
            Inicializar();
        }

        private void Inicializar()
        {
            if (!_inicializado)
            {
                _inicializado = true;
                SQLitePCL.Batteries_V2.Init();
                Database.Migrate();
                this.Database.EnsureCreated();
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PessoaMapeamento());
            modelBuilder.ApplyConfiguration(new SonhoMapeamento());
            modelBuilder.ApplyConfiguration(new TarefaMapeamento());
            modelBuilder.ApplyConfiguration(new FeitoMapeamento());
            modelBuilder.ApplyConfiguration(new RecordacaoMapeamento());
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite($"DataSource={_baseDadosNomeArquivo};Cache=Shared");
        }
    }
}
