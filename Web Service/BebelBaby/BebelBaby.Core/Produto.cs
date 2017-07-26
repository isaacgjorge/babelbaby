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
    public class Produto : BaseEntity
    {
        public int ProdutoId { get; set; }

        [MaxLength(50)]
        public string Codigo { get; set; }

        [MaxLength(50)]
        public string Nome { get; set; }

        [MaxLength(200)]
        public string Descricao { get; set; }

        public int TipoProdutoId { get; set; }

        [ForeignKey("TipoProdutoId")]
        public TipoProduto TipoProduto { get; set; }

        [InverseProperty("Produto")]
        public virtual ICollection<CorProduto> ProdutoCore { get; set; }

        [InverseProperty("Produto")]
        public virtual ICollection<ValorProduto> ValoresProduto { get; set; }

        [InverseProperty("Produto")]
        public virtual ICollection<TamanhoProduto> TamanhosProduto { get; set; }        
    }
}
