using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BebelBaby.Core;

namespace BebelBaby.Repository
{
    public interface IPerfilRepository
    {
        Perfil GetByDescricao(EnumPerfil enumPerfil);
        Perfil GetById(int idPerfil);
    }

    public enum EnumPerfil
    {
        [Description("Administrador")]
        Administrador,
        [Description("Vendedor")]
        Vendedor,

    }
}
