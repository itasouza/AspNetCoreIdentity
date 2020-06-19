using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace DevIO.Business.Model
{
    public class Usuario : IdentityUser<string> 
    {

        public string FuncaoUsuario { get; set; }
        public string Imagem { get; set; }

        /* EF relacionamento*/
        public IEnumerable<UsuarioPerfil> UsuarioPerfil { get; set; }

        public bool Ativo { get; set; }
        public DateTime? DataCadastro { get; set; }
        public DateTime? DataAlteracao { get; set; }

    }
}
