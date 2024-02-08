namespace Dominio.Interface
{
    public interface IRepositorio<T>
        where T : IRaizDeAgregado
    {
        void AdicionaOuAtualiza(T entidade);
        T ObterPeloId(Guid id);
        void Remove(Guid id);

        long Contar();
    }

    public interface IRaizDeAgregado : IEntidade { }

    public interface IEntidade : IEquatable<IEntidade>
    {
        public Guid Id { get; }
    }

    public interface IObjetoValor : IEquatable<IObjetoValor> { }
}
