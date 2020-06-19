using DevIO.Business.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DevIO.Data.Mapping
{

    public class PerfilAcessoMapping : IEntityTypeConfiguration<PerfilAcesso>
    {
        public void Configure(EntityTypeBuilder<PerfilAcesso> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).ValueGeneratedOnAdd();


            builder.HasData(
             new PerfilAcesso
             {
                 ClaimType = "Administrador",
                 ClaimValue = "Excluir,Editar,Criar,Visualizar"
             },
             new PerfilAcesso
             {
                 ClaimType = "Visitante",
                 ClaimValue = "Visualizar"
             },
             new PerfilAcesso
             {
                  ClaimType = "Apresentacao",
                  ClaimValue = "Editar,Criar,Visualizar"
             });

            builder.Property(e => e.Ativo).HasMaxLength(1).IsUnicode(false);
            builder.Property(e => e.DataCadastro).HasColumnType("datetime");
            builder.Property(e => e.DataAlteracao).HasColumnType("datetime");

            builder.ToTable("PerfilAcesso");
        }

    }

}
