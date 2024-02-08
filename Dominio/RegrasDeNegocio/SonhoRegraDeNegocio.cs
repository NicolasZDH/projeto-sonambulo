using Dominio.Entidade;
using Dominio.Interface;
using Dominio.Repoitorios;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.RegrasDeNegocio
{
    public class SonhoRegraDeNegocio: ISonhoRegraDeNegocio
    {
        private readonly ILogger<SonhoRegraDeNegocio> _registrador;
        private readonly RepositoriosSonhos _repositoriosSonhos;

        public SonhoRegraDeNegocio(ILogger<SonhoRegraDeNegocio> registrador)
        {
            _registrador = registrador;
        }

        public bool TornarSonhoEmRealidadde(Guid idSonho)
        {
            try
            {
                Sonho sonho = _repositoriosSonhos.ObterPeloId(idSonho);
                sonho.TornarReal();
                _repositoriosSonhos.AdicionaOuAtualiza(sonho);

                _registrador.LogInformation("[TornarSonhoEmRealidadde SKA79F] Sonho {} é realidade", idSonho);

                return true;
            }
            catch (Exception ex) 
            {
                _registrador.LogInformation("[TornarSonhoEmRealidadde SKA79F] Erro ao tornar sonho {idSonho} em realidade: {ex}", idSonho, ex);

                return false;
            }
        }
    }

    public class RespostaApi<T>
    {
    }
}
