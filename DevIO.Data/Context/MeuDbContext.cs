using DevIO.Business.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace DevIO.Data.Context
{

    //https://docs.microsoft.com/pt-br/aspnet/core/security/authentication/customize-identity-model?view=aspnetcore-3.1

    public class MeuDbContext : IdentityDbContext<Usuario,PerfilAcesso,Guid,IdentityUserClaim<Guid>,UsuarioPerfil, IdentityUserLogin<Guid>,Permissoes, IdentityUserToken<Guid>> 
    {

        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<PerfilAcesso> PerfilAcesso { get; set; }
        public DbSet<UsuarioPerfil> UsuarioPerfil { get; set; }
        public DbSet<Permissoes> Permissoes { get; set; }
        public DbSet<Produto> Produto { get; set; }

        public MeuDbContext(DbContextOptions options) : base(options)
        {

        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(MeuDbContext).Assembly);

            //evitar a deleção em cascade
            foreach (var foreignKey in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                foreignKey.DeleteBehavior = DeleteBehavior.Restrict;
            }


            base.OnModelCreating(modelBuilder);
        }

        //gravando a data de alteração e cadastro
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {


            //verificar adiciona a data atual em todos os elementos que forem adicionados no banco
            foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("DataCadastro") != null))
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Property("DataCadastro").CurrentValue = DateTime.Now;
                }
                else if (entry.State == EntityState.Modified)
                {
                    entry.Property("DataCadastro").IsModified = false;
                }
            }

            //adicionar a data de modificação em todos os dados que forem atualizados
            foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("DataAlteracao") != null))
            {
                if (entry.State == EntityState.Modified)
                {
                    entry.Property("DataAlteracao").CurrentValue = DateTime.Now;
                    entry.Property("DataCadastro").IsModified = false;
                }
                else if (entry.State == EntityState.Added)
                {
                    entry.Property("DataAlteracao").IsModified = false;
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }


    }
}

