using BebelBaby.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BebelBaby.Core;

namespace BebelBaby.Repository.Common
{
    public interface IUnitWork
    {
        void Save();
        void Dispose();

        IGenericRepository<Cor> CorRepository { get; }

        IGenericRepository<CorProduto> CorProdutoRepository { get; }

        IGenericRepository<Perfil> PerfilRepository { get; }

        IGenericRepository<PerfilUsuario> PerfilUsuarioRepository { get; }

        IGenericRepository<Produto> ProdutoRepository { get; }

        IGenericRepository<Tamanho> TamanhoRepository { get; }

        IGenericRepository<TamanhoProduto> TamanhoProdutoRepository { get; }

        IGenericRepository<TipoProduto> TipoProdutoRepository { get; }

        IGenericRepository<Usuario> UsuarioRepository { get; }

        IGenericRepository<ValorProduto> ValorProdutoRepository { get; }


    }
}
