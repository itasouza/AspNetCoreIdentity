using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace DevIO.Business.Model
{
    public class PerfilAcesso : IdentityRole<Guid>
    {

        public bool Ativo { get; set; }
        public DateTime? DataCadastro { get; set; }
        public DateTime? DataAlteracao { get; set; }
    }
}
