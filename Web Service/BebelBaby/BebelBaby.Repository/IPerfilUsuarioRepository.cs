using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BebelBaby.Core;

namespace BebelBaby.Repository
{
    public interface IPerfilUsuarioRepository
    {
        void AddPerfilUsuario(Usuario usuario, Usuario usuarioAlteracao, int idPerfil);
    }
}
