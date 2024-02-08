using Dominio.Entidade;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infraestrutura.Dados.Mapeamento
{
    internal class PessoaMapeamento : IEntityTypeConfiguration<Pessoa>
    {
        public void Configure(EntityTypeBuilder<Pessoa> construtor)
        {
            construtor.ToTable("Pessoa");

            construtor.HasKey(pessoa => pessoa.Id);

            #region relacionamentos

            construtor.HasMany(pessoa => pessoa.Sonhos)
                .WithOne()
                .HasForeignKey(sonho => sonho.PessoaId)
                .HasConstraintName("FK_Pessoa_Sonho")
                .OnDelete(DeleteBehavior.Cascade);

            #endregion

            #region propriedades

            construtor.Property(pessoa => pessoa.Id)
                .HasColumnName("id")
                .HasColumnType("uuid");

            construtor.Property(pessoa => pessoa.Nome)
                .IsRequired()
                .HasColumnName("nome")
                .HasColumnType("VARCHAR")
                .HasMaxLength(100);

            construtor.Property(pessoa => pessoa.Email)
                .IsRequired()
                .HasColumnName("email")
                .HasColumnType("VARCHAR")
                .HasMaxLength(100);

            construtor.Property(sonho => sonho.Senha)
                .IsRequired()
                .HasColumnName("senha")
                .HasColumnType("VARCHAR")
                .HasDefaultValue(100);
            
            #endregion

        }
    }
}
