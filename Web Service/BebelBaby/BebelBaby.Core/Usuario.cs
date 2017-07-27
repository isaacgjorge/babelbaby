using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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
        
        public string Senha { get; set; }

        [MaxLength(250)]
        public string Nome { get; set; }

        [InverseProperty("Usuario")]
        public virtual ICollection<PerfilUsuario> PerfisUsuario { get; set; }

    }
}
