using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BebelBaby.Core;

namespace BebelBaby.Core
{
    public class Usuario
    {
        public int UsuarioId { get; set; }

        [MaxLength(10)]
        public string Login { get; set; }
        
        public string PasswordHash { get; set; }

        public string Salt { get; set; }

    }
}
