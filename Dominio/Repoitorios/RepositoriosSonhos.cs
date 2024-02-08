using Dominio.Entidade;
using Dominio.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Repoitorios
{
    public class RepositoriosSonhos
        : IRepositorio<Sonho>
    {
        public void AdicionaOuAtualiza(Sonho entidade)
        {
            throw new NotImplementedException();
        }

        public long Contar()
        {
            throw new NotImplementedException();
        }

        public Sonho ObterPeloId(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Remove(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
