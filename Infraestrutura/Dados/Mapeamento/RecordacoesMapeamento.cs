using Dominio.Entidade;
using Dominio.ObjetoDeValor;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infraestrutura.Dados.Mapeamento
{
    internal class RecordacaoMapeamento : IEntityTypeConfiguration<Recordacao>
    {
        public void Configure(EntityTypeBuilder<Recordacao> construtor)
        {
            construtor.ToTable("Recordacao");

            construtor.HasKey(recordacao => new { recordacao.Foto, recordacao.Data});

            #region propriedades

            construtor.Property(recordacao => recordacao.Data)
                .IsRequired()
                .HasColumnName("data")
                .HasColumnType("DATE");

            construtor.Property(recordacao => recordacao.Foto)
                .IsRequired()
                .HasColumnName("foto")
                .HasColumnType("TEXT");

            #endregion

        }
    }
}
