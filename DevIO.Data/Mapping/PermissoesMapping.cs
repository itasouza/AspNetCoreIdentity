using DevIO.Business.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DevIO.Data.Mapping
{

    public class PermissoesMapping : IEntityTypeConfiguration<Permissoes>
    {
        public void Configure(EntityTypeBuilder<Permissoes> builder)
        {
            builder.Property(e => e.Ativo).HasMaxLength(1).IsUnicode(false);
            builder.Property(e => e.DataCadastro).HasColumnType("datetime");
            builder.Property(e => e.DataAlteracao).HasColumnType("datetime");

            builder.ToTable("Permissoes");
        }
    }

}
