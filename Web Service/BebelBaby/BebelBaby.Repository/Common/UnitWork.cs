using BebelBaby.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.Entity.Validation;
using BebelBaby.Core;

namespace BebelBaby.Repository.Common
{

    public class UnitWork : IUnitWork, IDisposable
    {
        private bool _disposed;
        public DataContext _db;
        
        public UnitWork()
        {            
            _db = new DataContext();
        }

        public UnitWork(DataContext db)
        {
            _db = db;            
        }

        #region UnitWork's Methods
        public void Save()
        {
            try
            {
                _db.SaveChanges();
            }
            catch (DbEntityValidationException dbEx)
            {
                Exception raise = dbEx;
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        string message = string.Format(validationError.ErrorMessage); 
                        raise = new InvalidOperationException(message, raise);
                    }
                }

                throw raise;
            }


        }


        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _db.Dispose();
                }
            }

            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion

        private IGenericRepository<Cor> corRepository;
        public IGenericRepository<Cor> CorRepository
        {
            get
            {
                return corRepository ?? (corRepository = new GenericRepository<Cor>(_db));
            }
        }

        private IGenericRepository<CorProduto> corProdutoRepository;
        public IGenericRepository<CorProduto> CorProdutoRepository
        {
            get
            {
                return corProdutoRepository ?? (corProdutoRepository = new GenericRepository<CorProduto>(_db));
            }
        }

        private IGenericRepository<Produto> produtoRepository;
        public IGenericRepository<Produto> ProdutoRepository
        {
            get
            {
                return produtoRepository ?? (produtoRepository = new GenericRepository<Produto> (_db));
            }
        }

        private IGenericRepository<Tamanho> tamanhoRepository;
        public IGenericRepository<Tamanho> TamanhoRepository
        {
            get
            {
                return tamanhoRepository ?? (tamanhoRepository = new GenericRepository<Tamanho> (_db));
            }
        }

        private IGenericRepository<TamanhoProduto> tamanhoProdutoRepository;
        public IGenericRepository<TamanhoProduto> TamanhoProdutoRepository
        {
            get
            {
                return tamanhoProdutoRepository ?? (tamanhoProdutoRepository = new GenericRepository<TamanhoProduto>(_db));
            }
        }


        private IGenericRepository<TipoProduto> tipoProdutoRepository;
        public IGenericRepository<TipoProduto> TipoProdutoRepository
        {
            get
            {
                return tipoProdutoRepository ?? (tipoProdutoRepository = new GenericRepository<TipoProduto>(_db));
            }
        }

        private IGenericRepository<Usuario> usuarioRepository;
        public IGenericRepository<Usuario> UsuarioRepository
        {
            get
            {
                return usuarioRepository ?? (usuarioRepository = new GenericRepository<Usuario>(_db));
            }
        }

        private IGenericRepository<ValorProduto> valorProdutoRepository;
        public IGenericRepository<ValorProduto> ValorProdutoRepository
        {
            get
            {
                return valorProdutoRepository ?? (valorProdutoRepository = new GenericRepository<ValorProduto>(_db));
            }
        }
    }
}
