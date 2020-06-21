using DevIO.Business.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DevIO.Data.Mapping
{

    public class ProdutoMapping : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.NomeProduto).IsRequired().HasColumnType("varchar(100)");
            builder.Property(e => e.Ativo).HasMaxLength(1).IsUnicode(false);
            builder.Property(e => e.DataCadastro).HasColumnType("datetime");
            builder.Property(e => e.DataAlteracao).HasColumnType("datetime");

            builder.ToTable("Produto");
        }
    }
}
