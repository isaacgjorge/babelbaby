using System;
using System.Collections.Generic;
using System.Linq;
using BebelBaby.Core;
using BebelBaby.Repository;
using BebelBaby.Repository.Common;
using BebelBaby.Util;

namespace BebelBaby.Service
{
    class ProdutoService : BaseService, IProdutoRepository
    {
        private readonly IUtilRepository _UtilService;
        public ProdutoService(IUnitWork unitWork, IUtilRepository utilService) : base(unitWork)
        {
            _UtilService = utilService;
        }

        public Produto GetByID(int id)
        {
            Produto produto = _UnitWork.ProdutoRepository
                .Get(x => x.ProdutoId == id)
                .FirstOrDefault();
            return produto;
        }

        public Produto GetByCodigo(string codigo)
        {
            Produto produto = _UnitWork.ProdutoRepository
                .Get(x => x.Codigo.Equals(codigo))
                .FirstOrDefault();
            return produto;
        }

        public Produto CriarProduto(Produto produto)
        {
            if (produtoExiste(produto.Codigo))
                throw new Exception("Produto já cadastrado");

            _UnitWork.ProdutoRepository.Insert(produto);
            _UnitWork.Save();
            return produto;
        }

        public void DeletarProduto(Produto produto)
        {


            _UnitWork.ProdutoRepository.Delete(produto);

        }

        public bool produtoExiste(string codigo)
        {
            return _UnitWork.ProdutoRepository
                .Get(x => x.Codigo.Equals(codigo)).Any();
        }

        public void AlterarProduto(Produto produto)
        {
            var produtoOriginal = GetByID(produto.ProdutoId);
            foreach (var propProdutoOriginal in produtoOriginal.GetType().GetProperties())
            {
                foreach (var propProduto in produto.GetType().GetProperties())
                {
                    if (propProdutoOriginal == propProduto)
                    {
                        propProdutoOriginal.SetValue(produtoOriginal, propProduto.GetValue(produto));
                    }
                }

            }
            _UnitWork.ProdutoRepository.Update(produtoOriginal);
            _UnitWork.Save();
        }


        public IEnumerable<Produto> RetornaProdutos()
        {
            var produto = _UnitWork.ProdutoRepository.Get();

            return produto;
        }
    }
}
