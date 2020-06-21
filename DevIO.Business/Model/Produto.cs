using System;

namespace DevIO.Business.Model
{
    public class Produto :Entity
    {
        public string NomeProduto { get; set; }
        public bool Ativo { get; set; }
        public DateTime? DataCadastro { get; set; }
        public DateTime? DataAlteracao { get; set; }
    }
}
