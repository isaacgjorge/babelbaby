using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyCare.Core.BusinessRules
{
    public class ExecutorDeRegrasDeNegocio : IExecutorDeRegrasDeNegocio
    {
        private readonly Func<Type, IRegraDeNegocio> criarRegraDeNegocio;

        public ExecutorDeRegrasDeNegocio(Func<Type, IRegraDeNegocio> criarRegraDeNegocio)
        {
            this.criarRegraDeNegocio = criarRegraDeNegocio;
        }

        public void Executar<TEntidade>(Type tipo, TEntidade entidade)
        {
            var regraDeNegocio = (IRegraDeNegocio<TEntidade>)criarRegraDeNegocio(tipo);

            if (!regraDeNegocio.EhSatisfeitaPor(entidade))
                throw new RegraDeNegocioException(regraDeNegocio.MensagemDeErro);
        }

        public void Executar<TEntidade, TGeneric>(Type tipo, TEntidade entidade, TGeneric parameter)
        {
            var regraDeNegocio = (IRegraDeNegocio<TEntidade, TGeneric>)criarRegraDeNegocio(tipo);

            if (!regraDeNegocio.EhSatisfeitaPor(entidade, parameter))
                throw new RegraDeNegocioException(regraDeNegocio.MensagemDeErro);
        }
    }
}
