using System.Collections.Generic;
using BebelBaby.Core;

namespace BebelBaby.Repository
{
    public interface IUsuarioRepository
    {
        Usuario GetByID(int id);
        Usuario GetByLoginSenha(string login, string senha);
        Usuario CriarUsuario(Usuario usuario);
        void AlterarUsuario(Usuario usuario);
        bool UsuarioExiste(string login);
        void AlterarSenha(Usuario usuario, string senha);
        IEnumerable<Usuario> RetornaUsuarios();
    }
}
