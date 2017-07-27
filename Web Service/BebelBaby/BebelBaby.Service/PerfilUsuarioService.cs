using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BebelBaby.Core;
using BebelBaby.Repository;
using BebelBaby.Repository.Common;

namespace BebelBaby.Service
{
    public class PerfilUsuarioService : BaseService, IPerfilUsuarioRepository
    {
        public PerfilUsuarioService(IUnitWork unitWork) : base(unitWork)
        {
        }

        public void AddPerfilUsuario(Usuario usuario, Usuario usuarioAlteracao, int idPerfil)
        {
            var perfilUsuario = new PerfilUsuario
            {

                PerfilId = idPerfil,
                UsuarioId = usuario.UsuarioId,
                Ativo = true,
                UsuarioAlteracaoId = usuarioAlteracao.UsuarioId
            };

            _UnitWork.PerfilUsuarioRepository.Insert(perfilUsuario);
            _UnitWork.Save();
        }

        public IEnumerable<PerfilUsuario> GetPerfisUsuario(Usuario usuario)
        {
            return _UnitWork.PerfilUsuarioRepository.Get(x => x.UsuarioId == usuario.UsuarioId);
        }
    }
}
