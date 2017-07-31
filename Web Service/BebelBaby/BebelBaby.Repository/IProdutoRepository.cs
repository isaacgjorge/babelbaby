using System.Collections.Generic;
using BebelBaby.Core;

namespace BebelBaby.Repository
{
    public interface IProdutoRepository
    {
        Produto GetByID(int id);
        Produto GetByCodigo(string codigo);
        Produto CriarProduto(Produto produto);
        void AlterarProduto(Produto produto);
        void DeletarProduto(Produto produto);   
        IEnumerable<Produto> RetornaProdutos();
    }
}
