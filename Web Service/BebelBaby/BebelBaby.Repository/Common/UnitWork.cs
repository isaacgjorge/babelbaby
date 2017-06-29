using EasyCare.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.Entity.Validation;

namespace EasyCare.Repository.Common
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
        
        //private IGenericRepository<Usuario> usuarioRepository;
        //public IGenericRepository<Usuario> UsuarioRepository
        //{
        //    get
        //    {
        //        return usuarioRepository ?? (usuarioRepository = new GenericRepository<Usuario>(_db));
        //    }
        //}
        
        
    }
}
