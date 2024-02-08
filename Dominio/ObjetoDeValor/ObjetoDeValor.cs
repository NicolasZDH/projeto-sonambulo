using Dominio.Interface;
using System.Reflection;
using System.Text;

namespace Dominio.ObjetoDeValor
{
    public abstract class ObjetoDeValorBase : IObjetoValor
    {
        public bool Equals(IObjetoValor? other)
        {
            if (other == null) return false;

            if (ReferenceEquals(this, other)) return true;

            foreach (PropertyInfo prop in other.GetType().GetProperties())
            {
                if(prop.GetValue(other) != prop.GetValue(this)) return false;
            }

            return true;
        }

        public override bool Equals(Object? obj)
        {
            ObjetoDeValorBase? outroObjetoDeValor = obj as ObjetoDeValorBase;
            if (outroObjetoDeValor == null) return false;

            return Equals(outroObjetoDeValor);
        }

        public override int GetHashCode()
        {
            StringBuilder hashCode = new StringBuilder();

            foreach (PropertyInfo prop in this.GetType().GetProperties())
            {
                hashCode.Append(prop.GetValue(this)).ToString();
            }

            return hashCode.ToString().GetHashCode();
        }
    }
}
