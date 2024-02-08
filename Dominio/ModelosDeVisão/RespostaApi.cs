namespace WebApi.Modelos
{
    public sealed class RespostaApi<T>
    {
        public bool Resultado { get; set; }
        public T Dado { get; set; }
        public string Menssagem { get; set; }
    }
}
