using Dominio.ObjetoDeValor;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infraestrutura.Dados.Mapeamento
{
    internal class FeitoMapeamento : IEntityTypeConfiguration<Feito>
    {
        public void Configure(EntityTypeBuilder<Feito> construtor)
        {
            construtor.ToTable("Feito");

            construtor.HasKey(feito => new {feito.TarefaId, feito.Data});

            #region propriedades

            construtor.Property(feito => feito.TarefaId)
                .HasColumnName("idTarefa")
                .HasColumnType("uuid");

            construtor.Property(feito => feito.Data)
                .IsRequired()
                .HasColumnName("data")
                .HasColumnType("DATE");

            construtor.Property(feito => feito.Concluido)
                .IsRequired()
                .HasColumnName("concluido")
                .HasColumnType("bool");

            #endregion

        }
    }
}
