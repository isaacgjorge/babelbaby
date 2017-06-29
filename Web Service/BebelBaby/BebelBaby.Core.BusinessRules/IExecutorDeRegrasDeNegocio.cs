using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyCare.Core.BusinessRules
{
    public interface IExecutorDeRegrasDeNegocio
    {
        void Executar<TEntidade>(Type tipo, TEntidade entidade);

        void Executar<TEntidade, TGeneric>(Type tipo, TEntidade entidade, TGeneric parameter);

    }
}
