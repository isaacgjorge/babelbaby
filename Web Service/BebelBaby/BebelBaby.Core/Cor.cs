using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BebelBaby.Core;

namespace BebelBaby.Core
{
    public class Cor : BaseEntity
    {
        public int CorId { get; set; }

        [MaxLength(50)]
        public string Descricao { get; set; }
    }
}
