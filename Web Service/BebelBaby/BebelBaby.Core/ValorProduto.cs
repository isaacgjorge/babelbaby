using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BebelBaby.Core
{
    public class ValorProduto
    {
        public int ValorProdutoId { get; set; }

        public int ProdutoId { get; set; }

        public decimal Valor { get; set; }

        [ForeignKey("ProdutoId")]
        public virtual Produto Produto { get; set; }

        public bool Ativo { get; set; }

        public DateTime DataCriacao { get; set; }

        public int? UsuarioCriacaoId { get; set; }

        [ForeignKey("UsuarioCriacaoId")]
        public virtual Usuario UsuarioCriacao { get; set; }

    }
}
