using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BebelBaby.Core;

namespace BebelBaby.Core
{
    public class TamanhoProduto : BaseEntity
    {
        public int TamanhoProdutoId { get; set; }

        public int ProdutoId { get; set; }

        public int TamanhoId { get; set; }

        [ForeignKey("ProdutoId")]
        public virtual Produto Produto { get; set; }

        [ForeignKey("TamanhoId")]
        public virtual Tamanho Tamanho { get; set; }
    }
}
