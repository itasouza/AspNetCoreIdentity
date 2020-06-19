using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace DevIO.Business.Model
{
    public class UsuarioPerfil : IdentityUserRole<Guid>
    {
        public int PerfilAcessoId { get; set; }
        public PerfilAcesso PerfilAcesso { get; set; }

        public string UsuarioId { get; set; }
        public Usuario Usuario { get; set; }

        public bool Ativo { get; set; }
        public DateTime? DataCadastro { get; set; }
        public DateTime? DataAlteracao { get; set; }

    }
}
