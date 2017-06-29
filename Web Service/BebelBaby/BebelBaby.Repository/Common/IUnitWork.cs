using EasyCare.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyCare.Repository.Common
{
    public interface IUnitWork 
    {
        void Save();
        void Dispose();

        //IGenericRepository<Usuario> UsuarioRepository { get; }
        

    }
}
