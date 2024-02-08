using Dominio.Entidade;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infraestrutura.Dados.Mapeamento
{
    internal class TarefaMapeamento : IEntityTypeConfiguration<Tarefa>
    {
        public void Configure(EntityTypeBuilder<Tarefa> builder)
        {
            builder.ToTable("Tarefa");

            builder.HasKey(tarefa => tarefa.Id);

            #region relacionamentos
            //builder
            //    .HasOne(tarefa => tarefa.Sonho)
            //    .WithMany(sonho => sonho.Tarefas)
            //    .HasConstraintName("FK_tarefa_sonho")
            //    .OnDelete(DeleteBehavior.Cascade);

            //builder
            //    .HasMany(tarefa => tarefa.Recordacoes)
            //    .WithOne()
            //    .HasConstraintName("FK_tarefa_recordacao")
            //    .OnDelete(DeleteBehavior.Cascade);

            builder
                .HasMany(tarefa => tarefa.Feitos)
                .WithOne()
                .HasConstraintName("FK_tarefa_feito")
                .HasForeignKey(feito => feito.TarefaId)
                .OnDelete(DeleteBehavior.Cascade);

            //builder
            //    .HasOne(tarefa => tarefa.Periodicidade)
            //    .WithOne()
            //    .HasConstraintName("FK_tarefa_feito")
            //    .OnDelete(DeleteBehavior.Cascade);

            #endregion

            #region propriedades

            builder.Property(tarefa => tarefa.Id)
                .HasColumnName("id")
                .HasColumnType("uuid");

            builder.Property(tarefa => tarefa.Nome)
                .IsRequired()
                .HasColumnName("Nome")
                .HasColumnType("NCHARNCHAR")
                .HasMaxLength(55);

            builder.Property(tarefa => tarefa.Descricao)
                .IsRequired()
                .HasColumnName("descricao")
                .HasColumnType("VARCHAR")
                .HasMaxLength(200);

            builder.Property(tarefa => tarefa.QuantidadePorPeriodo)
                .IsRequired()
                .HasColumnName("QuantidadePorPeriodo")
                .HasColumnType("INT");

            builder.Property(tarefa => tarefa.Ativa)
                .IsRequired()
                .HasColumnName("ativa")
                .HasColumnType("BOOLEAN");

            builder.Property(tarefa => tarefa.Periodicidade)
                .IsRequired()
                .HasColumnName("Periodicidade")
                .HasColumnType("VARCHAR")
                .HasMaxLength(50);

            #endregion

        }
    }
}
