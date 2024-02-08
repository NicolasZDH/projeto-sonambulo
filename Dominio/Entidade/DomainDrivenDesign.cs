using Dominio.Interface;
using System.ComponentModel.DataAnnotations;

namespace Dominio.Entidade
{
    public abstract class RaizDeAgregado : IRaizDeAgregado
    {
        public Guid Id { get; init; }

        public bool Equals(IEntidade? outraEntidade)
        {
            return outraEntidade is not null && outraEntidade.Id == Id;
        }
    }

    public abstract class EntidadeBase : IEntidade
    {
        public Guid Id { get; init; }

        public bool Equals(IEntidade? other)
        {
            return other is not null && other.Id == Id;
        }
    }
}
