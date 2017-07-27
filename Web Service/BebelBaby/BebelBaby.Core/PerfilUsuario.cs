using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BebelBaby.Core
{
    public class PerfilUsuario : BaseEntity
    {
        public int PerfilUsuarioId { get; set; }

        public int PerfilId { get; set; }

        public int UsuarioId { get; set; }

        [ForeignKey("PerfilId")]
        public virtual Perfil Perfil { get; set; }

        [ForeignKey("UsuarioId")]
        public virtual Usuario Usuario { get; set; }
    }
}
