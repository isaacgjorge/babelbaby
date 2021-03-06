﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BebelBaby.Core;

namespace BebelBaby.Core
{
    public class BaseEntity
    {
        public bool Ativo { get; set; }

        public DateTime DataCriacao { get; set; }

        public int? UsuarioCriacaoId { get; set; }

        public DateTime? DataAlteracao { get; set; }

        public int? UsuarioAlteracaoId { get; set; }

        [ForeignKey("UsuarioCriacaoId")]
        public virtual Usuario UsuarioCriacao { get; set; }

        [ForeignKey("UsuarioAlteracaoId")]
        public virtual Usuario UsuarioAlteracao { get; set; }


    }
}
