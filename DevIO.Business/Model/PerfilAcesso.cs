using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace DevIO.Business.Model
{
    public class PerfilAcesso : IdentityRoleClaim<int>
    {
        public IEnumerable<UsuarioPerfil> UsuarioPerfil { get; set; }

        public bool Ativo { get; set; }
        public DateTime? DataCadastro { get; set; }
        public DateTime? DataAlteracao { get; set; }
    }
}
