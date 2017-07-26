using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BebelBaby.Core;

namespace BebelBaby.Core
{
    public class CorProduto : BaseEntity
    {
        public int CorProdutoId { get; set; }

        public int ProdutoId { get; set; }

        public int CorId { get; set; }

        [ForeignKey("ProdutoId")]
        public virtual Produto Produto { get; set; }

        [ForeignKey("CorId")]
        public virtual Cor Cor { get; set; }

    }
}
