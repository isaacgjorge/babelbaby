using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BebelBaby.Core
{
    public class Perfil : BaseEntity
    {
        public int PerfilId { get; set; }

        [MaxLength(50)]
        public string Descricao { get; set; }

        public virtual ICollection<PerfilUsuario> PerfisUsuario { get; set; }
    }
}
