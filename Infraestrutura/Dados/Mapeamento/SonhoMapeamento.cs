using Dominio.Entidade;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infraestrutura.Dados.Mapeamento
{
    internal class SonhoMapeamento : IEntityTypeConfiguration<Sonho>
    {
        public void Configure(EntityTypeBuilder<Sonho> construtor)
        {
            construtor.ToTable("Sonho");

            construtor.HasKey(sonho => sonho.Id);

            #region relacionamentos

            construtor
                .HasMany(sonho => sonho.Tarefas)
                .WithOne()
                .HasConstraintName("FK_Sonho_Tarefa")
                .OnDelete(DeleteBehavior.Cascade);

            construtor
                .HasMany(sonho => sonho.Recordacoes)
                .WithOne()
                .HasConstraintName("FK_Sonho_Recordacao")
                .OnDelete(DeleteBehavior.Cascade);

            #endregion

            #region propriedades

            construtor.Property(sonho => sonho.Id)
                .HasColumnName("id")
                .HasColumnType("uuid");

            construtor.Property(sonho => sonho.PessoaId)
                .HasColumnName("pessoaId")
                .HasColumnType("uuid");

            construtor.Property(sonho => sonho.Descricao)
                .IsRequired()
                .HasColumnName("descricao")
                .HasColumnType("VARCHAR")
                .HasMaxLength(200);

            construtor.Property(sonho => sonho.Criacao)
                .IsRequired()
                .HasColumnName("criacao")
                .HasColumnType("DATETIME")
                .HasDefaultValue(DateTime.Now.ToUniversalTime());

            construtor.Property(sonho => sonho.Realizacao)
                .HasColumnName("realizacao")
                .HasColumnType("DATETIME");
            
            #endregion

        }
    }
}
