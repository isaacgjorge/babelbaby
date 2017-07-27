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
    class UsuarioService : BaseService, IUsuarioRepository
    {
        private readonly IUtilRepository _UtilService;
        public UsuarioService(IUnitWork unitWork, IUtilRepository utilService) : base(unitWork)
        {
            _UtilService = utilService;
        }

        public Usuario GetByID(int id)
        {
            var usuario = _UnitWork.UsuarioRepository
                .Get(x => x.UsuarioId == id, includeProperties: "PerfisUsuario, PerfisUsuario.Perfil")
                .FirstOrDefault();
            return usuario;
        }

        public Usuario GetByLoginSenha(string login, string senha)
        {
            var usuario = _UnitWork.UsuarioRepository
                .Get(x => x.Login.Equals(login) && x.Senha.Equals(senha), includeProperties: "PerfisUsuario, PerfisUsuario.Perfil")
                .FirstOrDefault();
            return usuario;
        }

        public Usuario CriarUsuario(Usuario usuario)
        {
            if (UsuarioExiste(usuario.Login))
                throw new Exception("Usuario já cadastrado");

            _UnitWork.UsuarioRepository.Insert(usuario);
            _UnitWork.Save();
            return usuario;
        }

        public bool UsuarioExiste(string login)
        {
            return _UnitWork.UsuarioRepository
                .Get(x => x.Login.Equals(login)).Any();
        }

        public void AlterarUsuario(Usuario usuario)
        {
            var usuarioOriginal = GetByID(usuario.UsuarioId);
            foreach (var propUsuarioOriginal in usuarioOriginal.GetType().GetProperties())
            {
                foreach (var propUsuario in usuario.GetType().GetProperties())
                {
                    if (propUsuarioOriginal == propUsuario)
                    {
                        propUsuarioOriginal.SetValue(usuarioOriginal, propUsuario.GetValue(usuario));
                    }
                }

            }
            _UnitWork.UsuarioRepository.Update(usuarioOriginal);
            _UnitWork.Save();
        }
        
        public void AlterarSenha(Usuario usuario, string senha)
        {
            usuario.Senha = senha;
            _UnitWork.UsuarioRepository.Update(usuario);
            _UnitWork.Save();
        }

        public IEnumerable<Usuario> RetornaUsuarios()
        {
            var usuario = _UnitWork.UsuarioRepository.Get();

            return usuario;
        }
    }
}
