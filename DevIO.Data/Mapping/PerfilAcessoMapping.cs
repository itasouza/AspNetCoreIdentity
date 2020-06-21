using DevIO.Business.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace DevIO.Data.Mapping
{

    public class PerfilAcessoMapping : IEntityTypeConfiguration<PerfilAcesso>
    {
        public void Configure(EntityTypeBuilder<PerfilAcesso> builder)
        {
            builder.Property(p => p.Id).ValueGeneratedOnAdd();

            builder.HasData(
             new PerfilAcesso
             {
                 Id = Guid.NewGuid(),
                 Name = "Administrador",
                 NormalizedName = "ADMINISTRADOR"
             },
             new PerfilAcesso
             {
                 Id = Guid.NewGuid(),
                 Name = "Visitante",
                 NormalizedName = "VISITANTE"
             });

            builder.Property(e => e.Ativo).HasMaxLength(1).IsUnicode(false);
            builder.Property(e => e.DataCadastro).HasColumnType("datetime");
            builder.Property(e => e.DataAlteracao).HasColumnType("datetime");

            builder.ToTable("PerfilAcesso");
        }

    }

}
