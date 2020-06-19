using DevIO.Business.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DevIO.Data.Mapping
{
    public class UsuarioMapping : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).ValueGeneratedOnAdd();
            builder.Property(p => p.UserName).IsRequired().HasColumnType("varchar(100)");
            builder.Property(p => p.Email).IsRequired().HasColumnType("varchar(100)");
            builder.Property(p => p.PhoneNumber).IsRequired().HasColumnType("varchar(15)");
            builder.Property(p => p.FuncaoUsuario).IsRequired().HasColumnType("varchar(50)");
            builder.Property(p => p.Imagem).HasColumnType("varchar(100)");

            builder.Property(e => e.Ativo).HasMaxLength(1).IsUnicode(false);
            builder.Property(e => e.DataCadastro).HasColumnType("datetime");
            builder.Property(e => e.DataAlteracao).HasColumnType("datetime");

            builder.ToTable("Usuario");
        }

    }
}
