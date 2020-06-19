using DevIO.Business.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DevIO.Data.Mapping
{
    public class UsuarioPerfilMapping : IEntityTypeConfiguration<UsuarioPerfil>
    {
        public void Configure(EntityTypeBuilder<UsuarioPerfil> builder)
        {

            builder.HasOne(d => d.PerfilAcesso)
                 .WithMany(p => p.UsuarioPerfil)
                 .HasForeignKey(d => d.PerfilAcessoId);

            builder.HasOne(d => d.Usuario)
                .WithMany(p => p.UsuarioPerfil)
                .HasForeignKey(d => d.UsuarioId);


            builder.Property(e => e.Ativo).HasMaxLength(1).IsUnicode(false);
            builder.Property(e => e.DataCadastro).HasColumnType("datetime");
            builder.Property(e => e.DataAlteracao).HasColumnType("datetime");

            builder.ToTable("UsuarioPerfil");
        }
    }
}
