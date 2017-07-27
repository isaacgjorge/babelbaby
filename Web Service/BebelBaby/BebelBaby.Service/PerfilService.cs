using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BebelBaby.Core;
using BebelBaby.Repository;
using BebelBaby.Repository.Common;
using BebelBaby.Util;

namespace BebelBaby.Service
{
    public class PerfilService : BaseService, IPerfilRepository
    {
        public PerfilService(IUnitWork unitWork) : base(unitWork)
        {
        }

        public Perfil GetByDescricao(EnumPerfil enumPerfil)
        {
            return _UnitWork.PerfilRepository.Get(x => x.Descricao.Equals(enumPerfil.GetDescription())).FirstOrDefault();
        }

        public Perfil GetById(int idPerfil)
        {
            return _UnitWork.PerfilRepository.GetByID(idPerfil);
        }
    }
}
