using DevIO.Business.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DevIO.Data.Mapping
{
    public class UsuarioPerfilMapping : IEntityTypeConfiguration<UsuarioPerfil>
    {
        public void Configure(EntityTypeBuilder<UsuarioPerfil> builder)
        {
            builder.HasNoKey();
            builder.Property(e => e.Ativo).HasMaxLength(1).IsUnicode(false);
            builder.Property(e => e.DataCadastro).HasColumnType("datetime");
            builder.Property(e => e.DataAlteracao).HasColumnType("datetime");

            builder.ToTable("UsuarioPerfil");
        }
    }
}


